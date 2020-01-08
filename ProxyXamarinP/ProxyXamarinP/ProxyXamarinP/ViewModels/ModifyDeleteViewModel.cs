namespace ProxyXamarinP.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using DLL.Models;
    using DLL.Patterns;
    using Acr.UserDialogs;

    public class ModifyDeleteViewModel : BaseViewModel
    {
        #region Atributos
        private Persona _Person, old;

        #endregion

        #region Propiedades
        public Persona Person
        {
            get { return _Person; }
            set
            {
                _Person = value;
                OnPropertyChanged("Person");
            }
        }

        public ICommand Delete { get { return new RelayCommand(DeleteMethod); } }
        public ICommand Edit { get { return new RelayCommand(EditMethod); } }


        #endregion


        #region Constructor
        public ModifyDeleteViewModel(Persona person)
        {
            _Person = person;
            old = person;
        }
        #endregion

        #region Metodos

        private void DeleteMethod()
        {

            if (SingletonRepository.Instancia.Repository.ObjectOperation(old, Facade.Operacion.Delete))
            {
                UserDialogs.Instance.Toast(new ToastConfig("Eliminado: " + this.Person.Nombre + " ha sido eliminado").SetBackgroundColor(Color.Red).SetPosition(ToastPosition.Top));
                App.Current.MainPage = new NavigationPage(new MainPage());
                return;
            }
            UserDialogs.Instance.Toast(new ToastConfig("Error, no se Elimino" + Person.Nombre).SetBackgroundColor(Color.Red).SetPosition(ToastPosition.Top));
        }
        private void EditMethod()
        {
            if (SingletonRepository.Instancia.Repository.ObjectOperation(Person, Facade.Operacion.Update))
            {
                UserDialogs.Instance.Toast(new ToastConfig("Modificado: " + this.Person.Nombre + " ha sido actualizado").SetBackgroundColor(Color.Blue).SetPosition(ToastPosition.Top));
                App.Current.MainPage = new NavigationPage(new MainPage());
                return;
            }
            UserDialogs.Instance.Toast(new ToastConfig("Error: No se Modifico" + old.Nombre).SetBackgroundColor(Color.Red).SetPosition(ToastPosition.Top));
        }


        #endregion

    }
}
