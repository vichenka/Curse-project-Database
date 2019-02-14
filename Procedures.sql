USE [KP]
GO
------------------------------------------USER------------------------------------------------------
----------------------[проверка паролей] ------------------------------------
create function [dbo].[AutoValid]( @login nvarchar(50), @password nvarchar(50))
returns int
as begin
Declare @a int =0;
if  exists (select [LOGIN] from [dbo].[USER] where [LOGIN]=@login and [PASSWORD]=@password) set @a=1;  
	else set @a=0;
	return @a;
end
GO
---------------------------------------Take_access---------------------------------
create function [dbo].[Take_access]
(
@login nvarchar(50)
)
 returns int
 as begin 
 Declare @id int;
 select @id = [ACCESS] from [USER]
 where LOGIN=@login
 return @id
 end
 GO
 select dbo.Take_access('user');
----------------------------------------IfEmpty-----------------------
create function IfEmpty (@login nvarchar(50))
returns int
as begin 
Declare @a int =0;
if  exists (select [LOGIN] from [dbo].[USER] where LOGIN=@login) set @a=1;  
	else set @a=0;
	return @a;
	END;
	go

select * from [dbo].[USER];
 select dbo.auto_user('anna','1234'); 
 ------------------------------------------Take_user_infoByLogin- НЕ ГРАНТИЛА--------------
  alter proc Take_user_info
   @login nvarchar(50)
  as begin 
  begin try
  select * from [dbo].[USER] where LOGIN=@login;
  end try
begin catch
print error_message()
  end catch
  END;

   exec Take_user_info @login='admin';
   go
----------------------------------------Update_user- НЕ ГРАНТИЛА---------------------
alter procedure Update_user @login nvarchar(50), @password nvarchar(50)
as begin 
  begin try 
UPDATE [dbo].[USER] SET [LOGIN]=@login,[PASSWORD]=@password WHERE [LOGIN]=@login
 end try
begin catch
print error_message()
  end catch
  END;
go

exec Update_user @login='qdmin', @password = 'admin';
------------------------------------------InsertUser--------------------------
CREATE PROCEDURE InsertUser
	@login nvarchar(50),
	@password nvarchar(50),
	@access int
	AS BEGIN
	begin try
		INSERT INTO [dbo].[USER] ([LOGIN], [PASSWORD], [ACCESS])
			VALUES(@login, @password, @access);
			COMMIT
			end try
begin catch
print error_message()
end catch
	END;
	GO

exec InsertUser
	@login = 'admin',
	@password = 'admin',
	@access = 1;

SELECT * FROM [dbo].[USER];
---------------------------------------DeleteUser--------------
CREATE PROCEDURE DeleteUser
@login nvarchar(50)
AS BEGIN
	begin try
		DELETE FROM [dbo].[User] WHERE [LOGIN] = @login;
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

exec DeleteUser @login = 'user';
------------------------------------------UsersSelect-----------------------
CREATE PROCEDURE UsersSelect
	AS BEGIN
	begin try
		SELECT [LOGIN]
		FROM [dbo].[USER] where [ACCESS]=2
		COMMIT
			end try
begin catch
print error_message()
end catch
	END;
	GO

	DROP PROCEDURE UsersSelect;
	exec UsersSelect;
----------------------------------------------------TEST--------------------------------------
--------------------------------------------Take_id_Test_ByName----------------
 Create function Take_id_Test
(
@name nvarchar(50)
)
 returns int
 as begin 
 Declare @id int;
 select @id = [ID] from [dbo].[TEST]
 where [NAME_TEST]=@name
 return @id
 end
 go
------------------------------------------NameTestEmpty--------------------
create function IfEmptyNameTest (@name nvarchar(50))
returns int
as begin 
Declare @a int =0;
if  exists (select [NAME_TEST] from [dbo].[TEST] where NAME_TEST=@name) set @a=1;  
	else set @a=0;
	return @a;
	END;
	go

