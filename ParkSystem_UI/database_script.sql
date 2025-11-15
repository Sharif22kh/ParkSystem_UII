/* ================================================================================
 ONEWHERO BAY HERITAGE PARK - DATABASE SCRIPT
 This script will DROP (delete) the old database and REBUILD a clean
 one with the correct tables and sample data.
================================================================================
*/

/* 1. COMPLETELY DELETE THE OLD DATABASE (if it exists) */
/* This ensures a 100% clean start */
DROP DATABASE IF EXISTS OnewheroParkDB;
GO

/* 2. CREATE A NEW, EMPTY DATABASE */
CREATE DATABASE OnewheroParkDB;
GO

/* 3. SWITCH TO THE NEW DATABASE */
USE OnewheroParkDB;
GO

/* 4. CREATE THE VISITORS TABLE */
CREATE TABLE Visitors (
    VisitorID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    ContactInfo VARCHAR(100) NOT NULL
);
GO

/* 5. CREATE THE EVENTS TABLE */
CREATE TABLE Events (
    EventID INT PRIMARY KEY IDENTITY(1,1),
    EventDetails VARCHAR(255) NOT NULL,
    EventDate DATETIME NOT NULL
);
GO

/* 6. CREATE THE BOOKINGS TABLE (with Foreign Keys) */
CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    VisitorID INT NOT NULL,
    EventID INT NOT NULL,
    FOREIGN KEY (VisitorID) REFERENCES Visitors(VisitorID),
    FOREIGN KEY (EventID) REFERENCES Events(EventID)
);
GO

/* 7. POPULATE TABLES WITH THE CORRECT SAMPLE DATA */
SET IDENTITY_INSERT Visitors ON; -- Allow inserting specific IDs
INSERT INTO Visitors (VisitorID, Name, ContactInfo)
VALUES 
(1, 'Sharif', 'sharif@yoobee.com'),
(2, 'Ruhia', 'ruhia@yoobee.com');
SET IDENTITY_INSERT Visitors OFF; -- Turn off ID inserting
GO

SET IDENTITY_INSERT Events ON;
INSERT INTO Events (EventID, EventDetails, EventDate)
VALUES
(1, 'Nocturnal Kiwi House Tour', '2025-11-20T19:00:00'),
(2, 'Marae Cultural Experience', '2025-11-21T11:00:00'),
(3, 'Native Bird Feeding Session', '2025-11-22T14:30:00');
SET IDENTITY_INSERT Events OFF;
GO

/* 8. SAMPLE BOOKING: Sharif (VisitorID 1) books the Kiwi Tour (EventID 1) */
INSERT INTO Bookings (VisitorID, EventID)
VALUES
(1, 1);
GO