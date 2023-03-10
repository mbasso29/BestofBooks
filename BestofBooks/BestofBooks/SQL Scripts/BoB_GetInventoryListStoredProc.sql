USE BestofBooks
GO

CREATE OR ALTER PROCEDURE GetInventoryList

AS

BEGIN
	SET NOCOUNT ON;
	BEGIN
	SELECT b.book_id as Id, b.isbn,b.title,a.author_firstname AS AuthorFirst,a.author_lastname AS AuthorLast,g.genre_type AS Genre,b.location,b.price,b.quantity
	FROM dbo.Book b
	INNER JOIN dbo.Author a ON b.author_id = a.author_id
	INNER JOIN dbo.Genre g ON b.genre_id = g.genre_id
	WHERE b.quantity != 0
	END
END