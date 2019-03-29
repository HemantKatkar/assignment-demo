-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddItems]
	-- Add the parameters for the stored procedure here
	@Name VARCHAR(255),
	@OptionId INT,
	@Code INT OUTPUT,
	@Message VARCHAR(255) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	INSERT INTO Items (Name, OptionId) VALUES (@Name, @OptionId)

	SELECT * FROM dbo.Items WHERE Id = SCOPE_IDENTITY()

	SET @Code = 201
	SET @Message = ''
END
