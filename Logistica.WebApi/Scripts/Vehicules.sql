DECLARE @i INT = 1;
WHILE @i <= 50
BEGIN
    DECLARE @Patent NVARCHAR(MAX) = CONCAT('AD', ABS(CHECKSUM(NEWID())) % 1000,'CD'); -- Generate dummy patent
    DECLARE @RouteId INT = ABS(CHECKSUM(NEWID())) % 24 + 1; -- Generate RouteId between 1 and 24

    INSERT INTO [dbo].[Vehicules] ([Patent], [RouteId])
    VALUES (@Patent, @RouteId);

    SET @i = @i + 1;
END;
