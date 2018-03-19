using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCoinMon.Services
{
    public class QRCodeGetterAPI : IQRCodeGetterAPI
    {
        public async Task SendQRCode(string code)
        {
            var t = Task.Run(() =>
            {
                //Send QR code to the API.
                var sentCode = code;
            });

            await t;
        }
    }
}
