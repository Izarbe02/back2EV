CREATE DATABASE dosEvBack;

USE dosEvBack;

GO
-- Usuarios
CREATE TABLE Usuarios (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(50) UNIQUE NOT NULL,
    nombre NVARCHAR(50) NOT NULL,
    email NVARCHAR(50) UNIQUE,
    ubicacion NVARCHAR(255),
    contraseña NVARCHAR(255) NOT NULL
);

-- Roles
CREATE TABLE Roles (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL
);

-- Relación entgre Usuarios - Roles
CREATE TABLE Usuario_Roles (
    idUsuario INT,
    idRol INT,
    PRIMARY KEY (idUsuario, idRol),
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(ID) ON DELETE CASCADE,
    FOREIGN KEY (idRol) REFERENCES Roles(ID) ON DELETE CASCADE
);

-- Establecimientos Colaboradores
CREATE TABLE EstablecimientosColaboradores (
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

-- Categorías de Eventos
CREATE TABLE Categorias_Evento (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL UNIQUE
);

-- Eventos
CREATE TABLE Eventos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(MAX),
    ubicacion NVARCHAR(255) NOT NULL,
    fecha_inicio DATETIME NOT NULL,
    fecha_fin DATETIME NOT NULL,
    tematica NVARCHAR(100),
    enlace NVARCHAR(255),
    idCategoria INT,
    idOrganizador INT,
    FOREIGN KEY (idCategoria) REFERENCES Categorias_Evento(ID) ON DELETE SET NULL,
    FOREIGN KEY (idOrganizador) REFERENCES Usuarios(ID) ON DELETE CASCADE
);

-- Comentarios
CREATE TABLE Comentarios (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    idUsuario INT,
    idEvento INT,
    comentario NVARCHAR(MAX) NOT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(ID) ON DELETE CASCADE,
    FOREIGN KEY (idEvento) REFERENCES Eventos(ID) ON DELETE CASCADE
);

-- Posts
CREATE TABLE Posts (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    idUsuario INT,
    titulo NVARCHAR(100) NOT NULL,
    contenido NVARCHAR(200) NOT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(ID) ON DELETE CASCADE
);

-- Productos
CREATE TABLE Productos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(150),
    ubicacion NVARCHAR(255),
    imagen NVARCHAR(255),
    idUsuario INT,
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(ID) ON DELETE CASCADE
);

-- Categorías de Productos
CREATE TABLE Categorias_Productos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL UNIQUE
);

-- Relación entre Productos - Categorías
CREATE TABLE Producto_Categoria (
    idProducto INT,
    idCategoria INT,
    PRIMARY KEY (idProducto, idCategoria),
    FOREIGN KEY (idProducto) REFERENCES Productos(ID) ON DELETE CASCADE,
    FOREIGN KEY (idCategoria) REFERENCES Categorias_Productos(ID) ON DELETE CASCADE
);
