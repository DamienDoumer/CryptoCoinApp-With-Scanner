using CryptoCoinMon.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCoinMon.Services
{
    public interface ICryptoDataService
    {
        Task<List<CryptoCurrency>> GetCryptoCurrenciesInDollars();
    }
}
