namespace Api.HealthMed.Model
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int IdHorarioDisponivel { get; set; }
        public bool Ativo { get; set; }
    }
}
