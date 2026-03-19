DECLARE @table_name NVARCHAR(100) = 'TOK_TABLE';

DECLARE @insert NVARCHAR(MAX) = 'INSERT INTO ' + @table_name + ' (';
DECLARE @select NVARCHAR(MAX) = 'SELECT ';

SELECT 
    @insert = @insert + QUOTENAME(c.COLUMN_NAME) + ',',
    
    @select = @select + 
    CASE 
        -- VARCHAR / NVARCHAR
        WHEN c.DATA_TYPE IN ('varchar','nvarchar','char','nchar') THEN
            'LEFT(CONVERT(VARCHAR(MAX), NEWID()), ' + 
            CAST(ISNULL(c.CHARACTER_MAXIMUM_LENGTH, 10) AS VARCHAR) + ') AS ' + QUOTENAME(c.COLUMN_NAME)

        -- INT
        WHEN c.DATA_TYPE IN ('int','bigint','smallint','tinyint') THEN
            'ABS(CHECKSUM(NEWID())) % 1000 AS ' + QUOTENAME(c.COLUMN_NAME)

        -- DECIMAL / NUMERIC
        WHEN c.DATA_TYPE IN ('decimal','numeric') THEN
            'CAST(RAND(CHECKSUM(NEWID())) * 1000 AS DECIMAL(' +
            CAST(c.NUMERIC_PRECISION AS VARCHAR) + ',' +
            CAST(c.NUMERIC_SCALE AS VARCHAR) + ')) AS ' + QUOTENAME(c.COLUMN_NAME)

        -- DATE / DATETIME
        WHEN c.DATA_TYPE IN ('date','datetime','datetime2') THEN
            'DATEADD(DAY, -ABS(CHECKSUM(NEWID())) % 365, GETDATE()) AS ' + QUOTENAME(c.COLUMN_NAME)

        -- DEFAULT
        ELSE
            'NULL AS ' + QUOTENAME(c.COLUMN_NAME)
    END + ','
FROM INFORMATION_SCHEMA.COLUMNS c
WHERE c.TABLE_NAME = @table_name
ORDER BY c.ORDINAL_POSITION;

-- hoàn thiện
SET @insert = LEFT(@insert, LEN(@insert) - 1) + ') ';
SET @select = LEFT(@select, LEN(@select) - 1) 
            + ' FROM (SELECT TOP 10 1 AS n FROM sys.objects) t;';

-- in ra câu SQL
PRINT @insert + @select;