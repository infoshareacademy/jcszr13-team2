using HotelHero.WebMVC.Models;

namespace HotelHero.WebMVC.Interface
{
    public interface IAdminService
    {
        List<AdditionalService> GetAdditionalServicesList();
        void SaveAdditionalServicesList(List<AdditionalService> additionalServicesList);
        void SaveAdditionalServiceToList(AdditionalService additionalService);
        AdditionalService GetAdditionalService(int id);
    }
}
