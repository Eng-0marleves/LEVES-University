CREATE TYPE UserTypeEnumeration FROM VARCHAR(50);

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Age INT NOT NULL,
    UserType VARCHAR(50) CHECK (UserType IN ('std', 'it', 'dr', 'Mr', 'librarian')) NOT NULL,
    Password VARCHAR(100) NOT NULL, -- You should encrypt passwords in a real-world scenario
    ProfileImage VARBINARY(MAX), -- Column to store the image,
    Email VARCHAR(100) NOT NULL,
    Phone VARCHAR(20) NOT NULL
);

DROP TABLE Users;

INSERT INTO Users (Age, UserType, Password, Email, Phone)
VALUES 
(25, 'it', 'password1', 'user1@example.com', '123-456-7890'),
(30, 'it', 'password2', 'user2@example.com', '234-567-8901'),
(28, 'it', 'password3', 'user3@example.com', '345-678-9012'),
(33, 'it', 'password4', 'user4@example.com', '456-789-0123'),
(27, 'it', 'password5', 'user5@example.com', '567-890-1234'),
(29, 'it', 'password6', 'user6@example.com', '678-901-2345'),
(31, 'it', 'password7', 'user7@example.com', '789-012-3456'),
(26, 'it', 'password8', 'user8@example.com', '890-123-4567'),
(32, 'it', 'password9', 'user9@example.com', '901-234-5678'),
(34, 'it', 'password10', 'user10@example.com', '012-345-6789'),
(35, 'it', 'password11', 'user11@example.com', '123-456-7890'),
(36, 'it', 'password12', 'user12@example.com', '234-567-8901'),
(37, 'it', 'password13', 'user13@example.com', '345-678-9012'),
(38, 'it', 'password14', 'user14@example.com', '456-789-0123'),
(39, 'it', 'password15', 'user15@example.com', '567-890-1234'),
(40, 'it', 'password16', 'user16@example.com', '678-901-2345'),
(41, 'it', 'password17', 'user17@example.com', '789-012-3456'),
(42, 'it', 'password18', 'user18@example.com', '890-123-4567'),
(43, 'it', 'password19', 'user19@example.com', '901-234-5678'),
(44, 'it', 'password20', 'user20@example.com', '012-345-6789');
