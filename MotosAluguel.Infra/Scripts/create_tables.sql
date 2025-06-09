-- Cria tabela para os entregadores

CREATE TABLE Riders (
    Id VARCHAR(50) PRIMARY KEY,
    CNPJ VARCHAR(18) NOT NULL UNIQUE,
    "Name" VARCHAR(100) NOT NULL,
    CNH VARCHAR(20) NOT NULL UNIQUE,
    CnhType VARCHAR(50) NOT NULL,
    BirthDate TIMESTAMP NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP NULL,
    DeletedAt TIMESTAMP NULL,
    IsDeleted BOOLEAN DEFAULT FALSE
);

-- Cria tabela para as motos
CREATE TABLE MotorCycles(
    Id VARCHAR(50) PRIMARY KEY,
    "Year" VARCHAR(18) NOT NULL,
    Model VARCHAR(100) NOT NULL,
    Plate VARCHAR(20) NOT NULL UNIQUE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP NULL,
    DeletedAt TIMESTAMP NULL,
    IsDeleted BOOLEAN DEFAULT FALSE
);

-- Cria tabela para a locação
CREATE TABLE Rentals (
    Id UUID PRIMARY KEY,      
    RiderId VARCHAR(50) NOT NULL,    -- Chave estrangeira para a tabela Riders
    MotorCycleId VARCHAR(50) NOT NULL, -- Chave estrangeira para a tabela Motorcycles
    BeginAt TIMESTAMP NOT NULL,      
    EndAt TIMESTAMP NULL,            
    EstimatedEndDate TIMESTAMP NOT NULL, 
    "Plan" INT NOT NULL,
    ValueRental BIGINT NOT NULL, 
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP, 
    UpdatedAt TIMESTAMP NULL,
    DeletedAt TIMESTAMP NULL,
    IsDeleted BOOLEAN DEFAULT FALSE,

    CONSTRAINT fk_rider FOREIGN KEY (RiderId) REFERENCES Riders(Id),
    CONSTRAINT fk_motorcycle FOREIGN KEY (MotorCycleId) REFERENCES Motorcycles(Id)
);


