using HolaXamarin.ViewModel;
using Xamarin.Forms;

namespace HolaXamarin.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new SwapiViewModel();
        }
    }
}
