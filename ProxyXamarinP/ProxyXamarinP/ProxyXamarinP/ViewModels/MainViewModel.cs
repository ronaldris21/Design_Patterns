using Acr.UserDialogs;
using DLL.Models;
using DLL.Patterns;
using GalaSoft.MvvmLight.Command;
using ProxyXamarinP.Classes;
using ProxyXamarinP.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProxyXamarinP.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Atributos
        private ObservableCollection<Persona> _Lpersonas;
        private bool _IsRefreshing;
        private Persona _PersonaSeleccionada;
        #endregion


        #region Propiedades
        public ObservableCollection<Persona> Lpersonas
        {
            get
            {
                return _Lpersonas;
            }
            set
            {
                if (_Lpersonas == value)
                {
                    return;
                }
                _Lpersonas = value;
                OnPropertyChanged("Lpersonas");
            }
        }
        public Persona PersonaSeleccionada
        {
            get { return _PersonaSeleccionada; }
            set
            {
                if (_PersonaSeleccionada!= value)
                {
                    _PersonaSeleccionada = value;
                    OnPropertyChanged("PersonaSeleccionada");
                    App.Current.MainPage.Navigation.PushAsync(new ModifyDeletePage(_PersonaSeleccionada));
                    _PersonaSeleccionada = null;
                }
            }
        }
        public bool IsRefreshing
        {
            get => _IsRefreshing;
            set
            {
                if (_IsRefreshing != value)
                {
                    _IsRefreshing = value;
                    OnPropertyChanged("IsRefreshing");
                }
            }
        }
        #endregion


        #region Constructor
        public MainViewModel()
        {
            IsRefreshing = true;
            Lpersonas = new ObservableCollection<Persona>();
            GetItemsData();
        }
        #endregion

        #region Commands
        public ICommand NewPerson { get { return new RelayCommand(NewPersonMethod); } }
        public ICommand RefreshingCommand { get { return new RelayCommand(GetItemsData); } }

        #endregion
        #region Metodos
        public void GetItemsData()
        {
            IRepository<Persona> datos = new ProxyRepository();
            var tempLista = new ObservableCollection<Persona>();
            datos.GetAll().ForEach(item => tempLista.Add(item));
            Lpersonas = tempLista;
            IsRefreshing = false;
        }
        public void NewPersonMethod()
        {
            
            App.Current.MainPage.Navigation.PushAsync(new Views.NewPage());
        }

        #endregion

    }
}
