USE WorldSkills2020
GO

CREATE TABLE [Authorization]
(
	ID INT IDENTITY PRIMARY KEY,
	Username	NVARCHAR(50)	NOT NULL,
	[Password]	NVARCHAR(50)	NOT NULL,	
	RoleId		NCHAR(1)		NOT NULL
)
GO

INSERT INTO [Authorization] (Username, [Password], RoleId) VALUES ('Gena', '12345', 'E')
INSERT INTO [Authorization] (Username, [Password], RoleId) VALUES ('User', '12345', 'C')

CREATE TABLE [Role]
(
	[RoleId]	NCHAR(1)		NOT NULL,	
	[RoleName]	NVARCHAR(50)	NOT NULL,
	CONSTRAINT pk_Role	PRIMARY KEY ([RoleId])
)
GO

INSERT INTO [Role] (RoleId, RoleName) VALUES ('E', 'Employee')
INSERT INTO [Role] (RoleId, RoleName) VALUES ('C', 'Client')

CREATE TABLE Receipts
(
	ID INT IDENTITY(0,1),
	[SNP]		NVARCHAR(50)	NOT NULL,
	[Address]	NVARCHAR(150)	NOT NULL,
	[Service]	NVARCHAR(50)	NOT NULL,
	[Data]		DATE DEFAULT	GETDATE(),
	[Price]		MONEY			NOT NULL,
	[Status]	BIT				NOT NULL
)
GO