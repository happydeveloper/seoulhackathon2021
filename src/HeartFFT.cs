using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeakerTracker
{
    class HeartFFT : IDisposable
    {
        private WaveFormat format;
        private short[] samples;
        short[] a = new short[256];
        private static int fftPoint = 512;
        private int framelen = 512;
        private float[] A; //amplitude (in decibel), each array stores 512 data (1 frame 232,2 ms)
        private string filename = "";
        private int nbframe = 0;
        private FIRFilters firFilter;
        private int comparedFrame = 0;
        private string missData = "";
        private const int MAX_PROGRESS = 500;

        private WaveControl wc2 { set; get; }


        private bool disposedValue;
        public double[] FFT(double[] data)
        {
            double[] fft = new double[data.Length];
            System.Numerics.Complex[] fftComplex = new System.Numerics.Complex[data.Length];
            for (int i = 0; i < data.Length; i++)
                fftComplex[i] = new System.Numerics.Complex(data[i], 0.0);
            for (int i = 0; i < data.Length; i++)
                fft[i] = fftComplex[i].Magnitude;
            return fft;
        }

        //mocking fails anaynis
        public string mocking()
        {
            Random rnd = new Random();
            int v = rnd.Next(60, 180);
            wavefileread();
            return v.ToString();
        }

        private void wavefileread()
        {
            double[] data;
            byte[] wave;


            try
            {
                wc2 = new WaveControl();
               //
                System.IO.FileStream WaveFile = System.IO.File.OpenRead(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "heartbeat-01a.wav");
            }
            catch (Exception e)
            {
                Dispose();
            }
        }


        ~HeartFFT()
        {
            Dispose();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                disposedValue = true;
            }
        }

        // // TODO: 비관리형 리소스를 해제하는 코드가 'Dispose(bool disposing)'에 포함된 경우에만 종료자를 재정의합니다.
        // ~HeartFFT()
        // {
        //     // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
