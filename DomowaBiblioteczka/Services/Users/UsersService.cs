using DomowaBiblioteczka.Components.Account.Pages.Manage;
using DomowaBiblioteczka.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DomowaBiblioteczka.Services.Users
{

    [Authorize(Roles = "Admin")]
    public class UsersService : IUsersService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<ApplicationUser>> SelectAll()
            => await SelectAllAsyncCallback();

        public async Task<ApplicationUser> SelectById(string id)
            => await SelectByIdAsyncCallback(id);

        public async Task<IEnumerable<ApplicationUser>> SelectByEmail(string email)
            => await SelectByEmailAsyncCallback(email);

        public async Task<bool> DeleteUser(string id)
            => await DeleteAsyncCallback(id);

        public async Task<ApplicationUser> UpdateUser(ApplicationUser updatedUser)
            => await UpdateUserAsyncCallback(updatedUser);

        public async Task<bool> CreateUser(ApplicationUser createdUser, string password)
            => await CreateUserAsyncCallback(createdUser, password);

        public async Task<bool> SetUserPassword(string userId, string newPassword)
            => await SetPasswordAsyncCallback(userId,newPassword);

        public async Task<bool> UpdateRoles(string id, List<string> roles)
            => await UpdateRolesAsyncCallback(id, roles);

        public async Task<IEnumerable<string>> SelectAllRolesByUser(string id)
            => await SelectAllRolesByUserAsyncCallback(id);

        private async Task<IEnumerable<ApplicationUser>> SelectAllAsyncCallback( )
        {
                return await _userManager.Users.ToListAsync();
        }

        private async Task<ApplicationUser> SelectByIdAsyncCallback(string id)
        {
                return await _userManager.FindByIdAsync(id);
        }        
        
        
        private async Task<IEnumerable<string>> SelectAllRolesByUserAsyncCallback(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            // TODO: add some conditions
            var roles = await _userManager.GetRolesAsync(user);
            
            return roles.AsEnumerable();
        }

        private async Task<bool> UpdateRolesAsyncCallback(string id, List<string> updatedRoles)
        {
            bool succeeded = true;
            try
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user == null)
                {
                    return false;
                }

                var roles = await _userManager.GetRolesAsync(user);

                var rolesToAdd = updatedRoles.Except(roles).ToList();

                var rolesToRemove = roles.Except(roles).ToList();

                if(rolesToRemove.Any())
                {
                    var removeResult = _userManager.RemoveFromRolesAsync(user, rolesToRemove);
                    succeeded = succeeded && removeResult.IsCompletedSuccessfully;
                }

                if (rolesToAdd.Any())
                {
                    var addResult = _userManager.AddToRolesAsync(user, rolesToAdd);
                    succeeded = succeeded && addResult.IsCompletedSuccessfully;
                }

                return succeeded;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

        private async Task<IEnumerable<ApplicationUser>> SelectByEmailAsyncCallback(string email)
        {
            throw new NotImplementedException();    //TODO: Implement
        }

        private async Task<bool> DeleteAsyncCallback(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
    
                if (user != null) 
                { 
                    var result = await _userManager.DeleteAsync(user);

                    return result.Succeeded;
                }          
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            return false;
        }

        private async Task<ApplicationUser> UpdateUserAsyncCallback(ApplicationUser updatedUser)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(updatedUser.Id);

                if (user != null)
                {
                    user.UserName = updatedUser.UserName;
                    user.Email = updatedUser.Email;

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return user; 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        private async Task<bool> CreateUserAsyncCallback(ApplicationUser newUser, string password)
        {
            var result = await _userManager.CreateAsync(newUser, password);

            return (result.Succeeded);           
        }        
        private async Task<bool> SetPasswordAsyncCallback(string id, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(id);

            if(user != null) 
            {
                var removePasswordResult = await _userManager.RemovePasswordAsync(user);

                if(removePasswordResult.Succeeded)
                {
                   var newPasswordResult = await _userManager.AddPasswordAsync(user, newPassword);
                    
                    return (newPasswordResult.Succeeded);
                }
            }

            return false;
        }
    }
}
