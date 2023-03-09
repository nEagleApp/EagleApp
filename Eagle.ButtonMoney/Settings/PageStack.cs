using Eagle.ButtonMoney.ViewModels;

namespace Eagle.ButtonMoney.Settings
{
    public class PageStack
    {
        public static PageStack _instance;
        public static PageStack Instance
        {
            get
            {
                if(_instance is null)
                {
                    _instance = new PageStack();
                }
                return _instance;
            }
        }

        public BaseViewModels CurrentPage
        {
            get
            {
                return _pages.Peek();
            }
        }
        public NavigationPage CurrentNavigation
        {
            get
            {
                return _navigations.Peek();
            }
        }


        private Stack<BaseViewModels> _pages = new Stack<BaseViewModels>();
        private Stack<NavigationPage> _navigations = new Stack<NavigationPage>();

        public async Task OpenApp(BaseViewModels viewModel)
        {
            var navigation = CreateNavigationView();
            await navigation.PushAsync(viewModel.ContentPage);
            _pages.Push(viewModel);

            App.Current.MainPage = navigation;
        }

        public void ChangePage<TViewModel>(bool isNaviagte = false) where TViewModel: BaseViewModels
        {

        }


        private NavigationPage CreateNavigationView()
        {
            NavigationPage navigation = new NavigationPage();
            navigation.Popped += Navigation_Popped;
            _navigations.Push(navigation);
            return navigation;
        }
        private void Navigation_Popped(object sender, NavigationEventArgs e)
        {
            _pages.Pop();
        }
    }
}
