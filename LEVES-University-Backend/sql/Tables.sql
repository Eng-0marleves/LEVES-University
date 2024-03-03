-- Users Table
CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Name VARCHAR(255),
    PhoneNumber VARCHAR(20),
    ProfileImage VARCHAR(255),
    Password VARCHAR(255),
    Email1 VARCHAR(255),
    Email2 VARCHAR(255)
);

-- Teachers Table
CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY,
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    -- Additional Teacher Details...
);

-- Students Table
CREATE TABLE Students (
    StudentID INT PRIMARY KEY,
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    -- Additional Student Details...
);

-- Employees Table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    -- Additional Employee Details...
);

-- Courses Table
CREATE TABLE Courses (
    CourseID INT PRIMARY KEY,
    CourseName VARCHAR(255),
    Description TEXT,
    StartDate DATE,
    EndDate DATE,
    TeacherID INT FOREIGN KEY REFERENCES Teachers(TeacherID),
    -- Additional Course Details...
);

-- Library Table
CREATE TABLE Library (
    ResourceID INT PRIMARY KEY,
    Title VARCHAR(255),
    Author VARCHAR(255),
    PublicationYear INT,
    Description TEXT,
    -- Additional Resource Details...
);

-- Articles Table
CREATE TABLE Articles (
    ArticleID INT PRIMARY KEY,
    Title VARCHAR(255),
    Author VARCHAR(255),
    PublicationDate DATE,
    Content TEXT,
    -- Additional Article Details...
);

-- News Table
CREATE TABLE News (
    NewsID INT PRIMARY KEY,
    Title VARCHAR(255),
    Description TEXT,
    PublicationDate DATE,
    -- Additional News Details...
);

-- CourseMaterials Table
CREATE TABLE CourseMaterials (
    MaterialID INT PRIMARY KEY,
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID),
    Title VARCHAR(255),
    Description TEXT,
    FileLink VARCHAR(255),
    -- Additional Material Details...
);

-- Posts Table
CREATE TABLE Posts (
    PostID INT PRIMARY KEY,
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    Content TEXT,
    PostDate DATETIME,
    -- Additional Post Details...
);

-- Pages Table
CREATE TABLE Pages (
    PageID INT PRIMARY KEY,
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    Title VARCHAR(255),
    Content TEXT,
    CreationDate DATETIME,
    -- Additional Page Details...
);

-- Enrollments Table
CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY,
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID),
    EnrollmentDate DATE,
    -- Additional Enrollment Details...
);

-- CourseGroups Table
CREATE TABLE CourseGroups (
    GroupID INT PRIMARY KEY,
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID),
    GroupName VARCHAR(255),
    -- Additional Group Details...
);

-- Attendance Table
CREATE TABLE Attendance (
    AttendanceID INT PRIMARY KEY,
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID),
    AttendanceDate DATE,
    IsPresent BIT,
    -- Additional Attendance Details...
);

-- Grades Table
CREATE TABLE Grades (
    GradeID INT PRIMARY KEY,
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID),
    AssignmentID INT FOREIGN KEY REFERENCES Assignments(AssignmentID),
    QuizID INT FOREIGN KEY REFERENCES Quizzes(QuizID),
    Grade FLOAT,
    -- Additional Grade Details...
);

-- Assignments Table
CREATE TABLE Assignments (
    AssignmentID INT PRIMARY KEY,
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID),
    Title VARCHAR(255),
    Description TEXT,
    Deadline DATE,
    -- Additional Assignment Details...
);

-- Quizzes Table
CREATE TABLE Quizzes (
    QuizID INT PRIMARY KEY,
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID),
    Title VARCHAR(255),
    Description TEXT,
    Deadline DATE,
    -- Additional Quiz Details...
);
