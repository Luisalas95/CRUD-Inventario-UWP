create database PruebaTecnicaUWP
use PruebaTecnicaUWP
go

create table Inventario(
Id int identity(1,1),
NombreProducto varchar(150)not null,
Categoria varchar(50) ,
Cantidad int not null,
Precio decimal not null
)
go
insert into Inventario values
('Monitor 22 Pulgadas Curvo ','Monitores',10220,125000.0),
('Mouse','Perifericos',21065,14999.99),
('Ryzen 5 5600','Procesadores',9053,88500.99)

select *from Inventario
-----------------------------------------------------------
Alter PROCEDURE InsertarInventario
    @NombreProducto VARCHAR(150),
    @Categoria VARCHAR(50),
    @Cantidad INT,
    @Precio DECIMAL
AS
BEGIN
    BEGIN TRY
        
        BEGIN TRANSACTION;

        INSERT INTO Inventario
        VALUES (@NombreProducto, @Categoria, @Cantidad, @Precio);

        COMMIT;
    END TRY
    BEGIN CATCH
        
        ROLLBACK;

          THROW;
    END CATCH;
END;

	
exec InsertarInventario 'test2',null,1250,99999.99
select *from Inventario

-----------------------------------------------------------

create procedure BorrarInventario
	@NombreProducto varchar(150)
	as
	begin
    declare @id int

    select @id = id
    from Inventario
    where NombreProducto = @NombreProducto

  
    if @id IS NOT NULL
    begin
        delete from Inventario
        where id = @id
    end
end


exec BorrarInventario 'esvfreb'
select *from Inventario

----------------------------------------------------------

create procedure ActualizarInventario
@NombreProducto varchar(150),
@Categoria varchar (50),
@Cantidad int,
@Precio decimal
	as
begin
    declare @Id int

    select @Id = Id
    from Inventario
    where NombreProducto = @NombreProducto

  
    if @id IS NOT NULL
    begin
        update Inventario
        set NombreProducto=@NombreProducto,
			Categoria=@Categoria,
			Cantidad = @Cantidad,
			Precio=@Precio
			
        where Id = @Id
    end
end

exec ActualizarInventario  'Ryzen 5 5600','Procesadores',9000,88499.99
select *from Inventario
--------------------------------------------------------------