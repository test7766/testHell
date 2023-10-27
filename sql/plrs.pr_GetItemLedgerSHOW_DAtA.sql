USE [jde_prod]
GO

DECLARE	@RC		int
DECLARE	@ITM	int
DECLARE	@MCU	char (12)
DECLARE	@LOCN	char(20)
DECLARE	@LOTN	char(30)

		

EXECUTE @RC = [plrs].[pr_GetItemLedger]
		@ITM = 5886,
		@MCU =  "       01LA1",
		@LOCN = "3LC  1 4            ",
		@LOTN = 202308102497             
GO
