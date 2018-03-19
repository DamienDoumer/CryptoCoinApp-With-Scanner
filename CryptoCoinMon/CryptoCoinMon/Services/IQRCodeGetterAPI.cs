using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCoinMon.Services
{
    public interface IQRCodeGetterAPI
    {
        Task SendQRCode(string code);
    }
}
