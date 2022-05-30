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
	@Password NVARCHAR ( 500 ),
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

CREATE PROCEDURE sp_validate_insert_user
	@Login NVARCHAR ( 70 ),
	@TitleId BIGINT,
	@DepartmentId BIGINT,
	@Email NVARCHAR ( 500 )
AS
BEGIN 
	DECLARE @LoginExists AS BIT = 0
	DECLARE @EmailExists AS BIT = 0

	DECLARE @TableErrors AS TABLE (
		Message NVARCHAR(MAX) NOT NULL
	);

	SELECT  @LoginExists = 1 FROM dbo.IUser Where UPPER(trim(Login)) = UPPER(trim(@Login))
	SELECT  @EmailExists = 1 FROM dbo.IUser Where UPPER(trim(Email)) = UPPER(trim(@Email))

	IF @LoginExists = 1
		INSERT INTO @TableErrors VALUES('Login already exists!')
	
	IF NOT EXISTS(SELECT * FROM dbo.Title Where Id = @TitleId)
		INSERT INTO @TableErrors VALUES('TitleId does not exist!')

	IF NOT EXISTS(SELECT * FROM dbo.Department Where Id = @DepartmentId)
		INSERT INTO @TableErrors VALUES('DepartmentId does not exist!')

	IF @EmailExists = 1
		INSERT INTO @TableErrors VALUES('Email already exists!')

	SELECT Message FROM @TableErrors
END;
GO

CREATE PROCEDURE sp_validate_update_user
	@Id BIGINT,
	@TitleId BIGINT,
	@DepartmentId BIGINT,
	@Email NVARCHAR ( 500 )
AS
BEGIN 
	DECLARE @LoginExists AS BIT = 0
	DECLARE @TitleIdExists AS BIT = 0
	DECLARE @DepartmentIdExists AS BIT = 0
	DECLARE @EmailExists AS BIT = 0

	DECLARE @TableErrors AS TABLE (
		Message NVARCHAR(MAX) NOT NULL
	);

	SELECT  @EmailExists = 1 FROM dbo.IUser Where UPPER(trim(Email)) = UPPER(trim(@Email)) AND Id <> @Id

	IF NOT EXISTS(SELECT * FROM dbo.Title Where Id = @TitleId)
		INSERT INTO @TableErrors VALUES('TitleId does not exist!')

	IF NOT EXISTS(SELECT * FROM dbo.Department Where Id = @DepartmentId)
		INSERT INTO @TableErrors VALUES('DepartmentId does not exist!')

	IF NOT EXISTS(SELECT * FROM dbo.IUser Where Id = @Id)
		INSERT INTO @TableErrors VALUES('UserId does not exist!')
	ELSE
		IF @EmailExists = 1
			INSERT INTO @TableErrors VALUES('Email already exists!')

	SELECT Message FROM @TableErrors
END;
GO