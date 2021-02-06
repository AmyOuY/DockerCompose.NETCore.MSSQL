CREATE PROCEDURE [dbo].[spPerson_Get]
	@Id int

AS
	select * 
	from dbo.Person
	where Id = @Id;

RETURN 0
