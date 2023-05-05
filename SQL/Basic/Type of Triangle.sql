-- Write a query identifying the type of each record in the TRIANGLES table using its three side lengths. Output one of the following statements for each record in the table:
--
-- Equilateral: It's a triangle with 3 sides of equal length.
-- Isosceles: It's a triangle with 2 sides of equal length.
-- Scalene: It's a triangle with 3 sides of differing lengths.
-- Not A Triangle: The given values of A, B, and C don't form a triangle.
--
-- The TRIANGLES table is defined as follows:
--
-- Column   Type
-- A        Integer
-- B        Integer
-- C        Integer
--
-- NOTE: For "Not a Triangle", we can check if the sum of the two smaller lengths are less than the longest length.

-- MS SQL Server

-- Attempt 1: Using an intermediate query.
-- It returns the wrong answer because we have to try all combinations.
WITH T AS (
    SELECT
        A, B, C,
        LengthDiff = CASE
            WHEN (A >= B AND A >= C) THEN (A - B - C)
            WHEN (B >= A AND B >= C) THEN (B - C - A)
            ELSE (C - B - A)
        END
    FROM TRIANGLES
)
SELECT Type = CASE
    WHEN (T.A = T.B AND T.B = T.C) THEN 'Equilateral'
    WHEN (T.A = T.B OR T.A = T.C OR T.B = T.C) THEN 'Isosceles'
    WHEN T.LengthDiff < 0 THEN 'Scalene'
    ELSE 'Not A Triangle'
END
FROM T;

-- Attempt 2: Turns out we can do this in a single CASE statement...
-- Note how all side combinations are attempted
SELECT CASE
    WHEN (A + B <= C OR A + C <= B OR B + C <= A) THEN 'Not A Triangle'
    WHEN (A = B AND B = C) THEN 'Equilateral'
    WHEN (A = B OR A = C OR B = C) THEN 'Isosceles'
    ELSE 'Scalene'
END
FROM TRIANGLES;
