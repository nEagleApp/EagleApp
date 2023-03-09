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

        public BaseViewModels<ContentPage> CurrentPage
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


        private Stack<BaseViewModels<ContentPage>> _pages = new Stack<BaseViewModels<ContentPage>>();
        private Stack<NavigationPage> _navigations = new Stack<NavigationPage>();

        public async Task OpenApp<TViewModel>() where TViewModel : BaseViewModels<ContentPage>
        {
            var navigation = CreateNavigationView();
            var viewModel = CreateViewModel<TViewModel>();
            await navigation.PushAsync(viewModel.View);
            _pages.Push(viewModel);

            App.Current.MainPage = navigation;
        }

        public void ChangePage<TViewModel>(bool isNaviagte = false) where TViewModel: BaseViewModels<ContentPage>
        {

        }


        private TViewModel CreateViewModel<TViewModel>()
        {
            var instance = (TViewModel)Activator.CreateInstance(typeof(TViewModel));
            return instance;
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
