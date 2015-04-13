namespace $rootnamespace$.ViewModels
{
    public class FirstViewModel 
		: BaseViewModel
    {
		private string _hello = "Hello MvvmCross & Xamarin Forms";
        public string Hello
		{ 
			get { return _hello; }
			set { SetProperty(ref _hello, value, () => Hello); }
		}
    }
}
