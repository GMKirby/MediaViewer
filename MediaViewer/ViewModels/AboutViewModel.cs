namespace MediaViewer.ViewModels
{
	public class AboutViewModel : MyBaseViewModel
	{
		public AboutViewModel()
		{
            Hello = "Hi guys, I hope you'll enjoy this MVVM template solution";
		}

		public string Hello { get; private set; }
	}
}
