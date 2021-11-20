using HolaMaui.ViewModel;
using Microsoft.Maui.Controls;

namespace HolaMaui.View
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
