USE [hallebot]
GO

/****** Object:  Table [dbo].[conversation]    Script Date: 4/2/2016 12:10:49 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[conversation](
	[conversationID] [uniqueidentifier] NOT NULL,
	[patientID] [varchar](255) NOT NULL,
	[createDate] [datetime] NULL,
	[currentLocation] [varchar](max) NULL,
 CONSTRAINT [PK_conversation] PRIMARY KEY CLUSTERED 
(
	[conversationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[conversation] ADD  CONSTRAINT [DF_conversation_createDate]  DEFAULT (getdate()) FOR [createDate]
GO
/*
ALTER TABLE [dbo].[conversation]  WITH CHECK ADD  CONSTRAINT [FK_conversation_patient] FOREIGN KEY([patientID])
REFERENCES [dbo].[patient] ([patientID])
*/
GO

ALTER TABLE [dbo].[conversation] CHECK CONSTRAINT [FK_conversation_patient]
GO