select * from HISTORY;
select * from RESULT;
select * from POINT;
select * from QUESTION;
select * from TEST;
select [dbo].IfEmptyNameTest ('T22');
-----------------------------------DeleteTest------------------------------
CREATE PROCEDURE DeleteTest
@name nvarchar(50)
AS BEGIN
	begin try
		DELETE FROM [dbo].[TEST] WHERE [NAME_TEST] = @name;
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

select * from TEST;
exec DeleteUser @login = 'user';
-----------------------------------DeleteQuestionByTest------------------------------
CREATE PROCEDURE DeleteQuestionByTest
@idTest int
AS BEGIN
	begin try
		DELETE FROM [dbo].[QUESTION] WHERE [ID_TEST] = @idTest;
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

select * from QUESTION;
-----------------------------------IdQuestionByIdTest------------------------------
CREATE PROCEDURE IdQuestionByIdTest
@idTest int
AS BEGIN
	begin try
		SELECT [ID_QUESTION] FROM [dbo].[QUESTION] WHERE [ID_TEST] = @idTest;
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

exec IdQuestionByIdTest @idTest=32;
-----------------------------------DeletePointByIdQuest------------------------------
CREATE PROCEDURE DeletePointByIdQuest
@idQ int
AS BEGIN
	begin try
		DELETE FROM [dbo].[POINT] WHERE [ID_Quest] = @idQ;
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

select * from TEST;
select * from QUESTION;
------------------------------------DeleteResultBiIdTest---------------
CREATE PROCEDURE DeleteResultBiIdTest
@idT int
AS BEGIN
	begin try
		DELETE FROM [dbo].[RESULT] WHERE [ID_Test] = @idT;
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO
-----------------------------------IdQResultIdTest------------------------------
CREATE PROCEDURE IdQResultIdTest
@idTest int
AS BEGIN
	begin try
		SELECT [ID_Result] FROM [dbo].[RESULT] WHERE [ID_Test] = @idTest;
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

select * from RESULT;
exec IdQResultIdTest @idTest=33;
----------------------------------------DeleteHistoryByIdResult----------
CREATE PROCEDURE DeleteHistoryByIdResult
@idR int
AS BEGIN
	begin try
		DELETE FROM [dbo].[HISTORY] WHERE [ID_RESULTH] = @idR;
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

select * from HISTORY;
--------------------------------------GetTestId-----------------------
create function IdTest(
@nameTest nvarchar(50)) 
returns int
 AS BEGIN
 Declare @testId int = (select [ID] from [dbo].[TEST] where [NAME_TEST]=@nameTest);  
  return @testId;
  END;
	GO

	select * from TEST;
	select [dbo].IdTest ('testOne');
	-------------------------------------ListTestsSelect-----------------------
CREATE PROCEDURE ListTestsSelect
	AS BEGIN
	begin try
		SELECT [NAME_TEST]
		FROM [dbo].[TEST] 
		COMMIT
			end try
begin catch
print error_message()
end catch
	END;
	GO

	DROP PROCEDURE ListTestsSelect;
	exec ListTestsSelect;
----------------------------------------SearchTestByName---------------------------------
ALTER PROCEDURE SearchTestByName
@name nvarchar(50)
 AS BEGIN
 begin try
 declare @name2 nvarchar(50)='FORMSOF(INFLECTIONAL,"'+@name+'")'; 
select [NAME_TEST] from [dbo].[TEST] where CONTAINS([NAME_TEST],@name2);
 end try
 begin catch
print error_message()
end catch
  END;
	GO

select * from TEST;
select * from [dbo].[TEST] where CONTAINS ([NAME_TEST],'FORMSOF(INFLECTIONAL,"тест")') ;
exec SearchTestByName @name ='T22';
--------------------------------------TestCreate------------------------------------
CREATE PROCEDURE TestCreate
	@nameTest nvarchar(50),
	@author nvarchar(50),
	@idType int
	AS BEGIN
	begin try
		INSERT INTO [dbo].[TEST] ( [NAME_TEST], [AUTHOR],[ID_TYPE])
			VALUES( @nameTest, @author, @idType);
			COMMIT
			end try
begin catch
print error_message()
end catch
	END;
	GO

