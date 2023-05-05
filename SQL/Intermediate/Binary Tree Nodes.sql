-- You are given a table, BST, containing two columns: N and P, where N represents the value of a node in Binary Tree, and P is the parent of N.
--
-- Column   Type
-- N        Integer
-- P        Integer (nullable)
--
-- Write a query to find the node type of Binary Tree ordered by the value of the node. Output one of the following for each node:
--
-- Root: If node is root node.
-- Leaf: If node is leaf node.
-- Inner: If node is neither root nor leaf node.

-- MS SQL Server
-- We can check these conditions as follows:
-- - Root: Parent node is null
-- - Leaf: Node is not a parent to any other node
-- - Inner: Default case
SELECT
    A.N,
    CASE
        WHEN A.P IS NULL THEN 'Root'
        WHEN NOT EXISTS (SELECT 1 FROM BST B WHERE B.P = A.N) THEN 'Leaf'
        ELSE 'Inner'
    END
FROM BST A
ORDER BY A.N;
