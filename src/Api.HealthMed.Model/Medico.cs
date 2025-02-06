namespace Api.HealthMed.Model
{
    public class Medico
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? CRM { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
