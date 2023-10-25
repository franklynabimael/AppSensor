namespace AppSensor.Views;

public partial class CompassView : ContentPage
{
	public CompassView()
	{
		InitializeComponent();
        ToggleCompass();

    }
    private void ToggleCompass()
    {
        if (Compass.Default.IsSupported)
        {
            if (!Compass.Default.IsMonitoring)
            {
                // Turn on compass
                Compass.Default.ReadingChanged += Compass_ReadingChanged;
                Compass.Default.Start(SensorSpeed.UI, applyLowPassFilter: true);
            }
            else
            {
                // Turn off compass
                Compass.Default.Stop();
                Compass.Default.ReadingChanged -= Compass_ReadingChanged;
            }



        }
    }

    private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
    {

        var Pcardinal = e.Reading.HeadingMagneticNorth;
        string nseo = "N";

        if ((Pcardinal >= 0) && (Pcardinal < 90))
        {
             nseo = "Norte";
        }else if ((Pcardinal >= 90) && (Pcardinal < 180))
        {
            nseo = "Este";
        }else if ((Pcardinal >= 180) && (Pcardinal < 270))
        {
            nseo = "Sur";
        }else if ((Pcardinal >= 270) && (Pcardinal<360))
        {
            nseo = "Oeste";
        }


        // Update UI Label with compass state
        CompassLabel.TextColor = Colors.DarkBlue;
        CompassLabel.Text = $"{nseo}: {Pcardinal:F2}";

        //programando Flechita

        Flechita.Rotation = Pcardinal *-1;

      
    }



}