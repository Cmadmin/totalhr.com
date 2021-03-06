﻿CREATE TABLE [dbo].[User] (
    [id]                 INT              IDENTITY (1, 1) NOT NULL,
    [GenderId]           INT              NOT NULL,
    [firstname]          NVARCHAR (50)    NOT NULL,
    [othernames]         NVARCHAR (50)    NULL,
    [surname]            NVARCHAR (50)    NOT NULL,
    [title]              INT              NOT NULL,
    [othertitle]         NVARCHAR (30)    NULL,
    [username]           NVARCHAR (100)   NOT NULL,
    [Address1]           NVARCHAR (255)   NULL,
    [Address2]           NVARCHAR (255)   NULL,
    [Address3]           NVARCHAR (255)   NULL,
    [Town]               NVARCHAR (50)    NULL,
    [stateorcounty]      NVARCHAR (50)    NULL,
    [PostCode]           NVARCHAR (30)    NULL,
    [countryId]          INT              NOT NULL,
    [Phone]              NVARCHAR (30)    NULL,
    [Mobile]             NVARCHAR (30)    NULL,
    [CompanyId]          INT              NOT NULL,
    [created]            DATETIME         CONSTRAINT [DF_user_created] DEFAULT (getdate()) NOT NULL,
    [createdby]          INT              NOT NULL,
    [lastvisit]          DATETIME         NULL,
    [novisits]           INT              CONSTRAINT [DF_user_novisits] DEFAULT ((0)) NOT NULL,
    [active]             BIT              CONSTRAINT [DF_user_active] DEFAULT ((0)) NOT NULL,
    [email]              NVARCHAR (100)   NOT NULL,
    [password]           NVARCHAR (150)   NOT NULL,
    [lastupdatedby]      INT              NULL,
    [lastupdated]        DATETIME         NULL,
    [typeid]             INT              NOT NULL,
    [userguid]           UNIQUEIDENTIFIER CONSTRAINT [DF_user_userguid] DEFAULT (newid()) NOT NULL,
    [preferedlanguageid] INT              CONSTRAINT [DF_user_preferedlanguageid] DEFAULT ((1)) NOT NULL,
    [tersmaccepted]      BIT              CONSTRAINT [DF_User_tersmaccepted] DEFAULT ((0)) NOT NULL,
    [activationcode]     NVARCHAR (150)   NULL,
    [chosenculture]      VARCHAR (10)     NULL,
    [departmentid]       INT              CONSTRAINT [DF_User_departmentid] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_User_Department] FOREIGN KEY ([departmentid]) REFERENCES [dbo].[Department] ([id])
);





