using PontoFacil.ViewModels;
using Windows.UI.Xaml.Controls;

namespace PontoFacil.Views
{
    public sealed partial class PlanningPage : Page
    {
        public PlanningPage()
        {
            this.InitializeComponent();
        }

        public PlanningPageViewModel ViewModel { get { return (PlanningPageViewModel)this.DataContext; } }
   }
}