using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain;
using log4net;
using log4net.Config;
using Valid.Fulfillment.Common;
using Valid.Fulfillment.Common.Mappers;
using Valid.Fulfillment.Common.Models;
using DCInformation = Domain.DCInformation;

namespace Valid.Fulfillment.Data
{
    public class SqlRepository : IDataService
    {
        private Settings _Settings;
        private Mapper _Mapper;
        private ILog _Logger;

        public SqlRepository(Settings settings)
        {
            _Settings = settings;
            _Mapper = new Mapper();
            _Logger = LogManager.GetLogger(typeof(SqlRepository));
            XmlConfigurator.Configure();
        }

        public IEnumerable<UserTable> GetUserList()
        {
            const string sql = @" SELECT * 
                                FROM [dbo].[UserTables]";
            var connection = new SqlConnection(_Settings.ConnectionString);
            var result = connection.Query<UserTable>(sql).ToList();
            if (result.Any())
            {
                return result;
            }
            return new BindingList<UserTable>();
        }

        public IEnumerable<StoreInfoFromEDI850> GetOrdersByDateRangeList(DateTime StartDate, DateTime EndDate)
        {
            const string sql = @"SELECT *
                              FROM [dbo].[StoreInfoFromEDI850]
                              WHERE PODate >= @StartDate
                              AND PODate < @EndDate";
            var connection = new SqlConnection(_Settings.ConnectionString);
            var result = connection.Query<StoreInfoFromEDI850>(sql, new { StartDate, EndDate }).ToList();
            if (result.Any())
            {
                foreach (var storeInfo in result)
                {
                    storeInfo.SerialRageNumber = GetSerialRangeList(storeInfo.Id).ToList();
                    storeInfo.Carton = GetCartonList(storeInfo.Id).ToList();
                    storeInfo.SkuItem = GetSkuItemList(storeInfo.SkuItemFK);
                    storeInfo.QtyPacked = storeInfo.SerialRageNumber.Select(x => x.Serialbundle).Distinct().Count() / 25;
                }
                return result;
            }
            return new List<StoreInfoFromEDI850>();
        }

        public bool UpdateStoreInfo(IEnumerable<StoreInfoFromEDI850> orderDetailGridList)
        {
            foreach (var storeInfo in orderDetailGridList)
            {
                var id = storeInfo.Id;
                var qtyPacked = storeInfo.QtyPacked;
                var user = storeInfo.User;
                var label = storeInfo.Label;
                var inUse = storeInfo.InUse;
                const string sql = @"UPDATE [dbo].[StoreInfoFromEDI850]
                                SET
                                [QtyPacked] = @qtyPacked
                                ,[User] = @user
                                ,[Label] = @label
                                ,[InUse] = @inUse
                                WHERE [ID] = @Id";
                var connection = new SqlConnection(_Settings.ConnectionString);
                var result = connection.Query<StoreInfoFromEDI850>(sql, new { id, qtyPacked, user, label, inUse }).ToList();

                UpSertSerialRanges(storeInfo.SerialRageNumber, storeInfo.Id);
            }
            return true;
        }

        private void UpSertSerialRanges(IEnumerable<SerialRageNumber> serialRageNumbers, Guid storeInfoFk)
        {
            var exisingSerialRanges = GetSerialRangeList(storeInfoFk);
            foreach (var serialRange in serialRageNumbers)
            {
                if (!exisingSerialRanges.Contains(serialRange))
                {
                    InsertSerialRange(serialRange);
                }
            }

            foreach (var exisingSerialRange in exisingSerialRanges)
            {
                if (!serialRageNumbers.Contains(exisingSerialRange))
                {
                    DeleteSerialRange(exisingSerialRange);
                }
            }
        }

        private void DeleteSerialRange(SerialRageNumber serialRangeNumber)
        {
            try
            {
                var id = serialRangeNumber.ID;
                const string sql = @"DELETE FROM[dbo].[SerialRageNumbers]
                                    WHERE [ID] = @id";
                var connection = new SqlConnection(_Settings.ConnectionString);
                var result =
                    connection.Query<StoreInfoFromEDI850>(sql, new {id}).ToList();
            }
            catch (Exception ex)
            {
                _Logger.Info(string.Format("Error Getting Order Details - {0}", ex.Message));
            }
        }

