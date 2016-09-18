using System;
using System.Collections.Generic;
using Domain;
using Valid.Fulfillment.Common;
using Valid.Fulfillment.Common.Models;
using Valid.Fulfillment.Data;
using DCInformation = Domain.DCInformation;

namespace Valid.Fulfillment.Service
{
    public class DataService : IDataService
    {
        private Settings _Settings;
        private EFRepository _sqlRepo;
        //private SqlRepository _sqlRepo;

        public DataService(Settings settings)
        {
            _Settings = settings;
            _sqlRepo = new EFRepository(_Settings);
            //_sqlRepo = new SqlRepository(_Settings);
        }

        public IEnumerable<UserTable> GetUserList()
        {
            return _sqlRepo.GetUserList();
        }

        public IEnumerable<StoreInfoFromEDI850> GetOrdersByDateRangeList(DateTime StartDate, DateTime EndDate)
        {
            return _sqlRepo.GetOrdersByDateRangeList(StartDate, EndDate);
        }

        public bool UpdateStoreInfo(IEnumerable<StoreInfoFromEDI850> orderDetailGridList)
        {
            return _sqlRepo.UpdateStoreInfo(orderDetailGridList);
        }

        public bool IsSerialNumberListAvailable(IEnumerable<string> serialNumberList)
        {
            return _sqlRepo.IsSerialNumberListAvailable(serialNumberList);
        }

        public DCInformation GetDcInformation(string dcNumber)
        {
            return _sqlRepo.GetDcInformation(dcNumber);
        }

        public ShipFromInformation GetShipFromAddress()
        {
            return _sqlRepo.GetShipFromAddress();
        }
    }
}
