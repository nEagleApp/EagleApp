using Eagle.ButtonMoney.Views;

namespace Eagle.ButtonMoney.ViewModels.Implementations
{
    public class LoginViewModel : BaseViewModels<LoginPage>
    {
        public LoginViewModel() : base(new LoginPage())
        {
        }



        /*
         * Private ViewModel datas
         */
        #region Private ViewModel datas
        private string _username;
        private string _password;
        #endregion

        /*
         * Public ViewModel datas
         */
        #region Public ViewModel datas
        public string Username { 
            get 
            { 
                return _username; 
            } 
            set 
            { 
                _username = value;
                OnPropertyChanged(nameof(Username));
            } 
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        #endregion
    }
}
