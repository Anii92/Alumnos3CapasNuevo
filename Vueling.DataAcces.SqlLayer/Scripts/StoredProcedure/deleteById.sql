create procedure deleteByIfd(
	@Id int
)
as
begin
	declare @transactionName varchar(20);
	select @transactionName = 'deleteByIdTransaction';
	begin try
		begin transaction @transactionName;
		delete from dbo.Alumnos
		where Guid = @Id;
		commit transaction @transactionName;
	end try
	begin catch
		rollback;
	end catch
	
end
go