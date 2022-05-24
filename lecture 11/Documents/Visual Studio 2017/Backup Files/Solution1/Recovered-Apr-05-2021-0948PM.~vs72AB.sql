exec sp_executesql N'SELECT TOP(@__p_0) [t].[UniqueId], [t].[IsMale], [t].[NickName], [t].[StudentEmail], [t].[StudentId], [t].[StudentName]
FROM [tblStudents] AS [t]
ORDER BY [t].[UniqueId]',N'@__p_0 int',@__p_0=100