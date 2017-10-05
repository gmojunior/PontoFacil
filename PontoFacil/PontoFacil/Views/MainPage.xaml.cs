using PontoFacil.ViewModels;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PontoFacil.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public void SetContentFrame(Frame frame)
        {
            MySplitView.Content = frame;
        }

        public MainPageViewModel ViewModel { get { return (MainPageViewModel)this.DataContext; } }
    }
}
