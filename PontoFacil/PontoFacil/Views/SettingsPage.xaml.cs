using PontoFacil.ViewModels;
using Windows.UI.Xaml.Controls;

namespace PontoFacil.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }

        public SettingsPageViewModel ViewModel { get { return (SettingsPageViewModel)DataContext; } }
    }
}
