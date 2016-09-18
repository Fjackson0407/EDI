using System.Collections.Generic;
using System.ComponentModel;
using Domain;

namespace Valid.Fulfillment.Client.ViewModels
{
    public class UserLogin_ViewModel : INotifyPropertyChanged
    {
        public UserLogin_ViewModel(IEnumerable<UserTable> userInfoList)
        {
            _UserInfoList = userInfoList;
        }

        private IEnumerable<UserTable> _UserInfoList = new List<UserTable>();
        public IEnumerable<UserTable> UserInfoList
        {
            get { return _UserInfoList; }
            set { SetField(ref _UserInfoList, value, "UserInfoList"); }
        }

        private UserTable _UserInfo_SelectedItem = new UserTable();
        public UserTable UserInfo_SelectedItem
        {
            get { return _UserInfo_SelectedItem; }
            set { SetField(ref _UserInfo_SelectedItem, value, "UserInfo_SelectedItem"); }
        }

        public bool ValidatePassword(string pw)
        {
            if (UserInfo_SelectedItem.Password == pw)
                return true;
            return false;
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
