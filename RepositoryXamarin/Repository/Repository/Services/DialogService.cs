
namespace Repository.Services
{
    using System.Threading.Tasks;
    public class DialogService
    {
        public async Task Message(string titulo, string sms)
        {
            await App.Current.MainPage.DisplayAlert(titulo, sms, "Aceptar");
        }

        public async Task<bool> Message(string titulo, string sms, string ok, string no)
        {
            var rs = await App.Current.MainPage.DisplayAlert(titulo, sms, ok, no);
            return rs;
        }

    }
}
