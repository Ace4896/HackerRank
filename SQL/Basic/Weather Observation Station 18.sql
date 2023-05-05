-- Consider P1(a,b) and P2(c,d) to be two points on a 2D plane.
--
-- a happens to equal the minimum value in Northern Latitude (LAT_N in STATION).
-- b happens to equal the minimum value in Western Longitude (LONG_W in STATION).
-- c happens to equal the maximum value in Northern Latitude (LAT_N in STATION).
-- d happens to equal the maximum value in Western Longitude (LONG_W in STATION).
--
-- Query the Manhattan Distance between points P1 and P2 and round it to a scale of 4 decimal places.
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
-- Manhattan distance is defined as follows: |x1 - x2| + |y1 - y2|

-- Attempt 1: This fails on MS SQL Server due to additional trailing 0's... works fine on MySQL
SELECT ROUND(ABS(MIN(LAT_N) - MAX(LAT_N)) + ABS(MIN(LONG_W) - MAX(LONG_W)), 4)
FROM STATION;

-- Attempt 2: Need to cast the value we're rounding first, so MS SQL knows how many decimal places to add
SELECT ROUND(
    CAST(ABS(MIN(LAT_N) - MAX(LAT_N)) + ABS(MIN(LONG_W) - MAX(LONG_W)) AS DECIMAL(10, 4)),
    4
)
FROM STATION;
