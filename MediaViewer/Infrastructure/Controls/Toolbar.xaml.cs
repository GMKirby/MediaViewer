using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MediaViewer.Infrastructure.Controls
{
    public sealed partial class Toolbar : UserControl
    {

        public Toolbar()
        {
            InitializeComponent();
            (Content as FrameworkElement).DataContext = this;
        }

        public RelayCommand NavigateToMainPageCommand
        {
            get { return (RelayCommand)GetValue(NavigateToMainPageCommandProperty); }
            set { SetValueDp(NavigateToMainPageCommandProperty, value); }
        }
        public static readonly DependencyProperty NavigateToMainPageCommandProperty =
            DependencyProperty.Register("NavigateToMainPageCommand",
            typeof(RelayCommand),
            typeof(Toolbar),
            null);

        public RelayCommand NavigateToOptionsPageCommand
        {
            get { return (RelayCommand)GetValue(NavigateToOptionsPageCommandProperty); }
            set { SetValueDp(NavigateToOptionsPageCommandProperty, value); }
        }
        public static readonly DependencyProperty NavigateToOptionsPageCommandProperty =
            DependencyProperty.Register("NavigateToOptionsPageCommand",
            typeof(RelayCommand),
            typeof(Toolbar),
            null);

        #region Dependency Property Utils

        public event PropertyChangedEventHandler PropertyChanged;
        void SetValueDp(DependencyProperty property, object value, [System.Runtime.CompilerServices.CallerMemberName] string p = null)
        {
            SetValue(property, value);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }

        internal void RaisePropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion Dependency Property Utils
    }
}
