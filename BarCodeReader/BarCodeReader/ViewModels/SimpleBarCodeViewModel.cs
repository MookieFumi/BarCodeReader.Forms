using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using BarCodeReader.Models;
using BarCodeReader.ViewModels.Base;
using Scandit.BarcodePicker.Unified;
using Xamarin.Forms;

namespace BarCodeReader.ViewModels
{
	public class SimpleBarCodeViewModel : ViewModelBase
	{
		private string _recognizedCode;

		public SimpleBarCodeViewModel()
		{
			ConfigureBarCodeScanner();
			ScanditService.BarcodePicker.DidScan += OnCodesScanned;
		}

		async Task ConfigureBarCodeScanner()
		{
			ScanditService.BarcodePicker.ScanOverlay.BeepEnabled = true;
			ScanditService.BarcodePicker.ScanOverlay.VibrateEnabled = true;
			ScanditService.BarcodePicker.ScanOverlay.TorchButtonVisible = true;
			ScanditService.BarcodePicker.ScanOverlay.GuiStyle = GuiStyle.Laser;
			ScanditService.BarcodePicker.CancelButtonText = "Stop scanning";
		}

		private async void OnCodesScanned(ScanSession session)
		{
			session.StopScanning();


			var firstCode = session.NewlyRecognizedCodes.First();
			var text = String.Format("{0} ({1})", firstCode.Data, firstCode.SymbologyString.ToUpper());

			//if (await Application.Current.MainPage.DisplayAlert("Are you sure to include it in the collection", $"You have scanned {text}", "Yes", "No"))
			//{
			if (!Products.Any(p => p.BarCode == text))
			{
				Products.Insert(0, new Product() { BarCode = text, Units = 1 });
			}
			else
			{
				var product = _products.Single(p => p.BarCode == text);
				_products.Remove(product);
				product.Units++;
				Products.Insert(0, product);
			}
			//}

			//await ScanditService.BarcodePicker.StartScanningAsync(false);
		}

		public ICommand StartScanningCommand => new Command(async () => await StartScanning());

		private async Task StartScanning()
		{
			await ScanditService.BarcodePicker.StartScanningAsync(false);
		}

		public string Name
		{
			get
			{
				return CurrentUser.Name;
			}
		}

		public string ShopName
		{
			get
			{
				return CurrentUser.ShopName;
			}
		}

		public int? Ranking
		{
			get
			{
				return CurrentUser.Ranking;
			}
		}

		private ObservableCollection<Product> _products = new ObservableCollection<Product>();
		public ObservableCollection<Product> Products
		{
			get
			{
				return _products;
			}
			set
			{
				_products = value;
				OnPropertyChanged(nameof(Products));
			}
		}
	}
}
