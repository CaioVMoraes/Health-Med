namespace Api.HealthMed.Model
{
    public class HorarioDisponivel
    {
        public int Id { get; set; }
        public int IdMedico { get; set; }
        public DateTime DataHora { get; set; }
        public bool Ativo { get; set; }
    }
}
