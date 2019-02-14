USE KP;
GO
--------------------------------------------------------[AnnaSavenko] ---------------------
CREATE LOGIN [AnnaSavenko] WITH PASSWORD = 'anna';
CREATE USER [AnnaSavenko] FOR LOGIN [AnnaSavenko];

grant execute on InsertUser to [AnnaSavenko] with grant option;
grant execute on IdQuestionByIdTest to [AnnaSavenko] with grant option;
grant execute on IdQResultIdTest to [AnnaSavenko] with grant option;
grant execute on ListTestsSelect to [AnnaSavenko] with grant option;
grant execute on TestSelectListByAuthor to [AnnaSavenko] with grant option;
grant execute on GetIdResultByLogin to [AnnaSavenko] with grant option;
grant execute on IdTestByIdRes to [AnnaSavenko] with grant option;
grant execute on GetNameTestByIdTest to [AnnaSavenko] with grant option;
grant execute on GetTestByAuthor to [AnnaSavenko] with grant option;
grant execute on AddNewQuestion to [AnnaSavenko] with grant option;
grant execute on QuestionSelectListByIdTest to [AnnaSavenko] with grant option;
grant execute on AddNewPoint to [AnnaSavenko] with grant option;
grant execute on AnsverSelectListByIdQuest to [AnnaSavenko] with grant option;
grant execute on AddNewHistory to [AnnaSavenko] with grant option;
grant execute on IdTestByIdRes to [AnnaSavenko] with grant option;
grant execute on IdTestByIdRes to [AnnaSavenko] with grant option;

---------------------------------------Õ≈ ¬€œŒÀÕ»À¿--------------------------------------

