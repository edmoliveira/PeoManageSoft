CREATE TABLE Title (
	Id BIGINT IDENTITY PRIMARY KEY NOT NULL,
	IsActive BIT NOT NULL, 
	Name VARCHAR ( 200 ) NOT NULL,
	RequestId VARCHAR ( 500 ) NOT NULL,
	CreationUser VARCHAR ( 70 ) NOT NULL,
	CreationDate DATETIME NOT NULL,
	UpdatedUser VARCHAR ( 70 ) NULL,
	UpdatedDate DATETIME NULL
);
GO

CREATE TABLE Department (
	Id BIGINT IDENTITY PRIMARY KEY NOT NULL,
	IsActive BIT NOT NULL, 
	Name VARCHAR ( 200 ) NOT NULL,
	RequestId VARCHAR ( 500 ) NOT NULL,
	CreationUser VARCHAR ( 70 ) NOT NULL,
	CreationDate DATETIME NOT NULL,
	UpdatedUser VARCHAR ( 70 ) NULL,
	UpdatedDate DATETIME NULL
);
GO

CREATE TABLE IUser (
	Id BIGINT IDENTITY PRIMARY KEY NOT NULL,
	IsActive BIT NOT NULL, 
	Login VARCHAR ( 70 ) NOT NULL UNIQUE,
	Password VARCHAR ( 500 ) NOT NULL,
	Role INTEGER NOT NULL,
	Name VARCHAR ( 200 ) NOT NULL,
	ShortName VARCHAR ( 50 ) NOT NULL,
	TitleId BIGINT NOT NULL,
	DepartmentId BIGINT NOT NULL,
	Email VARCHAR ( 500 ) NOT NULL UNIQUE,
	BussinessPhone VARCHAR ( 20 ) NULL,
	MobilePhone VARCHAR ( 20 ) NULL,
	Location VARCHAR ( 20 ) NULL,
	RequestId VARCHAR ( 500 ) NOT NULL,
	CreationUser VARCHAR ( 70 ) NOT NULL,
	CreationDate DATETIME NOT NULL,
	UpdatedUser VARCHAR ( 70 ) NULL,
	UpdatedDate DATETIME NULL,
	CONSTRAINT FK_Title FOREIGN KEY(TitleId) REFERENCES Title(Id),
	CONSTRAINT FK_Department FOREIGN KEY(DepartmentId) REFERENCES Department(Id)
);
GO

CREATE PROCEDURE sp_insert_user
	@IsActive BIT, 
	@Login VARCHAR ( 70 ),
	@Password VARCHAR ( 500 ),
	@Role INTEGER,
	@Name VARCHAR ( 200 ) ,
	@ShortName VARCHAR ( 50 ) ,
	@TitleId BIGINT,
	@DepartmentId BIGINT,
	@Email VARCHAR ( 500 ),
	@BussinessPhone VARCHAR ( 20 ) ,
	@MobilePhone VARCHAR ( 20 ) ,
	@Location VARCHAR ( 20 ) ,
	@RequestId VARCHAR ( 500 ),
	@CreationUser VARCHAR ( 70 ),
	@CreationDate DATETIME
AS
BEGIN 
	INSERT INTO IUser
	(
		IsActive, 
		Login,
		Password,
		Role,
		Name,
		ShortName,
		TitleId,
		DepartmentId,
		Email,
		BussinessPhone,
		MobilePhone,
		Location,
		RequestId,
		CreationUser,
		CreationDate	
	)
	OUTPUT Inserted.ID
	VALUES 
	(
		@IsActive, 
		@Login,
		@Password,
		@Role,
		@Name,
		@ShortName,
		@TitleId,
		@DepartmentId,
		@Email,
		@BussinessPhone,
		@MobilePhone,
		@Location,
		@RequestId,
		@CreationUser,
		@CreationDate	
	);
END;
GO

CREATE PROCEDURE sp_select_user
AS
BEGIN 
	SELECT
		U.Id,
		U.IsActive, 
		U.Login,
		U.Password,
		U.Role,
		U.Name,
		U.ShortName,		
		U.Email,
		U.BussinessPhone,
		U.MobilePhone,
		U.Location,
		U.RequestId,
		U.CreationUser,
		U.CreationDate,
		U.TitleId,
		T.Id,
		T.Name,
		U.DepartmentId,
		D.Id,
		D.Name
	FROM
		IUser AS U
			INNER JOIN Title AS T ON U.TitleId = T.Id
			INNER JOIN Department AS D ON U.DepartmentId = D.Id
END;
GO

CREATE PROCEDURE sp_select_by_id_user
	@Id BIGINT
AS
BEGIN 
	SELECT
		U.Id,
		U.IsActive, 
		U.Login,
		U.Password,
		U.Role,
		U.Name,
		U.ShortName,		
		U.Email,
		U.BussinessPhone,
		U.MobilePhone,
		U.Location,
		U.RequestId,
		U.CreationUser,
		U.CreationDate,
		U.TitleId,
		T.Id,
		T.Name,
		U.DepartmentId,
		D.Id,
		D.Name
	FROM
		IUser AS U
			INNER JOIN Title AS T ON U.TitleId = T.Id
			INNER JOIN Department AS D ON U.DepartmentId = D.Id
	WHERE
		U.Id = @Id
END;
GO