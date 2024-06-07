using Newtonsoft.Json;
using HotelHero.WebMVC.Models;
using HotelHero.HotelsDatabase;
using HotelHero.UserPanel;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace HotelHero.WebMVC.Services
{
    public class CustomerDataService
    {
        private Models.CustomerData customerData = new();

        public Models.CustomerData GetCustomerData(string email)
        {
            customerData.Email = email;
            try
            {
                var customerDataPath = PathMVC();
                if (!File.Exists(customerDataPath))
                {
                    customerData = new Models.CustomerData();
                }
                var customerJson = File.ReadAllText(customerDataPath);
                customerData = JsonConvert.DeserializeObject<Models.CustomerData>(customerJson);
            }
            catch (Exception ex)
            {
                customerData = new Models.CustomerData();
            }
            return customerData;
        }
        public void Save(Models.CustomerData data)
        {
            customerData = data;
            var customerDataJson = JsonConvert.SerializeObject(customerData, Formatting.Indented);
            File.WriteAllText(PathMVC(), customerDataJson);
        }
        private string PathMVC()
        {
            var path = @$"{AppDomain.CurrentDomain.BaseDirectory}/../../../CustomerFiles/{customerData.Email}.json";
            string newPath = path;
            if (path.Contains(".WebMVC"))
            {
                newPath = path.Replace(".WebMVC", "");
            }
            return newPath;
        }
    }
}