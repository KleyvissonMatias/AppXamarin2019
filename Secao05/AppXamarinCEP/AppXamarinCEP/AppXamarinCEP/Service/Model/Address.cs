using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarinCEP.Service.Model
{
    public class Address
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string Complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string unidade { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }

    }
}
