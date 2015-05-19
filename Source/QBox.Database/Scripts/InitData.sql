USE [QuizBox]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (1, N'Sports', NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (2, N'Politics', NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (3, N'Art', NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (4, N'Movies', NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (5, N'Geography', NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (6, N'Nature', NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([Id], [CategoryId], [Text]) VALUES (1, 1, N'Whic country won world cup in soccer 2014')
SET IDENTITY_INSERT [dbo].[Question] OFF
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (1, 1, N'Brazil', 0)
INSERT [dbo].[Answer] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (2, 1, N'Germany', 1)
INSERT [dbo].[Answer] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (3, 1, N'Spain', 0)
INSERT [dbo].[Answer] ([Id], [QuestionId], [Text], [IsCorrect]) VALUES (4, 1, N'Sweden', 0)
SET IDENTITY_INSERT [dbo].[Answer] OFF
