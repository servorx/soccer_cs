using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using soccer_cs.infrastructure.utils;

namespace soccer_cs;

public class DbInstaller
{
  private readonly Validaciones validate_data = new Validaciones();
  public void CrearBaseDeDatos(string connectionStringNoDB, string db_name)
  {
    Console.Clear();
    string query = $"""
    CREATE DATABASE IF NOT EXISTS `{db_name}`;
    USE `{db_name}`;

    CREATE TABLE IF NOT EXISTS personas (
      id INT PRIMARY KEY AUTO_INCREMENT,
      edad INT,
      nacionalidad VARCHAR(50),
      documento_identidad INT UNIQUE,
      genero VARCHAR(50)
    ) ENGINE=INNODB;

    CREATE TABLE IF NOT EXISTS cuerpo_medico (
      id INT PRIMARY KEY,
      especialidad VARCHAR(100),
      anios_experiencia INT,
      CONSTRAINT fk_id_cuerpomedico FOREIGN KEY (id) REFERENCES personas(id) 
    ) ENGINE=INNODB;

    CREATE TABLE IF NOT EXISTS cuerpo_tecnico (
      id INT PRIMARY KEY,
      rol VARCHAR(40),
      anios_experiencia INT,
      CONSTRAINT fk_id_cuerpotecnico FOREIGN KEY (id) REFERENCES personas(id)
    ) ENGINE=INNODB;

    CREATE TABLE IF NOT EXISTS jugadores (
      id INT PRIMARY KEY,
      posicion VARCHAR(40),
      numero_dorsal INT,
      pie_habil VARCHAR(50),
      valor_mercado DECIMAL(12,2),
      CONSTRAINT fk_id_jugadores FOREIGN KEY (id) REFERENCES personas(id)
    ) ENGINE=INNODB;

    CREATE TABLE IF NOT EXISTS estadistica_jugador (
      id INT PRIMARY KEY AUTO_INCREMENT,
      id_jugador INT,
      goles INT,
      asistencias INT,
      partidosJugados INT,
      estatura DECIMAL(4,2),
      peso DECIMAL(5,2),
      tarjetas_amarillas INT,
      tarjetas_rojas INT,
      CONSTRAINT fk_est_jugador FOREIGN KEY (id_jugador) REFERENCES jugadores(id)
    ) ENGINE=INNODB;

    CREATE TABLE IF NOT EXISTS equipos (
      id INT PRIMARY KEY AUTO_INCREMENT,
      nombre VARCHAR(100) UNIQUE,
      ciudad VARCHAR(50),
      pais VARCHAR(40),
      estadio VARCHAR(180),
      tipo_equipo VARCHAR(30),
      cantidad_titulos INT
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

    CREATE TABLE IF NOT EXISTS equipo_cuerpo_tecnico (
      id_equipo INT,
      id_cuerpo_tecnico INT,
      PRIMARY KEY (id_equipo, id_cuerpo_tecnico),
      CONSTRAINT fk_ie_ect FOREIGN KEY (id_equipo) REFERENCES equipos(id),
      CONSTRAINT fk_iect_ect FOREIGN KEY (id_cuerpo_tecnico) REFERENCES cuerpo_tecnico(id)
    ) ENGINE=INNODB;

    CREATE TABLE IF NOT EXISTS equipo_cuerpo_medico (
      id_equipo INT,
      id_cuerpo_medico INT,
      PRIMARY KEY (id_equipo, id_cuerpo_medico),
      CONSTRAINT fk_ie_ecm FOREIGN KEY (id_equipo) REFERENCES equipos(id),
      CONSTRAINT fk_icm_ecm FOREIGN KEY (id_cuerpo_medico) REFERENCES cuerpo_medico(id)
    ) ENGINE=INNODB;

    CREATE TABLE IF NOT EXISTS estadistica_equipo (
      id INT PRIMARY KEY AUTO_INCREMENT,
      id_equipo INT,
      partidos_ganados INT,
      partidos_empatados INT,
      partidos_perdidos INT,
      goles_a_favor INT,
      goles_en_contra INT,
      CONSTRAINT fk_id_equipo_ee FOREIGN KEY (id_equipo) REFERENCES equipos(id)
    ) ENGINE=INNODB;

    CREATE TABLE IF NOT EXISTS torneos (
      id INT PRIMARY KEY AUTO_INCREMENT,
      nombre VARCHAR(255) UNIQUE,
      tipo VARCHAR(30),
      ubicacion VARCHAR(255),
      fecha_creacion DATA, 
      duracion_dias INT,
      premio DECIMAL(12,2)
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
    """;

    using var connection = new MySqlConnection(connectionStringNoDB);
    connection.Open();

    using var command = new MySqlCommand(query, connection);
    command.ExecuteNonQuery();
    Console.WriteLine("Base de datos creada :D");
  }
  public void BorrarBaseDeDatos(string connectionStringNoDB, string db_name)
  {
    Console.Clear();
    Console.WriteLine("¿Estás seguro de que deseas borrar la base de datos? (s/n)");
    string? confirmacion = validate_data.ValidarTexto(Console.ReadLine());
    if (validate_data.ValidarBoleano(confirmacion))
    {
      string query = $"DROP DATABASE IF EXISTS `{db_name};";

      using var connection = new MySqlConnection(connectionStringNoDB);
      connection.Open();

      using var command = new MySqlCommand(query, connection);
      command.ExecuteNonQuery();
      Console.WriteLine("Base de datos borrada :D");
    }
    else
    {
      Console.WriteLine("La base de datos no ha sido borrada :(");
      Console.ReadLine();
    }
  }
}