-- Creación de la base de datos
CREATE DATABASE dosEvBack;
USE dosEvBack;

-- Tabla Usuarios
CREATE TABLE Usuarios (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(50) UNIQUE NOT NULL,
    nombre NVARCHAR(50) NOT NULL,
    email NVARCHAR(50) UNIQUE,
    ubicacion NVARCHAR(255),
    contraseña NVARCHAR(255) NOT NULL
);

-- Tabla Roles
CREATE TABLE Roles (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL
);

-- Tabla Categorías de Eventos
CREATE TABLE CategoriasEventos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL UNIQUE
);

-- Tabla Categorías de Productos
CREATE TABLE CategoriasProductos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL UNIQUE
);

-- Tabla Temáticas
CREATE TABLE Tematica (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL UNIQUE
);

-- Tabla Organizador
CREATE TABLE Organizador (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL,
    ubicacion NVARCHAR(255) NOT NULL,
    descripcion NVARCHAR(MAX),
    enlace NVARCHAR(255), 
    email NVARCHAR(50) UNIQUE,
    contraseña NVARCHAR(255) NOT NULL,
    telefono NVARCHAR(20),
    idRol INT NOT NULL,
    FOREIGN KEY (idRol) REFERENCES Roles(ID) ON DELETE CASCADE
);

-- Tabla Eventos (Corrección en las claves foráneas)
CREATE TABLE Eventos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(MAX),
    ubicacion NVARCHAR(255) NOT NULL,
    fecha_inicio DATETIME NOT NULL,
    fecha_fin DATETIME NOT NULL,
    idTematica INT NULL,  -- Permitir NULL para usar ON DELETE SET NULL
    enlace NVARCHAR(255),
    idCategoria INT NULL, -- Permitir NULL para usar ON DELETE SET NULL
    idOrganizador INT NOT NULL,
    FOREIGN KEY (idTematica) REFERENCES Tematica(ID) ON DELETE SET NULL,
    FOREIGN KEY (idCategoria) REFERENCES CategoriasEventos(ID) ON DELETE SET NULL,
    FOREIGN KEY (idOrganizador) REFERENCES Organizador(ID) ON DELETE CASCADE
);

-- Tabla Comentarios
CREATE TABLE Comentarios (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    idUsuario INT NOT NULL,
    idEvento INT NOT NULL,
    comentario NVARCHAR(MAX) NOT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(ID) ON DELETE CASCADE,
    FOREIGN KEY (idEvento) REFERENCES Eventos(ID) ON DELETE CASCADE
);

-- Tabla Posts
CREATE TABLE Posts (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    idUsuario INT NOT NULL,
    titulo NVARCHAR(100) NOT NULL,
    contenido NVARCHAR(200) NOT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(ID) ON DELETE CASCADE
);

-- Tabla Productos
CREATE TABLE Productos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(150) NOT NULL,
    ubicacion NVARCHAR(255) NOT NULL,
    imagen NVARCHAR(255) NOT NULL,
    idUsuario INT NOT NULL,
    idCategoria INT NOT NULL,
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(ID) ON DELETE CASCADE,
    FOREIGN KEY (idCategoria) REFERENCES CategoriasProductos(ID) ON DELETE CASCADE
);
