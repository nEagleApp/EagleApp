using Eagle.ButtonMoney.Settings;
using Eagle.ButtonMoney.ViewModels.Implementations;
using Eagle.ButtonMoney.Views;

namespace Eagle.ButtonMoney
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            PageStack.Instance.OpenApp(new LoginViewModel()).ConfigureAwait(false).GetAwaiter();
        }
    }
}