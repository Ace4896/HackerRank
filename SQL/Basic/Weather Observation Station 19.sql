-- Consider P1(a,c) and P2(b,d) to be two points on a 2D plane where:
--
-- - (a,b) are the respective minimum and maximum values of Northern Latitude (LAT_N)
-- - (c,d) are the respective minimum and maximum values of Western Longitude (LONG_W)
--
-- in STATION. 
--
-- Query the Euclidean Distance between points P1 and P2 and round it to a scale of 4 decimal places.
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
-- Euclidean distance is defined by sqrt((p1_x - p2_x)^2 + (p1_y - p2_y)^2)

-- NOTE: Need to cast the value on MS SQL Server, otherwise there's extra trailing 0s that fail the test
SELECT ROUND(
    CAST(
        SQRT(POWER(MIN(LAT_N) - MAX(LAT_N), 2) + POWER(MIN(LONG_W) - MAX(LONG_W), 2))
        AS DECIMAL(10, 4)
    ),
    4
)
FROM STATION;
