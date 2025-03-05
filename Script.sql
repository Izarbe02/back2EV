
-- CREACIÓN DE LA BASE DE DATOS
CREATE DATABASE dosEvBack;
USE dosEvBack;

-- CREACIÓN DE TABLAS

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

-- Tabla Organizadores
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
    FOREIGN KEY (idEvento) REFERENCES Eventos(ID) ON DELETE NO ACTION 
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
   -- idCategoria NVARCHAR(255) NOT NULL,
    idOrganizador INT NOT NULL,
    FOREIGN KEY (idOrganizador) REFERENCES Organizador(ID) ON DELETE CASCADE
);

-- Tabla Intermedia: Productos_Categoria
CREATE TABLE Productos_Categoria (
    idProducto INT NOT NULL,
    idCategoria INT NOT NULL,
    PRIMARY KEY (idProducto, idCategoria),
    FOREIGN KEY (idProducto) REFERENCES Productos(ID) ON DELETE CASCADE,
    FOREIGN KEY (idCategoria) REFERENCES CategoriaProducto(ID) ON DELETE CASCADE
);

-- INSERCIÓN DE DATOS

-- Insertar Roles
SET IDENTITY_INSERT Roles ON;
INSERT INTO Roles (ID, nombre) VALUES 
(1, 'Administrador'),
(2, 'Organizador'),
(3, 'Usuario');
SET IDENTITY_INSERT Roles OFF;

-- Insertar Usuarios
SET IDENTITY_INSERT Usuarios ON;
INSERT INTO Usuarios (ID, username, nombre, email, ubicacion, contrasenia, idRol)
VALUES
(1, 'admin1', 'Administrador Principal', 'admin1@agendazgz.com', 'Zaragoza, España', 'claveadmin1', 1),
(2, 'admin2', 'Administrador Secundario', 'admin2@agendazgz.com', 'Zaragoza, España', 'claveadmin2', 1),
(3, 'usuario1', 'Maria Perez', 'maria@agendazgz.com', 'Zaragoza', 'claveusuario1', 3),
(4, 'usuario2', 'Jorge Lopez', 'jorge@agendazgz.com', 'Zaragoza', 'claveusuario2', 3),
(5, 'usuario3', 'Laura Garcia', 'laura@agendazgz.com', 'Zaragoza', 'claveusuario3', 3),
(6, 'usuario4', 'Carlos Fernandez', 'carlos@agendazgz.com', 'España', 'claveusuario4', 3),
(7, 'usuario5', 'Ana Martínez', 'ana@agendazgz.com', 'Zaragoza', 'claveusuario5', 3);
SET IDENTITY_INSERT Usuarios OFF;

-- Insertar Organizadores

