using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidadorDeSenha
{
    public class Validador
    {
        public List<string> Valida(string password)
        {
            var erros = new List<string>();
            if (password.Length < 8)
                erros.Add("A deve ter no mínimo 8 caracteres");

            if (!password.Any(char.IsUpper))
                erros.Add("A senha deve conter pelo menos uma letra maiúscula");

            if (!password.Any(char.IsLower))
                erros.Add("A senha deve conter pelo menos uma letra minúscula");

            if (!password.Any(char.IsNumber))
                erros.Add("A senha deve conter pelo menos um número");

            return erros;

        }
    
    
    }
}