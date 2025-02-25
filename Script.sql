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
    contrasenia NVARCHAR(255) NOT NULL
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
    contrasenia NVARCHAR(255) NOT NULL,
    telefono NVARCHAR(20),
    idRol INT NOT NULL,
    FOREIGN KEY (idRol) REFERENCES Roles(ID) ON DELETE CASCADE
);

-- Tabla Eventos 
CREATE TABLE Eventos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(MAX),
    ubicacion NVARCHAR(255) NOT NULL,
    fecha_inicio DATETIME NOT NULL,
    fecha_fin DATETIME NOT NULL,
    idTematica INT NULL, 
    enlace NVARCHAR(255),
    idCategoria INT NULL,
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



--Inserts 
USE dosEvBack;

-- Insertar Roles
INSERT INTO Roles (nombre) VALUES ('Administrador');
INSERT INTO Roles (nombre) VALUES ('Organizador');
INSERT INTO Roles (nombre) VALUES ('Usuario');

-- Insertar Usuarios
INSERT INTO Usuarios (username, nombre, email, ubicacion, contraseniia)
VALUES ('zaragozano1', 'Carlos Zaragoza', 'carlos@local.com', 'Zaragoza, España', 'clave123');
INSERT INTO Usuarios (username, nombre, email, ubicacion, contraseniia)
VALUES ('localcomunidad', 'Ana Comunidad', 'ana@local.com', 'Zaragoza, España', 'clave456');

-- Insertar Categorías de Eventos
INSERT INTO CategoriasEventos (nombre) VALUES ('Cultural');
INSERT INTO CategoriasEventos (nombre) VALUES ('Fiesta Popular');
INSERT INTO CategoriasEventos (nombre) VALUES ('Jornada');

-- Insertar Categorías de Productos
INSERT INTO CategoriasProductos (nombre) VALUES ('Arte y Cultura');
INSERT INTO CategoriasProductos (nombre) VALUES ('Artesanía Local');
INSERT INTO CategoriasProductos (nombre) VALUES ('Recuerdos');

-- Insertar Temáticas
INSERT INTO Tematica (nombre) VALUES ('Agenda Local Autogestionada');
INSERT INTO Tematica (nombre) VALUES ('Difusión Comunitaria');
INSERT INTO Tematica (nombre) VALUES ('Participación Ciudadana');

-- Insertar Organizador
INSERT INTO Organizador (nombre, ubicacion, descripcion, enlace, email, contrasenia, telefono, idRol)
VALUES ('ZaragozaConecta', 'Zaragoza, España', 'Organizador de eventos y actividades locales autogestionados, promoviendo la comunicación de colectivos y pequeños comercios.', 'http://zaragoconecta.es', 'info@zaragoconecta.es', 'orgzarago', '976123456', 2);

-- Insertar Eventos
INSERT INTO Eventos (nombre, descripcion, ubicacion, fecha_inicio, fecha_fin, idTematica, enlace, idCategoria, idOrganizador)
VALUES ('Feria de Artesanía Zaragoza', 'Feria gratuita que reúne a artesanos locales para difundir productos culturales y artesanales en la ciudad.', 'Plaza del Pilar, Zaragoza, España', '2025-06-15 10:00', '2025-06-15 18:00', 1, 'http://zaragoconecta.es/feriaartesanias', 1, 1);
INSERT INTO Eventos (nombre, descripcion, ubicacion, fecha_inicio, fecha_fin, idTematica, enlace, idCategoria, idOrganizador)
VALUES ('Jornada de Participación Ciudadana', 'Jornada de varios días dedicada a la discusión, el debate y la implicación en temas locales.', 'Centro de Convenciones, Zaragoza, España', '2025-07-20 09:00', '2025-07-22 17:00', 3, 'http://zaragoconecta.es/jornada', 3, 1);
INSERT INTO Eventos (nombre, descripcion, ubicacion, fecha_inicio, fecha_fin, idTematica, enlace, idCategoria, idOrganizador)
VALUES ('Fiesta Popular de Zaragoza', 'Fiesta local con música, comida y actividades para todos los públicos, fomentando el tejido social.', 'Casco Histórico, Zaragoza, España', '2025-08-05 18:00', '2025-08-06 02:00', 2, 'http://zaragoconecta.es/fiestapopular', 2, 1);

-- Insertar Comentarios
INSERT INTO Comentarios (idUsuario, idEvento, comentario)
VALUES (1, 1, 'Gran oportunidad para conocer el talento local y apoyar a los artesanos.');
INSERT INTO Comentarios (idUsuario, idEvento, comentario)
VALUES (2, 2, 'Una jornada inspiradora que fortaleció la participación ciudadana en nuestra comunidad.');

-- Insertar Posts
INSERT INTO Posts (idUsuario, titulo, contenido)
VALUES (1, 'Impulso a la cultura local', 'La feria de artesanía es un ejemplo de cómo nuestra agenda promueve la cultura y el trabajo artesanal.');
INSERT INTO Posts (idUsuario, titulo, contenido)
VALUES (2, 'Participación ciudadana en acción', 'La jornada de participación ciudadana fue un éxito en fomentar el debate y la colaboración en Zaragoza.');

-- Insertar Productos
INSERT INTO Productos (nombre, descripcion, ubicacion, imagen, idUsuario, idCategoria)
VALUES ('Libro de Tradiciones Aragonesas', 'Recopilación de recetas y leyendas locales, ideal para conocer la cultura de Aragón.', 'Librería Central, Zaragoza', 'libro_tradiciones.jpg', 1, 1);
INSERT INTO Productos (nombre, descripcion, ubicacion, imagen, idUsuario, idCategoria)
VALUES ('Artesanía en Barro', 'Pieza única de artesanía local, perfecta para decorar y llevar un pedazo de Zaragoza a casa.', 'Taller Artesanal, Zaragoza', 'artesania_barro.jpg', 2, 2);

