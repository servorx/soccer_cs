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

-- Inserts para la tabla 'cuerpo_medico'
INSERT INTO cuerpo_medico (id, especialidad, anios_experiencia) VALUES
(21, 'Médico Deportivo', 15),
(22, 'Traumatóloga', 10),
(23, 'Fisioterapeuta', 8),
(24, 'Nutricionista Deportivo', 12),
(25, 'Psicólogo Deportivo', 20);

-- Inserts para la tabla 'cuerpo_tecnico'
INSERT INTO cuerpo_tecnico (id, rol, anios_experiencia) VALUES
(16, 'Entrenador Principal', 20),
(17, 'Entrenador Principal', 22),
(18, 'Entrenadora Principal', 15),
(19, 'Entrenador Principal', 25),
(20, 'Director Técnico', 18);

-- Inserts para la tabla 'jugadores'
INSERT INTO jugadores (id, posicion, numero_dorsal, pie_habil, valor_mercado) VALUES
(1, 'Delantero', 10, 'Izquierdo', 45000000.00),
(2, 'Delantero', 7, 'Derecho', 30000000.00),
(3, 'Delantero', 7, 'Derecho', 180000000.00),
(4, 'Delantero', 9, 'Izquierdo', 170000000.00),
(5, 'Extremo Izquierdo', 7, 'Derecho', 150000000.00),
(6, 'Mediocampista Central', 5, 'Derecho', 180000000.00),
(7, 'Mediocampista Central', 8, 'Derecho', 90000000.00),
(8, 'Mediocampista Central', 15, 'Derecho', 100000000.00),
(9, 'Mediocampista Ofensivo', 42, 'Derecho', 110000000.00),
(10, 'Extremo Derecho', 7, 'Izquierdo', 120000000.00),
(11, 'Delantero Centro', 9, 'Derecho', 25000000.00),
(12, 'Mediocampista Ofensivo', 17, 'Derecho', 70000000.00),
(13, 'Lateral Izquierdo', 19, 'Izquierdo', 60000000.00),
(14, 'Extremo Izquierdo', 7, 'Ambos', 50000000.00),
(15, 'Delantera', 11, 'Derecho', 1500000.00);

-- Inserts para la tabla 'equipos'
INSERT INTO equipos (nombre, ciudad, pais, estadio, tipo_equipo, cantidad_titulos) VALUES
('Los Leones FC', 'Madrid', 'España', 'Estadio El Coliseo', 'Profesional', 35),
('Águilas Negras', 'Múnich', 'Alemania', 'Arena Bávara', 'Profesional', 30),
('Rayos Azules', 'París', 'Francia', 'Parque de los Príncipes', 'Profesional', 28),
('Tigres del Sur', 'Buenos Aires', 'Argentina', 'La Bombonera', 'Profesional', 40),
('Dragones Rojos', 'Manchester', 'Inglaterra', 'Old Trafford', 'Profesional', 45),
('Estrellas del Norte', 'Río de Janeiro', 'Brasil', 'Estadio Maracaná', 'Profesional', 38),
('Halcones Dorados', 'Ciudad de México', 'México', 'Estadio Azteca', 'Profesional', 25);

-- Inserts para la tabla 'estadistica_jugador'
INSERT INTO estadistica_jugador (id_jugador, goles, asistencias, partidosJugados, estatura, peso, tarjetas_amarillas, tarjetas_rojas) VALUES
(1, 700, 350, 850, 1.70, 72.5, 80, 2),
(2, 750, 250, 900, 1.87, 83.0, 120, 5),
(3, 200, 100, 300, 1.78, 73.0, 25, 1),
(4, 180, 40, 250, 1.94, 88.0, 15, 0),
(5, 80, 70, 200, 1.76, 70.0, 30, 0),
(6, 40, 50, 180, 1.86, 78.0, 20, 0),
(7, 20, 35, 150, 1.74, 68.0, 18, 0),
(8, 30, 45, 220, 1.82, 75.0, 22, 1),
(9, 25, 30, 160, 1.80, 72.0, 10, 0),
(10, 50, 60, 210, 1.79, 70.0, 12, 0),
(11, 400, 100, 600, 1.85, 80.0, 60, 1),
(12, 100, 200, 450, 1.81, 70.0, 40, 0),
(13, 15, 40, 190, 1.83, 76.0, 28, 0),
(14, 120, 80, 380, 1.84, 77.0, 35, 1),
(15, 80, 40, 150, 1.72, 65.0, 10, 0);

