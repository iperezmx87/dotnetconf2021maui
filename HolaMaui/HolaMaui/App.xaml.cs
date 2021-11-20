using HolaMaui.View;
using Application = Microsoft.Maui.Controls.Application;

namespace HolaMaui
{
    public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}
	}
}
