/* Write your T-SQL query statement below */
/* 依照 managerId 進行檢查比較 */
SELECT E.name AS Employee
FROM Employee AS E
LEFT JOIN Employee AS M
ON E.managerId = M.id
WHERE E.salary > M.salary;