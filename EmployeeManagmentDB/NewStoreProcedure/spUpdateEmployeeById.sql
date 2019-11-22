CREATE PROCEDURE spUpdateEmployeeByID    
@Id int,    
@FullName varchar(50),    
@Email varchar(25),    
@Salary int,  
@Gender varchar(8)  
    
AS    
BEGIN    
    -- SET NOCOUNT ON added to prevent extra result sets from    
    -- interfering with SELECT statements.    
    SET NOCOUNT ON;    
    
    UPDATE Employee  
    Set FullName = @FullName,    
        Email = @Email ,    
        Salary = @Salary,   
  Gender=@Gender  
    Where Id = @Id    
END 