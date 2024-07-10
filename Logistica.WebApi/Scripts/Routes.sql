DECLARE @i INT = 1;
WHILE @i <= 30
BEGIN
    DECLARE @SourceNodeId INT = ABS(CHECKSUM(NEWID()) % 24) + 1;
    DECLARE @DestinationNodeId INT = ABS(CHECKSUM(NEWID()) % 24) + 1;

    WHILE @DestinationNodeId = @SourceNodeId
    BEGIN
        SET @DestinationNodeId = ABS(CHECKSUM(NEWID()) % 24) + 1;
    END;


    DECLARE @FromDate DATETIME2(7) = DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 365), GETDATE());
    DECLARE @ToDate DATETIME2(7) = DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 3), @FromDate);

	WHILE @FromDate = @ToDate 
	BEGIN
	 SET @FromDate = DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 365), GETDATE());
     SET @ToDate  = DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 3), @FromDate);
	END 

    INSERT INTO [dbo].[Routes] ([Name], [SourceNodeId], [DestinationNodeId], [FromDate], [ToDate])
    VALUES (
        'Route ' + CAST(@i AS NVARCHAR),
        @SourceNodeId,
        @DestinationNodeId,
        @FromDate,
        @ToDate
    );

    SET @i = @i + 1;
END;

