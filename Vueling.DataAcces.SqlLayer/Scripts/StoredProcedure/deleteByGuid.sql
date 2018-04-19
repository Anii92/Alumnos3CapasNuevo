create procedure deleteByGuid(
	@Guid varchar(50)
)
as
begin
	declare @transactionName varchar(20);
	select @transactionName = 'deleteByGuidTransaction';
	begin try
		begin transaction @transactionName;
		delete from dbo.Alumnos
		where Guid = @Guid;
		commit transaction @transactionName;
	end try
	begin catch
		rollback;
	end catch
	
end
go