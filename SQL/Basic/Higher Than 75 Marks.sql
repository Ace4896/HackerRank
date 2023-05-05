-- Query the Name of any student in STUDENTS who scored higher than 75 Marks.
-- Order your output by the last three characters of each name.
-- If two or more students both have names ending in the same last three characters (i.e.: Bobby, Robby, etc.), secondary sort them by ascending ID.
--
-- The STUDENTS table is described as follows:
--
-- Column   Type
-- ID       Integer
-- Name     String
-- Marks    Integer

-- MS SQL Server
-- RIGHT is specific to T-SQL, and retrieves the rightmost characters in a string
SELECT Name
FROM STUDENTS
WHERE Marks > 75
ORDER BY RIGHT(Name, 3) ASC, ID ASC;
