/* Write your T-SQL query statement below */
SELECT D.name AS Department, E.name AS Employee, E.salary AS Salary
/* 依部門取得前三高薪資 */
FROM (
    SELECT *, DENSE_RANK() OVER (PARTITION BY departmentId ORDER BY salary DESC) AS rnk
    FROM Employee
) AS E
JOIN Department D
ON E.departmentId = D.id
WHERE E.rnk <= 3
ORDER BY D.name, E.salary DESC;