using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Domain;

namespace Valid.Fulfillment.Common
{
    public interface IDataService
    {
        IEnumerable<UserTable> GetUserList();
        IEnumerable<StoreInfoFromEDI850> GetOrdersByDateRangeList(DateTime StartDate, DateTime EndDate);
        bool UpdateStoreInfo(IEnumerable<StoreInfoFromEDI850> orderDetailGridList);
        bool IsSerialNumberListAvailable(IEnumerable<string> serialNumberList);
        DCInformation GetDcInformation(string dcNumber);
        ShipFromInformation GetShipFromAddress();
    }
}