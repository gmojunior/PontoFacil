using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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

            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Object settingsOk = localSettings.Values["SettingsOk"];
            if (settingsOk != null)
                FrameContent.Navigate(typeof(PlanningPage));
            else
                FrameContent.Navigate(typeof(SettingsPage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void MenuButtonHome_Click(object sender, RoutedEventArgs e)
        {
            //FrameContent.Navigate(typeof());
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
