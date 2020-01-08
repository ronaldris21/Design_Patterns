

namespace Repository.Views
{
    using Repository.Models;
    using Repository.ViewModels;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModifyDeletePage : ContentPage
	{
		public ModifyDeletePage (Persona selectP)
		{
			InitializeComponent ();
            this.BindingContext = new ModifyDeleteViewModel(selectP);
		}
	}
}