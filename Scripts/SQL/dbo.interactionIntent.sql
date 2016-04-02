USE [hallebot]
GO

/****** Object:  Table [dbo].[interactionIntent]    Script Date: 4/2/2016 2:31:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[interactionIntent](
	[conversationID] [uniqueidentifier] NOT NULL,
	[createDate] [datetime] NOT NULL,
	[seq] [int] NOT NULL,
	[name] [varchar](50) NULL,
	[confidence] [decimal](18, 8) NULL,
 CONSTRAINT [PK_interactionIntent] PRIMARY KEY CLUSTERED 
(
	[conversationID] ASC,
	[createDate] ASC,
	[seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[interactionIntent]  WITH CHECK ADD  CONSTRAINT [FK_interactionIntent_interaction] FOREIGN KEY([conversationID], [createDate])
REFERENCES [dbo].[interaction] ([conversationID], [createDate])
GO

ALTER TABLE [dbo].[interactionIntent] CHECK CONSTRAINT [FK_interactionIntent_interaction]
GO


