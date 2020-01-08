using Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Repository
{
    public partial class MainPage : ContentPage
    {
        MainViewModel viewmodel = new MainViewModel();
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = viewmodel;

        }


    }
}
