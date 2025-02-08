# Health&Med

A API do Health&Med é um sistema para gerenciamento de consultas médicas, permitindo que médicos cadastrem seus horários e pacientes agendem consultas. O projeto segue a **Clean Architecture** e foi desenvolvido em **.NET 8**.

## Tecnologias Utilizadas
- **.NET 8**
- **SQL Server**
- **Swagger** (para documentação da API)
- **Bcript** (para reforçar a criptografia)

## Arquitetura do Projeto
O projeto segue a Clean Architecture, dividida nas seguintes camadas:

- **Application**: Contém os serviços e regras de negócio.
- **Crosscutting**: Helpers e injeção de dependências.
- **Domain**: Define entidades e configurações.
- **Infrastructure**: Implementação dos repositórios e acesso ao banco de dados.
- **Presentation**: Contém os controllers da API.

## Requisitos Funcionais Implementados
- [x] Autenticação do Médico
- [x] Cadastro e Edição de Horários Disponíveis
- [x] Aceite ou Recusa de Consultas Médicas
- [x] Autenticação do Paciente
- [x] Busca por Médicos
- [x] Agendamento de Consultas

## Configuração do Banco de Dados
Para conectar ao SQL Server, ajuste a **Connection String** no arquivo `appsettings.json`: Utilizando as tabelas salvas dentro do projeto na pasta **Requirements**


## Como Rodar o Projeto
1. **Clone o repositório**:
   ```sh
   git clone https://github.com/CaioVMoraes/Health-Med.git
   ```
2. **Navegue até o diretório do projeto**:
   ```sh
   cd HealthMed
   ```
3. **Execute a aplicação**:
   ```sh
   dotnet run
   ```
4. **Acesse o Swagger** para testar as APIs:
   - `https://localhost:5001/swagger`

## Pipeline de CI/CD
O projeto inclui um pipeline de CI/CD utilizando **GitHub Actions**. Ele realiza:
- Build e execução
- Deploy automatizado

## Aviso 
Este projeto foi desenvolvido como parte de um trabalho acadêmico na pós-graduação.