exec TestCreate
select * from TEST;

--------------------------------------------TestSelectListByAuthor-----------------------
CREATE PROCEDURE TestSelectListByAuthor
@Author nvarchar(50)
AS BEGIN
	begin try
	SELECT [NAME_TEST]
	FROM [dbo].[TEST] C1
	INNER JOIN [dbo].[User] CO
	ON C1.AUTHOR = CO.LOGIN
	WHERE C1.AUTHOR = @Author
	COMMIT
			end try
begin catch
print error_message()
end catch
	END;
GO

DROP PROCEDURE TestSelectListByAuthor;

exec TestSelectListByAuthor 
@Author = 'user';
-----------------------------------------По логину получить все ид резалт------
CREATE PROCEDURE GetIdResultByLogin
(
@login nvarchar(50)
)
AS BEGIN
	begin try
	select [ID_RESULTH] from [dbo].[HISTORY] where [ID_USER]=@login;
end try
begin catch
print error_message()
end catch 
 END;
	GO

	exec GetIdResultByLogin @login= 'user';
--вернуть все идрезалт принадлежащих юзеру,потом ридером читать каждый идрезалт и возвращать по нему назвние теста
----------------------------------GetTestIdByResultId--------------------------
CREATE proc IdTestByIdRes
@idR int
 AS BEGIN
  select [ID_Test] from [dbo].RESULT where [ID_Result]=@idR
  END;
	GO

	select * from RESULT;
	select * from HISTORY;
select [dbo].IdTestByResultId (10);
--------------------------------------------GetNameTest--------------------
CREATE proc GetNameTestByIdTest
@idT int 
 AS BEGIN 
 select [NAME_TEST] from [dbo].[TEST] where [ID]=@idT  
  END;
	GO 

select * from TEST;
 exec GetNameTestByIdTest @idT = 32;
--------------------------------------------GetTestByAuthor- НЕ ГРАНТИЛА-----------------
create function GetTestByAuthor(
@author nvarchar(50)) 
returns nvarchar(50)
 AS BEGIN
 Declare @name nvarchar(50) = (select [NAME_TEST] from [dbo].[TEST] where [ID]=@idT);  
  return @name;
  END;
	GO 
-------------------------------------------------------------QUESTION-------------------------------
------------------------------------------QuestionByTestEmpty--------------------
create function QuestionByTestEmpty (@idT int)
returns int
as begin 
Declare @a int =0;
if  exists (select [QUESTION] from [dbo].[QUESTION] where ID_TEST=@idT) set @a=1;  
	else set @a=0;
	return @a;
	END;
	go

select * from TEST;
select dbo.QuestionByTestEmpty(40);

---------------------------------------------ПоидТеста и тескту вопроса вернуть ид вопроса-----------
create function QuestionidByText(
@text nvarchar(50),
@idT int) 
returns int
 AS BEGIN
 Declare @b int = (select [ID_QUESTION] from [dbo].[QUESTION] where [QUESTION]=@text and [ID_TEST] = @idT);  
  return @b;
  END;
	GO

select * from POINT;
select * from QUESTION;
select [dbo].QuestionidByText('q2',32);

---------------------------------------------NumberPointofQ--ГРАНТИЛА-----------------------------------
create function IdQuestionforCreateTest(
@idTest int) 
returns int
 AS BEGIN
 Declare @id int = (select top(1) [ID_QUESTION] from [dbo].[QUESTION] where [ID_TEST]=@idTest );  
  return @id;
  END;
	GO
--------------------------------------GetQuestionById-----------------------
CREATE function GetQuestionById(
@idQ int) 
returns varchar(50)
 AS BEGIN
 Declare @quest varchar(50) = (select [QUESTION] from [dbo].[QUESTION] where [ID_QUESTION]=@idQ );  
  return @quest;
  END;
	GO

	select * from QUESTION;
	select * from TEST;
	select * from POINT;
	select [dbo].GetQuestionById(13);
-------------------------------------AddNewQuestion----------------------------
CREATE PROCEDURE AddNewQuestion
(
@testid int,
@question nvarchar(50)
)
AS BEGIN
	begin try
