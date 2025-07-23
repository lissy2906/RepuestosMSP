USE TiendaRepuestos;

CREATE DATABASE TiendaRepuestos;

CREATE TABLE Categoria 
(
Id INT PRIMARY KEY IDENTITY,
Nombre NVARCHAR(100) NOT NULL
);
INSERT INTO Categoria (Nombre) VALUES
('Motor'),
('Suspensión'),
('Sistema Eléctrico');

CREATE TABLE Proveedor 
(
Id INT PRIMARY KEY IDENTITY,
Nombre NVARCHAR(100),
Telefono NVARCHAR(20),
Direccion NVARCHAR(200),
Correo NVARCHAR(100)
);
INSERT INTO Proveedor (Nombre, Telefono, Direccion, Correo)
VALUES 
('REPUESTOS MARTÍNEZ', '809-555-1234', 'AV. INDEPENDENCIA #45, SANTO DOMINGO', 'CONTACTO@MARTINEZREPUESTOS.COM'),
('AUTOPARTES LOS HERMANOS', '829-777-4567', 'CARRETERA MELLA KM 12, STO. DGO ESTE', 'VENTAS@AUTOHERMANOS.DO'),
('DISTRIBUIDORA EL VOLANTE', '849-888-7890', 'CALLE PRINCIPAL #10, SAN CRISTÓBAL', 'INFO@ELVOLANTE.DO');
;

select * from Proveedor

CREATE TABLE Repuesto
(
Id INT PRIMARY KEY IDENTITY,
Nombre NVARCHAR(100),
CategoriaId INT FOREIGN KEY REFERENCES Categoria(Id),
ProveedorId INT FOREIGN KEY REFERENCES Proveedor(Id),
PrecioVenta DECIMAL(10, 2),
Stock INT
);
INSERT INTO Repuesto (Nombre, CategoriaId, ProveedorId, PrecioVenta, Stock) VALUES
('Bujía NGK', 3, 1, 150.00, 50),
('Amortiguador Trasero', 2, 2, 1200.00, 20),
('Filtro de Aceite', 1, 3, 300.00, 100);

SELECT * FROM Repuesto;


CREATE TABLE Cliente 
(
Id INT PRIMARY KEY IDENTITY,
Nombre NVARCHAR(100),
Telefono NVARCHAR(20),
Correo NVARCHAR(100),
Direccion NVARCHAR(150)
);

ALTER TABLE Cliente
ALTER COLUMN Nombre NVARCHAR(10) NOT NULL;

ALTER TABLE Cliente
ALTER COLUMN Telefono NVARCHAR(20) NOT NULL;

ALTER TABLE Cliente
ALTER COLUMN Correo NVARCHAR(100) NOT NULL;

ALTER TABLE Cliente
ALTER COLUMN Direccion NVARCHAR(150) NOT NULL;


select * from Cliente

INSERT INTO Cliente (Nombre, Telefono, Correo, Direccion)
VALUES ('Juan Pérez', '809-555-1234', 'juanperez@mail.com', 'Av. Independencia #45'),
('Ana Rodríguez', '829-555-6789', 'ana.rodriguez@mail.com', 'Calle Duarte #12'),
('Carlos Martínez', '849-555-4321', 'carlos.martinez@mail.com', 'Los Prados, Santo Domingo');


CREATE TABLE Venta 
(
Id INT PRIMARY KEY IDENTITY,
Cliente NVARCHAR (20),
Fecha DATETIME,
ClienteId INT FOREIGN KEY REFERENCES Cliente(Id),
Total DECIMAL(10, 2)
);

INSERT INTO Venta (Cliente, Fecha, ClienteId, Total)
VALUES ('YEISON POLANCO', '2025-07-22 10:30:00', 1, 4500.00),
('LISSENNY MEJÍA', '2025-07-21 14:15:00', 2, 2375.50),
('GREISY MARTÍNEZ', '2025-07-20 09:45:00', 3, 1199.99);
 
 select * from Venta


CREATE TABLE DetalleVenta 
(
Id INT PRIMARY KEY IDENTITY,
VentaId INT FOREIGN KEY REFERENCES Venta(Id),
RepuestoId INT FOREIGN KEY REFERENCES Repuesto(Id),
Cantidad INT,
PrecioUnitario DECIMAL(10, 2)
);
INSERT INTO DetalleVenta (VentaId, RepuestoId, Cantidad, PrecioUnitario) VALUES
(1, 2, 1, 1200.00),
(2, 1, 1, 150.00),
(3, 3, 2, 300.00);


SELECT 
    V.Id AS VentaID,
    C.Nombre AS Cliente,
    V.Fecha,
    R.Nombre AS Repuesto,
    DV.Cantidad,
    DV.PrecioUnitario,
    (DV.Cantidad * DV.PrecioUnitario) AS SubTotal,
    V.Total AS TotalVenta
FROM Venta V
JOIN Cliente C ON V.ClienteId = C.Id
JOIN DetalleVenta DV ON DV.VentaId = V.Id
JOIN Repuesto R ON DV.RepuestoId = R.Id
ORDER BY V.Fecha DESC;

SELECT * FROM Repuesto
