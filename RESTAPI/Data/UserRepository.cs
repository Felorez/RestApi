using RestApi.Models;
using System.Reflection;
using System.Text.Json;
using static RestApi.Models.UserModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestApi.Data
{
    public class UserRepository
    {
        private List<UserModel> _users;
        public JsonDatabaseService databaseService = new("Data/Database");
        public UserRepository() 
        {
            _users = databaseService.LoadData<List<UserModel>>("users.json");
        }

        public List<UserModel> GetUsers()
        {
            return _users;
        }

        public UserModel? GetUser(int userId) {
            var user = _users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        } 

        public void AddUser(UserModel user)
        {
            user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;

            _users.Add(user);

            databaseService.SaveData("users.json", _users);
        }

        public string? UpdateUser(int userId, UserModel userUpdater)
        {
            int index = _users.FindIndex(u => u.Id == userId);

            if (index != -1)
            {
                _users[index] = userUpdater;
            }
            else
            {
                return null;
            }

            if (userUpdater.Id is null)
            {
                userUpdater.Id = userId;
            }

            databaseService.SaveData("users.json", _users);

            return "Succefully";
        }

        public string? DeleteUser(int userId)
        {
            int index = _users.FindIndex(u => u.Id == userId);

            if (index != -1)
            {
                _users.Remove(_users[index]);
            }
            else
            {
                return null;
            }

            databaseService.SaveData("users.json", _users);

            return "Succefully";
        }
    }
}
