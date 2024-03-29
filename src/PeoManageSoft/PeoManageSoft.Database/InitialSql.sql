﻿CREATE TABLE IRole (
	Id BIGINT IDENTITY PRIMARY KEY NOT NULL,
	IsActive BIT NOT NULL, 
	Name NVARCHAR ( 200 ) NOT NULL UNIQUE,
	RequestId NVARCHAR ( 500 ) NOT NULL,
	CreationUser NVARCHAR ( 70 ) NOT NULL,
	CreationDate DATETIME NOT NULL,
	UpdatedUser NVARCHAR ( 70 ) NULL,
	UpdatedDate DATETIME NULL
);
GO

CREATE PROCEDURE sp_insert_role
	@IsActive BIT, 
	@Name NVARCHAR ( 200 ),
	@RequestId NVARCHAR ( 500 ),
	@CreationUser NVARCHAR ( 70 ),
	@CreationDate DATETIME
AS
BEGIN 
	INSERT INTO Role
	(
		IsActive, 
		Name,
		RequestId,
		CreationUser,
		CreationDate	
	)
	OUTPUT Inserted.ID
	VALUES 
	(
		@IsActive, 
		@Name,
		@RequestId,
		@CreationUser,
		@CreationDate	
	);
END;
GO

CREATE PROCEDURE sp_update_role
	@Id BIGINT,
	@IsActive BIT, 
	@Name NVARCHAR ( 200 ) ,
	@RequestId NVARCHAR ( 500 ),
	@UpdatedUser NVARCHAR ( 70 ),
	@UpdatedDate DATETIME
AS
BEGIN 
	UPDATE dbo.Role
	   SET IsActive = @IsActive
		  ,Name = @Name
		  ,RequestId = @RequestId
		  ,UpdatedUser = @UpdatedUser
		  ,UpdatedDate = @UpdatedDate
	 WHERE 
		Id = @Id
END;
GO

CREATE PROCEDURE sp_delete_role
	@Id BIGINT
AS
BEGIN 
	DELETE FROM dbo.Role WHERE Id = @Id
END;
GO

CREATE VIEW RoleView
AS
	SELECT
		Id AS Role_Id,
		IsActive AS Role_IsActive, 
		Name AS Role_Name,
		RequestId AS Role_RequestId,
		CreationUser AS Role_CreationUser,
		CreationDate AS Role_CreationDate,
		UpdatedUser AS Role_UpdatedUser,
		UpdatedDate AS Role_UpdatedDate	
	FROM
		Role 
GO

CREATE TABLE Title (
	Id BIGINT IDENTITY PRIMARY KEY NOT NULL,
	IsActive BIT NOT NULL, 
	Name NVARCHAR ( 200 ) NOT NULL UNIQUE,
	RequestId NVARCHAR ( 500 ) NOT NULL,
	CreationUser NVARCHAR ( 70 ) NOT NULL,
	CreationDate DATETIME NOT NULL,
	UpdatedUser NVARCHAR ( 70 ) NULL,
	UpdatedDate DATETIME NULL
);
GO

CREATE PROCEDURE sp_insert_title
	@IsActive BIT, 
	@Name NVARCHAR ( 200 ),
	@RequestId NVARCHAR ( 500 ),
	@CreationUser NVARCHAR ( 70 ),
	@CreationDate DATETIME
AS
BEGIN 
	INSERT INTO Title
	(
		IsActive, 
		Name,
		RequestId,
		CreationUser,
		CreationDate	
	)
	OUTPUT Inserted.ID
	VALUES 
	(
		@IsActive, 
		@Name,
		@RequestId,
		@CreationUser,
		@CreationDate	
	);
END;
GO

CREATE PROCEDURE sp_update_title
	@Id BIGINT,
	@IsActive BIT, 
	@Name NVARCHAR ( 200 ) ,
	@RequestId NVARCHAR ( 500 ),
	@UpdatedUser NVARCHAR ( 70 ),
	@UpdatedDate DATETIME
AS
BEGIN 
	UPDATE dbo.Title
	   SET IsActive = @IsActive
		  ,Name = @Name
		  ,RequestId = @RequestId
		  ,UpdatedUser = @UpdatedUser
		  ,UpdatedDate = @UpdatedDate
	 WHERE 
		Id = @Id
