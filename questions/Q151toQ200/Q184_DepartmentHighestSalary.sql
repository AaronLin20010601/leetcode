/* Write your T-SQL query statement below */
SELECT D.name AS Department, E.name AS Employee, E.salary AS Salary
FROM Employee E
JOIN Department D
ON E.departmentId = D.id
/* 每個部門的最高薪資 */
JOIN (
    SELECT departmentId, MAX(salary) AS MaxSalary
    FROM Employee
    GROUP BY departmentId
) AS M
ON E.departmentId = M.departmentId AND E.salary = M.MaxSalary;