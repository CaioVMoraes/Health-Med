using Api.HealthMed.Domain;
using System.Text.RegularExpressions;
using static Api.HealthMed.Helpers.Exceptions.CustomExceptions;

namespace Api.HealthMed.Helpers
{
    public static class Validations
    {
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

        public static bool ValidarEmail(string email)
        {
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }

        public static void ValidarMedico(Medico medico)
        {
            if (medico is null)
                throw new MedicoInvalidoException();

            if (string.IsNullOrWhiteSpace(medico.Nome))
                throw new NomeVazioException();

            if (string.IsNullOrWhiteSpace(medico.CPF))
                throw new CPFVazioException();

            if (string.IsNullOrWhiteSpace(medico.CRM))
                throw new CRMVazioException();

            if (string.IsNullOrWhiteSpace(medico.Email))
                throw new EmailVazioException();

            if (string.IsNullOrWhiteSpace(medico.Senha))
                throw new SenhaVaziaException();

            if (string.IsNullOrWhiteSpace(medico.Especializacao))
                throw new EspecializacaoVazioException();
        }

        public static void ValidarPaciente(Paciente paciente)
        {
            if (paciente is null)
                throw new PacienteInvalidoException();

            if (string.IsNullOrWhiteSpace(paciente.Nome))
                throw new NomeVazioException();

            if (string.IsNullOrWhiteSpace(paciente.CPF))
                throw new CPFVazioException();

            if (string.IsNullOrWhiteSpace(paciente.Email))
                throw new EmailVazioException();

            if (string.IsNullOrWhiteSpace(paciente.Senha))
                throw new SenhaVaziaException();

        }

        public static void ValidarConsulta(ConsultaDisponivel consulta)
        {
            if (consulta is null)
                throw new ConsultaInvalidoException();

            if (consulta.IdMedico <= 0)
                throw new IdMedicoVazioException();

            DateTime dataMinima = DateTime.Now;
            DateTime dataMaxima = DateTime.Now.AddYears(1);

            if (!DateHelper.ValidarData(consulta.DataHora, dataMinima, dataMaxima))
                throw new DataConsultaInvalidaException();
        }

        public static void ValidarAgendamento(Agendamento agendamento)
        {
            if (agendamento is null)
                throw new AgendamentoInvalidoException();

            if (agendamento.IdPaciente <= 0)
                throw new PacienteVazioException();

            if (agendamento.IdMedico <= 0)
                throw new MedicoVazioException();

            if (agendamento.IdConsulta <= 0)
                throw new HorarioConsultaInvalidoException();

            if (agendamento.PacienteCancelou && string.IsNullOrEmpty(agendamento.JustifcativaCancelamento))
                throw new JustificativaCancelouAgendamentoVaziaException();
        }
    }
}
