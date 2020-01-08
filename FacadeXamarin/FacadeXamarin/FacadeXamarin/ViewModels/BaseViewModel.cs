

namespace FacadeXamarin.ViewModels
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Metodos
        public event PropertyChangedEventHandler PropertyChanged;

        //Actualiza los cambios segun el caller detectado que sufrió un cambio
        protected virtual void OnPropertyChanged([CallerMemberName] string propertychange = "")
        {
            if (propertychange != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertychange));
            }
        }
        #endregion


    }
}
