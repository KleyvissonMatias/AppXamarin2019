using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using AppXamarinCEP.Service.Model;
using Newtonsoft.Json;

namespace AppXamarinCEP.Service
{
    public class ViaCEPService
    {
        private static string addressURL = @"https://viacep.com.br/ws/{0}/json/";

        public static Address searchAddressViaCEP(string cep)
        {
            string newAddressURL = string.Format(addressURL, cep);

            WebClient wc = new WebClient();
            string content = wc.DownloadString(newAddressURL);

            Address address = JsonConvert.DeserializeObject<Address>(content);

            if (address.cep == null)
            {
                return null;
            }

            return address;
        }
    }
}
