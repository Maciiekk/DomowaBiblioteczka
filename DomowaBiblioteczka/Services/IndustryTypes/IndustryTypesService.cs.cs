using DomowaBiblioteczka.Data;
using DomowaBiblioteczka.Data.Models;
using DomowaBiblioteczka.Services.Comon;

namespace DomowaBiblioteczka.Services.IndustryTypes
{
    public class IndustryTypesService : CRUDService<IndustryType, MediaDbContext>,IIndustryTypesService
    {
        public IndustryTypesService(MediaDbContext context) : base(context)
        {

        }
    }
}
