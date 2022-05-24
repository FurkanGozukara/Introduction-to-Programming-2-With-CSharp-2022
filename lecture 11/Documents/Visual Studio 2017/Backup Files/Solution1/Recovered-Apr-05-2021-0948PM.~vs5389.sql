exec sp_executesql N'SET NOCOUNT ON;
UPDATE [tblStudents] SET [StudentEmail] = @p0
WHERE [UniqueId] = @p1;
SELECT @@ROWCOUNT;

UPDATE [tblStudents] SET [StudentEmail] = @p2
WHERE [UniqueId] = @p3;
SELECT @@ROWCOUNT;

UPDATE [tblStudents] SET [StudentEmail] = @p4
WHERE [UniqueId] = @p5;
SELECT @@ROWCOUNT;

UPDATE [tblStudents] SET [StudentEmail] = @p6
WHERE [UniqueId] = @p7;
SELECT @@ROWCOUNT;

UPDATE [tblStudents] SET [StudentEmail] = @p8
WHERE [UniqueId] = @p9;
SELECT @@ROWCOUNT;

UPDATE [tblStudents] SET [StudentEmail] = @p10
WHERE [UniqueId] = @p11;
SELECT @@ROWCOUNT;

UPDATE [tblStudents] SET [StudentEmail] = @p12
WHERE [UniqueId] = @p13;
SELECT @@ROWCOUNT;

UPDATE [tblStudents] SET [StudentEmail] = @p14
WHERE [UniqueId] = @p15;
SELECT @@ROWCOUNT;

UPDATE [tblStudents] SET [StudentName] = @p16
WHERE [UniqueId] = @p17;
SELECT @@ROWCOUNT;

UPDATE [tblStudents] SET [StudentName] = @p18
WHERE [UniqueId] = @p19;
SELECT @@ROWCOUNT;

UPDATE [tblStudents] SET [StudentName] = @p20
WHERE [UniqueId] = @p21;
SELECT @@ROWCOUNT;

UPDATE [tblStudents] SET [StudentEmail] = @p22
WHERE [UniqueId] = @p23;
SELECT @@ROWCOUNT;

',N'@p1 int,@p0 varchar(2200),@p3 int,@p2 varchar(2200),@p5 int,@p4 varchar(2200),@p7 int,@p6 varchar(2200),@p9 int,@p8 varchar(2200),@p11 int,@p10 varchar(2200),@p13 int,@p12 varchar(2200),@p15 int,@p14 varchar(2200),@p17 int,@p16 nvarchar(200),@p19 int,@p18 nvarchar(200),@p21 int,@p20 nvarchar(200),@p23 int,@p22 varchar(2200)',@p1=43,@p0='dyuydtud',@p3=45,@p2='PÜ1ÜBtytrys@gmail.com',@p5=46,@p4='ghgfh',@p7=47,@p6='fdhgh',@p9=48,@p8='dyd',@p11=49,@p10='54654yt',@p13=50,@p12='uý',@p15=51,@p14='yýuyý',@p17=52,@p16=N'dsfdsfg',@p19=53,@p18=N'ghfh',@p21=54,@p20=N'fgdfs_',@p23=55,@p22='5ÇZ@ghjkjhkmail.com'