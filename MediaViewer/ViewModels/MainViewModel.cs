using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MediaViewer.Infrastructure.Helpers;
using CommonServiceLocator;

namespace MediaViewer.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    /// <remarks>
    /// I've sealed this class to prevent the CA2214 warning that will be shown
    /// because of of the call to the base "RaisePropertyChanged" otherwise.
    /// You can remove it to see the effects for yourself if you wish :) 
    /// (hint, nothing breaks)
    /// </remarks>>
    public sealed class MainViewModel : MyBaseViewModel
    {
        public MainViewModel()
        {
            // This will register our method with the Messenger class for incoming 
            // messages of type StatusMessage. So now we can send a StatusMessage from
            // any place in our application, it'l end up here, we'll update the string
            // we use to bind to our MainWindow status bar string, and wualla, magic
            // just happened.
            Messenger.Default.Register<StatusMessage>(this, msg => StatusBarMessage=msg.NewStatus);

            // This is how you can have some design time data
            if (IsInDesignMode)
            {
                StatusBarMessage = "Status in design";
            }
            else
            {
                StatusBarMessage = "Ready to rock and roll.";
            }
        }

        #region View Model Properties

        public RandomViewModel RandomVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RandomViewModel>();
            }
        }

        public MvvmLightViewModel MvvmLightVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MvvmLightViewModel>();
            }
        }

        public AboutViewModel AboutVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AboutViewModel>();
            }
        }

        public ValidationsConvertesViewModel ValAndConVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ValidationsConvertesViewModel>();
            }
        } 
        #endregion

        #region Properties
        /// <summary>
        /// Used to bind any incoming status messages, to the MainWindow status bar.
        /// </summary>
        public string StatusBarMessage
        {
            get { return _statusBarMessage; }
            set
            {
                if (value == _statusBarMessage) return;
                _statusBarMessage = value;
                RaisePropertyChanged();
            }
        }
        private string _statusBarMessage; 
        #endregion

        #region Refresh people command.

        /// <summary>
        /// This is in order to bind the command that we have in the MainWindow.
        /// The Command is always enabled (so the can execute just returns true),
        /// And it will send a message (that will be received by the Random View Model.
        /// </summary>
        public ICommand RefreshPeopleMenu_Command
        {
            get
            {
                return _refreshPeopleMenuCommand ??
                     (_refreshPeopleMenuCommand = new RelayCommand<string>(Execute_RefreshPeopleMenu, CanExecute_RefreshPeopleMenu));
            }
        }
        private ICommand _refreshPeopleMenuCommand;

        /// <summary>
        /// Can always exectue this
        /// </summary>
        private bool CanExecute_RefreshPeopleMenu(string aNumberAsString)
        {
            return true;
        }

        /// <summary>
        /// This will send the message when someone hits the command on the menu.
        /// </summary>
        /// <param name="aNumberAsString">In our case, hard codedd in the MenuItem paramater.
        /// You can easily bind it to anything you want.</param>
        private void Execute_RefreshPeopleMenu(string aNumberAsString)
        {
            var people_to_fetch = int.Parse(aNumberAsString);
            Messenger.Default.Send(new RefreshPeople(people_to_fetch));
        }

        #endregion

        public override void Cleanup()
        {
            // Clean up if needed

            base.Cleanup();
        }
    }
}