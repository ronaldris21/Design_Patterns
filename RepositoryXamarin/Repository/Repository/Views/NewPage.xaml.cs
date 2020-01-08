using Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repository.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewPage : ContentPage
	{
        NewPageViewModel viewmodel = new NewPageViewModel();
		public NewPage ()
		{
			InitializeComponent ();
            BindingContext = viewmodel;
		}



    }
}