﻿CREATE TABLE Title (
	Id BIGINT NOT NULL GENERATED ALWAYS AS IDENTITY,
	IsActive BOOLEAN NOT NULL, 
	Name VARCHAR ( 200 ) NOT NULL,
	RequestId VARCHAR ( 500 ) NOT NULL,
	CreationUser VARCHAR ( 70 ) NOT NULL,
	CreationDate TIMESTAMP NOT NULL,
	UpdatedUser VARCHAR ( 70 ) NULL,
	UpdatedDate TIMESTAMP NOT NULL,
	PRIMARY KEY(Id)
);

CREATE TABLE Department (
	Id BIGINT NOT NULL GENERATED ALWAYS AS IDENTITY,
	IsActive BOOLEAN NOT NULL, 
	Name VARCHAR ( 200 ) NOT NULL,
	RequestId VARCHAR ( 500 ) NOT NULL,
	CreationUser VARCHAR ( 70 ) NOT NULL,
	CreationDate TIMESTAMP NOT NULL,
	UpdatedUser VARCHAR ( 70 ) NULL,
	UpdatedDate TIMESTAMP NOT NULL,
	PRIMARY KEY(Id)
);

CREATE TABLE TbUser (
	Id BIGINT NOT NULL GENERATED ALWAYS AS IDENTITY,
	IsActive BOOLEAN NOT NULL, 
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
	CreationDate TIMESTAMP NOT NULL,
	UpdatedUser VARCHAR ( 70 ) NULL,
	UpdatedDate TIMESTAMP NOT NULL,
	PRIMARY KEY(Id),
	CONSTRAINT FK_Title FOREIGN KEY(TitleId) REFERENCES Title(Id),
	CONSTRAINT FK_Department FOREIGN KEY(DepartmentId) REFERENCES Department(Id)
);