insert into [dbo].[QUESTION]([ID_TEST],[QUESTION])
values (@testid,@question);
end try
begin catch
print error_message()
end catch
 END;
	GO

	select * from QUESTION;
	select * from TEST;
	select * from POINT;
	delete from QUESTION;
----------------------------------NumberQuestOfIdTest--------------------------
create function NumberQuest(
@idTest int) 
returns int
 AS BEGIN
 Declare @number int = (select COUNT(*) from [dbo].[QUESTION] where [ID_TEST]=@idTest);  
  return @number;
  END;
	GO

	select [dbo].NumberQuest(22);

--------------------------------------------QuestionSelectListByIdTest-----------------------
CREATE PROCEDURE QuestionSelectListByIdTest
@TestId int
AS BEGIN
begin try
	SELECT [QUESTION]
	FROM [dbo].[QUESTION] C1
	INNER JOIN [dbo].[TEST] CO
	ON C1.ID_TEST = CO.ID
	WHERE C1.ID_TEST = @TestId
	COMMIT
			end try
begin catch
print error_message()
end catch
	END;
GO

DROP PROC QuestionSelectListByIdTest;
select * from QUESTION;
exec QuestionSelectListByIdTest @TestId = '27';
-------------------------------------IdQBydTforUserTest---------------------------
CREATE function IdQuestion(
@idTest int) 
returns int
 AS BEGIN
 --WHERE `id` = (SELECT MAX(`id`) FROM `chat`)
 Declare @id int = (select top(1) [ID_QUESTION] from [dbo].[QUESTION] where [ID_TEST]=@idTest ORDER BY[ID_QUESTION] desc);  
  return @id;
  END;
	GO

delete from TEST;
delete from QUESTION;
delete from POINT;
delete from RESULT;
select [dbo].IdQuestion(30);

-------------------------------------IdQBydTforCreateTest--НЕ ГРАНТИЛА------------------------
CREATE function IdQuestionforCreateTest(
@idTest int) 
returns int
 AS BEGIN
 Declare @id int = (select top(1) [ID_QUESTION] from [dbo].[QUESTION] where [ID_TEST]=@idTest );  
  return @id;
  END;
	GO
delete from TEST;
delete from QUESTION;
delete from POINT;
delete from RESULT;
select * from TEST;
select * from QUESTION;
select [dbo].IdQuestionforCreateTest(30);
---------------------------------------------------------POINT-----------------------------------
-------------------------------------AddNewPoint----------------------------
CREATE PROCEDURE AddNewPoint
(
@idQuestion int,
@answer nvarchar(50),
@point int
)
AS BEGIN
	begin try
insert into [dbo].[POINT]([ID_Quest],[ANSWER], [POINT])
values (@idQuestion,@answer,@point);
end try
begin catch
print error_message()
end catch
 END;
	GO

	SELECT * FROM QUESTION;
	select * from POINT;
	select * from TEST;
--------------------------------------------AnsverSelectListByIdQuest-----------------------
CREATE PROCEDURE AnsverSelectListByIdQuest
@QuestId int
AS BEGIN
begin try
	SELECT [ANSWER]
	FROM [dbo].[POINT] C1
	INNER JOIN [dbo].[QUESTION] CO
	ON C1.ID_Quest = CO.ID_QUESTION
	WHERE C1.ID_Quest = @QuestId
	COMMIT
			end try
begin catch
print error_message()
end catch
	END;
GO

select * from QUESTION;
DROP PROC ResultSelectListByIdTest;
exec AnsverSelectListByIdQuest @QuestId = '38';

---------------------------------------------Есливыбранный ответ совпал с текстом ответа вернуть балл за него-----------
CREATE function Ball(
@answ nvarchar(50),
@idQ int) 
returns int
 AS BEGIN
 Declare @b int = (select [POINT] from [dbo].[POINT] where [ANSWER]=@answ and [ID_Quest] = @idQ);  
  return @b;
  END;
	GO

select * from POINT;
select * from QUESTION;
select [dbo].Ball('a12',38); --2


