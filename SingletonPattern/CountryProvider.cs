using SingletonPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class CountryProvider
    {

        private static CountryProvider? _instance = null;
        public static CountryProvider Instance => _instance ??= new CountryProvider();
        private List<Country>? Countries { get; set; }

        private CountryProvider()
        {
            Task.Delay(2000).GetAwaiter().GetResult();
            Countries = new List<Country>()
                {
                    new Country() { Name = "Türkiye" },
                    new Country() { Name = "Azarbaycan" },
                    new Country() { Name = "Germany" },
                };
        }
        public async Task<List<Country>> GetCountries() => Countries;

    }
}
