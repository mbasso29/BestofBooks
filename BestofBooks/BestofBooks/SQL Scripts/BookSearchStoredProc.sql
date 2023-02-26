USE BestofBooks
GO

CREATE PROCEDURE BookSearch
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
			SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname AS 'Author Last',a.author_firstname AS 'Author First',g.genre_type AS Genre,b.in_stock AS 'In Stock', b.quantity AS Qty,b.location AS Location,b.price AS Price
			FROM dbo.Book b
			INNER JOIN dbo.Author a ON b.author_id = a.author_id
			INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
			END
	-- Stored proc to search by Genre
		ELSE IF @AuthorFirst is null AND @AuthorLast is null AND @Title is null
			BEGIN 
			SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname AS 'Author Last',a.author_firstname AS 'Author First',g.genre_type AS Genre,b.in_stock AS 'In Stock', b.quantity AS Qty,b.location AS Location,b.price AS Price
			FROM dbo.Book b
			INNER JOIN dbo.Author a ON b.author_id = a.author_id
			INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
			WHERE g.genre_type = @Genre
			END
	-- Stored proc to search by Title
		ELSE IF @Genre is null AND @AuthorFirst is null AND @AuthorLast is null
			BEGIN 
			SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname AS 'Author Last',a.author_firstname AS 'Author First',g.genre_type AS Genre,b.in_stock AS 'In Stock', b.quantity AS Qty,b.location AS Location,b.price AS Price
			FROM dbo.Book b
			INNER JOIN dbo.Author a ON b.author_id = a.author_id
			INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
			WHERE b.title LIKE '%'+@Title+'%'
			END
	-- Stored proc to search by Author First
		ELSE IF @Genre is null AND @AuthorLast is null AND @Title is null
			BEGIN 
			SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname AS 'Author Last',a.author_firstname AS 'Author First',g.genre_type AS Genre,b.in_stock AS 'In Stock', b.quantity AS Qty,b.location AS Location,b.price AS Price
			FROM dbo.Book b
			INNER JOIN dbo.Author a ON b.author_id = a.author_id
			INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
			WHERE a.author_firstname LIKE '%'+@AuthorFirst+'%'
			END
	-- Stored proc to search by Author Last
		ELSE IF @Genre is null AND @AuthorFirst is null AND @Title is null
			BEGIN 
			SELECT b.isbn AS ISBN,b.title AS Title,a.author_lastname AS 'Author Last',a.author_firstname AS 'Author First',g.genre_type AS Genre,b.in_stock AS 'In Stock', b.quantity AS Qty,b.location AS Location,b.price AS Price
			FROM dbo.Book b
			INNER JOIN dbo.Author a ON b.author_id = a.author_id
			INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
			WHERE a.author_lastname LIKE '%'+@AuthorLast+'%'
			END

	END