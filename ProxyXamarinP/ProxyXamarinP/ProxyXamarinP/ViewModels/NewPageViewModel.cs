
namespace ProxyXamarinP.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;
    using DLL.Models;
    using Acr.UserDialogs;
    using DLL.Patterns;

    public class NewPageViewModel : BaseViewModel
    {
        #region Atributos
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
            set { _nombre = value; OnPropertyChanged("Nombre"); OnPropertyChanged("Descripcion"); }
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
        public NewPageViewModel() { }
        #endregion



        #region Metodos

        public void AddNewPerson()
        {
            if (String.IsNullOrEmpty(this.Nombre))
            {
                UserDialogs.Instance.Toast(new ToastConfig("El nombre es requerido").SetPosition(ToastPosition.Top));
                return;
            }
            if (String.IsNullOrEmpty(this.Apellido))
            {
                UserDialogs.Instance.Toast(new ToastConfig("El Apellido es requerido").SetPosition(ToastPosition.Top));
                return;
            }
            if (String.IsNullOrEmpty(this.Direccion))
            {
                UserDialogs.Instance.Toast(new ToastConfig("La dirección es requerido").SetPosition(ToastPosition.Top));
                return;
            }
            if (Edad <= 0)
            {
                UserDialogs.Instance.Toast(new ToastConfig("La edad debe de ser mayor a 0").SetPosition(ToastPosition.Top));
                return;
            }
            if (Edad > 110)
            {
                UserDialogs.Instance.Toast(new ToastConfig("La edad debe de ser menor a 110").SetPosition(ToastPosition.Top));
                return;
            }
            Persona p = new Persona()
            {
                Nombre = this.Nombre,
                Apellido = this.Apellido,
                Edad = this.Edad,
                Direccion = this.Direccion,
            };

            var correcto = SingletonRepository.Instancia.Repository.ObjectOperation(p, Facade.Operacion.Save);
            if (!correcto)
            {
                UserDialogs.Instance.Toast(new ToastConfig("Error, no se agrego" + Nombre).SetBackgroundColor(Color.Red).SetPosition(ToastPosition.Top));
                return;
            }
                UserDialogs.Instance.Toast(new ToastConfig("Agregado con exito. "+ Nombre + " Fue almacenado").SetBackgroundColor(Color.Green).SetPosition(ToastPosition.Top));
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
        #endregion
    }
}
