/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (5000) [StudentId]
      ,[StudentName]
      ,[StudentEmail]
      ,[IsMale]
      ,[NickName]
  FROM [school].[dbo].[tblStudents]

  select top 100 * from tblStudents order by StudentId asc