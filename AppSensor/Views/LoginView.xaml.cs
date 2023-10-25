using Plugin.Fingerprint.Abstractions;
namespace AppSensor.Views;

public partial class LoginView : ContentPage
{
    private readonly IFingerprint fingerprint;
    public LoginView()
    {
        InitializeComponent();
    }

    private async void OnAuthenticateButtonClicked(object sender, EventArgs e)
    {
        // Inicia la autenticación biométrica
        var huella = new AuthenticationRequestConfiguration("Validacion por huella", "Esto es una prueba");
        var biopass = await fingerprint.AuthenticateAsync(huella);

        // Si la autenticación es exitosa, redirige al usuario a la página principal
        if (biopass.Authenticated)
        {
            await DisplayAlert("Validacion Exitosa", "Presione Ok para continuar", "OK");
            // Redirige al usuario a la página principal
            _ = Navigation.PushAsync(new HomePage());
        }
        else
        {
            await DisplayAlert("Validacion Fallida", "Huella no valida", "OK");
        }
    }

}