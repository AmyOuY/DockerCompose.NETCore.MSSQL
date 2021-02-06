CREATE PROCEDURE [dbo].[spPerson_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(50),
	@Phone nvarchar(50)

AS
	update dbo.Person
	set FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone
	where Id = @Id;

RETURN 0
