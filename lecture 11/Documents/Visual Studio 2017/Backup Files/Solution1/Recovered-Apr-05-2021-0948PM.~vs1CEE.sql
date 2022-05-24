

CREATE TABLE [tblStudents](
	[StudentId] [int] NOT NULL,
	[StudentName] [nvarchar](200) NOT NULL,
	[StudentEmail] [varchar](2200) NOT NULL,
	[IsMale] [bit] NOT NULL,
	[NickName] [nvarchar](250) NULL
) ON [PRIMARY]
GO

ALTER TABLE [tblStudents] ADD  CONSTRAINT [DF_tblStudents_IsMale]  DEFAULT ((0)) FOR [IsMale]
GO


