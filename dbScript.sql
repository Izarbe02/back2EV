CREATE DATABASE CineDB;

SELECT name, database_id, create_date 
FROM sys.databases 
WHERE name = 'CineDB';

USE CineDB;

--Categorias
CREATE TABLE Categorias (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL
);

--  Pelicula
CREATE TABLE Pelicula (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(MAX),
    añoSalida DATETIME,
    director NVARCHAR(100),
    caratula NVARCHAR(255),
    duracion INT , 
    trailerURL NVARCHAR(255),
    FOREIGN KEY (idCategoria) REFERENCES Categorias(ID)
);

-- Categorias_pelicula (Relación)
CREATE TABLE Categorias_pelicula (
    IDCategoria INT,
    idPelicula INT,
    PRIMARY KEY (IDCategoria, idPelicula),
    FOREIGN KEY (IDCategoria) REFERENCES Categorias(ID),
    FOREIGN KEY (idPelicula) REFERENCES Pelicula(ID)
);

--  Sala
CREATE TABLE Sala (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    capacidad INT NOT NULL CHECK (capacidad > 0)
);

-- Asientos
CREATE TABLE Asientos (
    idSala INT,
    fila INT,
    numero INT,
    ocupado TINYINT DEFAULT 0,
    PRIMARY KEY (idSala, fila, numero),
    FOREIGN KEY (idSala) REFERENCES Sala(ID)
);

--  Sesion
CREATE TABLE Sesion (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    idPelicula INT,
    idSala INT,
    inicio DATETIME NOT NULL,
    fin DATETIME NOT NULL,
    FOREIGN KEY (idPelicula) REFERENCES Pelicula(ID),
    FOREIGN KEY (idSala) REFERENCES Sala(ID)
);

--  Usuario
CREATE TABLE Usuario (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(50) UNIQUE NOT NULL,
    nombre NVARCHAR(50) NOT NULL,
    apellido1 NVARCHAR(50),
    contraseña NVARCHAR(255) NOT NULL
);

--  Roles
CREATE TABLE Roles (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL
);

-- Usuario - Roles
CREATE TABLE Usuario_Roles (
    idUsuario INT,
    idRol INT,
    PRIMARY KEY (idUsuario, idRol),
    FOREIGN KEY (idUsuario) REFERENCES Usuario(ID),
    FOREIGN KEY (idRol) REFERENCES Roles(ID)
);

--  Comentarios
CREATE TABLE Comentarios (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    idUsuario INT,
    valoracion INT CHECK (valoracion BETWEEN 1 AND 5),
    FOREIGN KEY (idUsuario) REFERENCES Usuario(ID)
);

--  Reserva
CREATE TABLE Reserva (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    idUsuario INT,
    FOREIGN KEY (idUsuario) REFERENCES Usuario(ID)
);

--  Productos
CREATE TABLE Productos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    idCat INT,
    nombre NVARCHAR(100) NOT NULL,
    FOREIGN KEY (idCat) REFERENCES Categorias(ID)
);

--  categoriaProd
CREATE TABLE categoriaProd (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    IDProd INT,
    FOREIGN KEY (IDProd) REFERENCES Productos(ID)
);

--  LineaPedido
CREATE TABLE LineaPedido (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    idSession INT,
    idSala INT,
    cantidad INT NOT NULL CHECK (cantidad > 0),
    FOREIGN KEY (idSession) REFERENCES Sesion(ID),
    FOREIGN KEY (idSala) REFERENCES Sala(ID)
);
