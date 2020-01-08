
namespace FacadeXamarin.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using FacadeXamarin.Models;
    using FacadeXamarin.Patterns;
    using FacadeXamarin.Services;
    using System.Windows.Input;
    using Xamarin.Forms;
    public class ModifyDeleteViewModel : BaseViewModel
    {
        #region Atributos
        private Persona _Person, old;
        private DialogService _Dialog;

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
            _Dialog = new DialogService();
        }
        #endregion

        #region Metodos

        private async void DeleteMethod()
        {
            if (SingletonRepository.Instancia.Repository.ObjectOperation(old,Facade.Operacion.Delete))
            {
                await _Dialog.Message("Eliminado", this.Person.Nombre + " ha sido eliminado");
                App.Current.MainPage = new NavigationPage(new MainPage());
                return;
            }
            await _Dialog.Message("Error", "No se Elimino" + Person.Nombre);
        }
        private async void EditMethod()
        {
            if (SingletonRepository.Instancia.Repository.ObjectOperation(Person, Facade.Operacion.Update))
            {
                await _Dialog.Message("Modificado", this.Person.Nombre + " ha sido actualizado");
                App.Current.MainPage = new NavigationPage(new MainPage());
                return;
            }
            await _Dialog.Message("Error", "No se Modifico" + old.Nombre);
        }


        #endregion

    }
}
