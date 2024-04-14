USE Session1;

CREATE TABLE Employees (
    ID INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Phone VARCHAR(20),
    isAdmin BIT,
    Username VARCHAR(50),
    Password VARCHAR(50)
);

CREATE TABLE Parts (
    ID INT PRIMARY KEY IDENTITY,
    EffectiveLife VARCHAR(50)
);

CREATE TABLE Priorities (
    ID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50)
);

CREATE TABLE AssetGroups (
    ID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50)
);

CREATE TABLE Locations (
    ID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50)
);

CREATE TABLE Departments (
    ID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50)
);

CREATE TABLE DepartmentLocations (
    ID INT PRIMARY KEY IDENTITY,
    DepartmentID INT,
    LocationID INT,
    StartDate DATE,
    EndDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(ID),
    FOREIGN KEY (LocationID) REFERENCES Locations(ID)
);

CREATE TABLE Assets (
    ID INT PRIMARY KEY IDENTITY,
    AssetSN VARCHAR(255),
    AssetName VARCHAR(50),
    DepartmentLocationID INT,
    EmployeeID INT,
    AssetGroupID INT,
    Description VARCHAR(500),
    WarrantyDate DATE,
    FOREIGN KEY (DepartmentLocationID) REFERENCES DepartmentLocations(ID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(ID),
    FOREIGN KEY (AssetGroupID) REFERENCES AssetGroups(ID)
);

CREATE TABLE EmergencyMaintenances (
    ID INT PRIMARY KEY IDENTITY,
    AssetID INT,
    PriorityID INT,
    DescriptionEmergency VARCHAR(500),
    OtherConsiderations VARCHAR(500),
    EMReportDate DATE,
    EMStartDate DATE,
    EMEndDate DATE,
    EMTechnicianNote VARCHAR(500),
    FOREIGN KEY (AssetID) REFERENCES Assets(ID),
    FOREIGN KEY (PriorityID) REFERENCES Priorities(ID)
);

CREATE TABLE ChangedParts (
    ID INT PRIMARY KEY IDENTITY,
    EmergencyMaintenanceID INT,
    PartID INT,
    Amount VARCHAR(255),
    FOREIGN KEY (EmergencyMaintenanceID) REFERENCES EmergencyMaintenances(ID),
    FOREIGN KEY (PartID) REFERENCES Parts(ID)
);
