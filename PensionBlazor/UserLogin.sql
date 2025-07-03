USE [Pension]
GO
SET IDENTITY_INSERT [dbo].[UserLogin] ON 
GO
INSERT [dbo].[UserLogin] ([UserLoginId], [email], [password], [token]) VALUES (1, N'kolo.067@gmail.com', N'', N'')
GO
INSERT [dbo].[UserLogin] ([UserLoginId], [email], [password], [token]) VALUES (2, N'kolo.git.067@gmail.com', N'111', N'')
GO
SET IDENTITY_INSERT [dbo].[UserLogin] OFF
GO
