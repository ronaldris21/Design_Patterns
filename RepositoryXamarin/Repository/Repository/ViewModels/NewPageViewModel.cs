
namespace Repository.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Repository.Models;
    using Repository.Patterns;
    using Repository.Services;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;
    public class NewPageViewModel : BaseViewModel
    {
        #region Atributos
        private DialogService _dialogservice;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private int _edad;
        private string _descripcion;
        #endregion

        #region Propiedades
        public ICommand Add { get { return new RelayCommand(AddNewPerson); } }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value;  OnPropertyChanged("Nombre"); OnPropertyChanged("Descripcion"); }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; OnPropertyChanged("Apellido"); }
        }
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; OnPropertyChanged("Direccion"); }
        }
        public int Edad
        {
            get { return _edad; }
            set { _edad = Convert.ToInt32(value); OnPropertyChanged("Edad"); }
        }
        public string Descripcion
        {
            get { return "El nombre es: " + this.Nombre; }
            set { _descripcion = value; OnPropertyChanged(); }
        }

        #endregion

        #region Contructor
        public NewPageViewModel()
        {
            this._dialogservice = new DialogService();
        }
        #endregion

        #region Metodos

        public async void AddNewPerson()
        {
            if (String.IsNullOrEmpty(this.Nombre))
            {
                await _dialogservice.Message("Error", "El nombre es requerido");return;
            }
            if (String.IsNullOrEmpty(this.Apellido))
            {
                await _dialogservice.Message("Error", "El Apellido es requerido"); return;
            }
            if (String.IsNullOrEmpty(this.Direccion))
            {
                await _dialogservice.Message("Error", "La dirección es requerido"); return;
            }
            if (Edad<=0)
            {
                await _dialogservice.Message("Error", "La edad debe de ser mayor a 0"); return;
            }
            if (Edad>110)
            {
                await _dialogservice.Message("Error", "La edad debe de ser menor a 110"); return;
            }
            Persona p = new Persona()
            {
                Nombre = this.Nombre,
                Apellido = this.Apellido,
                Edad = this.Edad,
                Direccion = this.Direccion,
            };

            var ob = SingletonRepository.Instancia.Repository.Save(p);
            if (!ob)
            {
                await _dialogservice.Message("Error","No se agrego" +Nombre);
                return;
            }
            await _dialogservice.Message("Agregado con exito", Nombre + " Fue almacenado");
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
        #endregion
    }
}
