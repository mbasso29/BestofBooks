USE [BestofBooks]
GO
/****** Object:  StoredProcedure [dbo].[BookSearch]    Script Date: 2/26/2023 4:20:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[BookSearch]
@Genre VARCHAR(30) = NULL,
@AuthorFirst VARCHAR(255) = NULL,
@AuthorLast VARCHAR(255) = NULL,
@Title VARCHAR(255) = NULL
AS

BEGIN
	SET NOCOUNT ON;
	
	-- Base stored proc without any parameters. Returns all books, unfiltered
		IF @Genre is null AND @AuthorFirst is null AND @AuthorLast is null AND @Title is null
			BEGIN
			SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname AS 'AuthorLast',a.author_firstname AS 'AuthorFirst',g.genre_type AS Genre,CASE WHEN b.quantity > 0 THEN 1 ELSE 0 END AS InStock, b.quantity AS Quantity,b.location AS Location,b.price AS Price
			FROM dbo.Book b
			INNER JOIN dbo.Author a ON b.author_id = a.author_id
			INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
			END
	-- Stored proc to search by Genre
		ELSE IF @AuthorFirst is null AND @AuthorLast is null AND @Title is null
			BEGIN 
			SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname AS 'AuthorLast',a.author_firstname AS 'AuthorFirst',g.genre_type AS Genre,CASE WHEN b.quantity > 0 THEN 1 ELSE 0 END AS InStock, b.quantity AS Quantity,b.location AS Location,b.price AS Price
			FROM dbo.Book b
			INNER JOIN dbo.Author a ON b.author_id = a.author_id
			INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
			WHERE g.genre_type LIKE '%'+@Genre+'%'
			END
	-- Stored proc to search by Title
		ELSE IF @Genre is null AND @AuthorFirst is null AND @AuthorLast is null
			BEGIN 
			SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname AS 'AuthorLast',a.author_firstname AS 'AuthorFirst',g.genre_type AS Genre,CASE WHEN b.quantity > 0 THEN 1 ELSE 0 END AS InStock, b.quantity AS Quantity,b.location AS Location,b.price AS Price
			FROM dbo.Book b
			INNER JOIN dbo.Author a ON b.author_id = a.author_id
			INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
			WHERE b.title LIKE '%'+@Title+'%'
			END
	-- Stored proc to search by Author First
		ELSE IF @Genre is null AND @AuthorLast is null AND @Title is null
			BEGIN 
			SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname AS 'AuthorLast',a.author_firstname AS 'AuthorFirst',g.genre_type AS Genre,CASE WHEN b.quantity > 0 THEN 1 ELSE 0 END AS InStock, b.quantity AS Quantity,b.location AS Location,b.price AS Price
			FROM dbo.Book b
			INNER JOIN dbo.Author a ON b.author_id = a.author_id
			INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
			WHERE a.author_firstname LIKE '%'+@AuthorFirst+'%'
			END
	-- Stored proc to search by Author Last
		ELSE IF @Genre is null AND @AuthorFirst is null AND @Title is null
			BEGIN 
			SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname AS 'AuthorLast',a.author_firstname AS 'AuthorFirst',g.genre_type AS Genre,CASE WHEN b.quantity > 0 THEN 1 ELSE 0 END AS InStock, b.quantity AS Quantity,b.location AS Location,b.price AS Price
			FROM dbo.Book b
			INNER JOIN dbo.Author a ON b.author_id = a.author_id
			INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
			WHERE a.author_lastname LIKE '%'+@AuthorLast+'%'
			END

	END