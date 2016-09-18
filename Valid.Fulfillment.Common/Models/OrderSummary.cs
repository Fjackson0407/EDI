using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Valid.Fulfillment.Common.Models
{
    public class OrderSummary : INotifyPropertyChanged
    {
        private Int32 m_Total = 0;
        public Int32 Total
        {
            get { return m_Total; }
            set { SetField<Int32>(ref m_Total, value, "Total"); }
        }

        private Int32 m_Picked = 0;
        public Int32 Picked
        {
            get { return m_Picked; }
            set { SetField<Int32>(ref m_Picked, value, "Picked"); }
        }

        private Int32 m_Cancel = 0;
        public Int32 Cancel
        {
            get { return m_Cancel; }
            set { SetField<Int32>(ref m_Cancel, value, "Cancel"); }
        }

        private Int32 m_Open = 0;
        public Int32 Open
        {
            get { return m_Open; }
            set { SetField<Int32>(ref m_Open, value, "Open"); }
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