SET IDENTITY_INSERT Organizador ON;
INSERT INTO Organizador (ID, nombre, ubicacion, descripcion, enlace, email, contrasenia, telefono, idRol) VALUES 
(1, 'ZaragozaConecta', 'Zaragoza, España', 'Organizador de eventos comunitarios', 'https://i.pinimg.com/736x/48/1e/ea/481eea34012312eb2c70a22a7b811ff0.jpg', 'info@zaragoconecta.es', 'claveorg1', '976123456', 2),
(2, 'Colectivo Carlista', 'Zaragoza, España', 'Organización Carlista autogestionada', 'https://i.pinimg.com/736x/20/72/0d/20720da22007b96922129c7fd7bd6848.jpg', 'contacto@feminismo.es', 'claveorg2', '976789123', 2),
(3, 'Asamblea de Vecinos', 'Zaragoza, España', 'Colectivo vecinal que organiza actividades culturales y de barrio.', 'https://i.pinimg.com/736x/f1/0a/38/f10a3833dad60e72d76240763108c899.jpg', 'vecinos@zgz.com', 'claveorg3', '976456789', 2),
(4, 'Red de Apoyo Mutuo', 'Zaragoza, España', 'Grupo que organiza encuentros y charlas sobre autogestión.', 'https://i.pinimg.com/736x/5e/66/3d/5e663d55ee7de7adaa8931a692ff5d23.jpg', 'apoyomutuo@zgz.com', 'claveorg4', '976654321', 2),
(5, 'CSO La Fábrica de Chocolate', 'Zaragoza, España', 'Centro social autogestionado que organiza múltiples actividades culturales, políticas y sociales.', 'https://www.aragondigital.es/media/aragondigital/images/2024/11/13/2024111311403021287.jpg', 'contacto@lafabricadechocolate.es', 'claveorg5', '976333111', 2),
(6, 'Arrebato', 'Zaragoza, España', 'Sala de conciertos autogestionada con programación cultural y artística independiente.', 'https://cdn.aragonmusical.com/wp-content/uploads/2016/09/Viva-Belgrado-660x330.jpg', 'contacto@arrebato.es', 'claveorg6', '976222888', 2),
(7, 'Kike Mur', 'Zaragoza, España', 'Centro social autogestionado con actividades comunitarias, culturales y sociales.', 'https://pbs.twimg.com/media/DbJg9bOXkAA-Qgi.jpg', 'contacto@kikemur.es', 'claveorg7', '976111777', 2),
(8, 'Centro Social Librería La Pantera Rossa', 'Zaragoza, España', 'Centro social librería. Pensamiento crítico+autoorganización', 'https://www.lapanterarossa.net/sites/default/files/inline-images/colabora.jpg', 'contacto@pantera.es', 'claveorg8', '976111777', 2);
SET IDENTITY_INSERT Organizador OFF;



-- Insertar Posts
INSERT INTO Posts (idUsuario, titulo, contenido)
VALUES (1, 'Impulso a la cultura local', 'La feria de artesanía es un ejemplo de cómo nuestra agenda promueve la cultura y el trabajo artesanal.'),
(2, 'Participación ciudadana en acción', 'La jornada de participación ciudadana fue un éxito en fomentar el debate y la colaboración en Zaragoza.');

-- Insertar Categorías de Eventos
INSERT INTO CategoriaEvento (nombre) VALUES 
('Cultural'),
('Fiesta Popular'),
('Manifestaciones y Protestas'),
('Ecologismo y Medio Ambiente'),
('Derechos Humanos y Luchas Sociales'),
('Feminismo y Diversidad'),
('Música y Cultura DIY'),
('Economía Social y Solidaria'),
('Tecnología y Hacktivismo');

-- Insertar Temáticas
INSERT INTO Tematica (nombre) VALUES 
('Anticarcelario'),
('Arte y Cultura Comunitaria'),
('Autogestión Colectiva'),
('Feminismo y Diversidad'),
('Fiestas Populares'),
('Derechos Humanos y Lucha Social'),
('Sindicalismo'),
('Reparación y Autogestión'),
('Música y Cultura'),
('Eventos Deportivos'),
('Antirrepresión'),
('Educación Alternativa'),
('Limpieza y Cuidados'),
('Luchas Internacionalistas'),
('Hacktivismo y Ciberseguridad'),
('Economía Social y Solidaria'),
('Manifestaciones'),
('Presentaciones y Charlas'),
('Participación Ciudadana'),
('Ecologismo y Medio Ambiente');

-- Insertar Eventos

