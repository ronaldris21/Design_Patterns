

namespace ProxyXamarinP.Views
{
    using ProxyXamarinP.ViewModels;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewPage : ContentPage
	{
		public NewPage ()
		{
			InitializeComponent ();
            this.BindingContext = new NewPageViewModel();
		}
	}
}