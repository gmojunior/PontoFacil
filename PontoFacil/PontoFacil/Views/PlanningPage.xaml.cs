using System;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PontoFacil.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlanningPage : Page
    {
        private DateTime accumulatedHoursValue = DateTime.MinValue;
        
        private String hoursToAdjustValue = "";

        private String NumberOfDaysValue = "";

        private DateTime startDayValue = DateTime.Now;

        public PlanningPage()
        {
            this.InitializeComponent();
        }

        public string AccumulatedHoursValue { get => accumulatedHoursValue.ToString("HH:mm"); set => accumulatedHoursValue = DateTime.MinValue; }
        public string StartDayValue { get => startDayValue.ToString("HH:mm"); set => startDayValue = DateTime.MinValue; }

        private void NumberTypeCheck(object sender, KeyRoutedEventArgs e)
        {
            e.Handled = ((uint)e.Key >= (uint)VirtualKey.Number0 && (uint)e.Key >= (uint)VirtualKey.Number9);
        }
    }
}