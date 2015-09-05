using System;
using System.Net;
using System.Runtime.Serialization.Json;
using GoogleApiRequest;
using GoogleEntities;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string addressNumber = "5900";
                string streetName = "Rivadavia";
                string cityName = "Buenos Aires";
                string countryName = "AR";

                GeocodeResponse googleResponse = GoogleConnector.MakeRequest(addressNumber, streetName, cityName.Replace(" ", "+"), countryName); // entry point, replace hard coded string with params
                ProcessResponse(googleResponse);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
            }

        }

        static public void ProcessResponse(GeocodeResponse googleResponse)
        {
            string Status = googleResponse.status;
            //googleResponse.results[0].types[0];
            Console.WriteLine(googleResponse.results[0].types[0]);
            Console.WriteLine(googleResponse.results[0].geometry.location.lat);
            Console.WriteLine(googleResponse.results[0].geometry.location.lng);
        }
    }
}


