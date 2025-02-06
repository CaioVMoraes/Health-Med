namespace Api.HealthMed.Model
{
    public class Medico
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string CPF { get; set; }
        public required string CRM { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
