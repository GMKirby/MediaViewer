using MediaViewer.Models;

namespace MediaViewer.ViewModels
{
    public class MvvmLightViewModel : MyBaseViewModel
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get{return _welcomeTitle;}

            set{
                if (_welcomeTitle == value)
                    return;

                _welcomeTitle = value;
                RaisePropertyChanged();
            }
        }
        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Initializes a new instance of the Main_ViewModel class.
        /// </summary>
        public MvvmLightViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
        }
    }
}
