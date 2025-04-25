using System;
using System.Collections.Generic;
using CodeconChallenge.Model;

namespace CodeconChallenge.Models
{
    public class User
    {
        public Guid Id { get; set; } // Identificador único
        public string Name { get; set; } // Nome do usuário
        public int Age { get; set; } // Idade
        public int Score { get; set; } // Pontuação
        public bool Active { get; set; } // Se o usuário está ativo
        public string? Country { get; set; } // País
        public Team Team { get; set; } // Time ao qual pertence
        public List<Log> Logs { get; set; } = new List<Log>(); // Logs de login/logout
    }
}
