using DomowaBiblioteczka.Data;
using DomowaBiblioteczka.Data.Models;
using DomowaBiblioteczka.Services.Comon;

namespace DomowaBiblioteczka.Services.Units
{
    public class UnitsService : CRUDService<Unit, MediaDbContext>, IUnitsService
    {
        public UnitsService (MediaDbContext context) : base(context)
        {

        }
    }
}
