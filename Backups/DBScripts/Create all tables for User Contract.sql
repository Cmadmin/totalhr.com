USE [totalhr]
GO
/****** Object:  Table [dbo].[Label]    Script Date: 11/07/2014 14:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Label](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Term] [nvarchar](1000) NOT NULL,
	[RootId] [int] NOT NULL,
	[LanguageId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[LastUpdatedOn] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[Obsolete] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormField]    Script Date: 11/07/2014 14:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormField](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FormControlId] [int] NOT NULL,
	[LabelId] [int] NULL,
	[TooltipId] [int] NULL,
	[Created] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[obsolete] [bit] NOT NULL,
 CONSTRAINT [PK_FormField] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormControl]    Script Date: 11/07/2014 14:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FormControl](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Created] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[HtmlCode] [nvarchar](255) NULL,
	[LastModified] [datetime] NULL,
	[LastModifiedBy] [int] NULL,
	[obsolete] [bit] NOT NULL,
 CONSTRAINT [PK_FormControls] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContractTemplateSection]    Script Date: 11/07/2014 14:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractTemplateSection](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SectionName] [nvarchar](100) NOT NULL,
	[Heading] [nvarchar](2000) NULL,
	[Created] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[TemplateId] [int] NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
 CONSTRAINT [PK_TemplateSection] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractFormFieldValues]    Script Date: 11/07/2014 14:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractFormFieldValues](
	[FormFieldid] [int] NOT NULL,
	[Userid] [int] NOT NULL,
	[Value] [nvarchar](max) NULL,
	[IntValue] [int] NULL,
	[Created] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Lastupdated] [datetime] NULL,
	[LastupdatedBy] [int] NULL,
 CONSTRAINT [PK_ContractFormFieldValues] PRIMARY KEY CLUSTERED 
(
	[FormFieldid] ASC,
	[Userid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserContract]    Script Date: 11/07/2014 14:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserContract](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Userid] [int] NOT NULL,
	[TemplateId] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Lastupdated] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[Views] [int] NOT NULL,
	[LastViewed] [datetime] NULL,
 CONSTRAINT [PK_ContractTemplate] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractTemplate]    Script Date: 11/07/2014 14:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractTemplate](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[Created] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Lastupdated] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
 CONSTRAINT [PK_Template] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTSectionFieldLink]    Script Date: 11/07/2014 14:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTSectionFieldLink](
	[TemplateSectionId] [int] NOT NULL,
	[FormFieldId] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
 CONSTRAINT [PK_CTSectionFieldLink] PRIMARY KEY CLUSTERED 
(
	[TemplateSectionId] ASC,
	[FormFieldId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTemplateSectionLink]    Script Date: 11/07/2014 14:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTemplateSectionLink](
	[TemplateSectionId] [int] NOT NULL,
	[TemplateId] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
 CONSTRAINT [PK_TemplateSectionLink] PRIMARY KEY CLUSTERED 
(
	[TemplateSectionId] ASC,
	[TemplateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Template_Created]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[ContractTemplate] ADD  CONSTRAINT [DF_Template_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_TemplateSection_Created]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[ContractTemplateSection] ADD  CONSTRAINT [DF_TemplateSection_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_CTSectionFieldLink_Created]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[CTSectionFieldLink] ADD  CONSTRAINT [DF_CTSectionFieldLink_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_FormControls_Created]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[FormControl] ADD  CONSTRAINT [DF_FormControls_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_FormControls_obsolete]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[FormControl] ADD  CONSTRAINT [DF_FormControls_obsolete]  DEFAULT ((0)) FOR [obsolete]
GO
/****** Object:  Default [DF_FormField_Created]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[FormField] ADD  CONSTRAINT [DF_FormField_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_FormField_obsolete]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[FormField] ADD  CONSTRAINT [DF_FormField_obsolete]  DEFAULT ((0)) FOR [obsolete]
GO
/****** Object:  Default [DF__Label__RootId__503BEA1C]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[Label] ADD  DEFAULT ((-1)) FOR [RootId]
GO
/****** Object:  Default [DF__Label__LanguageI__51300E55]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[Label] ADD  DEFAULT ((1)) FOR [LanguageId]
GO
/****** Object:  Default [DF__Label__CreatedOn__5224328E]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[Label] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF__Label__Obsolete__531856C7]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[Label] ADD  DEFAULT ((0)) FOR [Obsolete]
GO
/****** Object:  Default [DF_ContractTemplate_Created]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[UserContract] ADD  CONSTRAINT [DF_ContractTemplate_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_UserContract_Views]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[UserContract] ADD  CONSTRAINT [DF_UserContract_Views]  DEFAULT ((0)) FOR [Views]
GO
/****** Object:  ForeignKey [FK_Template_User]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[ContractTemplate]  WITH CHECK ADD  CONSTRAINT [FK_Template_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[ContractTemplate] CHECK CONSTRAINT [FK_Template_User]
GO
/****** Object:  ForeignKey [FK_CTemplateSectionLink_ContractTemplateSection]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[CTemplateSectionLink]  WITH CHECK ADD  CONSTRAINT [FK_CTemplateSectionLink_ContractTemplateSection] FOREIGN KEY([TemplateSectionId])
REFERENCES [dbo].[ContractTemplateSection] ([id])
GO
ALTER TABLE [dbo].[CTemplateSectionLink] CHECK CONSTRAINT [FK_CTemplateSectionLink_ContractTemplateSection]
GO
/****** Object:  ForeignKey [FK_CTSectionFieldLink_ContractTemplateSection]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[CTSectionFieldLink]  WITH CHECK ADD  CONSTRAINT [FK_CTSectionFieldLink_ContractTemplateSection] FOREIGN KEY([TemplateSectionId])
REFERENCES [dbo].[ContractTemplateSection] ([id])
GO
ALTER TABLE [dbo].[CTSectionFieldLink] CHECK CONSTRAINT [FK_CTSectionFieldLink_ContractTemplateSection]
GO
/****** Object:  ForeignKey [FK_CTSectionFieldLink_FormField]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[CTSectionFieldLink]  WITH CHECK ADD  CONSTRAINT [FK_CTSectionFieldLink_FormField] FOREIGN KEY([FormFieldId])
REFERENCES [dbo].[FormField] ([id])
GO
ALTER TABLE [dbo].[CTSectionFieldLink] CHECK CONSTRAINT [FK_CTSectionFieldLink_FormField]
GO
/****** Object:  ForeignKey [FK_CTSectionFieldLink_User]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[CTSectionFieldLink]  WITH CHECK ADD  CONSTRAINT [FK_CTSectionFieldLink_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[CTSectionFieldLink] CHECK CONSTRAINT [FK_CTSectionFieldLink_User]
GO
/****** Object:  ForeignKey [FK_ContractTemplate_User]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[UserContract]  WITH CHECK ADD  CONSTRAINT [FK_ContractTemplate_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[UserContract] CHECK CONSTRAINT [FK_ContractTemplate_User]
GO
/****** Object:  ForeignKey [FK_UserContract_User]    Script Date: 11/07/2014 14:42:11 ******/
ALTER TABLE [dbo].[UserContract]  WITH CHECK ADD  CONSTRAINT [FK_UserContract_User] FOREIGN KEY([Userid])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[UserContract] CHECK CONSTRAINT [FK_UserContract_User]
GO
