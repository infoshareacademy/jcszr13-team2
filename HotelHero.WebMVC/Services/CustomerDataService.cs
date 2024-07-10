using Newtonsoft.Json;
using HotelHero.WebMVC.Models;
using HotelHero.HotelsDatabase;
using HotelHero.UserPanel;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using HotelHero.WebMVC.Interface;

namespace HotelHero.WebMVC.Services
{
    public class CustomerDataService : ICustomerDataService
    {
        private Models.CustomerData customerData = new();

        public Models.CustomerData GetCustomerData()
        {
            try
            {
                var customerDataPath = PathMVC();
                var customerJson = File.ReadAllText(customerDataPath);
                customerData = JsonConvert.DeserializeObject<Models.CustomerData>(customerJson);
            }
            catch
            {
                customerData = new();
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
            var email = UserContext.GetUser().Email;
            var path = @$"{AppDomain.CurrentDomain.BaseDirectory}/../../../CustomerFiles/{email}.json";
            string newPath = path;
            if (path.Contains(".WebMVC"))
            {
                newPath = path.Replace(".WebMVC", "");
            }
            return newPath;
        }
    }
}