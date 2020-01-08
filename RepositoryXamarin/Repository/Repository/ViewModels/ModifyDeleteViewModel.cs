

namespace Repository.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Repository.Models;
    using Repository.Patterns;
    using Repository.Services;
    using System.Windows.Input;
    using Xamarin.Forms;
    public class ModifyDeleteViewModel : BaseViewModel
    {
        #region Atributos
        private Persona _Person, old;
        private DialogService _Dialog;

        #endregion

        #region Propiedades
        public Persona Person { get { return _Person; }
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
            if (SingletonRepository.Instancia.Repository.Delete(this.old))
            {
                await _Dialog.Message("Eliminado", this.Person.Nombre + " ha sido eliminado");
                App.Current.MainPage = new NavigationPage(new MainPage());
                return;
            }
            await _Dialog.Message("Error", "No se Elimino" + Person.Nombre);
        }
        private async void EditMethod()
        {
            if (SingletonRepository.Instancia.Repository.Update(old,this.Person))
            {
                await _Dialog.Message("Modificado", this.old.Nombre + " ha sido actualizado");
                App.Current.MainPage = new NavigationPage(new MainPage());
                return;
            }
            await _Dialog.Message("Error", "No se Modifico" + old.Nombre);
        }


        #endregion

    }
}
