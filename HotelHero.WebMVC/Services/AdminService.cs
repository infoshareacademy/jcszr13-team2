using HotelHero.HotelsDatabase;
using HotelHero.WebMVC.Interface;
using HotelHero.WebMVC.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HotelHero.WebMVC.Services
{
    public class AdminService : IAdminService
    {
        private readonly string _filePath = @$"{AppDomain.CurrentDomain.BaseDirectory}/../../../Data/AdditionalServices.json";
        //public AdminService()
        //{
        //    _additionalServices = new List<AdditionalService>()
        //        {
        //        new AdditionalService(1, "Safe", 30m),
        //        new AdditionalService(2, "Mini Bar", 150m),
        //        new AdditionalService(3, "Laundry", 60m),
        //        new AdditionalService(4, "SPA & Wellness", 210m),
        //        new AdditionalService(5, "Car Rent", 160m),
        //        new AdditionalService(6, "Airport transport", 70m),
        //        new AdditionalService(7, "Tour Guide", 130m),
        //        new AdditionalService(8, "Room Service", 110m)
        //        };
        //    var listJson = JsonConvert.SerializeObject(_additionalServices, Formatting.Indented);
        //    File.WriteAllText(_filePath, listJson);
        //}

        public List<AdditionalService> GetAdditionalServicesList()
        {
            List<AdditionalService>? additionalServices;

			if (File.Exists(_filePath))
            {
                var additionalServicesJson = File.ReadAllText(_filePath);
                additionalServices = JsonConvert.DeserializeObject<List<AdditionalService>>(additionalServicesJson);
            }
            else
            {
                additionalServices = new();
            }
            return additionalServices;
        }
        public void SaveAdditionalServicesList(List<AdditionalService> additionalServicesList)
        {
            var listJson = JsonConvert.SerializeObject(additionalServicesList, Formatting.Indented);
            File.WriteAllText(_filePath, listJson);
        }

        public void SaveAdditionalServiceToList(AdditionalService additionalService)
        {
            var list = GetAdditionalServicesList();
            list.Add(additionalService);
            var listJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(_filePath, listJson);
        }
        public AdditionalService GetAdditionalService(int id)
        {
            var list = GetAdditionalServicesList();
            var service = list.Find(x => x.Id == id);
            return service;
        }
    }
}
