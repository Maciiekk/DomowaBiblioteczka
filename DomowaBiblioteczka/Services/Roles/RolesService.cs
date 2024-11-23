namespace DomowaBiblioteczka.Services.Roles
{
    using Microsoft.AspNetCore.Identity;

    public class RolesService : IRolesService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        public async Task<IEnumerable<IdentityRole>> SelectAllRoles()
        => await SelectAllRolesAsyncCallback();

        private async Task<IEnumerable<IdentityRole>> SelectAllRolesAsyncCallback()
        {
            return await Task.FromResult(_roleManager.Roles.ToList());
        }        

    }

}
