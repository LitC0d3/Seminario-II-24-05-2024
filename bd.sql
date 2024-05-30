USE master;
GO

DROP DATABASE IF EXISTS seminario;
GO

CREATE DATABASE seminario;
GO

USE seminario;
GO

-- Crear la tabla Clientes
CREATE TABLE Clientes (
    ID_Cliente INT PRIMARY KEY,
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50),
    Direccion NVARCHAR(100),
    CorreoElectronico NVARCHAR(100),
    Telefono NVARCHAR(20)
);
GO

-- Insertar datos de ejemplo en la tabla Clientes
INSERT INTO Clientes (ID_Cliente, Nombre, Apellido, Direccion, CorreoElectronico, Telefono)
VALUES (1, 'Juan', 'Perez', 'Calle 123', 'juan@example.com', '123456789');
GO

-- Crear la tabla Productos
CREATE TABLE Productos (
    ID_Producto INT PRIMARY KEY,
    NombreProducto NVARCHAR(100),
    Descripcion NVARCHAR(255),
    Precio DECIMAL(10, 2),
    Stock INT
);
GO

-- Insertar datos de ejemplo en la tabla Productos
INSERT INTO Productos (ID_Producto, NombreProducto, Descripcion, Precio, Stock)
VALUES (1, 'Producto 1', 'Descripción del producto 1', 10.50, 100);
GO

-- Crear la tabla Empleados
CREATE TABLE Empleados (
    ID_Empleado INT PRIMARY KEY,
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50),
    Cargo NVARCHAR(50),
    Salario DECIMAL(10, 2),
    FechaContratacion DATE
);
GO

-- Insertar datos de ejemplo en la tabla Empleados
INSERT INTO Empleados (ID_Empleado, Nombre, Apellido, Cargo, Salario, FechaContratacion)
VALUES (1, 'Pedro', 'Gomez', 'Gerente', 3000.00, '2020-01-01');
GO

-- Crear la tabla Ventas
CREATE TABLE Ventas (
    ID_Venta INT PRIMARY KEY,
    ID_Cliente INT,
    FechaVenta DATE,
    TotalVenta DECIMAL(10, 2),
    MetodoPago NVARCHAR(50)
);
GO

-- Insertar datos de ejemplo en la tabla Ventas
INSERT INTO Ventas (ID_Venta, ID_Cliente, FechaVenta, TotalVenta, MetodoPago)
VALUES (1, 1, '2024-05-28', 50.00, 'Tarjeta');
GO

-- Crear la tabla Proveedores
CREATE TABLE Proveedores (
    ID_Proveedor INT PRIMARY KEY,
    NombreEmpresa NVARCHAR(100),
    Direccion NVARCHAR(100),
    CorreoElectronico NVARCHAR(100),
    Telefono NVARCHAR(20)
);
GO

-- Insertar datos de ejemplo en la tabla Proveedores
INSERT INTO Proveedores (ID_Proveedor, NombreEmpresa, Direccion, CorreoElectronico, Telefono)
VALUES (1, 'Proveedor A', 'Avenida 456', 'proveedor@example.com', '987654321');
GO

-- Procedimiento almacenado para listar clientes
CREATE PROCEDURE sp_ListarClientes
AS
BEGIN
    SELECT * FROM Clientes;
END;
GO

-- Procedimiento almacenado para consultar un cliente por ID
CREATE PROCEDURE sp_ConsultarClientePorID
    @ID_Cliente INT
AS
BEGIN
    SELECT * FROM Clientes WHERE ID_Cliente = @ID_Cliente;
END;
GO

-- Procedimiento almacenado para listar productos
CREATE PROCEDURE sp_ListarProductos
AS
BEGIN
    SELECT * FROM Productos;
END;
GO

-- Procedimiento almacenado para consultar un producto por ID
CREATE PROCEDURE sp_ConsultarProductoPorID
    @ID_Producto INT
AS
BEGIN
    SELECT * FROM Productos WHERE ID_Producto = @ID_Producto;
END;
GO

-- Procedimiento almacenado para listar empleados
CREATE PROCEDURE sp_ListarEmpleados
AS
BEGIN
    SELECT * FROM Empleados;
END;
GO

-- Procedimiento almacenado para consultar un empleado por ID
CREATE PROCEDURE sp_ConsultarEmpleadoPorID
    @ID_Empleado INT
AS
BEGIN
    SELECT * FROM Empleados WHERE ID_Empleado = @ID_Empleado;
END;
GO

-- Procedimiento almacenado para listar ventas
CREATE PROCEDURE sp_ListarVentas
AS
BEGIN
    SELECT * FROM Ventas;
END;
GO

-- Procedimiento almacenado para consultar una venta por ID
CREATE PROCEDURE sp_ConsultarVentaPorID
    @ID_Venta INT
AS
BEGIN
    SELECT * FROM Ventas WHERE ID_Venta = @ID_Venta;
END;
GO

-- Procedimiento almacenado para listar proveedores
CREATE PROCEDURE sp_ListarProveedores
AS
BEGIN
    SELECT * FROM Proveedores;
END;
GO

-- Procedimiento almacenado para consultar un proveedor por ID
CREATE PROCEDURE sp_ConsultarProveedorPorID
    @ID_Proveedor INT
AS
BEGIN
    SELECT * FROM Proveedores WHERE ID_Proveedor = @ID_Proveedor;
END;
GO
