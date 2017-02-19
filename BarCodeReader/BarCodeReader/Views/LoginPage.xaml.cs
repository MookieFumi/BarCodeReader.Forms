using BarCodeReader.ViewModels;
using Xamarin.Forms;

namespace BarCodeReader.Views
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
			BindingContext = new LoginViewModel();
		}
	}
}