        private void InsertSerialRange(SerialRageNumber serialRageNumber)
        {
            try
            {
                var id = serialRageNumber.ID;
                var serialNum = serialRageNumber.SerialNumber;
                var serialBundle = serialRageNumber.Serialbundle;
                var orderfk = serialRageNumber.StoreInfoFromEDI850FK;
                const string sql = @"INSERT INTO [dbo].[SerialRageNumbers]
                                           ([ID], [SerialNumber], [Serialbundle], [StoreInfoFromEDI850FK])
                                     VALUES
                                           (id, serialNum, serialBundle, orderfk)";
                var connection = new SqlConnection(_Settings.ConnectionString);
                var result = connection.Query<StoreInfoFromEDI850>(sql, new { id, serialNum, serialBundle, orderfk }).ToList();
            }
            catch (Exception ex)
            {
                _Logger.Info(string.Format("Error Getting Order Details - {0}", ex.Message));
            }

        }

        public bool IsSerialNumberListAvailable(IEnumerable<string> serialNumberList)
        {
            bool retval = false;
            if (serialNumberList.Any())
            {
                foreach (var serial in serialNumberList)
                {
                    const string sql = @"SELECT * 
                                FROM [dbo].[SerialRageNumbers]
                                WHERE [SerialNumber] = @serial";
                    var connection = new SqlConnection(_Settings.ConnectionString);
                    var result = connection.Query<SerialRageNumber>(sql, new { serial }).ToList();
                    if (!result.Any())
                    {
                        retval = true;
                    }
                }
            }
            return retval;
        }

        public DCInformation GetDcInformation(string dcNumber)
        {
            const string sql = @"SELECT * 
                                FROM [dbo].[DCInformations]
                                WHERE [StoreID] = @dcNumber";
            var connection = new SqlConnection(_Settings.ConnectionString);
            var result = connection.Query<DCInformation>(sql, new { dcNumber }).ToList();
            if (result.Any())
            {
                return result.First();
            }
            return new DCInformation();
        }

        public ShipFromInformation GetShipFromAddress()
        {
            const string sql = @"SELECT * 
                                FROM [dbo].[ShipFromInformations]";
            var connection = new SqlConnection(_Settings.ConnectionString);
            var result = connection.Query<ShipFromInformation>(sql).ToList();
            if (result.Any())
            {
                return result.First();
            }
            return new ShipFromInformation();
        }

        private IEnumerable<SerialRageNumber> GetSerialRangeList(Guid StoreInfoFk)
        {
            const string sql = @"SELECT *
                              FROM [dbo].[SerialRageNumbers]
                              WHERE [StoreInfoFromEDI850FK] = @StoreInfoFk";
            var connection = new SqlConnection(_Settings.ConnectionString);
            var result = connection.Query<SerialRageNumber>(sql, new { StoreInfoFk }).ToList();
            if (result.Any())
            {
                return result;
            }
            return new List<SerialRageNumber>();
        }

        private IEnumerable<Carton> GetCartonList(Guid StoreInfoFk)
        {
            const string sql = @"SELECT *
                              FROM [dbo].[Cartons]
                              WHERE [StoreNumberFK] = @StoreInfoFk";
            var connection = new SqlConnection(_Settings.ConnectionString);
            var result = connection.Query<Carton>(sql, new { StoreInfoFk }).ToList();
            if (result.Any())
            {
                return result;
            }
            return new List<Carton>();
        }

        private SkuItem GetSkuItemList(Guid? SkuItemFK)
        {
            if (SkuItemFK.HasValue)
            {
                const string sql = @"SELECT *
                              FROM [dbo].[SkuItems]
                              WHERE [Id] = @SkuItemFK";
                var connection = new SqlConnection(_Settings.ConnectionString);
                var result = connection.Query<SkuItem>(sql, new {SkuItemFK}).ToList();
                if (result.Any())
                {
                    return result.First();
                }
            }
            return new SkuItem();
        }
    }
}
