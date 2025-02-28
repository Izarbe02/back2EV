-- Creación de la base de datos
CREATE DATABASE dosEvBack;
USE dosEvBack;

-- Tabla Roles
CREATE TABLE Roles (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL
);

-- Tabla Usuarios
CREATE TABLE Usuarios (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(50) UNIQUE NOT NULL,
    nombre NVARCHAR(50) NOT NULL,
    email NVARCHAR(50) UNIQUE,
    ubicacion NVARCHAR(255),
    contrasenia NVARCHAR(255) NOT NULL,
    idRol INT NOT NULL,
    FOREIGN KEY (idRol) REFERENCES Roles(ID) ON DELETE CASCADE
);

-- Tabla Categorías de Eventos
CREATE TABLE CategoriaEvento (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL UNIQUE
);

-- Tabla Categorías de Productos
CREATE TABLE CategoriaProducto (
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
    enlace NVARCHAR(255),
    idOrganizador INT NOT NULL,
    FOREIGN KEY (idOrganizador) REFERENCES Organizador(ID) ON DELETE CASCADE
);

-- Tabla Intermedia: Eventos_Tematica (N-M)
CREATE TABLE Eventos_Tematica (
    idEvento INT NOT NULL,
    idTematica INT NOT NULL,
    PRIMARY KEY (idEvento, idTematica),
    FOREIGN KEY (idEvento) REFERENCES Eventos(ID) ON DELETE CASCADE,
    FOREIGN KEY (idTematica) REFERENCES Tematica(ID) ON DELETE CASCADE
);

-- Tabla Intermedia: Eventos_Categoria (N-M)
CREATE TABLE Eventos_Categoria (
    idEvento INT NOT NULL,
    idCategoria INT NOT NULL,
    PRIMARY KEY (idEvento, idCategoria),
    FOREIGN KEY (idEvento) REFERENCES Eventos(ID) ON DELETE CASCADE,
    FOREIGN KEY (idCategoria) REFERENCES CategoriaEvento(ID) ON DELETE CASCADE
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
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(ID) ON DELETE CASCADE
);

-- Tabla Intermedia: Productos_Categoria (N-M)
CREATE TABLE Productos_Categoria (
    idProducto INT NOT NULL,
    idCategoria INT NOT NULL,
    PRIMARY KEY (idProducto, idCategoria),
    FOREIGN KEY (idProducto) REFERENCES Productos(ID) ON DELETE CASCADE,
    FOREIGN KEY (idCategoria) REFERENCES CategoriaProducto(ID) ON DELETE CASCADE
);



--Inserts 
USE dosEvBack;

-- Insertar Roles
-- Habilitar la inserción en columnas IDENTITY
SET IDENTITY_INSERT Roles ON;

-- Insertar Roles asegurando que Administrador sea 1, Organizador 2 y Usuario 3
INSERT INTO Roles (ID, nombre) VALUES (1, 'Administrador');
INSERT INTO Roles (ID, nombre) VALUES (2, 'Organizador');
INSERT INTO Roles (ID, nombre) VALUES (3, 'Usuario');
-- Deshabilitar la inserción en columnas IDENTITY
SET IDENTITY_INSERT Roles OFF;

-- Insertar Usuarios
-- Campos: username (NVARCHAR(50), UNIQUE, NOT NULL), nombre (NVARCHAR(50), NOT NULL), 
-- email (NVARCHAR(50), UNIQUE), ubicacion (NVARCHAR(255)), contrasenia (NVARCHAR(255), NOT NULL)
INSERT INTO Usuarios (ID, username, nombre, email, ubicacion, contrasenia, idRol) 
VALUES 
-- Administradores (idRol = 1)
(1, 'admin1', 'Administrador Principal', 'admin1@agendazgz.com', 'Zaragoza, España', 'claveadmin1', 1),
(2, 'admin2', 'Administrador Secundario', 'admin2@agendazgz.com', 'Zaragoza, España', 'claveadmin2', 1),
--(idRol = 3)
(3, 'usuario1', 'Maria Perez', 'maria@agendazgz.com', 'Zaragoza', 'claveusuario1', 3),
(4, 'usuario2', 'Jorge Lopez', 'jorge@agendazgz.com', 'Zaragoza', 'claveusuario2', 3),
(5, 'usuario3', 'Laura Garcia', 'laura@agendazgz.com', 'Zaragoza', 'claveusuario3', 3),
(6, 'usuario4', 'Carlos Fernandez', 'carlos@agendazgz.com', 'España', 'claveusuario4', 3),
(7, 'usuario5', 'Ana Martínez', 'ana@agendazgz.com', 'Zaragoza', 'claveusuario5', 3);


-- Insertar Categorías de Eventos
INSERT INTO CategoriaEvento (nombre) VALUES ('Cultural');
INSERT INTO CategoriaEvento (nombre) VALUES ('Fiesta Popular');
INSERT INTO CategoriaEvento (nombre) VALUES ('Jornada');

-- Insertar Categorías de Productos
INSERT INTO CategoriaProducto (nombre) VALUES ('Arte y Cultura');
INSERT INTO CategoriaProducto (nombre) VALUES ('Artesanía Local');
INSERT INTO CategoriaProducto (nombre) VALUES ('Recuerdos');

-- Insertar Temáticas
INSERT INTO Tematica (ID, nombre) VALUES (1, 'Anticarcelario');
INSERT INTO Tematica (ID, nombre) VALUES (2, 'Arte y Cultura Comunitaria');
INSERT INTO Tematica (ID, nombre) VALUES (3, 'Autogestión Colectiva');
INSERT INTO Tematica (ID, nombre) VALUES (4, 'Feminismo y Diversidad');
INSERT INTO Tematica (ID, nombre) VALUES (5, 'Fiestas Populares');
INSERT INTO Tematica (ID, nombre) VALUES (6, 'Derechos Humanos y Lucha Social');
INSERT INTO Tematica (ID, nombre) VALUES (7, 'Sindicalismo');
INSERT INTO Tematica (ID, nombre) VALUES (8, 'Reparación y Autogestión');
INSERT INTO Tematica (ID, nombre) VALUES (9, 'Música y Cultura');
INSERT INTO Tematica (ID, nombre) VALUES (10, 'Eventos Deportivos');
INSERT INTO Tematica (ID, nombre) VALUES (11, 'Antirrepresión');
INSERT INTO Tematica (ID, nombre) VALUES (12, 'Educación Alternativa');
INSERT INTO Tematica (ID, nombre) VALUES (13, 'Limpieza y Cuidados');
INSERT INTO Tematica (ID, nombre) VALUES (14, 'Luchas Internacionalistas');
INSERT INTO Tematica (ID, nombre) VALUES (15, 'Hacktivismo y Ciberseguridad');
INSERT INTO Tematica (ID, nombre) VALUES (16, 'Economía Social y Solidaria');
INSERT INTO Tematica (ID, nombre) VALUES (17, 'Manifestaciones');
INSERT INTO Tematica (ID, nombre) VALUES (18, 'Presentaciones y Charlas');
INSERT INTO Tematica (ID, nombre) VALUES (19, 'Participación Ciudadana');
INSERT INTO Tematica (ID, nombre) VALUES (20, 'Ecologismo y Medio Ambiente');


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



--DROP TABLE

DROP TABLE Productos;
DROP TABLE Posts;
DROP TABLE Comentarios;
DROP TABLE Eventos;
DROP TABLE Organizador;
DROP TABLE Tematica;
DROP TABLE CategoriaProducto;
DROP TABLE CategoriaEvento;
DROP TABLE Roles;
DROP TABLE Usuarios;