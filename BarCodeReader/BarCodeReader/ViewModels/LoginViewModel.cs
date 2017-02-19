using BarCodeReader.ViewModels.Base;
using BarCodeReader.Views;
using Xamarin.Forms;

namespace BarCodeReader.ViewModels
{

	public class LoginViewModel : ViewModelBase
	{
		private string _userName;
		private string _password;

		public LoginViewModel()
		{
#if DEBUG
			UserName = "mookiefumi@outlook.com";
			Password = "mookie@2";
#endif
		}

		public string UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				_userName = value;
				OnPropertyChanged(nameof(UserName));
			}
		}

		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
			}
		}

		public Command LoginCommand
		{
			get { return new Command(LoginCommandExecute); }
		}

		private async void LoginCommandExecute()
		{
			if (Password != "mookie@2")
			{
				CurrentUser.Clear();
				await Application.Current.MainPage.DisplayAlert("Error", "You are not authorized", "Try again");
			}
			else
			{
				CurrentUser.Init("Miguel Angel Martin Hernández", "Parque Corredor", 2);
				await Application.Current.MainPage.Navigation.PushAsync(new SimpleBarCodePage());
			}
		}
	}
}