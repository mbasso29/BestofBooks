/* BEST OF BOOKS DATABASE CREATION SCRIPT */

CREATE DATABASE BestofBooks;
GO

USE BestofBooks;
GO

CREATE  TABLE Book ( 
	book_id              int      NOT NULL,
	isbn                 varchar(13)      NOT NULL,
	title                text      NOT NULL,
	author_id            int      NOT NULL,
	genre_id             int      NOT NULL,
	in_stock             bit      NULL,
	quantity             numeric      NOT NULL,
	location             varchar(5)      NOT NULL,
	price                money      NOT NULL,
	CONSTRAINT pk_book PRIMARY KEY  ( book_id ) 
 );
GO

CREATE  TABLE Author ( 
	author_id            int      NOT NULL,
	author_firstname     varchar(100)      NOT NULL,
	author_lastname      varchar(100)      NOT NULL,
	CONSTRAINT pk_author PRIMARY KEY  ( author_id ) 
 );
GO

CREATE  TABLE Genre ( 
	genre_id             int      NOT NULL,
	genre_type           text      NULL,
	CONSTRAINT pk_genre PRIMARY KEY  ( genre_id ) 
 );
GO

CREATE  TABLE [User] ( 
	user_id              int      NOT NULL,
	user_last            text      NOT NULL,
	user_first           text      NOT NULL,
	user_email           text      NOT NULL,
	username             varchar(100)      NOT NULL,
	password             varchar(128)      NOT NULL,
	is_employee          bit  DEFAULT 0    NOT NULL,
	is_admin             bit  DEFAULT 0    NOT NULL,
	CONSTRAINT pk_user PRIMARY KEY  ( user_id ) 
 );
GO

ALTER TABLE Book
ADD CONSTRAINT book_FK1 
FOREIGN KEY (author_id) REFERENCES Author(author_id);
GO

ALTER TABLE Book
ADD CONSTRAINT book_FK2 
FOREIGN KEY (genre_id) REFERENCES Genre(genre_id);
GO 




