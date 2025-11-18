

/* This ensures a 100% clean start */
DROP DATABASE IF EXISTS OnewheroParkDB;
GO

/* this create a new, database */

CREATE DATABASE OnewheroParkDB;
GO

/*  SWITCH TO THE NEW DATABASE */
USE OnewheroParkDB;
GO

/* CREATE THE VISITORS TABLE */
CREATE TABLE Visitors (
    VisitorID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    ContactInfo VARCHAR(100) NOT NULL
);
GO

/*  CREATE THE EVENTS TABLE */
CREATE TABLE Events (
    EventID INT PRIMARY KEY IDENTITY(1,1),
    EventDetails VARCHAR(255) NOT NULL,
    EventDate DATETIME NOT NULL
);
GO

/*  CREATE THE BOOKINGS TABLE */
CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    VisitorID INT NOT NULL,
    EventID INT NOT NULL,
    FOREIGN KEY (VisitorID) REFERENCES Visitors(VisitorID),
    FOREIGN KEY (EventID) REFERENCES Events(EventID)
);
GO

/*  dummy visirtors to do th4e4 testing*/
SET IDENTITY_INSERT Visitors ON; 
INSERT INTO Visitors (VisitorID, Name, ContactInfo)
VALUES 
(1, 'Sharif', 'sharif@yoobee.com'),
(2, 'Ruiha', 'ruiha@yoobee.com');
SET IDENTITY_INSERT Visitors OFF; 
GO

SET IDENTITY_INSERT Events ON;
INSERT INTO Events (EventID, EventDetails, EventDate)
VALUES
(1, 'Nocturnal Kiwi House Tour', '2025-11-20T19:00:00'),
(2, 'Marae Cultural Experience', '2025-11-21T11:00:00'),
(3, 'Native Bird Feeding Session', '2025-11-22T14:30:00');
SET IDENTITY_INSERT Events OFF;
GO

/* sample booking for : Sharif (VisitorID 1) books the Kiwi Tour (EventID 1) */
INSERT INTO Bookings (VisitorID, EventID)
VALUES
(1, 1);
GO