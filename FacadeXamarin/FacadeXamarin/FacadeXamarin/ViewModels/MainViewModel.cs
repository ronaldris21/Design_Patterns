

namespace FacadeXamarin.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using FacadeXamarin.Models;
    using FacadeXamarin.Patterns;
    using FacadeXamarin.Services;
    using FacadeXamarin.Views;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;
    public class MainViewModel : BaseViewModel
    {
        #region Atributos
        private Persona _PersonaSeleccionada;

        #endregion


        #region Propiedades
        public Persona PersonaSeleccionada
        {
            get { return _PersonaSeleccionada; }
            set
            {
                if (_PersonaSeleccionada != value)
                {
                    _PersonaSeleccionada = value;//Segun el que selecciono de la lista
                    OnPropertyChanged("PersonaSeleccionada");
                    App.Current.MainPage.Navigation.PushAsync(new ModifyDeletePage(this.PersonaSeleccionada));
                    _PersonaSeleccionada = null; //Para que la lista no quere marcada
                }
            }
        }
        public ObservableCollection<Persona> Personas { get; set; }
        public ICommand NewPerson { get { return new RelayCommand(NewPage); } }
        #endregion


        #region Constructor
        public MainViewModel()
        {
            GetPeople();
        }
        #endregion



        #region Metodos
        public void GetPeople()
        {
            Personas = new ObservableCollection<Persona>(SingletonRepository.Instancia.Repository.GetAll());
        }

        private void NewPage()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewPage());
        }
        #endregion


    }
}
