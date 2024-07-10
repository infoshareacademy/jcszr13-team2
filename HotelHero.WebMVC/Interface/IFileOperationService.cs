using HotelHero.WebMVC.Models;
using Newtonsoft.Json;

namespace HotelHero.WebMVC.Interface
{
    public interface IFileOperationService
    {
        void SerializeFile(List<User> users);
        List<User> DeserializeFile();
    }
}
