using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MediaViewer.Models;

namespace MediaViewer.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }


            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MvvmLightViewModel>();
            SimpleIoc.Default.Register<RandomViewModel>();
            SimpleIoc.Default.Register<AboutViewModel>();
            SimpleIoc.Default.Register<ValidationsConvertesViewModel>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }


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

        public static void Cleanup()
        {
        }
    }
}
