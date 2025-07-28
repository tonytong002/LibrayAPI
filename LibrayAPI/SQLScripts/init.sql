CREATE TABLE Members (
    MemberId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Email NVARCHAR(100)
);

CREATE TABLE Books (
    BookId INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(200),
    Author NVARCHAR(100)
);

CREATE TABLE MemberBooks (
    MemberId INT,
    BookId INT,
    CheckoutDate DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (MemberId, BookId),
    FOREIGN KEY (MemberId) REFERENCES Members(MemberId),
    FOREIGN KEY (BookId) REFERENCES Books(BookId)
);

INSERT INTO Members (Name, Email) VALUES 
('Alice Johnson', 'alice@example.com'),
('Bob Smith', 'bob@example.com');

INSERT INTO Books (Title, Author) VALUES 
('Clean Code', 'Robert C. Martin'),
('The Pragmatic Programmer', 'Andrew Hunt');

INSERT INTO MemberBooks (MemberId, BookId) VALUES 
(1, 1),
(2, 2);