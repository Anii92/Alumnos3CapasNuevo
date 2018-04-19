create procedure getAllAlumnos
as
begin
	begin try
		declare @transactionName varchar(20);
		select @transactionName = 'getAllAlumnosTransaction';
		begin transaction @transactionName
			select *
			from dbo.Alumnos
		commit transaction @transactionName;
	end try
	begin catch
		rollback;
	end catch
end