USE BestofBooks
GO


CREATE OR ALTER PROCEDURE UpdateRights
@BoBuser_id int,
@adds_enabled int = -1,
@edits_enabled int = -1,
@deletes_enabled int = -1,
@is_admin int = -1,
@is_ViewOnly int = -1,
@modifiedBy varchar(30)

AS

BEGIN
	SET NOCOUNT ON;
	
	-- Stored proc that will update the adds_enabled column
		IF @adds_enabled > -1
			BEGIN
			UPDATE BoBUser
			SET adds_enabled = @adds_enabled, modifiedBy = @modifiedBy
			WHERE BoBuser_id = @BoBuser_id
			END
	-- Stored proc that will update the edits_enabled column
		IF @edits_enabled > -1
			BEGIN
			UPDATE BoBUser
			SET edits_enabled = @edits_enabled, modifiedBy = @modifiedBy
			WHERE BoBuser_id = @BoBuser_id
			END
	-- Stored proc that will update the deletes_enabled column
		IF @deletes_enabled > -1
			BEGIN
			UPDATE BoBUser
			SET deletes_enabled = @deletes_enabled, modifiedBy = @modifiedBy
			WHERE BoBuser_id = @BoBuser_id
			END
	-- Stored proc that will update the is_admin column
		IF @is_admin > -1
			BEGIN
			UPDATE BoBUser
			SET is_admin = @is_admin, modifiedBy = @modifiedBy
			WHERE BoBuser_id = @BoBuser_id
			END
	-- Stored proc that will update the is_ViewOnly column
		IF @is_ViewOnly > -1
			BEGIN
			UPDATE BoBUser
			SET is_ViewOnly = @is_ViewOnly, modifiedBy = @modifiedBy
			WHERE BoBuser_id = @BoBuser_id
			END

	END