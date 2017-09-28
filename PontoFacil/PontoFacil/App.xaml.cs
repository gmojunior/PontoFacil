﻿using PontoFacil;
using PontoFacil.Views;
using Prism.Unity.Windows;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PontoFacil
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : PrismUnityApplication
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        protected override UIElement CreateShell(Frame rootFrame)
        {
            var shell = Container.TryResolve<MainPage>();
            shell.SetContentFrame(rootFrame);
            return shell;
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Object settingsOk = localSettings.Values["SettingsOk"];
            if (settingsOk != null)
                NavigationService.Navigate(PageTokens.Planning, null);
            else
                NavigationService.Navigate(PageTokens.Settings, null);

            return Task.FromResult<object>(null);
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }
    }
}