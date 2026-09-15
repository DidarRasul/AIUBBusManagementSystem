SELECT 
    name,
    definition
FROM sys.check_constraints
WHERE parent_object_id = OBJECT_ID('dbo.Routes');