-- Query the two cities in STATION with the shortest and longest CITY names, as well as their respective lengths (i.e.: number of characters in the name).
-- If there is more than one smallest or largest city, choose the one that comes first when ordered alphabetically.
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
--
-- For example, CITY has four entries: DEF, ABC, PQRS and WXY.
-- ABC 3
-- PQRS 4
--
-- You can write two separate queries to get the desired output. It need not be a single query.

-- MS SQL Server
-- I was overthinking this one - immediately thought about using MIN() and MAX(), but we can easily achieve this with ordering.
SELECT TOP 1 CITY, LEN(CITY) AS LENGTH
FROM STATION
ORDER BY LENGTH ASC, CITY ASC;

SELECT TOP 1 CITY, LEN(CITY) AS LENGTH
FROM STATION
ORDER BY LENGTH DESC, CITY ASC;
