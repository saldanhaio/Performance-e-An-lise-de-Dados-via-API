using CodeconChallenge.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CodeconChallenge.Helpers
{
    public static class DataLoader
    {
        private const string DataFilePath = "/home/samuel/Documentos/dev/dados-def/usuarios_1000json";
        public static List<User> LoadData()
        {
            // Ler o arquivo JSON e desserializa para uma lista de usuários
            var jsonData = File.ReadAllText(DataFilePath);
            var users = JsonConvert.DeserializeObject<List<User>>(jsonData);

            return users;
        }
    }
}
