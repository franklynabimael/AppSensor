using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
namespace AppSensor.Views;

public partial class LoginView : ContentPage
{
    
    public LoginView()
    {
        InitializeComponent();
    }

    private async void OnAuthenticateButtonClicked(object sender, EventArgs e)
    {
        // Inicia la autenticaci�n biom�trica
        var request = new AuthenticationRequestConfiguration("Validacion por huella", "Esto es una prueba");
        var resul = await CrossFingerprint.Current.AuthenticateAsync(request);

        // Si la autenticaci�n es exitosa, redirige al usuario a la p�gina principal
        if (resul.Authenticated)
        {
            await DisplayAlert("Validacion Exitosa", "Presione Ok para continuar", "OK");
            // Redirige al usuario a la p�gina principal
            _ = Navigation.PushAsync(new HomePage());
        }
        else
        {
            await DisplayAlert("Validacion Fallida", "Huella no valida", "OK");
        }
    }

}