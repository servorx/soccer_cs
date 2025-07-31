DROP DATABASE IF EXISTS soccer_scharp;
CREATE DATABASE IF NOT EXISTS soccer_scharp;
USE soccer_scharp;

CREATE TABLE IF NOT EXISTS Persona (
  Id INT PRIMARY KEY AUTO_INCREMENT,
  Nombre VARCHAR(255),
  Apellido VARCHAR(255),
  Edad INT,
  Nacionalidad VARCHAR(255),
  DocumentoIdentidad INT UNIQUE,
  Genero VARCHAR(50)
);

CREATE TABLE IF NOT EXISTS CuerpoMedico (
  Id INT PRIMARY KEY,
  Especialidad VARCHAR(255),
  AniosExperiencia INT,
  CONSTRAINT fk_id_cuerpomedico FOREIGN KEY (Id) REFERENCES Persona(Id) 
);

CREATE TABLE IF NOT EXISTS CuerpoTecnico (
  Id INT PRIMARY KEY,
  Rol VARCHAR(255),
  AniosExperiencia INT,
  FOREIGN KEY (Id) REFERENCES Persona(Id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS EstadisticaJugador (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Goles INT,
    Asistencias INT,
    PartidosJugados INT,
    Estatura FLOAT,
    Peso FLOAT,
    TarjetasAmarillas INT,
    TarjetasRojas INT
);

CREATE TABLE IF NOT EXISTS Jugador (
    Id INT PRIMARY KEY,
    Posicion VARCHAR(255),
    NumeroDorsal INT,
    PieHabil VARCHAR(50),
    ValorMercado FLOAT,
    -- EquipoActual VARCHAR(255), -- Esto se manejará con una relación en la tabla Equipo
    FOREIGN KEY (Id) REFERENCES Persona(Id) ON DELETE CASCADE
);

-- Table: JugadorEstadistica
CREATE TABLE IF NOT EXISTS JugadorEstadistica (
    JugadorId INT,
    EstadisticaId INT,
    PRIMARY KEY (JugadorId, EstadisticaId),
    FOREIGN KEY (JugadorId) REFERENCES Jugador(Id) ON DELETE CASCADE,
    FOREIGN KEY (EstadisticaId) REFERENCES EstadisticaJugador(Id) ON DELETE CASCADE
);

-- Table: Equipo
CREATE TABLE IF NOT EXISTS Equipo (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(255) UNIQUE,
    Ciudad VARCHAR(255),
    Pais VARCHAR(255),
    Estadio VARCHAR(255),
    TipoEquipo VARCHAR(255),
    CantidadTitulos INT DEFAULT 0
);

-- Table: EquipoCuerpoTecnico (Tabla de unión para la relación N:M)
CREATE TABLE IF NOT EXISTS EquipoCuerpoTecnico (
    EquipoId INT,
    CuerpoTecnicoId INT,
    PRIMARY KEY (EquipoId, CuerpoTecnicoId),
    FOREIGN KEY (EquipoId) REFERENCES Equipo(Id) ON DELETE CASCADE,
    FOREIGN KEY (CuerpoTecnicoId) REFERENCES CuerpoTecnico(Id) ON DELETE CASCADE
);

-- Table: EquipoCuerpoMedico (Tabla de unión para la relación N:M)
CREATE TABLE IF NOT EXISTS EquipoCuerpoMedico (
    EquipoId INT,
    CuerpoMedicoId INT,
    PRIMARY KEY (EquipoId, CuerpoMedicoId),
    FOREIGN KEY (EquipoId) REFERENCES Equipo(Id) ON DELETE CASCADE,
    FOREIGN KEY (CuerpoMedicoId) REFERENCES CuerpoMedico(Id) ON DELETE CASCADE
);

-- Table: EquipoJugador (Tabla de unión para la relación N:M, o 1:N si un jugador solo juega para un equipo a la vez)
CREATE TABLE IF NOT EXISTS EquipoJugador (
    EquipoId INT,
    JugadorId INT,
    FechaInicio DATE, -- Para saber cuándo el jugador se unió al equipo
    FechaFin DATE,    -- Para saber cuándo el jugador dejó el equipo (puede ser NULL)
    PRIMARY KEY (EquipoId, JugadorId),
    FOREIGN KEY (EquipoId) REFERENCES Equipo(Id) ON DELETE CASCADE,
    FOREIGN KEY (JugadorId) REFERENCES Jugador(Id) ON DELETE CASCADE
);

-- Table: EstadisticaEquipo
CREATE TABLE IF NOT EXISTS EstadisticaEquipo (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    EquipoId INT,
    PartidosGanados INT DEFAULT 0,
    PartidosEmpatados INT DEFAULT 0,
    PartidosPerdidos INT DEFAULT 0,
    GolesAFavor INT DEFAULT 0,
    GolesEnContra INT DEFAULT 0,
    FOREIGN KEY (EquipoId) REFERENCES Equipo(Id) ON DELETE CASCADE
);

-- Table: Torneo
CREATE TABLE IF NOT EXISTS Torneo (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(255) UNIQUE,
    Tipo VARCHAR(255),
    Ubicacion VARCHAR(255),
    FechaCreacion DATE, -- Cambiado a DATE para mejor manejo de fechas
    DuracionDias INT,
    Premio VARCHAR(255)
);

-- Table: TorneoEquipo (Tabla de unión para la relación N:M)
CREATE TABLE IF NOT EXISTS TorneoEquipo (
    TorneoId INT,
    EquipoId INT,
    PRIMARY KEY (TorneoId, EquipoId),
    FOREIGN KEY (TorneoId) REFERENCES Torneo(Id) ON DELETE CASCADE,
    FOREIGN KEY (EquipoId) REFERENCES Equipo(Id) ON DELETE CASCADE
);

-- Table: Transferencia
CREATE TABLE IF NOT EXISTS Transferencia (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    JugadorId INT,
    EquipoOrigen VARCHAR(255), -- Podríamos usar IDs de equipos aquí para una mejor normalización
    EquipoDestino VARCHAR(255), -- Podríamos usar IDs de equipos aquí para una mejor normalización
    TipoTransferencia VARCHAR(255),
    ValorTransferencia FLOAT,
    FechaTransferencia DATE DEFAULT (CURRENT_DATE), -- Añadida columna para la fecha de la transferencia
    FOREIGN KEY (JugadorId) REFERENCES Jugador(Id) ON DELETE CASCADE
);