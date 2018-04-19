create procedure getById(
	@Id nvarchar(20)
)
as
begin
	begin try
		declare @transactionName nvarchar(20);
		select @transactionName = 'getByIdTransaction';
		begin transaction @transactionName
			select *
			from dbo.Alumnos
			where Guid = @Id
		commit transaction @transactionName;
	end try
	begin catch
		rollback;
	end catch
end