use KP;
GO

CREATE FULLTEXT INDEX ON TEST(NAME_TEST)
	KEY INDEX ID ON (TestCatalog) 
	WITH (CHANGE_TRACKING AUTO)
   GO

   DROP FULLTEXT INDEX ON TEST;

create procedure RandString (@a nvarchar(10) output)
as
begin
declare @str nvarchar(10)
SET @str = (
SELECT
	c1 AS [text()]
FROM
	(
	SELECT TOP (10) c1
	FROM
	  (
    VALUES
      ('A'), ('B'), ('C'), ('D'), ('E'), ('F'), ('G'), ('H'), ('I'), ('J'),
      ('K'), ('L'), ('M'), ('N'), ('O'), ('P'), ('Q'), ('R'), ('S'), ('T'),
      ('U'), ('V'), ('W'), ('X'), ('Y'), ('Z'), ('0'), ('1'), ('2'), ('3'),
      ('4'), ('5'), ('6'), ('7'), ('8'), ('9')	
	  ) AS T1(c1)
	ORDER BY ABS(CHECKSUM(NEWID()))
	) AS T2
FOR XML PATH('')
);
set @a = @str
end
GO

select count(*) from [dbo].[USER];
select [LOGIN] from [dbo].[USER];

create procedure RandomFillUser
as begin
	declare @kol int = 0
	while @kol < 200--кол-во вставленных строк
	begin
	declare @l nvarchar(10) exec RandString @l out
	declare @p nvarchar(10) exec RandString @p out
	declare @a int  = 2;
	
	insert into [dbo].[USER] ([LOGIN], [PASSWORD], [ACCESS]) values( @l, @p, @a);
	set @kol = @kol +1
	end
	end
GO

RandomFillUser
Go 100

create nonclustered index LogIndex
on [dbo].[USER]([LOGIN])
GO

drop index LoginIndex on[dbo].[USER];
create nonclustered index PswIndex
on [dbo].[USER]([PASSWORD])
GO
select [PASSWORD] from [dbo].[USER];

create nonclustered index AccessIndex
on [dbo].[USER]([ACCESS])
GO
drop index AccessIndex on[dbo].[USER];

select [ACCESS] from [dbo].[USER];