END;
GO

CREATE PROCEDURE sp_delete_title
	@Id BIGINT
AS
BEGIN 
	DELETE FROM dbo.Title WHERE Id = @Id
END;
GO

CREATE VIEW TitleView
AS
	SELECT
		Id AS Title_Id,
		IsActive AS Title_IsActive, 
		Name AS Title_Name,
		RequestId AS Title_RequestId,
		CreationUser AS Title_CreationUser,
		CreationDate AS Title_CreationDate,
		UpdatedUser AS Title_UpdatedUser,
		UpdatedDate AS Title_UpdatedDate	
	FROM
		Title 
GO

CREATE TABLE Department (
	Id BIGINT IDENTITY PRIMARY KEY NOT NULL,
	IsActive BIT NOT NULL, 
	Name NVARCHAR ( 200 ) NOT NULL UNIQUE,
	RequestId NVARCHAR ( 500 ) NOT NULL,
	CreationUser NVARCHAR ( 70 ) NOT NULL,
	CreationDate DATETIME NOT NULL,
	UpdatedUser NVARCHAR ( 70 ) NULL,
	UpdatedDate DATETIME NULL
);
GO

CREATE PROCEDURE sp_insert_department
	@IsActive BIT, 
	@Name NVARCHAR ( 200 ),
	@RequestId NVARCHAR ( 500 ),
	@CreationUser NVARCHAR ( 70 ),
	@CreationDate DATETIME
AS
BEGIN 
	INSERT INTO Department
	(
		IsActive, 
		Name,
		RequestId,
		CreationUser,
		CreationDate	
	)
	OUTPUT Inserted.ID
	VALUES 
	(
		@IsActive, 
		@Name,
		@RequestId,
		@CreationUser,
		@CreationDate	
	);
END;
GO

CREATE PROCEDURE sp_update_department
	@Id BIGINT,
	@IsActive BIT, 
	@Name NVARCHAR ( 200 ) ,
	@RequestId NVARCHAR ( 500 ),
	@UpdatedUser NVARCHAR ( 70 ),
	@UpdatedDate DATETIME
AS
BEGIN 
	UPDATE dbo.Department
	   SET IsActive = @IsActive
		  ,Name = @Name
		  ,RequestId = @RequestId
		  ,UpdatedUser = @UpdatedUser
		  ,UpdatedDate = @UpdatedDate
	 WHERE 
		Id = @Id
END;
GO

CREATE PROCEDURE sp_delete_department
	@Id BIGINT
AS
BEGIN 
	DELETE FROM dbo.Department WHERE Id = @Id
END;
GO

CREATE VIEW DepartmentView
AS
	SELECT
		Id AS Department_Id,
		IsActive AS Department_IsActive, 
		Name AS Department_Name,
		RequestId AS Department_RequestId,
		CreationUser AS Department_CreationUser,
		CreationDate AS Department_CreationDate,
		UpdatedUser AS Department_UpdatedUser,
		UpdatedDate AS Department_UpdatedDate	
	FROM
		Department 
GO

CREATE TABLE IUser (
	Id BIGINT IDENTITY PRIMARY KEY NOT NULL,
	IsActive BIT NOT NULL, 
	Login NVARCHAR ( 70 ) NOT NULL UNIQUE,
	Password NVARCHAR ( 500 ) NOT NULL,
	PasswordToken NVARCHAR ( MAX ) NULL,
	RoleId BIGINT NOT NULL,
	Name NVARCHAR ( 200 ) NOT NULL,
	ShortName NVARCHAR ( 50 ) NOT NULL,
	TitleId BIGINT NOT NULL,
	DepartmentId BIGINT NOT NULL,
	Email NVARCHAR ( 500 ) NOT NULL UNIQUE,
	BussinessPhone NVARCHAR ( 20 ) NULL,
	MobilePhone NVARCHAR ( 20 ) NULL,
	Location NVARCHAR ( 50 ) NULL,
	RequestId NVARCHAR ( 500 ) NOT NULL,
	CreationUser NVARCHAR ( 70 ) NOT NULL,
	CreationDate DATETIME NOT NULL,
	UpdatedUser NVARCHAR ( 70 ) NULL,
	UpdatedDate DATETIME NULL,
	CONSTRAINT FK_Role FOREIGN KEY(RoleId) REFERENCES IRole(Id),
	CONSTRAINT FK_Title FOREIGN KEY(TitleId) REFERENCES Title(Id),
	CONSTRAINT FK_Department FOREIGN KEY(DepartmentId) REFERENCES Department(Id)
);
GO

