-- Pivot the Occupation column in OCCUPATIONS so that each Name is sorted alphabetically and displayed underneath its corresponding Occupation.
-- The output column headers should be Doctor, Professor, Singer, and Actor, respectively.
--
-- Note: Print NULL when there are no more names corresponding to an occupation.
--
-- The OCCUPATIONS table is defined as follows:
--
-- Column       Type
-- Name         String
-- Occupation   String
--
-- Occupation will only contain one of the following values: Doctor, Professor, Singer or Actor.

-- MS SQL Server
-- Haven't used PIVOT before this challenge...

-- Attempt 1: Valid syntax, but I only get one row...
SELECT Doctor, Professor, Singer, Actor
FROM OCCUPATIONS
PIVOT (
    MAX(Name)
    FOR Occupation IN (Doctor, Professor, Singer, Actor)
) AS pvt;

-- Attempt 2: https://stackoverflow.com/a/57868079
-- This answer was helpful in understanding the format (official documentation was too dense...)
--
-- The format is something like this:
--
-- WITH PivotData AS
-- (
--     SELECT <grouping column>,
--            <spreading column>,
--            <aggregation column>
--     FROM <source table>
-- )
-- SELECT <grouping column>, <distinct spreading values>
-- FROM PivotData
--     PIVOT (<aggregation function>(<aggregation column>)
--         FOR <spreading column> IN <distinct spreading values>));
--
-- The part that got me confused is that we need a grouping column, but the grouping column isn't obvious.
--
-- What we can do is determine the row numbers for each row - this can be done with PARTITION.
-- - The partition needs to be done based on the occupation (so each occupation has it's own count)
-- - The ordering needs to be based on the name (to match the output we want)
--
-- The row numbers are shared between occupations, but are unique within occupations.
-- This lets us display the results by row number, while still preserving all the names that appeared for each occupation.
--
-- In the final query, the pivot columns are:
-- - Grouping: Row Number (partitioned by occupation, ordered by ascending name)
-- - Spreading: Occupation
-- - Aggregation: Name (have to use an aggregation function - MAX/MIN are OK for this task)
--
-- If we output the grouping column as well (the row number), we can see how the rows are ordered.
SELECT Doctor, Professor, Singer, Actor
FROM (
    SELECT
        RowNumber = ROW_NUMBER() OVER (PARTITION BY Occupation ORDER BY Name),
        Name,
        Occupation
    FROM OCCUPATIONS
) AS sub
PIVOT (
    MAX(Name)
    FOR Occupation IN (Doctor, Professor, Singer, Actor)
) AS pvt
ORDER BY RowNumber;
