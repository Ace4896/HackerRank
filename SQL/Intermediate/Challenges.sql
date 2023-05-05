-- Julia asked her students to create some coding challenges.
-- Write a query to print the hacker_id, name, and the total number of challenges created by each student.
-- Sort your results by the total number of challenges in descending order.
-- If more than one student created the same number of challenges, then sort the result by hacker_id.
-- If more than one student created the same number of challenges and the count is less than the maximum number of challenges created, then exclude those students from the result.
--
-- Input Format
--
-- The following tables contain challenge data:
--
-- Hackers: The hacker_id is the id of the hacker, and name is the name of the hacker.
--
-- Column       Type
-- hacker_id    Integer
-- name         String
--
-- Challenges: The challenge_id is the id of the challenge, and hacker_id is the id of the student who created the challenge.
--
-- Column           Type
-- challenge_id     Integer
-- hacker_id        Integer

-- MS SQL Server
--
-- First step is finding how many challenges each student created - this can be done using COUNT and GROUP BY.
-- The rules for students with the same number of challenges are a bit confusing...
-- - If the number of challenges is the maximum, display all of these students
-- - If the number of challenges is not the maximum and there's only one student, display them
-- - If the number of challenges is not the maximum and there's multiple students, don't display any of them
--
-- This query works, although it's a little janky because I have to query all of it in one go...
WITH ChallengesCreated AS (
    SELECT hacker_id, challenges_created = COUNT(*)
    FROM Challenges
    GROUP BY hacker_id
)
SELECT h.hacker_id, h.name, cc.challenges_created
FROM Hackers h
JOIN ChallengesCreated cc ON cc.hacker_id = h.hacker_id
WHERE cc.challenges_created = (
    SELECT MAX(cc2.challenges_created)
    FROM ChallengesCreated cc2
)
OR EXISTS (
    SELECT 1
    FROM ChallengesCreated cc3
    WHERE cc3.challenges_created = cc.challenges_created
    GROUP BY cc3.challenges_created
    HAVING COUNT(*) = 1
)
ORDER BY cc.challenges_created DESC, h.hacker_id ASC;
