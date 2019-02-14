use KP;
go
CREATE PROCEDURE Export
AS
	SELECT [LOGIN], [PASSWORD], [ACCESS]
	FROM [dbo].[USER]
	FOR XML PATH('user'), ROOT('Users');
	Export;



ALTER PROCEDURE Import
	@xml XML = NULL
AS
Select  @xml  = 
CONVERT(XML,bulkcolumn,2) FROM OPENROWSET(BULK 'E:\пюанвее\3 йспя 1 яел\3 ЙСПЯ 1 ЯЕЛЕЯРП\лни йспяюв\MyTEST\1.xml',SINGLE_BLOB) AS X
SET ARITHABORT ON
Insert into [dbo].[USER]
        (
          [LOGIN],[PASSWORD],[ACCESS]
        )
    Select 
        P.value('LOGIN[1]', 'varchar(50)') AS [LOGIN],
        P.value('PASSWORD[1]', 'varchar(50)') AS [PASSWORD],
        P.value('ACCESS[1]', 'int') AS ACCESS --id_producer[1]
       
    From @xml.nodes('/Users/user') PropertyFeed(P)
GO

Import;