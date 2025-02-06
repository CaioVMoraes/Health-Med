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
    }
}