using Feel.Service.LocalStorage;
using Feel.Shared.Dto.User;

namespace Feel.Service
{
    public class UserService(LocalDbService service)
    {
        private const string Key = "user";
        private static List<UserDto> DefaultFactory() => new();

        public async Task<UserDto?> GetUser()
        {
            return await service.GetFirstAsync<UserDto>(Key, DefaultFactory);
        }


        public async Task CreateNewUserAsync(UserDto user)
        {
            await service.CreateAsync<UserDto>(Key, DefaultFactory, user);
        }

        public async Task UpdateUserAsync(UserDto user)
        {

            await service.UpdateAsync<UserDto>(Key, DefaultFactory, user);
        }

        public async Task DeleteUserAsync()
        {
            await service.DeleteFirstAsync<UserDto>(Key, DefaultFactory);
        }
    }
}
