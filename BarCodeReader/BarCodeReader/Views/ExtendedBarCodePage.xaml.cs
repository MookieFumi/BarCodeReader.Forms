using System.Linq;
using Scandit.BarcodePicker.Unified;
using Scandit.BarcodePicker.Unified.Abstractions;
using Xamarin.Forms;

namespace BarCodeReader.Views
{
	public partial class ExtendedBarCodePage : ContentPage
	{

		public ExtendedBarCodePage()
		{
			InitializeComponent();

			// retrieve the actual native barcode picker implementation. The concrete implementation 
			// will be different depending on the platform the code runs on.
			_picker = ScanditService.BarcodePicker;
			// will get invoked whenever a code has been scanned.
			_picker.DidScan += OnDidScan;

			// set up the settings page
			_settingsPage = new SettingsPage();
		}

		void OnDidScan(ScanSession session)
		{

			// guaranteed to always have at least one element, so we don't have to 
			// check the size of the NewlyRecognizedCodes array.
			var firstCode = session.NewlyRecognizedCodes.First();
			var message = string.Format("Code Scanned:\n {0}\n({1})", firstCode.Data, firstCode.SymbologyString.ToUpper());
			// Because this event handler is called from an scanner-internal thread, 
			// you must make sure to dispatch to the main thread for any UI work.
			Device.BeginInvokeOnMainThread(() => this.ResultLabel.Text = message);
			session.StopScanning();
		}

		async void OnSettingsClicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(_settingsPage);
		}

		async void OnScanButtonClicked(object sender, System.EventArgs e)
		{

			// The scanning behavior of the barcode picker is configured through scan
			// settings. We start with empty scan settings and enable a very generous
			// set of symbologies. In your own apps, only enable the symbologies you
			// actually need.
			await _picker.StartScanningAsync(false);
		}

		IBarcodePicker _picker;

		SettingsPage _settingsPage;
	}
}
