USE [hallebot]
GO

/****** Object:  Table [dbo].[interaction]    Script Date: 4/2/2016 12:11:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[interaction](
	[conversationID] [uniqueidentifier] NOT NULL,
	[createDate] [datetime] NOT NULL,
	[text] [varchar](max) NULL,
	[sentiment] [decimal](18, 8) NULL,
	[flag] [int] NULL,
 CONSTRAINT [PK_interaction] PRIMARY KEY CLUSTERED 
(
	[conversationID] ASC,
	[createDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[interaction] ADD  CONSTRAINT [DF_interaction_createDate]  DEFAULT (getdate()) FOR [createDate]
GO

ALTER TABLE [dbo].[interaction]  WITH CHECK ADD  CONSTRAINT [FK_interaction_conversation] FOREIGN KEY([conversationID])
REFERENCES [dbo].[conversation] ([conversationID])
GO

ALTER TABLE [dbo].[interaction] CHECK CONSTRAINT [FK_interaction_conversation]
GO


