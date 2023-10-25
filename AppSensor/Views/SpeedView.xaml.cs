namespace AppSensor.Views;

public partial class SpeedView : ContentPage
{
    public SpeedView()
    {
        InitializeComponent();
        ToggleAccelerometer();

    }
    public void ToggleAccelerometer()
    {
        if (Accelerometer.Default.IsSupported)
        {
            if (!Accelerometer.Default.IsMonitoring)
            {
                // Turn on accelerometer
                Accelerometer.Default.ReadingChanged += Accelerometer_ReadingChanged;
                Accelerometer.Default.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off accelerometer
                Accelerometer.Default.Stop();
                Accelerometer.Default.ReadingChanged -= Accelerometer_ReadingChanged;
            }

        }
  
    }
    private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {

        // Calcular aceleración en m/s^2
        var ax = e.Reading.Acceleration.X;
        var ay = e.Reading.Acceleration.Y;
        var az = e.Reading.Acceleration.Z;

        // Asumir aceleración constante para calcular velocidad
        const float elapsedTime = 1 / 60f; // 60 fps
        var vx = ax * elapsedTime;
        var vy = ay * elapsedTime;
        var vz = az * elapsedTime;

        // Convertir velocidad a km/h 
        var speedKmh = Math.Sqrt(vx * vx + vy * vy + vz * vz) * 3.6f;

        // Actualizar UI 
        labelSpeed.TextColor = Colors.DarkRed;
        labelSpeed.Text = $"Velocidad: {speedKmh:F1} km/h";
    }
}
