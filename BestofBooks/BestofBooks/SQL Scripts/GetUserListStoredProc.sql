USE BestofBooks
GO

CREATE PROCEDURE GetUserList

AS

BEGIN
	BEGIN
	SELECT u.user_first,u.user_last,u.user_type,u.is_ViewOnly,u.adds_enabled,u.edits_enabled,u.deletes_enabled,u.is_Admin
	FROM dbo.BoBUser u
	END
END