SET DATEFORMAT YMD;
SET IDENTITY_INSERT Eventos ON;
INSERT INTO Eventos (ID, nombre, descripcion, ubicacion, fecha_inicio, fecha_fin, enlace, idOrganizador)
VALUES 
(1, 'La primera vez que bailamos', 'Exposición de collages de la artista Laura Miqueo.', 'La Pantera Rossa', '2025-02-20 10:00', '2025-03-09 18:00', 'https://zgz.convoca.la/media/1a7cec4dc2aa72605c5ea53e74f80440.jpg', 5),
(2, 'Por unos parques y jardines dignos', 'Concentración por el mantenimiento adecuado de espacios verdes.', 'Plaza Ontonar', '2025-02-28 17:00', '2025-02-28 18:00', 'https://jardiarte.es/wp-content/uploads/2020/01/DSC_2892-1024x576.jpg', 1),
(3, 'Alimentación sana y agricultura ecológica', 'Charla sobre hábitos saludables y sostenibilidad.', 'La Pantera Rossa', '2025-02-28 18:00', '2025-02-28 20:00', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQtPN-55jloKOoRxP5bvF3xCB-RXy8RZMuKvA&s', 5),
(4, 'Cine por la paz: Parar las guerras', 'Proyección de documentales sobre conflictos bélicos y pacifismo.', 'Filmoteca de Zaragoza', '2025-02-28 18:00', '2025-02-28 20:00', 'https://zgz.convoca.la/media/a5231b88663f0b7ff0a267e33493b3ef.jpg', 1),
(5, 'Cadena humana por los seis de Zaragoza', 'Movilización en solidaridad con los seis de Zaragoza.', 'Delegación del Gobierno', '2025-02-28 18:30', '2025-02-28 19:30', 'https://imagenes.heraldo.es/files/image_990_556/uploads/imagenes/2024/02/23/manifestacion-en-apoyo-a-los-6-de-zaragoza-1.jpeg', 1),
(6, 'Concierto: Sal del coche + Muelles', 'Noche de música independiente.', 'A.VV. Arrebato', '2025-02-28 20:00', '2025-02-28 22:00', 'https://f4.bcbits.com/img/a3238194177_65', 6),
(7, 'Facharnaval', 'Vermú carnavalero en apoyo a las radios libres.', 'CSO La Fábrica de Chocolate', '2025-03-01 12:00', '2025-03-01 18:00', 'https://zgz.convoca.la/media/74f90f9792111d83e0b5f526a8be6db4.jpg', 5),
(8, 'Presentación de "Mauro"', 'Novela sobre una de las mayores evasiones carcelarias de Europa.', 'La Pantera Rossa', '2025-03-01 12:00', '2025-03-01 14:00', 'https://www.kulturklik.euskadi.eus/contenidos/creacion/2025020508060060/es_def/images/I.png', 5),
(9, 'Taller: desmontando  + Fiesta', 'Debate y análisis crítico del auge de la extrema derecha.', 'Centro Cultural Socialista La Comuna', '2025-03-01 17:00', '2025-03-01 00:00', 'https://estaticos-cdn.prensaiberica.es/clip/aa9939a3-704c-4c04-a4be-5e7b0514b390_alta-libre-aspect-ratio_default_0.jpg', 1),
(10, 'Cine por la paz 2', 'Segunda jornada de proyección de documentales.', 'Filmoteca de Zaragoza', '2025-03-01 18:00', '2025-03-01 20:00', 'https://www.enjoyzaragoza.es/wp-content/uploads/2022/11/Captura-de-Pantalla-2023-09-18-a-las-10.12.32.png', 1),
(11, 'Concierto Apoyo XXII Marcha Zuera', 'Concierto solidario en apoyo a la marcha anual a la cárcel de Zuera.', 'A.VV. Arrebato', '2025-03-01 20:00', '2025-03-01 22:00', 'https://zgz.convoca.la/media/11711629221f29e8c4786cb75b0f8e9c.jpg', 6),
(12, 'Torneo de ajedrez "Por la paz en Palestina"', 'Competencia amistosa con enfoque en la justicia social.', 'Casa Palestina de Aragón', '2025-03-02 16:00', '2025-03-02 18:00', 'https://images.chesscomfiles.com/uploads/v1/images_users/tiny_mce/AquivaRubinstein/phpVvOvC8.png', 1),
(13, 'Taller de lectura', 'Espacio de lectura y análisis del libro "La llamada" de Leila Guerriero.', 'La Pantera Rossa', '2025-03-03 19:00', '2025-03-03 21:00', 'https://www.lapanterarossa.net/sites/default/files/leilaWeb.png', 5),
(14, 'Charla: disidencias y revolución', 'Conversación sobre  luchas sociales.', 'Unizar, Aula 4.5', '2025-03-06 19:00', '2025-03-06 20:30', 'https://i.pinimg.com/736x/aa/99/11/aa9911cf9c637071e5e05b6a0377c5ec.jpg', 2),
(15, 'Huelga y manifestación estudiantil 7M', 'Marcha por los derechos estudiantiles.', 'Plaza San Francisco', '2025-03-07 12:00', '2025-03-07 14:00', 'https://www.izquierdadiario.es/IMG/jpg/dsc00743.jpg', 1),
(16, 'Concierto: The Cramps + Guiñote de Qontaqto', 'Noche de psichobilleo duro.', 'A.VV. Arrebato', '2025-03-14 20:00', '2025-03-14 22:00', 'https://i.pinimg.com/736x/d4/bd/56/d4bd56d7b80704db0de7fe73d514d0d8.jpg', 6),
(17, 'Presentación del libro "Vértebras"', 'La poeta Pilar Roig Ferreruela presenta su nuevo poemario.', 'La Pantera Rossa', '2025-03-15 12:00', '2025-03-15 14:00', 'https://i.pinimg.com/736x/7d/91/f9/7d91f9a8e58dd6e78b5f953c42535d59.jpg', 5),
(18, 'Asesoría laboral', 'Sesión de asesoramiento gratuito sobre derechos laborales.', 'AAVV Venecia/Torrero', '2025-03-26 18:00', '2025-03-26 20:00', 'https://i.pinimg.com/736x/95/1b/b6/951bb6f192d23834399cb848c2e6bf9b.jpg', 1),
(19, 'Concierto solidario ', 'Evento musical para recaudar fondos.', 'CSP Amapola', '2025-03-29 19:00', '2025-03-29 21:00', 'https://i.pinimg.com/736x/ae/84/50/ae8450303fc703320a0c5691d88d381e.jpg', 6),
(20, 'Concierto Hillbilly Moon Explosion', 'Desde Suiza, The Hillbilly Moon Explosion es una de las bandas europeas de referencia Rockabilly.', 'Arrebato', '2025-03-30 11:00', '2025-03-30 18:00', 'https://i.pinimg.com/736x/8a/08/26/8a0826ee6626197006a4ba847b8c9d37.jpg', 1),
(21, 'Tatu Circus Zgz', 'Festival de tatuajes solidario con eventos culturales.', 'CSO Kike Mur', '2025-05-02 10:00', '2025-05-04 22:00', 'https://zgz.convoca.la/media/0c3d76509349689944ae2778e10d9c8d.jpg', 7),
(22, 'Concierto Benéfico', 'Concierto benéfico para las victimas de la dana', 'Calles de Delicias', '2025-05-09 17:00', '2025-05-09 19:00', 'https://imagenes.heraldo.es/files/image_1920_1080/uploads/imagenes/2024/04/13/cocadictos-con-alma-como-voz-cantante-en-plena-actuacion-durante-la-muestra-de-pop-rock-y-otros-rollos-zaragoza-1984.jpeg', 6),
(23, 'Fiesta del Sol', 'Celebración al aire libre con música y talleres de concienciación ecológica.', 'Parque Emilio Lacambra', '2025-05-10 11:00', '2025-05-10 00:00', 'https://media.istockphoto.com/id/1971980189/es/vector/ilustraci%C3%B3n-vectorial-de-estilo-maravilloso-que-camina-por-el-sol-con-botas-y-muestra-el.jpg?s=612x612&w=0&k=20&c=DFyxdrq485aOr2lKltS1sYQKWSpXynelzMyE0AFRESU=', 5), 
(24, 'Concierto benéfico castores', 'Recaudación de madera para las casas de los castores', 'CDM La Granja', '2025-05-17 09:00', '2025-05-17 19:00', 'https://i.pinimg.com/736x/13/2b/86/132b86a85bbbfe656d30deb9a3e8f0c5.jpg', 1),
(25, 'Jornada solidaria por los osos polares', 'el dinero destinado será para cubitos de hielo', 'CSA La Revuelta', '2025-09-13 12:00', '2025-09-13 23:00', 'https://www.zaragozarebelde.org/wp-content/uploads/2009/04/f_00318.jpg', 1);
SET IDENTITY_INSERT Eventos OFF;

--La conversión del tipo de datos varchar en datetime produjo un valor fuera de intervalo.



-- Insertar Comentarios
INSERT INTO Comentarios (idUsuario, idEvento, comentario)
VALUES (1, 1, 'Gran oportunidad para conocer el talento local y apoyar a los artesanos.'),
(2, 2, 'Una jornada inspiradora que fortaleció la participación ciudadana en nuestra comunidad.');
-- Insertar Productos
INSERT INTO Productos (nombre, descripcion, ubicacion, imagen, idOrganizador)
VALUES 
('Libro de Tradiciones Aragonesas', 'Recopilación de recetas y leyendas locales, ideal para conocer la cultura de Aragón.', 'Librería Central, Zaragoza', 'libro_tradiciones.jpg', 1),
('Artesanía en Barro', 'Pieza única de artesanía local, perfecta para decorar y llevar un pedazo de Zaragoza a casa.', 'Taller Artesanal, Zaragoza', 'artesania_barro.jpg', 2);

--Insert CategoriaProducto
INSERT INTO CategoriaProducto (nombre) VALUES
('Cultural'),
('Fiesta Popular'); -- Agrega otras categorías necesarias

-- Insertar relaciones Productos_Categoria
INSERT INTO Productos_Categoria (idProducto, idCategoria)
VALUES 
(1, 1),  -- "Libro de Tradiciones Aragonesas" -> Categoría "Cultural"
(2, 2);  -- "Artesanía en Barro" -> Categoría "Fiesta 



-- Insertar relaciones Eventos_Categoria
INSERT INTO Eventos_Categoria (idEvento, idCategoria)
VALUES 
-- Cultural
(1, 1), (8, 1), (13, 1), (17, 1), (25, 1),
-- Ecologismo y Medio Ambiente
(2, 6), (3, 6), (23, 6),
-- Derechos Humanos y Luchas Sociales
(4, 7), (5, 7), (10, 7), (12, 7), (20, 7), (24, 7),
-- Fiesta Popular
(7, 3), (22, 3), (25, 3),
-- Feminismo y Diversidad
(9, 4), (14, 4),
-- Música y Cultura DIY
(6, 1), (11, 1), (16, 1), (19, 1), (21, 1),
-- Manifestaciones y Movilizaciones Sociales
(15, 7),
-- Economía Social y Solidaria
(18, 5),
-- Tecnología y Hacktivismo
(21, 5);


-- Insertar relaciones Eventos_Tematica
INSERT INTO Eventos_Tematica (idEvento, idTematica) VALUES
(1, 2),
(8, 2),
(17, 2),
(25, 2),
(2, 8),
(3, 8),
(23, 8),
(4, 7),
(5, 7),
(10, 7),
(12, 7),
(20, 7),
(24, 7),
(6, 9),
(11, 9),
(16, 9),
(19, 9),
(21, 9),
(7, 3),
(22, 3),
(25, 3),
(9, 4),
(14, 4),
(15, 7),
(18, 6),
(21, 5),
(13, 1); -- Evento 13 asignado a "Cultural" para cubrir todos los eventos





--Contingencias -- drops
DROP TABLE IF EXISTS Eventos_Tematica;
DROP TABLE IF EXISTS Eventos_Categoria;
DROP TABLE IF EXISTS Productos_Categoria;
DROP TABLE IF EXISTS Comentarios;
DROP TABLE IF EXISTS Posts;
DROP TABLE IF EXISTS Productos;
DROP TABLE IF EXISTS Eventos;
DROP TABLE IF EXISTS Usuarios;
DROP TABLE IF EXISTS Organizador;
DROP TABLE IF EXISTS Roles;
DROP TABLE IF EXISTS CategoriaEvento;
DROP TABLE IF EXISTS CategoriaProducto;
DROP TABLE IF EXISTS Tematica;