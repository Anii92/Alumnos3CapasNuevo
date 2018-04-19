USE master
GO
IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'Vueling3CapasDB'
)
CREATE DATABASE Vueling3CapasDB
ON PRIMARY(
    name='Vueling3CapasDB_Primary',
	filename='C:\CursoSqlServer2017\Vueling3Capas\MDF\Vueling3CapasDB.mdf',
	size=4MB,
	maxsize=10MB,
	filegrowth=1MB),
FILEGROUP Vueling3CapasDB_FG1
  ( NAME = 'Vueling3CapasDB_FG1_Dat1',
    FILENAME =
       'C:\CursoSqlServer2017\Vueling3Capas\NDF\MyDB_FG1_1.ndf',
    SIZE = 1MB,
    MAXSIZE=10MB,
    FILEGROWTH=1MB),
  ( NAME = 'Vueling3CapasDB_FG1_Dat2',
    FILENAME =
       'C:\CursoSqlServer2017\Vueling3Capas\NDF\MyDB_FG1_2.ndf',
    SIZE = 1MB,
    MAXSIZE=10MB,
    FILEGROWTH=1MB)
LOG ON(
	name=Vueling3CapasDB_log,
	filename='C:\CursoSqlServer2017\Vueling3Capas\LDF\FlyWayDB_log.ldf',
	size=2MB, 
	maxsize=2MB,
	filegrowth=0MB
	)
	COLLATE modern_spanish_ci_as
GO