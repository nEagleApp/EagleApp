using System.ComponentModel;

namespace Eagle.ButtonMoney.ViewModels
{
    public abstract class BaseViewModels: INotifyPropertyChanged
    {
        private ContentPage _view;
        public ContentPage ContentPage
        {
            get
            {
                return _view;
            }
        }
        public BaseViewModels(ContentPage view)
        {
            _view = view;
            _view.BindingContext = this;
        }

        public TView GetView<TView>() where TView: ContentPage
        {
            return (TView)_view;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
