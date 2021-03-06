USE [Tree]
GO
/****** Object:  Table [dbo].[Tree]    Script Date: 11/21/2014 16:19:50 ******/
SET ARITHABORT ON
GO
SET CONCAT_NULL_YIELDS_NULL ON
GO
SET ANSI_NULLS ON
GO
SET ANSI_PADDING ON
GO
SET ANSI_WARNINGS ON
GO
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
SET ARITHABORT ON
GO
CREATE TABLE [dbo].[Tree](
	[node_id] [int] IDENTITY(1,1) NOT NULL,
	[age] [int] NOT NULL,
	[name] [varchar](20) NOT NULL,
	[hid] [hierarchyid] NOT NULL,
	[parent]  AS ([hid].[GetAncestor]((1))) PERSISTED,
	[level]  AS ([hid].[GetLevel]()),
	[path]  AS ([hid].[ToString]())
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AddNode]    Script Date: 11/21/2014 16:19:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddNode]
  @Name VARCHAR(20),
  @Age  Integer,
  @Path VARCHAR(MAX),
  @node_id INT = NULL OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT Tree(age, name, hid) VALUES (@Age, @Name, hierarchyid::Parse(@Path));

    SET @node_id = SCOPE_IDENTITY();
END
GO
/****** Object:  ForeignKey [FK__Tree__parent__0CBAE877]    Script Date: 11/21/2014 16:19:50 ******/
ALTER TABLE [dbo].[Tree]  WITH CHECK ADD  CONSTRAINT [FK__Tree__parent__0CBAE877] FOREIGN KEY([parent])
REFERENCES [dbo].[Tree] ([hid])
GO
ALTER TABLE [dbo].[Tree] CHECK CONSTRAINT [FK__Tree__parent__0CBAE877]
GO
