create procedure getByGuid(
	@Guid nvarchar(20)
)
as
begin
	begin try
		declare @transactionName nvarchar(20);
		select @transactionName = 'getByGuidTransaction';
		begin transaction @transactionName
			select *
			from dbo.Alumnos
			where Guid = @Guid
		commit transaction @transactionName;
	end try
	begin catch
		rollback;
	end catch
end