--------------------------------------------------------------RESULT----------------------------------
-------------------------------------AddNewResult----------------------------
CREATE PROCEDURE AddNewResult
(
@testid int,
@result1 int,
@result2 int,
@textResult nvarchar(50)
)
AS BEGIN
	begin try
insert into [dbo].[RESULT]([ID_Test],[RESULT1], [RESULT2], [TEXT_RESULT])
values (@testid,@result1,@result2,@textResult);
end try
begin catch
print error_message()
end catch
 END;
	GO

	select * from RESULT;
	select * from TEST;
----------------------------------------------------ShowResult---------------------------
CREATE function ShowResult(
@ball int,
@idT int) 
returns nvarchar(50)
 AS BEGIN
 Declare @text nvarchar(50) = (select [TEXT_RESULT] from [dbo].[RESULT] where [ID_Test]=@idT and  [RESULT1] <=  @ball and [RESULT2] >= @ball);  
  return @text;
  END;
	GO

select * from RESULT;
select * from TEST;
select [dbo].ShowResult(9,32);
----------------------------------------------GetTextRes------------------------------
CREATE function GetTextRes(
@idR int) 
returns nvarchar(50)
 AS BEGIN
 Declare @text nvarchar(50) = (select [TEXT_RESULT] from [dbo].[RESULT] where [ID_Result]=@idR );  
  return @text;
  END;
	GO

select [dbo].[GetTextRes] (10);
----------------------------------------По idTest и тексту результата получить его id-----------------
CREATE function ResultidByText(
@text nvarchar(50),
@idT int) 
returns int
 AS BEGIN
 Declare @b int = (select [ID_RESULT] from [dbo].[RESULT] where [TEXT_RESULT]=@text and [ID_Test] = @idT);  
  return @b;
  END;
	GO

select * from RESULT;
select [dbo].ResultidByText('r1',33);

-----------------------------------IdResbyTdTest----------------------------
CREATE proc IdResbyTdTest
@idT int 
 AS BEGIN 
 select [ID_Result] from [dbo].[RESULT] where [ID_Test]=@idT  
  END;
	GO 

select * from RESULT;
select * from HISTORY;
exec IdResbyTdTest @idT = 33;
----------------------------------------------DeleteResultByIdTest---------------------------
---------------------------------------------------------HISTORY---------------------------------------
----------------------------------найти ид рез  в хистори табл --НЕ ГРАНТИЛА-----------------
CREATE function BoolResinHistory(
@idR int) 
returns int
 AS BEGIN
 Declare @b int = 0;
 if @b = (select [ID_RESULT] from [dbo].[RESULT] where [TEXT_RESULT]=@text and [ID_Test] = @idT);  
  return @b;
  END;
	GO
--и если да то вывести его-------------

-----------------------------------------AddNewHistory-------------------------------------
CREATE procedure AddNewHistory
@user nvarchar(50),
@resultId int,
@typeId int
AS BEGIN
begin try
insert  into [dbo].[HISTORY]([ID_USER], [ID_RESULTH], [ID_TYPE])
values (@user, @resultId,@typeId);
end try
begin catch
print error_message()
end catch
end;
go

exec AddNewHistory @user ='user', @resultId= 10;
select * from RESULT;
select * from HISTORY;

-------------------------------------------------------TypeByIdTest------------------
CREATE function GetIdTypeByIdTest(
@idT int) 
returns int
 AS BEGIN
 Declare @t int = (select [ID_TYPE] from [dbo].[TEST] where  [ID] = @idT);  
  return @t;
  END;
	GO

select * from RESULT;
select [dbo].ResultidByText('r1',33);
---------------------------------------------------TypeById--------------------
CREATE function GetTypeById(
@idType int) 
returns nvarchar(50)
 AS BEGIN
 Declare @t nvarchar(50) = (select [NAME_TYPE] from [dbo].[TYPE] where  [ID] = @idType);  
  return @t;
  END;
	GO

select* from [dbo].[USER];
select [dbo].GetTypeById(1);
delete from [dbo].[USER];

select * from TEST;
