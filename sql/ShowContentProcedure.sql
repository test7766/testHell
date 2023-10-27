USE MinimalApiUserDB;
GO

DECLARE @ProcedureName NVARCHAR(128) = 'spUser_Insert'; 
SELECT 
    m.definition AS [СодержимоеПроцедуры]
FROM sys.objects o
INNER JOIN sys.sql_modules m ON m.object_id = o.object_id
WHERE o.type_desc = 'SQL_STORED_PROCEDURE'
    AND o.name = @ProcedureName;