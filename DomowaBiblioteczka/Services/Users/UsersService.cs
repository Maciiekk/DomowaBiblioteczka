using DomowaBiblioteczka.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace DomowaBiblioteczka.Services.Users
{

    [Authorize(Roles = "Admin")]
    public class UsersService : IUsersService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public UsersService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<ApplicationUser>> SelectAll(CancellationToken cancellationToken = default)
            => await SelectAllAsyncCallback(cancellationToken);

        public async Task<ApplicationUser> SelectById(string id, CancellationToken cancellationToken = default)
            => await SelectByIdAsyncCallback(id, cancellationToken);

        public async Task<IEnumerable<ApplicationUser>> SelectByEmail(string email)
            => await SelectByEmailAsyncCallback(email);


        private async Task<IEnumerable<ApplicationUser>> SelectAllAsyncCallback(CancellationToken cancellationToken)
        {
            using (var context = _contextFactory.CreateDbContext()) 
            {
                return await context.Users.ToListAsync(cancellationToken);
            }
        }
        private async Task<ApplicationUser> SelectByIdAsyncCallback(string id, CancellationToken cancellationToken)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Users.FirstOrDefaultAsync(u=>u.Id.Equals(id));
            }
        }
        private async Task<IEnumerable<ApplicationUser>> SelectByEmailAsyncCallback(string email)
        {
            throw new NotImplementedException();    //TODO: Implement
        }

    }
}
