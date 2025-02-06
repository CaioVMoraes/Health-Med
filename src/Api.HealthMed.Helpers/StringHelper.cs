using System.Text.RegularExpressions;
using static BCrypt.Net.BCrypt;

namespace Api.HealthMed.Helpers
{
    public static class StringHelper
    {
        private const int WorkFactor = 12;

        public static string Criptografar(string text)
        {
            return HashPassword(text, WorkFactor);
        }

        public static bool ValidarCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf)) return false;

            // Remove caracteres não numéricos
            cpf = Regex.Replace(cpf, "[^0-9]", "");

            // CPF precisa ter 11 dígitos
            if (cpf.Length != 11) return false;

            // CPF com todos os números iguais é inválido
            if (new string(cpf[0], 11) == cpf) return false;

            // Calcula os dígitos verificadores
            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            // Calcula primeiro dígito
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            int primeiroDigito = resto < 2 ? 0 : 11 - resto;

            tempCpf += primeiroDigito;
            soma = 0;

            // Calcula segundo dígito
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            int segundoDigito = resto < 2 ? 0 : 11 - resto;

            // Verifica se os dígitos calculados são iguais aos do CPF informado
            return cpf.EndsWith(primeiroDigito.ToString() + segundoDigito.ToString());
        }
    }
}