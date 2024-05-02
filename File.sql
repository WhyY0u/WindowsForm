USE Session1;

INSERT INTO Employees (FirstName, LastName, Phone, isAdmin, Username, Password)
VALUES 
    ('Jane', 'Smith', '234-567-8901', 0, 'jane_smith', 'password456'),
    ('Mike', 'Johnson', '345-678-9012', 0, 'mike_johnson', 'password789'),
    ('KillMe', 'Badd', '345-455-123', 1, 'JustWork', 'password789');

INSERT INTO Parts (EffectiveLife, Name)
VALUES 
    ('2026-01-01', 'Dvigatil'),
    ('2021-01-01', 'Kardan'),
    ('2019-01-01', 'Kolotki');

INSERT INTO Priorities (Name)
VALUES 
    ('Priority1'),
    ('Priority2'),
    ('Priority3');

INSERT INTO AssetGroups (Name)
VALUES 
    ('AssetGR1'),
    ('AssetGR2'),
    ('AssetGR3');

INSERT INTO Locations (Name)
VALUES 
    ('Loc1'),
    ('Loc2'),
    ('Loc3');

INSERT INTO Departments (Name)
VALUES 
    ('Depart1'),
    ('Depart2'),
    ('Depart3');

INSERT INTO DepartmentLocations (DepartmentID, LocationID, StartDate, EndDate)
VALUES 
    (1, 1, '2022-01-01', '2018-09-08'),     
    (2, 2, '2022-01-01', '2008-01-02'),
    (3, 3, '2022-01-01', NULL);

INSERT INTO Assets (AssetSN, AssetName, DepartmentLocationID, EmployeeID, AssetGroupID, Description, WarrantyDate)
VALUES 
    ('03/05/009', 'Name1', 1, 1, 1, 'Description1', '2018-09-08'),     
    ('01/11/0014', 'Name2', 2, 1, 2, 'Description2', '2008-01-02'),
    ('03/05/0015', 'Name3', 3, 1, 3, 'Description3', NULL);

INSERT INTO EmergencyMaintenances (AssetID, PriorityID, DescriptionEmergency, OtherConsiderations, EMReportDate, EMStartDate, EMEndDate, EMTechnicianNote)
VALUES 
    (1, 1, 'Description1', 'OtherConsiderations1', '2022-01-01', '2012-08-01', '2018-09-08', 'TechnicianNote1'),     
    (2, 2, 'Description2', 'OtherConsiderations2', '2022-01-01', '2012-06-01', '2018-09-08', 'TechnicianNote2'),
    (3, 3, 'Description3', 'OtherConsiderations3', '2022-01-01', '2022-01-01', NULL, 'TechnicianNote3');

INSERT INTO ChangedParts (EmergencyMaintenanceID, PartID, Amount)
VALUES 
    (1, 1, 'Amount1'),     
    (2, 2, 'Amount2'),
    (3, 3, 'Amount3');
