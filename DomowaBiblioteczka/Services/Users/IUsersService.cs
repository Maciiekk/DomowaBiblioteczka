using DomowaBiblioteczka.Data;

namespace DomowaBiblioteczka.Services.Users
{
    public interface IUsersService
    {
        public Task<IEnumerable<ApplicationUser>> SelectAll();

        public Task<ApplicationUser> SelectById(string id);

        public Task<IEnumerable<ApplicationUser>> SelectByEmail(string email);

        public Task<bool> DeleteUser(string id);

        public Task<ApplicationUser> UpdateUser(ApplicationUser updatedUser);
        
        public Task<bool> CreateUser(ApplicationUser updatedUser, string password);

        public Task<bool> UpdateRoles(string id, List<string> roles);
        public Task<IEnumerable<string>> SelectAllRolesByUser(string id);

        public  Task<bool> SetUserPassword(string userId, string newPassword);
    }
}
