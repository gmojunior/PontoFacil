using PontoFacil.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PontoFacil.Views
{
    public sealed partial class CurrentDatePage : Page
	{
		public CurrentDatePage()
		{
			this.InitializeComponent();
		}

		public CurrentDatePageViewModel ViewModel { get { return (CurrentDatePageViewModel)DataContext; } }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.SetupVisualState(sender,e);
        }
    }
}