-- Inserts para la tabla 'equipo_jugador'
INSERT INTO equipo_jugador (id_equipo, id_jugador, fecha_inicio, fecha_fin) VALUES
(1, 1, '2021-08-10', '2025-06-30'), -- Messi en Los Leones FC
(5, 2, '2021-08-27', '2025-06-30'), -- Ronaldo en Dragones Rojos
(3, 3, '2017-07-01', '2027-06-30'), -- Mbappé en Rayos Azules
(5, 4, '2022-07-01', '2027-06-30'), -- Haaland en Dragones Rojos
(1, 5, '2018-07-01', '2028-06-30'), -- Vinicius Jr. en Los Leones FC
(1, 6, '2023-07-01', '2029-06-30'), -- Bellingham en Los Leones FC
(1, 7, '2020-07-01', '2026-06-30'), -- Pedri en Los Leones FC
(1, 8, '2018-07-01', '2027-06-30'), -- Valverde en Los Leones FC
(2, 9, '2020-07-01', '2028-06-30'), -- Musiala en Águilas Negras
(5, 10, '2019-07-01', '2026-06-30'), -- Saka en Dragones Rojos
(2, 11, '2022-07-01', '2025-06-30'), -- Lewandowski en Águilas Negras
(5, 12, '2015-07-01', '2026-06-30'), -- De Bruyne en Dragones Rojos
(2, 13, '2019-07-01', '2027-06-30'), -- Davies en Águilas Negras
(5, 14, '2015-07-01', '2025-06-30'), -- Son en Dragones Rojos
(2, 15, '2018-07-01', '2026-06-30'); -- Popp en Águilas Negras

-- Inserts para la tabla 'equipo_cuerpo_tecnico'
INSERT INTO equipo_cuerpo_tecnico (id_equipo, id_cuerpo_tecnico) VALUES
(5, 16), -- Guardiola en Dragones Rojos
(5, 17), -- Klopp en Dragones Rojos (como asistente, por ejemplo)
(2, 18), -- Hayes en Águilas Negras
(1, 19), -- Ancelotti en Los Leones FC
(3, 20); -- Deschamps en Rayos Azules

-- Inserts para la tabla 'equipo_cuerpo_medico'
INSERT INTO equipo_cuerpo_medico (id_equipo, id_cuerpo_medico) VALUES
(1, 21), -- Dr. Pérez en Los Leones FC
(2, 22), -- Dra. González en Águilas Negras
(5, 23), -- Fisiot. Ramírez en Dragones Rojos
(3, 24), -- Nutric. Silva en Rayos Azules
(4, 25); -- Psic. Castro en Tigres del Sur

-- Inserts para la tabla 'estadistica_equipo'
INSERT INTO estadistica_equipo (id_equipo, partidos_ganados, partidos_empatados, partidos_perdidos, goles_a_favor, goles_en_contra) VALUES
(1, 800, 200, 150, 2500, 1000),
(2, 750, 220, 180, 2300, 1100),
(3, 700, 250, 200, 2100, 1200),
(4, 850, 180, 120, 2700, 900),
(5, 900, 150, 100, 2900, 800),
(6, 780, 210, 160, 2400, 1050),
(7, 680, 230, 220, 2000, 1300);

-- Inserts para la tabla 'torneos'
INSERT INTO torneos (nombre, tipo, ubicacion, fecha_creacion, duracion_dias, premio) VALUES
('Liga Nacional', 'Liga', 'Nacional', '1929-01-01', 270, 50000000.00),
('Copa Continental', 'Copa', 'Internacional', '1955-09-04', 180, 80000000.00),
('Torneo de Verano', 'Amistoso', 'Local', '2023-01-15', 30, 500000.00),
('Copa de Campeones', 'Eliminación Directa', 'Internacional', '1992-05-25', 210, 120000000.00),
('Liga Juvenil Sub-20', 'Liga', 'Nacional', '2005-03-10', 150, 1000000.00);

-- Inserts para la tabla 'torneo_equipo'
INSERT INTO torneo_equipo (id_torneo, id_equipo) VALUES
(1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 6), (1, 7), -- Todos en Liga Nacional
(2, 1), (2, 2), (2, 3), (2, 5), -- Algunos en Copa Continental
(3, 1), (3, 4), (3, 6), -- Algunos en Torneo de Verano
(4, 1), (4, 2), (4, 3), (4, 5), -- Los grandes en Copa de Campeones
(5, 4), (5, 6), (5, 7); -- Algunos en Liga Juvenil

-- Inserts para la tabla 'transferencia'
INSERT INTO transferencia (id_jugador, id_equipo_origen, id_equipo_destino, tipo_transferencia, valor_transferencia, fecha_transferencia) VALUES
(1, NULL, 1, 'Agente Libre', 0.00, '2021-08-10'), -- Messi a Los Leones FC
(4, 2, 5, 'Compra', 60000000.00, '2022-07-01'), -- Haaland de Águilas Negras a Dragones Rojos
(6, 4, 1, 'Compra', 103000000.00, '2023-07-01'), -- Bellingham de Tigres del Sur a Los Leones FC
(11, 3, 2, 'Compra', 45000000.00, '2022-07-15'), -- Lewandowski de Rayos Azules a Águilas Negras
(15, 6, 2, 'Préstamo con opción de compra', 500000.00, '2024-01-01'); -- Popp de Estrellas del Norte a Águilas Negras
