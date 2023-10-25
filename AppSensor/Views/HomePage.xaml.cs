namespace AppSensor.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage.Navigation.PushAsync(new SpeedView());
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        App.Current.MainPage.Navigation.PushAsync(new AccelerometerView());
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        App.Current.MainPage.Navigation.PushAsync(new BarometerView());
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {
        App.Current.MainPage.Navigation.PushAsync(new CompassView());
    }

    private void Button_Clicked_4(object sender, EventArgs e)
    {
        App.Current.MainPage.Navigation.PushAsync(new ShakeView());
    }

    private void Button_Clicked_5(object sender, EventArgs e)
    {
        App.Current.MainPage.Navigation.PushAsync(new GyroscopeView());
    }

    private void Button_Clicked_6(object sender, EventArgs e)
    {
        App.Current.MainPage.Navigation.PushAsync(new MagnetometerView());
    }

    private void Button_Clicked_7(object sender, EventArgs e)
    {
        App.Current.MainPage.Navigation.PushAsync(new OrientationView());
    }

    private void Button_Clicked_8(object sender, EventArgs e)
    {
        App.Current.MainPage.Navigation.PushAsync(new LoginView());

    }


}
