


namespace FacadeXamarin.Views
{
    using FacadeXamarin.Models;
    using FacadeXamarin.ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModifyDeletePage : ContentPage
	{
        public ModifyDeletePage(Persona selectP)
        {
            InitializeComponent();
            this.BindingContext = new ModifyDeleteViewModel(selectP);
        }
    }
}