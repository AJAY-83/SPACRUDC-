﻿CREATE PROCEDURE spGetEmployeeById    
    -- Add the parameters for the stored procedure here    
    @Id int    
        
AS    
BEGIN    
    -- SET NOCOUNT ON added to prevent extra result sets from    
    -- interfering with SELECT statements.    
    SET NOCOUNT ON;    
    
    Select * From Employee     
    where Id=@Id    
            
END 