using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Domain;
using Valid.Fulfillment.Common.Enums;
using Valid.Fulfillment.Common.Models;
using DCInformation = Domain.DCInformation;
using static Helpers.EDIHelperFunctions;

namespace Valid.Fulfillment.Common.Mappers
{
    public class Mapper
    {
        public IEnumerable<FulfillmentBreakdown> MapFulfillmentBreakdownList(IEnumerable<StoreInfoFromEDI850> orderInfoList)
        {
            var retList = new List<FulfillmentBreakdown>();
            var dcNumberList = orderInfoList.Select(x => x.DCNumber).Distinct();

            foreach (var dc in dcNumberList)
            {
                var storeCount = orderInfoList.Where(x => x.DCNumber == dc).Select(x => x.OrderStoreNumber).Distinct().Count();
                var packCount = orderInfoList.Where(x => x.DCNumber == dc).Sum(x => x.BundleQty);

                retList.Add(new FulfillmentBreakdown { DcNumber = dc, StoreCount = storeCount, PackCount = packCount });
            }

            return retList;
        }

        public OrderSummary MapSummary(IEnumerable<StoreInfoFromEDI850> orderInfoList)
        {
            var orderSummary = new OrderSummary();

            orderSummary.Total = orderInfoList.Count();
            orderSummary.Picked = orderInfoList.Count(x => x.QtyOrdered == x.QtyPacked);
            orderSummary.Open = orderInfoList.Count(x => x.QtyOrdered != x.QtyPacked);
            orderSummary.Cancel = 0;

            return orderSummary;
        }

        public IEnumerable<StoreDetailGrid> MapStoreDetailList(IEnumerable<StoreInfoFromEDI850> orderInfoList, EOrderStatus orderStatus)
        {
            var retList = new ObservableCollection<StoreDetailGrid>();
            var orderList = orderInfoList.Where(y=>y.PickStatus == (int)orderStatus).Select(x => x.OrderStoreNumber).Distinct();

            foreach (var store in orderList)
            {
                var storeInfoList = orderInfoList.Where(x => x.OrderStoreNumber == store && x.PickStatus == (int)orderStatus).ToList();
                retList.Add(new StoreDetailGrid
                {
                    DcNumber = storeInfoList.FirstOrDefault().DCNumber,
                    StoreNumber = store,
                    OrderQty = (storeInfoList.Sum(x => x.BundleQty)),

                    OrderStatusDescription = Enum.GetName(typeof(EOrderStatus), storeInfoList.FirstOrDefault().PickStatus)
                });
            }
            return retList;
        }

        public EOrderType MapCompanyCodeToOrderType(string companyCode)
        {
            switch (companyCode)
            {
                case "STO08":
                    return EOrderType.VisaMc;
                case "CER05":
                    return EOrderType.Amex;
                default:
                    return EOrderType.Unknown;
            }
        }

        public IEnumerable<Label> MapStoreTolabel(StoreInfoFromEDI850 store, DCInformation dcInformation, ShipFromInformation shipFrom)
        {
            List<Label> labelList = new List<Label>();
            var test = store.Carton.Distinct();
            foreach (var carton in store.Carton)
            {
                labelList.Add(new Label
                {
                    Count = 0,
                    OrderStoreNumber = store.OrderStoreNumber,
                    DcNumber = store.DCNumber,
                    PONumber = store.PONumber,

                    To = "TARGET STORES",
                    SSCC = carton.UCC128,

                    From = "Valid USA",
                    Faddress = shipFrom.Address,
                    Fcity = shipFrom.City,
                    Fstate = shipFrom.State,
                    FZip = shipFrom.PostalCode,

                    Taddress = dcInformation.Address,
                    Tcity = dcInformation.City,
                    Tstate = dcInformation.State,
                    Tzip = dcInformation.PostalCode

                });
            }
            return labelList;
        }

        public ObservableCollection<T> MapListToObservColl<T>(IEnumerable<T> List)
        {
            var newCollection = new ObservableCollection<T>();
            foreach (var item in List)
            {
                newCollection.Add(item);
            }
            return newCollection;
        }


    }
}
