using DomowaBiblioteczka.Data;

namespace DomowaBiblioteczka.Services.Users
{
    public interface IUsersService
    {
        public Task<IEnumerable<ApplicationUser>> SelectAll(CancellationToken cancellationToken);

        public Task<ApplicationUser> SelectById(string id, CancellationToken cancellationToken);

        public Task<IEnumerable<ApplicationUser>> SelectByEmail(string email);
    }
}
