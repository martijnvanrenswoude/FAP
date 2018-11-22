using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace FAP.Desktop.ViewModel
{
    public class RouteCalculationViewModel : ViewModelBase
    {
        /*
         * 
         * Variables
         * 
         */
        private string _key;

        /*
        * 
        * Properties
        * 
        */
        public List<Inspector> Inspectors { get { return this._inspectors; } }
        public Inspector SelectedInspector { get; set; }
        public string SelectedTransport { get; set; }
        public List<string> Transport { get; set; }
        public string TravelTime { get; set; }
        public ICommand Calculate { get; set; }
        
        /*
        * 
        * Constructor
        * 
        */
        public RouteCalculationViewModel()
        {
            Transport = new List<string> { "Auto", "Fiets" };
            Calculate = new RelayCommand(CalculateTravelTime);
        }

        /*
         * 
        * Methods
        * 
        */
        public void CalculateTravelTime()
        {

            var url = $"https://services.geodan.nl/routing/addressroute?from={SelectedInspector}&to={to}&networkType={vervoersmiddel}&servicekey={_key}";

            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(url).Result;
                dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(response);
                // Hier moet nog shit met die JSON gebeuren.
                TravelTime = ("De reistijd is " + "JSON int waarde" + "JSON tijdseenheid");
            }

        }

    }

}


