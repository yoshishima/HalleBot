USE [hallebot]
GO

/****** Object:  Table [dbo].[patient]    Script Date: 4/2/2016 12:11:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[patient](
	[patientID] [varchar](255) NOT NULL,
	[name] [varchar](255) NULL,
	[mobileNumber] [varchar](20) NULL,
	[homeNumber] [varchar](20) NULL,
	[workNumber] [varchar](20) NULL,
	[dateOfBirth] [datetime] NULL,
	[gender] [char](1) NULL,
	[createDate] [datetime] NULL,
 CONSTRAINT [PK_patient] PRIMARY KEY CLUSTERED 
(
	[patientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[patient] ADD  CONSTRAINT [DF_patient_CreateDate]  DEFAULT (getdate()) FOR [createDate]
GO


