

namespace ProxyXamarinP.Views
{
    using DLL.Models;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModifyDeletePage : ContentPage
    {
        public ModifyDeletePage(Persona selectP)
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.ModifyDeleteViewModel(selectP);
        }
    }
}