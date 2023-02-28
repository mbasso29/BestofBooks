USE BestofBooks
GO

CREATE PROCEDURE CreateNewUser

@user_last varchar(50),
@user_first varchar(50),
@user_email varchar(50),
@username varchar(100),
@password varchar(50),
@user_type varchar(8),
@adds_enabled bit = 0,
@edits_enabled bit = 0,
@deletes_enabled bit = 0,
@is_admin bit = 0,
@is_ViewOnly bit = 1

AS

BEGIN
	INSERT INTO BoBUser (user_last,user_first,user_email,username,password,user_type,adds_enabled,edits_enabled,deletes_enabled,is_admin,is_ViewOnly)
	VALUES (@user_last,@user_first,@user_email,@username,@password,@user_type,@adds_enabled,@edits_enabled,@deletes_enabled,@is_admin,@is_ViewOnly)
END
