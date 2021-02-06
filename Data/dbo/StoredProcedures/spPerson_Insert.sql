CREATE PROCEDURE [dbo].[spPerson_Insert]
	@Id int = 0 output,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(50),
	@Phone nvarchar(50)

AS
	insert into dbo.Person (FirstName, LastName, Email, Phone)
	values (@FirstName, @LastName, @Email, @Phone);

	select @Id = SCOPE_IDENTITY();

RETURN 0
