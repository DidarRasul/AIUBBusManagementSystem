INSERT INTO Users
(
    Name,
    Username,
    Password,
    Email,
    Role,
    Status
)
VALUES
(
    'System Admin',
    'admin',
    '123456',
    'admin@aiub.edu',
    'Admin',
    'Active'
);

SELECT * FROM Users;