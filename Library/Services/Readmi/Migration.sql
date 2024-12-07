Create database CouseDB;


CREATE TABLE Students (
    StudentId SERIAL PRIMARY KEY,
    First_Name VARCHAR(50),
    Last_Name VARCHAR(50),
    Age INT,
    Address VARCHAR(100),
    PhoneNumber VARCHAR(15),
    Email VARCHAR(50)
);



CREATE TABLE Mentors (
    MentorId SERIAL PRIMARY KEY,
    First_Name VARCHAR(50),
    Last_Name VARCHAR(50),
    Age INT,
    Email VARCHAR(50),
    PhoneNumber VARCHAR(15),
    Address VARCHAR(100)
);


CREATE TABLE Groups (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(50),
    Description TEXT,
    StudentId INT REFERENCES Students(StudentId),
    MentorId INT REFERENCES Mentors(MentorId)
);


CREATE TABLE Courses (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(50),
    Description TEXT,
    CreateDate TIMESTAMP DEFAULT NOW(),
    GroupId INT REFERENCES Groups(Id),
    MentorId INT REFERENCES Mentors(MentorId),
    StudentId INT REFERENCES Students(StudentId)
);


INSERT INTO Students (First_Name, Last_Name, Age, Address, PhoneNumber, Email)
VALUES
('Ali', 'Karimi', 20, 'Dushanbe', '987654321', 'ali.karimi@mail.com'),
('Zahra', 'Rahimi', 21, 'Khujand', '987654322', 'zahra.rahimi@mail.com'),
('Omar', 'Saidov', 22, 'Kulob', '987654323', 'omar.saidov@mail.com'),
('Maryam', 'Habibi', 23, 'Dushanbe', '987654324', 'maryam.habibi@mail.com'),
('Rustam', 'Azizov', 20, 'Panjakent', '987654325', 'rustam.azizov@mail.com'),
('Layla', 'Gulzoda', 24, 'Khorog', '987654326', 'layla.gulzoda@mail.com'),
('Imran', 'Shah', 21, 'Vahdat', '987654327', 'imran.shah@mail.com'),
('Nilufar', 'Hakimi', 22, 'Rudaki', '987654328', 'nilufar.hakimi@mail.com'),
('Farid', 'Kamolov', 23, 'Gissar', '987654329', 'farid.kamolov@mail.com'),
('Amina', 'Sabz', 24, 'Shahrinav', '987654330', 'amina.sabz@mail.com');


INSERT INTO Mentors (First_Name, Last_Name, Age, Email, PhoneNumber, Address)
VALUES
('Asad', 'Jafari', 30, 'asad.jafari@mail.com', '123456789', 'Dushanbe'),
('Sara', 'Nemat', 29, 'sara.nemat@mail.com', '123456780', 'Khujand'),
('Omid', 'Zarif', 35, 'omid.zarif@mail.com', '123456781', 'Kulob'),
('Shabnam', 'Rahimova', 28, 'shabnam.rahimova@mail.com', '123456782', 'Dushanbe'),
('Farhad', 'Samimi', 32, 'farhad.samimi@mail.com', '123456783', 'Panjakent'),
('Sadaf', 'Noor', 31, 'sadaf.noor@mail.com', '123456784', 'Khorog'),
('Navid', 'Rahbar', 33, 'navid.rahbar@mail.com', '123456785', 'Vahdat'),
('Samira', 'Ehsani', 29, 'samira.ehsani@mail.com', '123456786', 'Rudaki'),
('Ahmad', 'Hamidi', 34, 'ahmad.hamidi@mail.com', '123456787', 'Gissar'),
('Parisa', 'Jami', 30, 'parisa.jami@mail.com', '123456788', 'Shahrinav');


INSERT INTO Groups (Name, Description, StudentId, MentorId)
VALUES
('Group A', 'Advanced group', 1, 1),
('Group B', 'Beginner group', 2, 2),
('Group C', 'Intermediate group', 3, 3),
('Group D', 'Math enthusiasts', 4, 4),
('Group E', 'Coding enthusiasts', 5, 5),
('Group F', 'Science lovers', 6, 6),
('Group G', 'Reading club', 7, 7),
('Group H', 'Sports enthusiasts', 8, 8),
('Group I', 'Music lovers', 9, 9),
('Group J', 'Art enthusiasts', 10, 10);


INSERT INTO Courses (Name, Description, GroupId, MentorId, StudentId)
VALUES
('Math 101', 'Basic mathematics course', 1, 1, 1),
('Physics 101', 'Intro to physics', 2, 2, 2),
('Coding 101', 'Learn coding basics', 3, 3, 3),
('Chemistry 101', 'Introduction to chemistry', 4, 4, 4),
('Biology 101', 'Basics of biology', 5, 5, 5),
('Art 101', 'Introduction to arts', 6, 6, 6),
('Music 101', 'Learn the basics of music', 7, 7, 7),
('History 101', 'Basics of history', 8, 8, 8),
('Geography 101', 'Learn about the earth', 9, 9, 9),
('Programming 101', 'Introduction to programming', 10, 10, 10);
