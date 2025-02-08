namespace Api.HealthMed.Helpers
{
    public static class DateHelper
    {
        public static bool ValidarData(DateTime data, DateTime? dataMinima = null, DateTime? dataMaxima = null)
        {
            // Verifica se a data é menor que a data mínima permitida
            if (dataMinima.HasValue && data < dataMinima.Value)
            {
                return false;
            }

            // Verifica se a data é maior que a data máxima permitida
            if (dataMaxima.HasValue && data > dataMaxima.Value)
            {
                return false;
            }

            // Se passou por todas as validações, a data é válida
            return true;
        }
    }
}