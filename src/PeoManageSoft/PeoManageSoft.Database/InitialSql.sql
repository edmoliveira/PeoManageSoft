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

CREATE TABLE IUser (
	Id BIGINT IDENTITY PRIMARY KEY NOT NULL,
	IsActive BIT NOT NULL, 
	Login NVARCHAR ( 70 ) NOT NULL UNIQUE,
	Password NVARCHAR ( 500 ) NOT NULL,
	PasswordToken NVARCHAR ( MAX ) NULL,
	Role INTEGER NOT NULL,
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
	CONSTRAINT FK_Title FOREIGN KEY(TitleId) REFERENCES Title(Id),
	CONSTRAINT FK_Department FOREIGN KEY(DepartmentId) REFERENCES Department(Id)
);
GO

CREATE PROCEDURE sp_insert_user
	@IsActive BIT, 
	@Login NVARCHAR ( 70 ),
	@Password NVARCHAR ( 500 ),
	@Role INTEGER,
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

CREATE PROCEDURE sp_update_user
	@Id BIGINT,
	@IsActive BIT, 
	@Role INTEGER,
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
		  ,Role = @Role
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

CREATE PROCEDURE sp_exists_by_id_user
	@Id BIGINT
AS
BEGIN 
	SELECT CAST(1 AS BIT) FROM IUser WHERE Id = @Id
END;
GO

CREATE VIEW UserView
AS
	SELECT
		U.Id AS IUser_Id,
		U.IsActive AS IUser_IsActive, 
		U.Login AS IUser_Login,
		U.Password AS IUser_Password,
		U.Role AS IUser_Role,
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
		U.TitleId AS IUser_TitleId,
		U.DepartmentId AS IUser_DepartmentId,
		T.Id AS Title_Id,
		T.Name AS Title_Name,		
		D.Id AS Department_Id,
		D.Name AS Department_Name
	FROM
		IUser AS U
			INNER JOIN Title AS T ON U.TitleId = T.Id
			INNER JOIN Department AS D ON U.DepartmentId = D.Id
GO