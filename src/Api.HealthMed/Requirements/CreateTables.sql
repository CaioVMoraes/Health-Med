CREATE TABLE Paciente (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    CPF NVARCHAR(11) NOT NULL UNIQUE,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Senha NVARCHAR(255) NOT NULL,
    DataCadastro DATETIME NOT NULL,
    Ativo BIT
);
 
CREATE TABLE Medico (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    CPF NVARCHAR(11) NOT NULL UNIQUE,
    CRM NVARCHAR(20) NOT NULL UNIQUE,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Senha NVARCHAR(255) NOT NULL,
    Especializacao NVARCHAR(50) NOT NULL,
    DataCadastro DATETIME NOT NULL,
    Ativo BIT
);
 
CREATE TABLE ConsultaDisponivel (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdMedico INT NOT NULL,
    DataHora DATETIME NOT NULL,
    Disponivel BIT DEFAULT 1,
    ValorConsulta MONEY NOT NULL,
	DataCadastro DATETIME NOT NULL,
	DataAtualizacao DATETIME,
    FOREIGN KEY (IdMedico) REFERENCES Medico(Id)
);
 
CREATE TABLE Agendamento (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdPaciente INT NOT NULL,
    IdMedico INT NOT NULL,
    IdConsulta INT NOT NULL,   
    MedicoAceitou BIT NOT NULL DEFAULT 0,
    MedicoRecusou BIT NOT NULL DEFAULT 0,
    PacienteCancelou BIT NOT NULL DEFAULT 0, -- Se for cancelado, deve haver justicativa
    JustificativaCancelamento NVARCHAR(100),
    Ativo BIT,  
	DataCadastro DATETIME NOT NULL,
	DataAtualizacao DATETIME,
    DataAtualizacaoMedico DATETIME,
    FOREIGN KEY (IdPaciente) REFERENCES Paciente(Id),
    FOREIGN KEY (IdMedico) REFERENCES Medico(Id),
    FOREIGN KEY (IdConsulta) REFERENCES ConsultaDisponivel(Id)
);