create procedure addAlumno(
	@Nombre nvarchar(50),
	@Apellidos nvarchar(50),
	@Dni nvarchar(50),
	@FechaNacimiento datetime,
	@Edad int,
	@FechaCreacion datetime,
	@Guid nvarchar(50))
as
begin
	declare @transactionName varchar(20);
	select @transactionName='InsertAlumnoTransaction';
	begin try
		begin transaction @transactionName;
		set identity_insert dbo.Alumnos off;
		insert into dbo.Alumnos (Nombre, Apellidos, Dni, FechaNacimiento, Edad, FechaCreacion, Guid)
		values (@Nombre, @Apellidos, @Dni, @FechaNacimiento, @Edad, @FechaCreacion, @Guid);
		commit transaction @transactionName;
	end try
	begin catch
		rollback
	end catch
end;
go