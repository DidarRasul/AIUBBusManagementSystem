-- ============================================
-- AIUB BUS MANAGEMENT SYSTEM
-- DATABASE TABLES
-- ============================================


-- =====================
-- 1. USERS
-- =====================

CREATE TABLE Users
(
    Id INT IDENTITY(1,1) PRIMARY KEY,

    Name VARCHAR(100) NOT NULL,

    Username VARCHAR(50) NOT NULL UNIQUE,

    Password VARCHAR(100) NOT NULL,

    Email VARCHAR(100) NULL,

    Role VARCHAR(20) NOT NULL,

    Status VARCHAR(20) NOT NULL DEFAULT 'Pending',

    CONSTRAINT CK_Users_Role
    CHECK (Role IN ('Admin', 'Student', 'Driver')),

    CONSTRAINT CK_Users_Status
    CHECK (Status IN ('Pending', 'Active', 'Blocked'))
);


-- =====================
-- 2. STUDENT PROFILES
-- =====================

CREATE TABLE StudentProfiles
(
    UserId INT PRIMARY KEY,

    StudentId VARCHAR(30) NOT NULL UNIQUE,

    Department VARCHAR(100) NOT NULL,

    Email VARCHAR(100) NOT NULL,

    CONSTRAINT FK_StudentProfiles_Users
    FOREIGN KEY (UserId)
    REFERENCES Users(Id)
    ON DELETE CASCADE
);


-- =====================
-- 3. DRIVER PROFILES
-- =====================

CREATE TABLE DriverProfiles
(
    UserId INT PRIMARY KEY,

    LicenseNo VARCHAR(50) NOT NULL UNIQUE,

    Phone VARCHAR(20) NOT NULL,

    CONSTRAINT FK_DriverProfiles_Users
    FOREIGN KEY (UserId)
    REFERENCES Users(Id)
    ON DELETE CASCADE
);


-- =====================
-- 4. ROUTES
-- =====================

CREATE TABLE Routes
(
    Id INT IDENTITY(1,1) PRIMARY KEY,

    RouteName VARCHAR(100) NOT NULL,

    Direction VARCHAR(30) NOT NULL,

    CONSTRAINT CK_Routes_Direction
    CHECK (Direction IN ('ToUniversity', 'FromUniversity'))
);


-- =====================
-- 5. ROUTE LOCATIONS
-- =====================

CREATE TABLE RouteLocations
(
    Id INT IDENTITY(1,1) PRIMARY KEY,

    RouteId INT NOT NULL,

    LocationName VARCHAR(100) NOT NULL,

    CONSTRAINT FK_RouteLocations_Routes
    FOREIGN KEY (RouteId)
    REFERENCES Routes(Id)
    ON DELETE CASCADE
);


-- =====================
-- 6. TIME SLOTS
-- =====================

CREATE TABLE TimeSlots
(
    Id INT IDENTITY(1,1) PRIMARY KEY,

    StartTime TIME NOT NULL,

    EndTime TIME NOT NULL,

    CONSTRAINT CK_TimeSlots_Time
    CHECK (EndTime > StartTime)
);


-- =====================
-- 7. BUS ASSIGNMENTS
-- =====================

CREATE TABLE BusAssignments
(
    Id INT IDENTITY(1,1) PRIMARY KEY,

    RouteId INT NOT NULL,

    DriverId INT NOT NULL,

    TimeSlotId INT NOT NULL,

    Date DATE NOT NULL,

    CONSTRAINT FK_BusAssignments_Routes
    FOREIGN KEY (RouteId)
    REFERENCES Routes(Id),

    CONSTRAINT FK_BusAssignments_Users
    FOREIGN KEY (DriverId)
    REFERENCES Users(Id),

    CONSTRAINT FK_BusAssignments_TimeSlots
    FOREIGN KEY (TimeSlotId)
    REFERENCES TimeSlots(Id)
);


-- =====================
-- 8. STUDENT PICKUP SELECTIONS
-- =====================

CREATE TABLE StudentPickupSelections
(
    Id INT IDENTITY(1,1) PRIMARY KEY,

    StudentId INT NOT NULL,

    LocationId INT NOT NULL,

    TimeSlotId INT NOT NULL,

    CONSTRAINT FK_PickupSelections_Users
    FOREIGN KEY (StudentId)
    REFERENCES Users(Id)
    ON DELETE CASCADE,

    CONSTRAINT FK_PickupSelections_RouteLocations
    FOREIGN KEY (LocationId)
    REFERENCES RouteLocations(Id)
    ON DELETE CASCADE,

    CONSTRAINT FK_PickupSelections_TimeSlots
    FOREIGN KEY (TimeSlotId)
    REFERENCES TimeSlots(Id)
    ON DELETE CASCADE,

    CONSTRAINT UQ_Student_TimeSlot
    UNIQUE (StudentId, TimeSlotId)
);


-- =====================
-- 9. TRAVEL LOGS
-- =====================

CREATE TABLE TravelLogs
(
    Id INT IDENTITY(1,1) PRIMARY KEY,

    StudentId INT NOT NULL,

    AssignmentId INT NOT NULL,

    Amount DECIMAL(10,2) NOT NULL,

    IsPaid BIT NOT NULL DEFAULT 0,

    PickupConfirmed BIT NOT NULL DEFAULT 0,

    Date DATE NOT NULL,

    CONSTRAINT FK_TravelLogs_Users
    FOREIGN KEY (StudentId)
    REFERENCES Users(Id),

    CONSTRAINT FK_TravelLogs_BusAssignments
    FOREIGN KEY (AssignmentId)
    REFERENCES BusAssignments(Id),

    CONSTRAINT UQ_TravelLog
    UNIQUE (StudentId, AssignmentId, Date)
);