CREATE PROCEDURE sp_insert_user
	@IsActive BIT, 
	@Login NVARCHAR ( 70 ),
	@Password NVARCHAR ( 500 ),
	@RoleId BIGINT,
	@Name NVARCHAR ( 200 ) ,
	@ShortName NVARCHAR ( 50 ) ,
	@TitleId BIGINT,
	@DepartmentId BIGINT,
	@Email NVARCHAR ( 500 ),
	@BussinessPhone NVARCHAR ( 20 ) ,
	@MobilePhone NVARCHAR ( 20 ) ,
	@Location NVARCHAR ( 50 ) ,
	@RequestId NVARCHAR ( 500 ),
	@CreationUser NVARCHAR ( 70 ),
	@CreationDate DATETIME
AS
BEGIN 
	INSERT INTO IUser
	(
		IsActive, 
		Login,
		Password,
		RoleId,
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
		@RoleId,
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

CREATE PROCEDURE sp_update_user
	@Id BIGINT,
	@IsActive BIT, 
	@RoleId BIGINT,
	@Name NVARCHAR ( 200 ) ,
	@ShortName NVARCHAR ( 50 ) ,
	@TitleId BIGINT,
	@DepartmentId BIGINT,
	@Email NVARCHAR ( 500 ),
	@BussinessPhone NVARCHAR ( 20 ) ,
	@MobilePhone NVARCHAR ( 20 ) ,
	@RequestId NVARCHAR ( 500 ),
	@UpdatedUser NVARCHAR ( 70 ),
	@UpdatedDate DATETIME
AS
BEGIN 
	UPDATE dbo.IUser
	   SET IsActive = @IsActive
		  ,RoleId = @RoleId
		  ,Name = @Name
		  ,ShortName = @ShortName
		  ,TitleId = @TitleId
		  ,DepartmentId = @DepartmentId
		  ,Email = @Email
		  ,BussinessPhone = @BussinessPhone
		  ,MobilePhone = @MobilePhone
		  ,RequestId = @RequestId
		  ,UpdatedUser = @UpdatedUser
		  ,UpdatedDate = @UpdatedDate
	 WHERE 
		Id = @Id
END;
GO

CREATE PROCEDURE sp_delete_user
	@Id BIGINT
AS
BEGIN 
	DELETE FROM IUser WHERE Id = @Id
END;
GO

CREATE VIEW UserView
AS
	SELECT
		U.Id AS IUser_Id,
		U.IsActive AS IUser_IsActive, 
		U.Login AS IUser_Login,
		U.Password AS IUser_Password,
		U.PasswordToken AS IUser_PasswordToken,
		U.Name AS IUser_Name,
		U.ShortName AS IUser_ShortName,		
		U.Email AS IUser_Email,
		U.BussinessPhone AS IUser_BussinessPhone,
		U.MobilePhone AS IUser_MobilePhone,
		U.Location AS IUser_Location,
		U.RequestId AS IUser_RequestId,
		U.CreationUser AS IUser_CreationUser,
		U.CreationDate AS IUser_CreationDate,
		U.UpdatedUser AS IUser_UpdatedUser,
		U.UpdatedDate AS IUser_UpdatedDate,
		U.RoleId AS IUser_RoleId,
		U.TitleId AS IUser_TitleId,
		U.DepartmentId AS IUser_DepartmentId,
		R.Id AS Role_Id,
		R.IsActive AS Role_IsActive, 
		R.Name AS Role_Name,
		T.Id AS Title_Id,
		T.IsActive AS Title_IsActive, 
		T.Name AS Title_Name,		
		D.Id AS Department_Id,
		D.IsActive AS Department_IsActive, 
		D.Name AS Department_Name
	FROM
		IUser AS U
			INNER JOIN IRole AS R ON U.RoleId = R.Id
			INNER JOIN Title AS T ON U.TitleId = T.Id
			INNER JOIN Department AS D ON U.DepartmentId = D.Id
GO