USE jde_prod;
GO

SELECT *
FROM sys.objects
WHERE type_desc = 'SQL_STORED_PROCEDURE' AND name = 'pr_CA_GetRelatedAddress';
