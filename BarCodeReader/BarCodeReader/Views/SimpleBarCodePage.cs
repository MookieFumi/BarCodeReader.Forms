using BarCodeReader.ViewModels;
using Xamarin.Forms;

namespace BarCodeReader.Views
{
	public partial class SimpleBarCodePage : ContentPage
	{
		public SimpleBarCodePage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
			BindingContext = new SimpleBarCodeViewModel();
		}
	}
}