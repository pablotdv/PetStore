CREATE TABLE Pets (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Breed NVARCHAR(255) NOT NULL,
    Color NVARCHAR(255) NOT NULL,
    DateOfBirth DATETIME2 NOT NULL,
    Description NVARCHAR(MAX) NOT NULL
);


INSERT INTO Pets (Id, Name, Breed, Color, DateOfBirth, Description)
VALUES 
(NEWID(), 'Buddy', 'Golden Retriever', 'Golden', '2017-03-15', 'Friendly and playful. Loves to fetch.'),
(NEWID(), 'Mittens', 'Siamese', 'Cream', '2019-07-23', 'Curious and vocal. Enjoys climbing.'),
(NEWID(), 'Max', 'German Shepherd', 'Black and Tan', '2018-11-02', 'Loyal and protective. Great guard dog.'),
(NEWID(), 'Whiskers', 'Tabby', 'Gray', '2020-05-18', 'Calm and affectionate. Loves to nap.'),
(NEWID(), 'Charlie', 'Beagle', 'Tricolor', '2016-01-10', 'Energetic and friendly. Excellent scent tracker.');
;

select *
from pets;