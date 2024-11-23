using Microsoft.AspNetCore.Identity;

namespace DomowaBiblioteczka.Services.Roles
{
    public interface IRolesService
    {
        public Task<IEnumerable<IdentityRole>> SelectAllRoles();
    }
}
