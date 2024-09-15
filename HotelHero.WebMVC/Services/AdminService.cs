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
            var newAdditionalService = new AdditionalService(GetNewAdditionalServicesId(), additionalService.Name, additionalService.Cost);
            var list = GetAdditionalServicesList();
            list.Add(newAdditionalService);
            var listJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(_filePath, listJson);
        }
        public AdditionalService GetAdditionalService(int id)
        {
            var list = GetAdditionalServicesList();
            var service = list.Find(x => x.Id == id);
            return service;
        }
        public void EditAdditionalService(AdditionalService additionalService)
        {
            var list = GetAdditionalServicesList();
            var additionalServiceIndex = list.FindIndex(x => x.Id == additionalService.Id);
            list[additionalServiceIndex] = additionalService;
            SaveAdditionalServicesList(list);
        }
        public void DeleteAdditionalService(int id)
        {
            var list = GetAdditionalServicesList();
            var additionalService = list.Find(x => x.Id == id);
            list.Remove(additionalService);
            SaveAdditionalServicesList(list);
        }
        private int GetNewAdditionalServicesId()
        {
            var id = GetAdditionalServicesList().Last().Id + 1;
            return id;
        }
    }
}
