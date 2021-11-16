if(DB_ID(N'$(DatabaseName)') is null)
Begin
Print N'Start Process $(DatabaseName)............. Creation';
End
Go
If(DB_ID(N'$(DatabaseName)') is null)
Begin
Create database [$(DatbaseName)];
Print N'End Process $(DatabaseName)'
End