using Scandit.BarcodePicker.Unified;
using Scandit.BarcodePicker.Unified.Abstractions;
using Xamarin.Forms;

namespace BarCodeReader
{
	public partial class App : Application
	{
		private static string scanditLicenseAppKey = "OtYJAR0FvTXAVROUthqMV3CgHXmJLBH9Oyz2GTa1AcU";

		public App()
		{
			ScanditService.ScanditLicense.AppKey = scanditLicenseAppKey;
			InitScanditSettings();

			InitializeComponent();
			MainPage = new NavigationPage(new BarCodeReader.Views.LoginPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		async void InitScanditSettings()
		{
			IBarcodePicker picker = ScanditService.BarcodePicker;

			// The scanning behavior of the barcode picker is configured through scan
			// settings. We start with empty scan settings and enable a very generous
			// set of symbologies. In your own apps, only enable the symbologies you
			// actually need.
			var settings = picker.GetDefaultScanSettings();
			var symbologiesToEnable = new Symbology[] {
				Symbology.Ean13
			};
			foreach (var sym in symbologiesToEnable)
			{
				settings.EnableSymbology(sym, true);
			}
			await picker.ApplySettingsAsync(settings);
			// This will open the scanner in full-screen mode. 
		}
	}
}
