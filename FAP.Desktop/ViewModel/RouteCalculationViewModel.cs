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
        private string _key = "6c4c63db-de9a-11e8-8aac-005056805b87";
        private List<Inspector> inspectors;
        private List<Event> events;

        /*
        * 
        * Properties
        * 
        */
        public List<Inspector> Inspectors { get; set; }
        public Inspector SelectedInspector { get; set; }
        public Event SelectedEvent { get; set; }
        public List<Event> Events { get; set; }
        //Volgens mij niet nodig
    
        //public GenericRepository<Inspector> inspectorRepository;
        //public GenericRepository<Event> eventRepository;

            //-- eind of niet nodig, denk ik #martijn

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
            getAllFromDatabase();
        }

        /*
         * 
        * Methods
        * 
        */

            //this methods gets moved soemwhere else if it works, this is just for ease of use
        public void CalculateTravelTime()
        {

            //string from = SelectedInspector.postcode + SelectedInspector.house_number;
            //string to = //SelectedEvent.po + SelectedEvent.housenumber
            ////This method uses the GeoDan API to calculate based on postcodes
            //var url = $"https://services.geodan.nl/routing/addressroute?from={from}&to={to}&networkType={SelectedTransport}&servicekey={_key}";

            //using (var httpClient = new HttpClient())
            //{
            //    var response = httpClient.GetStringAsync(url).Result;
            //    dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(response);
            //    // Hier moet nog shit met die JSON gebeuren.
            //    TravelTime = ("De reistijd is " + "JSON int waarde" + "JSON tijdseenheid");
            //}

        }

        public void getAllFromDatabase()
        {
            using(var context = new FAPDatabaseEntities())
            {

                Events = context.Events.ToList();
                Inspectors = context.Inspectors.ToList();
            }
        }

    }

}


