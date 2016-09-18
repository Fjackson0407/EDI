using System.Collections.Generic;
using Domain;
using Valid.Fulfillment.Common.Mappers;
using Valid.Fulfillment.Common.MCLabel;
using Valid.Fulfillment.Common.Models;

namespace Valid.Fulfillment.Service
{
    public class PrintService
    {
        private MCLabel _label;
        private Mapper _mapper;
        private DataService _sqlService;

        public PrintService(Settings settings)
        {
            AppSettings = settings;
            _label = new MCLabel(AppSettings.PrintPath, AppSettings.ConnectionString, AppSettings.PrintFileName);
            _mapper = new Mapper();
            _sqlService = new DataService(AppSettings);
        }

        public Settings AppSettings { get; set; }

        public string PrintCartonLabel(List<StoreInfoFromEDI850> orderDetailGridList)
        {
            List<Label> labelList = new List<Label>();

            foreach (var store in orderDetailGridList)
            {
                var dcInfo = _sqlService.GetDcInformation(store.DCNumber.Replace("'",""));
                var shipFrom = _sqlService.GetShipFromAddress();
                labelList.AddRange(_mapper.MapStoreTolabel(store, dcInfo, shipFrom));
            }

            return _label.ConvertToString(labelList);
        }
    }
}
