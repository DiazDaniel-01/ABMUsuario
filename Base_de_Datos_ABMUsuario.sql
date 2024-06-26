CREATE DATABASE DBUsuario

USE DBUsuario

CREATE TABLE Usuario (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
	Apellido VARCHAR(100) NOT NULL,
    Correo VARCHAR(100) NOT NULL UNIQUE,
    Contraseņa VARCHAR(200) NOT NULL,
	Activo bit DEFAULT 1 ,
);

CREATE PROCEDURE sp_Listar
as
begin
	select * from Usuario
	end



CREATE PROCEDURE sp_Obtener(
	@IdUsuario int
)
as
begin
	select * from Usuario where IdUsuario = @IdUsuario
	end



CREATE PROCEDURE sp_Guardar(
@Nombre varchar(100),
@Apellido varchar(100),
@Correo varchar(100),
@Contraseņa varchar(200),
@Activo bit
)
as
begin
	insert into Usuario(Nombre,Apellido,Correo,Contraseņa,Activo) values (@Nombre,@Apellido,@Correo,@Contraseņa,@Activo)
end



CREATE PROCEDURE sp_Editar(
@IdUsuario int,
@Nombre varchar(100),
@Apellido varchar(100),
@Correo varchar(100),
@Contraseņa varchar(200),
@Activo bit
)
as
begin
	update Usuario set Nombre = @Nombre, Apellido = @Apellido, Correo = @Correo, Contraseņa = @Contraseņa, Activo = @Activo where IdUsuario = @IdUsuario
end

CREATE PROCEDURE sp_Eliminar(
@IdUsuario int
)
as
begin
	delete from Usuario where IdUsuario = @IdUsuario
end

select * from Usuario