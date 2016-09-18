using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Domain;
using log4net;
using log4net.Config;
using Valid.Fulfillment.Common.Enums;
using Valid.Fulfillment.Common.Mappers;
using Valid.Fulfillment.Common.Models;
using Valid.Fulfillment.Data;
using Valid.Fulfillment.Service;
using static Helpers.EDIHelperFunctions;

namespace Valid.Fulfillment.Client.ViewModels
{
    public class OrderDetail_ViewModel : INotifyPropertyChanged
    {
        private DataService _SqlService;
        private PrintService _PrintService;
        private Mapper _Mapper;
        private ILog _logger;

        public OrderDetail_ViewModel(Settings settings, IEnumerable<StoreInfoFromEDI850> orderInfoList, string username)
        {
            _logger = LogManager.GetLogger(typeof(EFRepository));
            XmlConfigurator.Configure();
            _logger.Info("OrderDetail_ViewModel Loaded");

            AppSettings = settings;
            _SqlService = new DataService(AppSettings);
            _PrintService = new PrintService(AppSettings);
            _Mapper = new Mapper();
            CurentUser = username;
            OrderType = orderInfoList.FirstOrDefault().CompanyCode;
            OrderDetailGridList = _Mapper.MapListToObservColl<StoreInfoFromEDI850>(orderInfoList);
        }

        #region Order Detail Properties

        public Settings AppSettings { get; set; }

        private string _CurentUser = string.Empty;
        public string CurentUser
        {
            get { return _CurentUser; }
            set
            {
                _CurentUser = value;
                //ToDo: should this be a const ??
                OnPropertyChanged("CurentUser");
            }
        }


        private string _StatusMessage = string.Empty;
        public string StatusMessage
        {
            get { return _StatusMessage; }
            set
            {
                _StatusMessage = value;
                //ToDo: should this be a const ??
                OnPropertyChanged("StatusMessage");
            }
        }

        private Visibility _UpcMatched = Visibility.Hidden;
        public Visibility UpcMatched
        {
            get { return _UpcMatched; }
            set
            {
                _UpcMatched = value;
                //ToDo: should this be a const ??
                OnPropertyChanged("UpcMatched");
            }
        }

        private string _OrderType = string.Empty;
        public string OrderType
        {
            get { return _OrderType; }
            set
            {
                _OrderType = value;
                //ToDo: should this be a const ??
                OnPropertyChanged("OrderType");
            }
        }

        private bool _PrintBtnEnabled = false;
        public bool PrintBtnEnabled
        {
            get { return _PrintBtnEnabled; }
            set
            {
                _PrintBtnEnabled = value;
                //ToDo: should this be a const ??
                OnPropertyChanged("PrintBtnEnabled");
            }
        }
         
        private ObservableCollection<StoreInfoFromEDI850> _OrderDetailGridList = new ObservableCollection<StoreInfoFromEDI850>();
        public ObservableCollection<StoreInfoFromEDI850> OrderDetailGridList
        {
            get { return _OrderDetailGridList; }
            set
            {
                _OrderDetailGridList = value;
                OnPropertyChanged("OrderDetailGridList");
            }
        }

        private ObservableCollection<SerialRageNumber> _SerialRangeList = new ObservableCollection<SerialRageNumber>();
        public ObservableCollection<SerialRageNumber> SerialRangeList
        {
            get { return _SerialRangeList; }
            set
            {
                _SerialRangeList = value;
                OnPropertyChanged("SerialRangeList");
            }
        }

        #endregion

        public string PrintCartonLabel()
        {
            //ToDo: avoid tolist when possible Projects can take a lor of time 
            return _PrintService.PrintCartonLabel(OrderDetailGridList.ToList());
        }

        //ToDo: remove this one 
        public void ReprintCartonLabel()
        {
            throw new NotImplementedException();
        }

        public void UpdateOrders(string label)
        {
            
            foreach (var storeInfo in OrderDetailGridList)
            {
                storeInfo.Label = label;
                storeInfo.PickStatus = (int) EOrderStatus.Closed;
            }
           _SqlService.UpdateStoreInfo(OrderDetailGridList.ToList());
        }

        public bool SerialRangeIsAvailable(List<string> serialList)
        {
            return _SqlService.IsSerialNumberListAvailable(serialList);
        }

        public List<string> SerialRangeToSerialList(string serialRange)
        {
            List<string> serialList = new List<string>();
            try
            {
                var list = serialRange.Split('-');
                if (list.Count() == 2)
                {
                    //ToDo: use Double.Parse  so you will not thorw a error 
                    double start = Convert.ToDouble(list[0]);
                    double  end = Convert.ToDouble(list[1]);
                    for (double  i =  start; i <= end; i++)
                    {
                        serialList.Add(i.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                serialList = new List<string>();
                _logger.Info(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            return serialList;
        } 

        public void AddSerialRange(string serialRange, StoreInfoFromEDI850 orderInfo)
        {
            var record = OrderDetailGridList.FirstOrDefault(x=>x.Id == orderInfo.Id);
            var snList = SerialRangeToSerialList(serialRange);
            //ToDo: I do not care so just fyi you can also use snList.ForEach 
            foreach (var sn in snList)
            {
                record.SerialRageNumber.Add(new SerialRageNumber
                {
                    ID = Guid.NewGuid(),
                    SerialNumber = sn,
                    StoreInfoFromEDI850FK = orderInfo.Id,
                    Serialbundle = serialRange
                });
            }
            
            record.QtyPacked++;
            record.User = CurentUser;
            OnPropertyChanged("OrderDetailGridList");
            LoadSerialRangeList(record);
        }

        public void RemoveSerialRange(SerialRageNumber serialRange)
        {
            var record = OrderDetailGridList.FirstOrDefault(x => x.Id == serialRange.StoreInfoFromEDI850FK);
            var sbRecords = record.SerialRageNumber.Where(x => x.Serialbundle == serialRange.Serialbundle).ToList();
            foreach (var sbRecord in sbRecords)
            {
                record.SerialRageNumber.Remove(sbRecord);
            }
            record.QtyPacked--;
            OnPropertyChanged("OrderDetailGridList");
            LoadSerialRangeList(record);
        }

        public void LoadSerialRangeList(StoreInfoFromEDI850 record)
        {
            var serialList = new ObservableCollection<SerialRageNumber>();
            foreach (var sb in record.SerialRageNumber.Select(x => x.Serialbundle).Distinct())
            {
                serialList.Add(record.SerialRageNumber.FirstOrDefault(x => x.Serialbundle == sb));
            }
            SerialRangeList = serialList;
        }

        public void CheckReadyToPrint()
        {
            bool isReady = true;
            foreach (var store in OrderDetailGridList)
            {
                if (store.SerialRageNumber.Count < store.QtyOrdered)
                {
                    isReady = false;
                    break;
                }
            }
            
            PrintBtnEnabled = isReady;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion


    }
}


