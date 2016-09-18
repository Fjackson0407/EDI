using System;

namespace Valid.Fulfillment.Common.Models
{
    public class StoreDetailGrid
    {
        public string DcNumber { get; set; }
        public Guid StoreFk { get; set; }
        public string StoreNumber { get; set; }
        public int OrderQty { get; set; }
        public string OrderStatusDescription { get; set; }

    }
}
