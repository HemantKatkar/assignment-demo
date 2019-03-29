-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetOptions 
	-- Add the parameters for the stored procedure here
	@Name VARCHAR(255),
	@Code INT OUTPUT,
	@Message VARCHAR(255) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @tmpItems AS TABLE (
		Id INT,
		Name VARCHAR(255),
		Category VARCHAR(50)
	)

	INSERT INTO @tmpItems
	        ( Id, Name, Category )
	SELECT TOP 2 tmp.Id, tmp.Name, 'Suggested' FROM (SELECT O.Id, O.Name, COUNT(O.Id) AS TotalCount FROM Items I INNER JOIN Options O ON O.Id = I.OptionId  WHERE ( ISNULL(@Name, '') = '' OR I.Name = @Name) GROUP BY O.Id, O.Name) tmp ORDER BY tmp.TotalCount DESC, tmp.Name ASC

	INSERT INTO @tmpItems
	        ( Id, Name, Category )
	SELECT Id, Name, 'Other Options' FROM Options WHERE Id NOT IN (SELECT Id FROM @tmpItems)

	SELECT * FROM @tmpItems

	SET @Code = 200
	SET @Message = ''
END
