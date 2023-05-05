-- A median is defined as a number separating the higher half of a data set from the lower half.
-- Query the median of the Northern Latitudes (LAT_N) from STATION and round your answer to 4 decimal places.
--
-- The STATION table is described as follows:
--
-- Field    Type
-- ID       NUMBER
-- CITY     VARCHAR2(21)
-- STATE    VARCHAR2(2)
-- LAT_N    NUMBER
-- LONG_W   NUMBER
--
-- where LAT_N is the northern latitude and LONG_W is the western longitude.

-- MS SQL Server
-- NOTE: Need to cast the value on MS SQL Server, otherwise there's extra trailing 0s that fail the test
--
-- Calculating median involves sorting by the value we want the median of, then finding the middle value
-- - If we have an odd number of values, then we can just pick the middle value
-- - If we have an even number of values, then we have to pick the arithmetic mean of the middle two values

-- Attempt 1: Using row numbers
-- It looks like I need to implement this in one query... not sure how.
DECLARE @MiddleIndex NUMERIC;

SELECT @MiddleIndex = (COUNT(*) + 1) / 2
FROM STATION;

IF @MiddleIndex % 2 = 1
THEN
    -- Odd Number of Elements
    SELECT ROUND(CAST(LAT_N AS DECIMAL(10, 4)), 4)
    FROM (
        SELECT
            RowNumber = ROW_NUMBER() OVER (PARTITION BY ID ORDER BY LAT_N ASC),
            LAT_N
        FROM STATION
    ) AS tmp
    WHERE RowNumber = @MiddleIndex;
ELSE
    SELECT ROUND(CAST(AVG(LAT_N) AS DECIMAL(10, 4)), 4)
    FROM (
        SELECT
            RowNumber = ROW_NUMBER() OVER (PARTITION BY ID ORDER BY LAT_N ASC),
            LAT_N
        FROM STATION
    ) AS tmp2
    WHERE RowNumber = FLOOR(@MiddleIndex)
    OR RowNumber = CEILING(@MiddleIndex);
END;

-- Attempt 2: https://stackoverflow.com/a/2026609
-- In MS SQL Server, It's possible to select the top/bottom percentage of rows in a result set
-- So I'm kinda cheating here... but I doubt this will be asked in an interview question (since implementations of median already exist)
SELECT ROUND(
    CAST((
        (SELECT MAX(LAT_N) FROM (SELECT TOP 50 PERCENT LAT_N FROM STATION ORDER BY LAT_N ASC) AS BottomHalf)
        +
        (SELECT MIN(LAT_N) FROM (SELECT TOP 50 PERCENT LAT_N FROM STATION ORDER BY LAT_N DESC) AS TopHalf)
    ) / 2.0 AS DECIMAL(10, 4)),
    4
);
