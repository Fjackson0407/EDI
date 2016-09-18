using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Repository.DataSource;
using Repository.UOW;
using Valid.Fulfillment.Common.Mappers;
using Valid.Fulfillment.Common.Models;
using DCInformation = Domain.DCInformation;

namespace Valid.Fulfillment.Service
{
    public class EFService
    {
        private Settings _Settings;
        private Mapper _Mapper;

        public EFService(Settings settings)
        {
            _Settings = settings;
            _Mapper = new Mapper();
        }

        public List<UserTable> GetUserList()
        {
            using (var UoW = new UnitofWork(new EDIContext(_Settings.ConnectionString)))
            {
               List<UserTable> userList =  UoW.User.GetAll().ToList();
                return userList;
            }
        }

        public IEnumerable<StoreInfoFromEDI850> GetOrdersByDateRangeList(DateTime StartDate, DateTime EndDate)
        {
            using (var UoW = new UnitofWork(new EDIContext(_Settings.ConnectionString)))
            { 
                var stores = UoW.AddEDI850.Find(x => x.PODate >= StartDate && x.PODate <= EndDate);

                //ToDo: This should be fixed in the context to load the empty object/list
                //do we really need this 
                foreach (var store in stores)
                {
                    if (!store.SerialRageNumber.Any())
                    {
                        store.SerialRageNumber = new List<SerialRageNumber>();
                    }
                    else
                    {
                        store.QtyPacked = store.SerialRageNumber.Select(x => x.Serialbundle).Distinct().Count() / 25;
                    }
                    if (!store.Carton.Any())
                    {
                        store.Carton = new List<Carton>();
                    }
                    if (store.SkuItem == null)
                    {
                        store.SkuItem = new SkuItem();
                    }
                }

                return stores.ToList();
            }
        }

        public void UpdateStoreInfo(List<StoreInfoFromEDI850> orderDetailGridList)
        {
            using (var context = new EDIContext(_Settings.ConnectionString))
            {
                foreach (var orderinfo in orderDetailGridList)
                {
                    var sod = context.EDI850.First(x => x.Id == orderinfo.Id);
                    if (sod != null)
                    {
                        sod.User = orderinfo.User;
                        sod.QtyPacked = orderinfo.QtyPacked;
                        sod.SerialRageNumber = orderinfo.SerialRageNumber;
                        
                    }
                    context.SaveChanges();
                }
                //context.SaveChanges();
            }
        }

        public bool IsSerialNumberListAvailable(List<string> serialNumberList)
        {
            bool retval = false;
            using (var context = new EDIContext(_Settings.ConnectionString))
            {
                foreach (var serialNumber in serialNumberList)
                {
                    var duplicateList = context.SerialRageNumber.Where(x => x.SerialNumber == serialNumber);
                    if (!duplicateList.Any())
                    {
                        retval = true;
                    }
                }
            }
            return retval;
        }

        public DCInformation GetDcInformation(string dcNumber)
        {
            using (var context = new EDIContext(_Settings.ConnectionString))
            {
                DCInformation dc = context.DCInformation.FirstOrDefault(x => x.StoreID == dcNumber);
                return dc;
            }
        }

        public ShipFromInformation GetShipFromAddress()
        {
            using (var context = new EDIContext(_Settings.ConnectionString))
            {
                ShipFromInformation ship = context.ShipFromInformation.FirstOrDefault();
                return ship;
            }
        }
    }
}
