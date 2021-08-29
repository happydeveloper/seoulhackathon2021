using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Net.Http;



namespace BeakerTracker
{
    public partial class Scene1Page : View
    {
        public Scene1Page()
        {
            InitializeComponent();
        }

        private void Gps_Clicked(object sender, ClickedEventArgs e)
        {
            GPSI2C gpsI2c = new GPSI2C();
            using (gpsI2c)
            {
                rstSensor.Text = gpsI2c.set_start();
            }
        }


        private void FFT_Clicked(object sender, ClickedEventArgs e)
        {
            using (HeartFFT heartFFT = new HeartFFT()){
                rstSensor.Text = heartFFT.mocking() + "/m";
            }
        }
       
    }
}
