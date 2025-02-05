using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorUserManagement.Models;

namespace BlazorUserManagement.Services
{
    public class UserService
    {
        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> RegisterUserAsync(RegisterUserDto userDto)
        {
            var response = await _http.PostAsJsonAsync("users/register", userDto);
            return response.IsSuccessStatusCode;
        }

        //public async Task<UserDto> LoginAsync(LoginDto loginDto)
        //{
        //    var response = await _http.PostAsJsonAsync("users/login", loginDto);
        //    if (response.IsSuccessStatusCode)
        //        return await response.Content.ReadFromJsonAsync<UserDto>();
        //    return null;
        //}
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var response = await _http.PostAsJsonAsync("users/login", loginDto);

            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<UserDto>();

                // Здесь можно обработать приветственное сообщение, которое вернуло API
                if (user.Role == "User")
                {
                    // Если это обычный пользователь, вы можете вернуть сообщение как часть ответа.
                    // Например, просто вывести его в консоль или каким-либо образом отобразить.
                    Console.WriteLine($"Привет, дорогой {user.Name}!");
                }

                return user;
            }

            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Ошибка входа: {error}");
        }


        public async Task<List<UserDto>> GetUsersAsync()
        {
            return await _http.GetFromJsonAsync<List<UserDto>>("users/all");
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var response = await _http.DeleteAsync($"users/{id}");
            return response.IsSuccessStatusCode;
        }

    }
}
