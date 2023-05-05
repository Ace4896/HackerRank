-- You are given two tables: Students and Grades. Students contains three columns ID, Name and Marks.
--
-- Column   Type
-- ID       Integer
-- Name     String
-- Marks    Integer
--
-- Grades contains the following data:
--
-- Grade    Min_Mark    Max_Mark
-- 1        0           9
-- 2        10          19
-- 3        20          29
-- 4        30          39
-- ...
-- 9        80          89
-- 10       90          100
--
-- Ketty gives Eve a task to generate a report containing three columns: Name, Grade and Mark.
-- Ketty doesn't want the NAMES of those students who received a grade lower than 8.
-- The report must be in descending order by grade -- i.e. higher grades are entered first.
-- If there is more than one student with the same grade (8-10) assigned to them, order those particular students by their name alphabetically.
-- Finally, if the grade is lower than 8, use "NULL" as their name and list them by their grades in descending order.
-- If there is more than one student with the same grade (1-7) assigned to them, order those particular students by their marks in ascending order.
--
-- Write a query to help Eve.

-- MS SQL Server
--
-- The main part that makes this problematic is the grade ranges - 1-7 and 8-10 - use different sorting methods
-- - Both need to sort by grade in ascending order
-- - 1-7 needs to sort by marks in ascending order, but 8-10 can't use this.
-- - 8-10 needs to sort by name in ascending order, but 1-7 can't use this.
--
-- Apparently, it's possible to use CASE in ORDER BY statements???
-- https://stackoverflow.com/q/15621609
--
-- Only caveat is that we can't specify sort direction here within the CASE statement itself
-- So if we wanted dynamic sort order, we either need more CASE statements w/ variables or dynamic SQL
SELECT
    CASE
        WHEN g.Grade >= 8 THEN s.Name
        ELSE NULL
    END,
    g.Grade,
    s.Marks
FROM Students s
JOIN Grades g ON s.Marks BETWEEN g.Min_Mark AND g.Max_Mark
ORDER BY
    g.Grade DESC,
    CASE WHEN g.Grade >= 8 THEN s.Name END ASC,
    CASE WHEN g.Grade <= 7 THEN s.Marks END ASC;
