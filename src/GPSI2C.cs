using System;
using Tizen.Peripheral.I2c;


namespace BeakerTracker
{
    class GPSI2C : IDisposable
    {
        private const int Bus = 0x01;
        private const int Address = 0x08; 

        private I2cDevice i2cDevice;
        private bool disposedValue;

        public GPSI2C()
        {
            // Open device
            i2cDevice = new I2cDevice(Bus, Address);
        }

        private void write()
        {
            try
            {
                byte[] val = new byte[2];
                val[0] = 0x00;
                val[1] = 0x01;

                i2cDevice.Write(val);
            }
            catch (Exception e)
            {
                i2cDevice.Close();
                Console.WriteLine(e.Message);
            }
        }

        //gps uart -> ardino i2c -> write i2c
        public string set_start()
        {
            try
            {
                byte[] val = new byte[2];
                val[0] = 0x00;
                val[1] = 0x01;

                i2cDevice.Write(val); // io error occure!
                return val.ToString(); 
            } catch (Exception e) {
                i2cDevice.Close();
                return "GPS WRONG";
            }
        }

        public string get_seq(byte reg)
        {
            try{
                ushort gpsdata = i2cDevice.ReadRegisterWord(reg);
                return gpsdata.ToString();
            } catch (Exception e) {
                i2cDevice.Close();
                return "GPS WRONG";
            }
        }

        public void disconnect()
        {
            i2cDevice.Close();
        }

        ~GPSI2C()
        {
            disconnect();
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
        // ~GPSI2C()
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
