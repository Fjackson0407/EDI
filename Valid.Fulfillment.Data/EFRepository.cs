using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Domain;
using log4net;
using log4net.Config;
using Repository.DataSource;
using Repository.UOW;
using Valid.Fulfillment.Common;
using Valid.Fulfillment.Common.Models;
using DCInformation = Domain.DCInformation;

namespace Valid.Fulfillment.Data
{
    public class EFRepository : IDataService
    {
        private Settings _Settings;
        private ILog _logger;

        public EFRepository(Settings settings)
        {
            _Settings = settings;
            _logger = LogManager.GetLogger(typeof(EFRepository));
            XmlConfigurator.Configure();
            _logger.Info("EFRepository Loaded");
        }

        public IEnumerable<UserTable> GetUserList()
        {
            try
            {
                using (var UoW = new UnitofWork(new EDIContext(_Settings.ConnectionString)))
                {
                    List<UserTable> userList = UoW.User.GetAll().ToList();
                    return userList;
                }
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format("Error Getting User List - {0}", ex.Message));
                return new List<UserTable>();
            }
            
        }

        public IEnumerable<StoreInfoFromEDI850> GetOrdersByDateRangeList(DateTime StartDate, DateTime EndDate)
        {
            try
            {
                using (var UoW = new UnitofWork(new EDIContext(_Settings.ConnectionString)))
                {
                    var stores = UoW.AddEDI850.Find(x => x.PODate >= StartDate && x.PODate <= EndDate);

                    //ToDo: This should be fixed in the context to load the empty object/list
                    foreach (var store in stores)
                    {
                        if (!store.SerialRageNumber.Any())
                        {
                            store.SerialRageNumber = new List<SerialRageNumber>();
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
            catch (Exception ex)
            {
                _logger.Info(string.Format("Error Getting Order Details - {0}", ex.Message));
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return new List<StoreInfoFromEDI850>();
            }

        }




        public bool UpdateStoreInfo(IEnumerable<StoreInfoFromEDI850> orderDetailGridList)
        {
            bool retVal = false;
            try
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
                            if (sod.SerialRageNumber != orderinfo.SerialRageNumber )
                            {
                                sod.SerialRageNumber = orderinfo.SerialRageNumber;
                            }
                            sod.Label = orderinfo.Label;
                            sod.PickStatus = orderinfo.PickStatus;
                        }
                        context.SaveChanges();
                        retVal = true;
                    }
                    //context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format("Error Saving Order Details - {0}", ex.Message));
            }
            return retVal;

        }

        public bool IsSerialNumberListAvailable(IEnumerable<string> serialNumberList)
        {
            bool retval = false;
            try
            {
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
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format("Error Getting Serial List - {0}", ex.Message));
            }
            
            
            return retval;
        }

        public DCInformation GetDcInformation(string dcNumber)
        {
            try
            {
                using (var context = new EDIContext(_Settings.ConnectionString))
                {
                    DCInformation dc = context.DCInformation.FirstOrDefault(x => x.StoreID == dcNumber);
                    return dc;
                }
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format("Error Getting DC Info - {0}", ex.Message));
                return new DCInformation();
            }
            
        }

        public ShipFromInformation GetShipFromAddress()
        {
            try
            {
                using (var context = new EDIContext(_Settings.ConnectionString))
                {
                    ShipFromInformation ship = context.ShipFromInformation.FirstOrDefault();
                    return ship;
                }
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format("Error Getting Ship From Address - {0}", ex.Message));
                return new ShipFromInformation();
            }
            
        }
    }
}
