using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppXamarinCEP.Service.Model;
using AppXamarinCEP.Service;
using System.Text.RegularExpressions;

namespace AppXamarinCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTTON.Clicked += SearchCEP;
        }

        private void SearchCEP(object sender, EventArgs args)
        {
            Address address = new Address();

            string cep = Convert.ToString(CEP.Text.Trim());

            if (isValidCEP(cep))
            {
                try
                {
                    address = ViaCEPService.searchAddressViaCEP(cep);

                    if (address != null )
                    {
                        TEXTNAME.Text = string.Format("Endereço: {0}, {1}, {2}, {3}, {4}", address.logradouro, address.bairro, address.localidade, address.Complemento, address.uf);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "CEP não encontrado: "+cep, "OK");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO CRÍTICO", ex.Message, "OK");
                }
            }
        }

        private bool isValidCEP(string cep)
        {
            bool returnValue;

            if (!string.IsNullOrWhiteSpace(cep) && cep.Length == 8)
            {
                returnValue = true;
            }
            else
            {
                returnValue = false;
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter 8 dígitos", "OK");
            }

            Match match = Regex.Match(cep, @"([0-9])\w+");

            if (match.Success)
            {
                returnValue = true;
            }
            else
            {
                returnValue = false;
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter apenas números", "OK");
            }

            return returnValue;
        }
    }
}
