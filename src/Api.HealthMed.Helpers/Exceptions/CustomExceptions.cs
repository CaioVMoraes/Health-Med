namespace Api.HealthMed.Helpers.Exceptions
{
    public static class CustomExceptions
    {
        //Não identificado!             
        public class MedicoNotFoundException() : Exception(message: $"Médico não identificado!");

        public class PacienteNotFoundException() : Exception(message: $"Paciente não identificado!");

        //Preencher!
        public class NomeVazioException() : Exception(message: $"Por favor, preencha o campo \"Nome\"!");

        public class EmailVazioException() : Exception(message: $"Por favor, preencha o campo \"E-mail\"!");

        public class CRMVazioException() : Exception(message: $"Por favor, preencha o campo \"CRM\"!");

        public class CPFVazioException() : Exception(message: $"Por favor, preencha o campo \"CPF\"!");

        public class SenhaVaziaException() : Exception(message: $"Por favor, preencha o campo \"Senha\"!");

        public class EspecializacaoVazioException() : Exception(message: $"Por favor, preencha o campo \"CPF\"!");
        public class IdMedicoVazioException() : Exception(message: $"Por favor, preencha o campo \"Médico Escolhido\"!");
        public class DataConsultaInvalidaException() : Exception(message: $"O campo \"Data\" é inválido!");

        public class SenhaIncorretaException() : Exception(message: $"A senha é incorreta!");

        //Inválido!
        public class InvalidIdException() : Exception(message: $"O ID utilizado é inválido!");

        public class EmailInvalidoException() : Exception(message: $"O e-mail é inválido!");

        public class CPFInvalidoException() : Exception(message: $"O CPF é inválido!");

        public class MedicoInvalidoException() : Exception(message: $"Os dados do médico estão inválidos!");
        public class PacienteInvalidoException() : Exception(message: $"Os dados do paciente estão inválidos!");
        public class ConsultaInvalidoException() : Exception(message: $"Os dados da consulta estão inválidos!");
    }
}
