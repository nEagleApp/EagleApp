using System.ComponentModel;

namespace Eagle.ButtonMoney.ViewModels
{
    public abstract class BaseViewModels<TView> : INotifyPropertyChanged where TView : ContentPage
    {
        public BaseViewModels(TView view)
        {
            View = view;
            View.BindingContext = this;
        }

        public TView View { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
