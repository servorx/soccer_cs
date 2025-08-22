CREATE DATABASE IF NOT EXISTS soccer_cs;
USE soccer_cs;

CREATE TABLE IF NOT EXISTS equipos (
  id INT PRIMARY KEY AUTO_INCREMENT,
  nombre VARCHAR(100) UNIQUE,
  ciudad VARCHAR(50),
  pais VARCHAR(40),
  estadio VARCHAR(180),
  tipo_equipo VARCHAR(30),
  cantidad_titulos INT
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS personas (
  id INT PRIMARY KEY AUTO_INCREMENT,
  nombre VARCHAR(80) NOT NULL,
  apellido VARCHAR(80) NOT NULL,
  edad INT NOT NULL,
  nacionalidad VARCHAR(50) NOT NULL,
  documento_identidad INT UNIQUE,
  genero VARCHAR(50)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS cuerpo_medico (
  id INT PRIMARY KEY AUTO_INCREMENT,
  id_persona INT NOT NULL,
  especialidad VARCHAR(100) NOT NULL,
  anios_experiencia INT NOT NULL,
  id_equipo INT, 
  CONSTRAINT fk_id_cuerpomedico FOREIGN KEY (id_persona) REFERENCES personas(id),
  CONSTRAINT fk_id_equipo_cuerpo_medico FOREIGN KEY (id_equipo) REFERENCES equipos(id)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS cuerpo_tecnico (
  id INT PRIMARY KEY AUTO_INCREMENT,
  id_persona INT NOT NULL,
  rol VARCHAR(40) NOT NULL,
  anios_experiencia INT NOT NULL,
  id_equipo INT,
  CONSTRAINT fk_id_cuerpotecnico FOREIGN KEY (id_persona) REFERENCES personas(id),
  CONSTRAINT fk_id_equipo_cuerpo_tecnico FOREIGN KEY (id_equipo) REFERENCES equipos(id)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS jugadores (
  id INT PRIMARY KEY AUTO_INCREMENT,
  id_persona INT NOT NULL,
  posicion VARCHAR(40),
  numero_dorsal INT,
  pie_habil VARCHAR(15),
  valor_mercado DECIMAL(12,2),
  id_equipo_actual INT,
  CONSTRAINT fk_id_jugador_persona FOREIGN KEY (id_persona) REFERENCES personas(id),
  CONSTRAINT fk_id_equipo_actual_jugadores FOREIGN KEY (id_equipo_actual) REFERENCES equipos(id)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS estadistica_jugador (
  id INT PRIMARY KEY AUTO_INCREMENT,
  id_jugador INT,
  goles INT,
  asistencias INT,
  partidos_jugados INT,
  estatura DECIMAL(3,2),
  peso DECIMAL(5,2),
  tarjetas_amarillas INT,
  tarjetas_rojas INT,
  fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  CONSTRAINT fk_est_jugador FOREIGN KEY (id_jugador) REFERENCES jugadores(id)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS estadistica_equipo (
  id INT PRIMARY KEY AUTO_INCREMENT,
  id_equipo INT,
  partidos_ganados INT,
  partidos_empatados INT,
  partidos_perdidos INT,
  goles_a_favor INT,
  goles_en_contra INT,
  fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  CONSTRAINT fk_id_equipo_ee FOREIGN KEY (id_equipo) REFERENCES equipos(id)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS equipo_jugador (
  id_equipo INT,
  id_jugador INT,
  fecha_inicio DATE,
  fecha_fin DATE,    
  PRIMARY KEY (id_equipo, id_jugador),
  CONSTRAINT fk_id_equipo_equipo_jugador FOREIGN KEY (id_equipo) REFERENCES equipos(id),
  CONSTRAINT fk_id_jugador_equipo_jugador FOREIGN KEY (id_jugador) REFERENCES jugadores(id)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS torneos (
  id INT PRIMARY KEY AUTO_INCREMENT,
  nombre VARCHAR(255) UNIQUE,
  tipo VARCHAR(30),
  ubicacion VARCHAR(255),
  fecha_inicio DATE,
  fecha_final DATE,
  premio DECIMAL(15,2)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS torneo_equipo (
  id_torneo INT,
  id_equipo INT,
  PRIMARY KEY (id_torneo, id_equipo),
  CONSTRAINT fk_id_torneo_te FOREIGN KEY (id_torneo) REFERENCES torneos(id),
  CONSTRAINT fk_id_equipo_te FOREIGN KEY (id_equipo) REFERENCES equipos(id)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS transferencia (
  id INT PRIMARY KEY AUTO_INCREMENT,
  id_jugador INT,
  id_equipo_origen INT,
  id_equipo_destino INT, 
  tipo_transferencia VARCHAR(120), 
  valor_transferencia DECIMAL(12,2),
  fecha_transferencia DATE,
  CONSTRAINT fk_id_jugador_transferencia FOREIGN KEY (id_jugador) REFERENCES jugadores(id),
  CONSTRAINT fk_id_equipo_origen_transferencia FOREIGN KEY (id_equipo_origen) REFERENCES equipos(id),
  CONSTRAINT fk_id_equipo_destino_transferencia FOREIGN KEY (id_equipo_destino) REFERENCES equipos(id)
) ENGINE=INNODB;

INSERT INTO equipos (nombre, ciudad, pais, estadio, tipo_equipo, cantidad_titulos) VALUES
('Los Leones FC', 'Madrid', 'España', 'Estadio El Coliseo', 'Profesional', 35),
('Águilas Negras', 'Múnich', 'Alemania', 'Arena Bávara', 'Profesional', 30),
('Rayos Azules', 'París', 'Francia', 'Parque de los Príncipes', 'Profesional', 28),
('Tigres del Sur', 'Buenos Aires', 'Argentina', 'La Bombonera', 'Profesional', 40),
('Dragones Rojos', 'Manchester', 'Inglaterra', 'Old Trafford', 'Profesional', 45),
('Estrellas del Norte', 'Río de Janeiro', 'Brasil', 'Estadio Maracaná', 'Profesional', 38),
('Halcones Dorados', 'Ciudad de México', 'México', 'Estadio Azteca', 'Profesional', 25);

-- Inserts para la tabla 'personas'
-- Jugadores (IDs 1-15)
INSERT INTO personas (nombre, apellido, edad, nacionalidad, documento_identidad, genero) VALUES
('Lionel', 'Messi', 37, 'Argentina', 100000001, 'Masculino'),
('Cristiano', 'Ronaldo', 39, 'Portugal', 100000002, 'Masculino'),
('Kylian', 'Mbappé', 25, 'Francia', 100000003, 'Masculino'),
('Erling', 'Haaland', 24, 'Noruega', 100000004, 'Masculino'),
('Vinicius', 'Jr.', 24, 'Brasil', 100000005, 'Masculino'),
('Jude', 'Bellingham', 21, 'Inglaterra', 100000006, 'Masculino'),
('Pedri', 'González', 21, 'España', 100000007, 'Masculino'),
('Federico', 'Valverde', 26, 'Uruguay', 100000008, 'Masculino'),
('Jamal', 'Musiala', 21, 'Alemania', 100000009, 'Masculino'),
('Bukayo', 'Saka', 23, 'Inglaterra', 100000010, 'Masculino'),
('Robert', 'Lewandowski', 36, 'Polonia', 100000011, 'Masculino'),
('Kevin', 'De Bruyne', 33, 'Bélgica', 100000012, 'Masculino'),
('Alphonso', 'Davies', 23, 'Canadá', 100000013, 'Masculino'),
('Son', 'Heung-min', 32, 'Corea del Sur', 100000014, 'Masculino'),
('Alexandra', 'Popp', 33, 'Alemania', 200000015, 'Femenino');

-- Cuerpo Técnico (IDs 16-20)
INSERT INTO personas (nombre, apellido, edad, nacionalidad, documento_identidad, genero) VALUES
('Pep', 'Guardiola', 53, 'España', 100000016, 'Masculino'),
('Jürgen', 'Klopp', 57, 'Alemania', 100000017, 'Masculino'),
('Emma', 'Hayes', 48, 'Inglaterra', 200000018, 'Femenino'),
('Carlo', 'Ancelotti', 65, 'Italia', 100000019, 'Masculino'),
('Didier', 'Deschamps', 55, 'Francia', 100000020, 'Masculino');

-- Cuerpo Médico (IDs 21-25)
INSERT INTO personas (nombre, apellido, edad, nacionalidad, documento_identidad, genero) VALUES
('Dr. Juan', 'Pérez', 45, 'España', 100000021, 'Masculino'),
('Dra. María', 'González', 38, 'México', 200000022, 'Femenino'),
('Fisiot. Luis', 'Ramírez', 32, 'Colombia', 100000023, 'Masculino'),
('Nutric. Ana', 'Silva', 40, 'Brasil', 200000024, 'Femenino'),
('Psic. David', 'Castro', 50, 'Argentina', 100000025, 'Masculino');

-- Inserts para la tabla 'jugadores'
INSERT INTO jugadores (id_persona, posicion, numero_dorsal, pie_habil, valor_mercado, id_equipo_actual) VALUES
(1, 'Delantero', 10, 'Izquierdo', 45000000.00, 1), -- Messi a Los Leones FC
(2, 'Delantero', 7, 'Derecho', 30000000.00, 5), -- Ronaldo a Dragones Rojos
(3, 'Delantero', 7, 'Derecho', 180000000.00, 3), -- Mbappé a Rayos Azules
(4, 'Delantero', 9, 'Izquierdo', 170000000.00, 5), -- Haaland a Dragones Rojos
(5, 'Extremo Izquierdo', 7, 'Derecho', 150000000.00, 1), -- Vinicius Jr. a Los Leones FC
(6, 'Mediocampista Central', 5, 'Derecho', 180000000.00, 1), -- Bellingham a Los Leones FC
(7, 'Mediocampista Central', 8, 'Derecho', 90000000.00, 1), -- Pedri a Los Leones FC
(8, 'Mediocampista Central', 15, 'Derecho', 100000000.00, 1), -- Valverde a Los Leones FC
(9, 'Mediocampista Ofensivo', 42, 'Derecho', 110000000.00, 2), -- Musiala a Águilas Negras
(10, 'Extremo Derecho', 7, 'Izquierdo', 120000000.00, 5), -- Saka a Dragones Rojos
(11, 'Delantero Centro', 9, 'Derecho', 25000000.00, 2), -- Lewandowski a Águilas Negras
(12, 'Mediocampista Ofensivo', 17, 'Derecho', 70000000.00, 5), -- De Bruyne a Dragones Rojos
(13, 'Lateral Izquierdo', 19, 'Izquierdo', 60000000.00, 2), -- Davies a Águilas Negras
(14, 'Extremo Izquierdo', 7, 'Ambos', 50000000.00, 5), -- Son a Dragones Rojos
(15, 'Delantera', 11, 'Derecho', 1500000.00, 2); -- Popp a Águilas Negras

-- Inserts para la tabla 'cuerpo_medico'
INSERT INTO cuerpo_medico (id_persona, especialidad, anios_experiencia, id_equipo) VALUES
(21, 'Médico Deportivo', 15, 1),
(22, 'Traumatóloga', 10, 5),
(23, 'Fisioterapeuta', 8, 3),
(24, 'Nutricionista Deportivo', 12, 2),
(25, 'Psicólogo Deportivo', 20, 1);

-- Inserts para la tabla 'cuerpo_tecnico'
INSERT INTO cuerpo_tecnico (id_persona, rol, anios_experiencia, id_equipo) VALUES
(16, 'Entrenador Principal', 20, 5),
(17, 'Entrenador Principal', 22, 2),
(18, 'Entrenadora Principal', 15, 4),
(19, 'Entrenador Principal', 25, 1),
(20, 'Director Técnico', 18, 3);

-- Inserts para la tabla 'estadistica_jugador'
INSERT INTO estadistica_jugador (id_jugador, goles, asistencias, partidos_jugados, estatura, peso, tarjetas_amarillas, tarjetas_rojas, fecha_creacion) VALUES
(1, 700, 350, 850, 1.70, 72.5, 80, 2, '2024-07-26'),
(2, 750, 250, 900, 1.87, 83.0, 120, 5, '2024-07-26'),
(3, 200, 100, 300, 1.78, 73.0, 25, 1, '2024-07-26'),
(4, 180, 40, 250, 1.94, 88.0, 15, 0, '2024-07-26'),
(5, 80, 70, 200, 1.76, 70.0, 30, 0, '2024-07-26'),
(6, 40, 50, 180, 1.86, 78.0, 20, 0, '2024-07-26'),
(7, 20, 35, 150, 1.74, 68.0, 18, 0, '2024-07-26'),
(8, 30, 45, 220, 1.82, 75.0, 22, 1, '2024-07-26'),
(9, 25, 30, 160, 1.80, 72.0, 10, 0, '2024-07-26'),
(10, 50, 60, 210, 1.79, 70.0, 12, 0, '2024-07-26'),
(11, 400, 100, 600, 1.85, 80.0, 60, 1, '2024-07-26'),
(12, 100, 200, 450, 1.81, 70.0, 40, 0, '2024-07-26'),
(13, 15, 40, 190, 1.83, 76.0, 28, 0, '2024-07-26'),
(14, 120, 80, 380, 1.84, 77.0, 35, 1, '2024-07-26'),
(15, 80, 40, 150, 1.72, 65.0, 10, 0, '2024-07-26');

-- Inserts para la tabla 'equipo_jugador'
INSERT INTO equipo_jugador (id_equipo, id_jugador, fecha_inicio, fecha_fin) VALUES
(1, 1, '2021-08-10', '2025-06-30'), 
(5, 2, '2021-08-27', '2025-06-30'), 
(3, 3, '2017-07-01', '2027-06-30'), 
(5, 4, '2022-07-01', '2027-06-30'), 
(1, 5, '2018-07-01', '2028-06-30'), 
(1, 6, '2023-07-01', '2029-06-30'), 
(1, 7, '2020-07-01', '2026-06-30'), 
(1, 8, '2018-07-01', '2027-06-30'), 
(2, 9, '2020-07-01', '2028-06-30'), 
(5, 10, '2019-07-01', '2026-06-30'), 
(2, 11, '2022-07-01', '2025-06-30'), 
(5, 12, '2015-07-01', '2026-06-30'), 
(2, 13, '2019-07-01', '2027-06-30'), 
(5, 14, '2015-07-01', '2025-06-30'), 
(2, 15, '2018-07-01', '2026-06-30'); 

-- Inserts para la tabla 'estadistica_equipo'
INSERT INTO estadistica_equipo (id_equipo, partidos_ganados, partidos_empatados, partidos_perdidos, goles_a_favor, goles_en_contra, fecha_creacion) VALUES
(1, 800, 200, 150, 2500, 1000, '2024-07-26'),
(2, 750, 220, 180, 2300, 1100, '2024-07-26'),
(3, 700, 250, 200, 2100, 1200, '2024-07-26'),
(4, 850, 180, 120, 2700, 900, '2024-07-26'),
(5, 900, 150, 100, 2900, 800, '2024-07-26'),
(6, 780, 210, 160, 2400, 1050, '2024-07-26'),
(7, 680, 230, 220, 2000, 1300, '2024-07-26');

-- Inserts para la tabla 'torneos'
INSERT INTO torneos (nombre, tipo, ubicacion, fecha_inicio, fecha_final, premio) VALUES
('Liga Nacional', 'Liga', 'Nacional', '1929-01-01', '1929-09-28', 50000000.00),
('Copa Continental', 'Copa', 'Internacional', '1955-09-04', '1956-03-02', 80000000.00),
('Torneo de Verano', 'Amistoso', 'Local', '2023-01-15', '2023-02-14', 500000.00),
('Copa de Campeones', 'Eliminación Directa', 'Internacional', '1992-05-25', '1993-01-08', 120000000.00),
('Liga Juvenil Sub-20', 'Liga', 'Nacional', '2005-03-10', '2005-08-07', 1000000.00);

-- Inserts para la tabla 'torneo_equipo'
INSERT INTO torneo_equipo (id_torneo, id_equipo) VALUES
(1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 6), (1, 7),
(2, 1), (2, 2), (2, 3), (2, 5),
(3, 1), (3, 4), (3, 6),
(4, 1), (4, 2), (4, 3), (4, 5),
(5, 4), (5, 6), (5, 7);

-- Inserts para la tabla 'transferencia'
INSERT INTO transferencia (id_jugador, id_equipo_origen, id_equipo_destino, tipo_transferencia, valor_transferencia, fecha_transferencia) VALUES
(1, NULL, 1, 'Agente Libre', 0.00, '2021-08-10'), 
(4, 2, 5, 'Compra', 60000000.00, '2022-07-01'), 
(6, 4, 1, 'Compra', 103000000.00, '2023-07-01'), 
(11, 3, 2, 'Compra', 45000000.00, '2022-07-15'), 
(15, 6, 2, 'Préstamo con opción de compra', 500000.00, '2024-01-01'); 
