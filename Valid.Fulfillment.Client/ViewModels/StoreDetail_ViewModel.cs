using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Domain;
using Valid.Fulfillment.Common.Enums;
using Valid.Fulfillment.Common.Mappers;
using Valid.Fulfillment.Common.Models;
using static Helpers.EDIHelperFunctions;

namespace Valid.Fulfillment.Client.ViewModels
{
    public class StoreDetail_ViewModel : INotifyPropertyChanged
    {
        private Mapper _mapper = new Mapper();

        public StoreDetail_ViewModel(Settings settings, IEnumerable<StoreInfoFromEDI850> orderInfoList, string userName, string orderType, EOrderStatus orderStatus)
        {
            _AppSettings = settings;
            _OrderStatus = orderStatus;

            _CurentUser = userName;
            _OrderType = orderType;

            OrderDetailList = orderInfoList;

            UpdateStoreDetailGrid();
        }

        private EOrderStatus _OrderStatus;
        public Settings _AppSettings { get; set; }

        private string _CurentUser = string.Empty;
        public string CurentUser
        {
            get { return _CurentUser; }
            set { SetField(ref _CurentUser, value, "CurentUser"); }
        }

        private string _OrderType = string.Empty;
        public string OrderType
        {
            get { return _OrderType; }
            set { SetField(ref _OrderType, value, "OrderType"); }
        }

        private IEnumerable<StoreInfoFromEDI850> m_OrderDetailList = new List<StoreInfoFromEDI850>();
        public IEnumerable<StoreInfoFromEDI850> OrderDetailList
        {
            get { return m_OrderDetailList; }
            set { SetField(ref m_OrderDetailList, value, "OrderDetailList"); }
        }

        private IEnumerable<StoreDetailGrid> m_StoreDetailGridList = new List<StoreDetailGrid>();
        public IEnumerable<StoreDetailGrid> StoreDetailGridList
        {
            get { return m_StoreDetailGridList; }
            set { SetField(ref m_StoreDetailGridList, value, "StoreDetailGridList"); }
        }

        public void UpdateStoreDetailGrid()
        {
            StoreDetailGridList = _mapper.MapStoreDetailList(OrderDetailList, _OrderStatus).OrderBy(x => x.StoreNumber);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion


    }
}
