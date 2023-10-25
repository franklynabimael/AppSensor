using System.Security.Cryptography.X509Certificates;

namespace AppSensor.Views;

public partial class BarometerView : ContentPage
{
    public BarometerView()
    {
        InitializeComponent();


    }
    public async void ToggleBarometer()
    {
        if (Barometer.Default.IsSupported)
        {
            
            if (!Barometer.Default.IsMonitoring)
            {
                // Turn on barometer
                Barometer.Default.ReadingChanged += Barometer_ReadingChanged;
                Barometer.Default.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off barometer
                Barometer.Default.Stop();
                Barometer.Default.ReadingChanged -= Barometer_ReadingChanged;
            }
        }
        else
        {
            await DisplayAlert("Mensaje", "No soportado", "ok");
        }
    }

    private void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
    {
        // Update UI Label with barometer state
        BarometerLabel.TextColor = Colors.DarkBlue;
        BarometerLabel.TextTransform = TextTransform.Uppercase;
        BarometerLabel.Text = $"Barometer: {e.Reading}";
    }


    private  void s1_Toggled(object sender, ToggledEventArgs e)
    {
        bool a = e.Value;
        if (a == true)
        {
            ToggleBarometer();
        }

    }
}
