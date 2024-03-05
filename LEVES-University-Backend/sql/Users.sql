CREATE TABLE Users (
    UserID INT PRIMARY KEY NOT NULL,
    FirstName VARCHAR(50) NOT NULL,
    FamilyName VARCHAR(200) NOT NULL,
    PhoneNumber VARCHAR(20) NOT NULL,
    ProfileImage VARCHAR(500) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Email1 VARCHAR(255) NOT NULL,
    Email2 VARCHAR(255),
    Role VARCHAR(20) CHECK (Role IN ('student', 'teacher', 'employee')) NOT NULL,
);

