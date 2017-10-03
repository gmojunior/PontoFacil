using Prism.Windows.Mvvm;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PontoFacil.ViewModels
{
    public class StateViewModelBase : ViewModelBase
	{
		public const string REGISTER_IN_STATE = "RegisterIn";

        public const string REGISTER_OUT_STATE = "RegisterOut";

        public const string REGISTER_DISABLED = "RegisterDisabled";

        private Control visualStateObject;

		protected virtual void OnLoaded() { }

        public void SetupVisualState(object sender, RoutedEventArgs e)
        {
            if (sender != null)
                visualStateObject = (sender as Control);

            OnLoaded();
        }

        public bool GoToState(string state, bool useTransitions = true)
		{
			bool result = false;

			if (visualStateObject != null)
				result = VisualStateManager.GoToState(visualStateObject, state, false);

			return result;
		}
	}
}
