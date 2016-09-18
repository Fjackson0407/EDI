using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Domain;
using Valid.Fulfillment.Common.Enums;
using Valid.Fulfillment.Common.Mappers;
using Valid.Fulfillment.Common.Models;
using Valid.Fulfillment.Service;
using static Helpers.EDIHelperFunctions;

namespace Valid.Fulfillment.Client.ViewModels
{
    public class MainWindow_ViewModel : INotifyPropertyChanged
    {
        Mapper m_Mapper = new Mapper();
        private DataService _SqlService;


        public MainWindow_ViewModel(Settings settings)
        {
            AppSettings = settings;
            _SqlService = new DataService(AppSettings);
        }

        #region Misc Properties

        public Settings AppSettings { get; set; }

        private UserTable m_CurrentUser = new UserTable();
        public UserTable CurrentUser
        {
            get { return m_CurrentUser; }
            set { SetField(ref m_CurrentUser, value, "CurrentUser"); }
        }

        public Visibility FilterVisibility
        {
            get
            {
                if (MasterOrderDetailList.Any())
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }

        public Visibility FulfillmentVisibility
        {
            get
            {
                if (OrderDetailList.Any())
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }

        private EOrderStatus m_OrderStatus = EOrderStatus.All;
        public EOrderStatus OrderStatus
        {
            get { return m_OrderStatus; }
            set { SetField(ref m_OrderStatus, value, "OrderStatus"); }
        }

        private IEnumerable<StoreInfoFromEDI850> m_MasterOrderDetailList = new List<StoreInfoFromEDI850>();
        public IEnumerable<StoreInfoFromEDI850> MasterOrderDetailList
        {
            get { return m_MasterOrderDetailList; }
            set
            {
                SetField(ref m_MasterOrderDetailList, value, "MasterOrderDetailList");
                OnPropertyChanged("FilterVisibility");
            }
        }

        private IEnumerable<StoreInfoFromEDI850> m_OrderDetailList = new List<StoreInfoFromEDI850>();
        public IEnumerable<StoreInfoFromEDI850> OrderDetailList
        {
            get { return m_OrderDetailList; }
            set
            {
                SetField(ref m_OrderDetailList, value, "OrderDetailList");
                OnPropertyChanged("FulfillmentVisibility");
            }
        }

        private IEnumerable<StoreInfoFromEDI850> m_VisaMcOrderDetailList = new List<StoreInfoFromEDI850>();
        public IEnumerable<StoreInfoFromEDI850> VisaMcOrderDetailList
        {
            get { return m_VisaMcOrderDetailList; }
            set { SetField(ref m_VisaMcOrderDetailList, value, "VisaMcOrderDetailList"); }
        }

        private IEnumerable<StoreInfoFromEDI850> m_AmexOrderDetailList = new List<StoreInfoFromEDI850>();
        public IEnumerable<StoreInfoFromEDI850> AmexOrderDetailList
        {
            get { return m_AmexOrderDetailList; }
            set { SetField(ref m_AmexOrderDetailList, value, "AmexOrderDetailList"); }
        }

        private IEnumerable<PurchaseOrderInfo> m_PurchaseOrderList = new List<PurchaseOrderInfo>();
        public IEnumerable<PurchaseOrderInfo> PurchaseOrderList
        {
            get { return m_PurchaseOrderList; }
            set { SetField(ref m_PurchaseOrderList, value, "PurchaseOrderList"); }
        }

        private PurchaseOrderInfo m_SelectedPurchaseOrder = new PurchaseOrderInfo();
        public PurchaseOrderInfo SelectedPurchaseOrder
        {
            get { return m_SelectedPurchaseOrder; }
            set { SetField(ref m_SelectedPurchaseOrder, value, "SelectedPurchaseOrder"); }
        }

        private Visibility m_LoadButtonVisibility = Visibility.Hidden;

        public Visibility LoadButtonVisibility
        {
            get { return m_LoadButtonVisibility; }
            set { SetField(ref m_LoadButtonVisibility, value, "LoadButtonVisibility"); }
        }

        #endregion

        #region Fulfillment Detail Tab Properties

        private IEnumerable<FulfillmentBreakdown> m_VisaMcDetailList = new List<FulfillmentBreakdown>();
        public IEnumerable<FulfillmentBreakdown> VisaMcDetailList
        {
            get { return m_VisaMcDetailList; }
            set { SetField(ref m_VisaMcDetailList, value, "VisaMcDetailList"); }
        }

        private IEnumerable<FulfillmentBreakdown> m_AmexDetailList = new List<FulfillmentBreakdown>();
        public IEnumerable<FulfillmentBreakdown> AmexDetailList
        {
            get { return m_AmexDetailList; }
            set { SetField(ref m_AmexDetailList, value, "AmexDetailList"); }
        }

        #endregion

        #region Summary Tab properties

        private OrderSummary m_SummaryVisaMc = new OrderSummary();
        public OrderSummary SummaryVisaMc
        {
            get { return m_SummaryVisaMc; }
            set { SetField(ref m_SummaryVisaMc, value, "SummaryVisaMc"); }
        }

        private OrderSummary m_SummaryAmex = new OrderSummary();
        public OrderSummary SummaryAmex
        {
            get { return m_SummaryAmex; }
            set { SetField(ref m_SummaryAmex, value, "SummaryAmex"); }
        }

        private OrderSummary m_SummaryTotal = new OrderSummary();
        public OrderSummary SummaryTotal
        {
            get { return m_SummaryTotal; }
            set { SetField(ref m_SummaryTotal, value, "SummaryTotal"); }
        }

        #endregion

        public void LoadOrderData(DateTime startDate, DateTime endDate)
        {
            MasterOrderDetailList = _SqlService.GetOrdersByDateRangeList(startDate, endDate);
            LoadPurchaseOrders(MasterOrderDetailList);
            FilterOrderDetails();
        }

        public void LoadPurchaseOrders(IEnumerable<StoreInfoFromEDI850> masterOrderDetailList)
        {
            var poList = new List<PurchaseOrderInfo>();
            foreach (var storeInfo in masterOrderDetailList)
            {
                if (!poList.Any(x => x.PoNumber == storeInfo.PONumber))
                {
                    string[] POPart = storeInfo.PONumber.Split('-');
                    string Po = string.Format("{0}-{1}", POPart[0], POPart[1]);
                    if (!poList.Exists(t => t.PoNumber == Po))
                    {
                        poList.Add(new PurchaseOrderInfo { PoNumber = Po  });
                    }
                }
            }
            PurchaseOrderList = poList;
        }

        public void FilterOrderDetails()
        {
            if (!string.IsNullOrEmpty(SelectedPurchaseOrder.PoNumber))
            {
                if (OrderStatus == EOrderStatus.Open)
                {
                   
                    OrderDetailList = MasterOrderDetailList.Where(x => x.PickStatus == (int) EOrderStatus.Open && x.POSubstring  == SelectedPurchaseOrder.PoNumber).ToList();
                
                }
                else if (OrderStatus == EOrderStatus.Closed)
                {
                    OrderDetailList =
                        MasterOrderDetailList.Where(x => x.PickStatus == (int) EOrderStatus.Closed && x.PONumber == SelectedPurchaseOrder.PoNumber).ToList();
                }
                else
                {
                    OrderDetailList = MasterOrderDetailList.Where(x => x.PONumber == SelectedPurchaseOrder.PoNumber).ToList();
                }
                VisaMcOrderDetailList =
                    OrderDetailList.Where(x => m_Mapper.MapCompanyCodeToOrderType(x.CompanyCode) == EOrderType.VisaMc)
                    .OrderBy(x=>x.DCNumber)
                    .ToList();
                VisaMcDetailList = m_Mapper.MapFulfillmentBreakdownList(VisaMcOrderDetailList);

                AmexOrderDetailList =
                    OrderDetailList.Where(x => m_Mapper.MapCompanyCodeToOrderType(x.CompanyCode) == EOrderType.Amex)
                    .OrderBy(x => x.DCNumber)
                    .ToList();
                AmexDetailList = m_Mapper.MapFulfillmentBreakdownList(AmexOrderDetailList);

                SummaryVisaMc = m_Mapper.MapSummary(VisaMcOrderDetailList);
                SummaryAmex = m_Mapper.MapSummary(AmexOrderDetailList);
                SummaryTotal = m_Mapper.MapSummary(OrderDetailList);
            }
            else
            {
                VisaMcOrderDetailList = new List<StoreInfoFromEDI850>();
                AmexOrderDetailList = new List<StoreInfoFromEDI850>();
                SummaryAmex = new OrderSummary();
                SummaryVisaMc = new OrderSummary();
                SummaryTotal = new OrderSummary();
            }
        }

        public IEnumerable<UserTable> LoadUserData()
        {
            var userList = _SqlService.GetUserList();
            return userList;
        }

        public void SetOrderStatus(bool open, bool closed)
        {
            if(open)
                OrderStatus = EOrderStatus.Open;
            else if(closed)  
                OrderStatus = EOrderStatus.Closed;
            else 
                OrderStatus = EOrderStatus.All;
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
