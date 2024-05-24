USE master;
GO

DROP DATABASE IF EXISTS bd_ventas_ds505;
GO

CREATE DATABASE bd_ventas_ds505;
GO

USE bd_ventas_ds505;
GO

CREATE TABLE tb_personal (
    dni CHAR(8) NOT NULL PRIMARY KEY,
    ap_paterno VARCHAR(25) NOT NULL,
    ap_materno VARCHAR(25) NOT NULL,
    nombre VARCHAR(25) NOT NULL,
    genero CHAR(1),
    fecha_nacimiento DATE,
    sueldo FLOAT
);
GO

CREATE TABLE tb_categoria(
    codigo_categoria CHAR(5) NOT NULL PRIMARY KEY,
    categoria VARCHAR(30) NOT NULL
);
GO

-- INSERTADO DE DATOS EN CATEGORIA
INSERT INTO tb_categoria VALUES
    ('CAT01', 'Electrónicos'),
    ('CAT02', 'Ropa'),
    ('CAT03', 'Hogar');
GO

-- LISTADO DE LA TABLA CATEGORIA
SELECT * FROM tb_categoria;
GO

CREATE TABLE tb_marca(
    codigo_marca CHAR(5) PRIMARY KEY,
    marca VARCHAR(30) NOT NULL
);
GO

-- INSERTADO DE LA TABLA MARCA
INSERT INTO tb_marca VALUES
    ('MAR01', 'Samsung'),
    ('MAR02', 'Nike'),
    ('MAR03', 'IKEA');
GO

-- LISTADO DE LA TABLA MARCA
SELECT * FROM tb_marca;
GO

CREATE TABLE tb_producto(
    codigo_producto CHAR(5) PRIMARY KEY,
    producto VARCHAR(40) NOT NULL,
    stock_disponible INT,
    costo FLOAT,
    ganancia FLOAT,
    producto_codigo_marca CHAR(5),
    producto_codigo_categoria CHAR(5),
    FOREIGN KEY(producto_codigo_marca) REFERENCES tb_marca(codigo_marca),
    FOREIGN KEY(producto_codigo_categoria) REFERENCES tb_categoria(codigo_categoria)
);
GO

-- INSERTADO DE DATOS EN LA TABLA PRODUCTO
INSERT INTO tb_producto VALUES
    ('PR001', 'Celular', 100, 250.00, 100.00, 'MAR01', 'CAT01'),
    ('PR002', 'Camisa', 50, 35.00, 15.00, 'MAR02', 'CAT02'),
    ('PR003', 'Mueble', 10, 500.00, 200.00, 'MAR03', 'CAT03');
GO

-- LISTADO DE DATOS DE LA TABLA PRODUCTO
SELECT * FROM tb_producto;
GO

SET DATEFORMAT 'dmy';
GO

insert into tb_personal values
	('75607434', 'Villegas', 'Mozo', 'Aldair', 'M', '19-01-2005', 3521.74),
	('34854565', 'Ramos', 'Lopez', 'Ericka', 'F', '20-11-2002', 1000.74),
	('34248631', 'Flores', 'Alvarez', 'Rosa', 'F', '30-06-1999', 3000.74),
	('38751152', 'Ruiz', 'Montes', 'Elena', 'F', '22-09-2001', 500.74);
GO

SELECT * FROM tb_personal;
GO

create procedure sp_listar_personal
as
begin
	select * from tb_personal order by ap_paterno asc
end
go

create procedure sp_consultar_personal
	@dni char(8)
as
begin
	select * from tb_personal where dni = @dni
end
go
