ALTER TABLE Routes
DROP CONSTRAINT CK_Routes_Direction;
GO

ALTER TABLE Routes
ADD CONSTRAINT CK_Routes_Direction
CHECK (Direction IN ('To University', 'From University'));
GO