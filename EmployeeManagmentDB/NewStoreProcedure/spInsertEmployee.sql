CREATE PROCEDURE spInsertEmployee    
@FullName varchar(20),    
@Email varchar(30),    
@Salary int,  
@Gender varchar(8)  
    
AS    
BEGIN    
    -- SET NOCOUNT ON added to prevent extra result sets from    
    -- interfering with SELECT statements.    
    SET NOCOUNT ON;    
    
    Insert into Employee (FullName,Email,Salary,Gender)     
           Values (@FullName,@Email, @Salary,@Gender)    
END