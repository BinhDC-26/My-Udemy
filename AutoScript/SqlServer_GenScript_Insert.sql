DECLARE @table_name NVARCHAR(100) = 'TOK_TABLE';

DECLARE @insert NVARCHAR(MAX) = 'INSERT INTO ' + @table_name + ' (';
DECLARE @select NVARCHAR(MAX) = 'SELECT ';

SELECT 
    @insert += QUOTENAME(c.COLUMN_NAME) + ',',
    
    @select += 
    CASE 
        -- STRING
        WHEN c.DATA_TYPE IN ('varchar','char') THEN
            'LEFT(CONVERT(VARCHAR(MAX), NEWID()), ' + 
            CAST(CASE WHEN c.CHARACTER_MAXIMUM_LENGTH = -1 THEN 20 ELSE c.CHARACTER_MAXIMUM_LENGTH END AS VARCHAR) + ')'

        WHEN c.DATA_TYPE IN ('nvarchar','nchar') THEN
            'LEFT(CONVERT(NVARCHAR(MAX), NEWID()), ' + 
            CAST(CASE WHEN c.CHARACTER_MAXIMUM_LENGTH = -1 THEN 20 ELSE c.CHARACTER_MAXIMUM_LENGTH END AS VARCHAR) + ')'

        -- INT
        WHEN c.DATA_TYPE IN ('int','bigint','smallint','tinyint') THEN
            'ABS(CHECKSUM(NEWID())) % 1000'

        -- DECIMAL
        WHEN c.DATA_TYPE IN ('decimal','numeric') THEN
            'CAST(ABS(CHECKSUM(NEWID())) % 1000 AS DECIMAL(' +
            CAST(c.NUMERIC_PRECISION AS VARCHAR) + ',' +
            CAST(c.NUMERIC_SCALE AS VARCHAR) + '))'

        -- FLOAT
        WHEN c.DATA_TYPE IN ('float','real') THEN
            'RAND(CHECKSUM(NEWID())) * 1000'

        -- DATE
        WHEN c.DATA_TYPE IN ('date','datetime','datetime2') THEN
            'DATEADD(DAY, -ABS(CHECKSUM(NEWID())) % 365, GETDATE())'

        -- BIT
        WHEN c.DATA_TYPE = 'bit' THEN
            'ABS(CHECKSUM(NEWID())) % 2'

        -- GUID
        WHEN c.DATA_TYPE = 'uniqueidentifier' THEN
            'NEWID()'

        ELSE
            'NULL'
    END + ' AS ' + QUOTENAME(c.COLUMN_NAME) + ','
FROM INFORMATION_SCHEMA.COLUMNS c
WHERE c.TABLE_NAME = @table_name
AND COLUMNPROPERTY(object_id(c.TABLE_SCHEMA + '.' + c.TABLE_NAME), c.COLUMN_NAME, 'IsIdentity') = 0
ORDER BY c.ORDINAL_POSITION;

-- hoàn thiện
SET @insert = LEFT(@insert, LEN(@insert) - 1) + ') ';
SET @select = LEFT(@select, LEN(@select) - 1) 
            + ' FROM (SELECT TOP 10 1 FROM sys.objects) t;';

PRINT @insert + @select;