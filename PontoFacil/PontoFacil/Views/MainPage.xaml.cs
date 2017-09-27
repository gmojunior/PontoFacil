using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PontoFacil.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void MenuButtonHome_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuButtonPlanning_Click(object sender, RoutedEventArgs e)
        {
            FrameContent.Navigate(typeof(PlanningPage));
        }

        private void MenuButtonHistory_Click(object sender, RoutedEventArgs e)
        {
            FrameContent.Navigate(typeof(HistoryPage));
        }

        private void MenuButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            FrameContent.Navigate(typeof(SettingsPage));
        }
    }
}
