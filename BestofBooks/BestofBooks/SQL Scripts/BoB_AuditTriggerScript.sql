/*Best of Books Audit Table Creation and Triggers Script*/

USE BestofBooks
GO

CREATE TABLE Audit (
	change_id            int	IDENTITY(1,1)		NOT NULL UNIQUE,
	table_name           varchar(30)      NOT NULL,
	modified_by_user     varchar(30)      NOT NULL,
	modified_by_last     varchar(30)      NOT NULL,
	modified_date        varchar(30)      NOT NULL,
	audit_action         varchar(30)	NOT NULL,
	CONSTRAINT pk_Audit	PRIMARY KEY  (change_id) 
);
GO

CREATE TRIGGER TR_Book_AfterInsert
ON Book
AFTER INSERT
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Book', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Insert');
GO

CREATE TRIGGER TR_Book_AfterUpdate
ON Book
AFTER UPDATE
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Book', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Update');
GO

CREATE TRIGGER TR_Book_AfterDelete
ON Book
AFTER DELETE
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Book', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Delete');
GO

CREATE TRIGGER TR_Admin_AfterInsert
ON Admin
AFTER INSERT
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Admin', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Insert');
GO

CREATE TRIGGER TR_Admin_AfterUpdate
ON Admin
AFTER UPDATE
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Admin', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Update');
GO

CREATE TRIGGER TR_Admin_AfterDelete
ON Admin
AFTER DELETE
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Admin', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Delete');
GO

CREATE TRIGGER TR_Author_AfterInsert
ON Author
AFTER INSERT
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Author', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Insert');
GO

CREATE TRIGGER TR_Author_AfterUpdate
ON Author
AFTER UPDATE
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Author', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Update');
GO

CREATE TRIGGER TR_Author_AfterDelete
ON Author
AFTER DELETE
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Author', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Delete');
GO

CREATE TRIGGER TR_BoBUser_AfterInsert
ON BoBUser
AFTER INSERT
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('BoBUser', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Insert');
GO

CREATE TRIGGER TR_BoBUser_AfterUpdate
ON BoBUser
AFTER UPDATE
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('BoBUser', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Update');
GO

CREATE TRIGGER TR_BoBUser_AfterDelete
ON BoBUser
AFTER DELETE
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('BoBUser', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Delete');
GO

CREATE TRIGGER TR_Employee_AfterInsert
ON Employee
AFTER INSERT
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Employee', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Insert');
GO

CREATE TRIGGER TR_Employee_AfterUpdate
ON Employee
AFTER UPDATE
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Employee', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Update');
GO

CREATE TRIGGER TR_Employee_AfterDelete
ON Employee
AFTER DELETE
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Employee', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Delete');
GO

CREATE TRIGGER TR_Genre_AfterInsert
ON Genre
AFTER INSERT
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Genre', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Insert');
GO

CREATE TRIGGER TR_Genre_AfterUpdate
ON Genre
AFTER UPDATE
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Genre', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Update');
GO

CREATE TRIGGER TR_Genre_AfterDelete
ON Genre
AFTER DELETE
AS
INSERT INTO dbo.Audit
(table_name, modified_by_user, modified_by_last, modified_date, audit_action)
Values
('Genre', SUSER_SNAME(), 'Last Name TBD', GETDATE(), 'Delete');
GO




