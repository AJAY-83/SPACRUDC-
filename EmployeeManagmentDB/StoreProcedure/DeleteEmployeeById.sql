CREATE PROCEDURE spDeleteEmployeeById     
    @Id int    
AS    
BEGIN    
    -- SET NOCOUNT ON added to prevent extra result sets from    
    -- interfering with SELECT statements.    
    SET NOCOUNT ON;    
    
    Delete from Employee    
    where Id = @Id   
        
END 
