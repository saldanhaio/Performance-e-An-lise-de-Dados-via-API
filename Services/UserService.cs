using CodeconChallenge.Helpers;
using CodeconChallenge.Models;
using System.Collections.Generic;

namespace CodeconChallenge.Services
{
    public class UserService
    {
        private List<User> _users;

        public UserService()
        {
            // Carrega os dados do arquivo e armazena em memória
            _users = DataLoader.LoadData();
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        // Aqui você pode adicionar outros métodos para filtrar e manipular os dados
        public List<User> GetSuperUsers()
        {
            return _users.FindAll(user => user.Score >= 900 && user.Active);
        }

        public List<string> GetTopCountries()
        {
            var topCountries = new List<string>();
            
            // Agrupa os superusuários por país
            var countries = new Dictionary<string, int>();

            foreach (var user in GetSuperUsers())
            {
                if (countries.ContainsKey(user.Country))
                {
                    countries[user.Country]++;
                }
                else
                {
                    countries[user.Country] = 1;
                }
            }

            // Ordena os países por número de superusuários
            foreach (var country in countries.OrderByDescending(c => c.Value).Take(5))
            {
                topCountries.Add(country.Key);
            }

            return topCountries;
        }
    }
}
