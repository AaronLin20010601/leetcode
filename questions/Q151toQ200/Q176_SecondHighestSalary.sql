/* Write your T-SQL query statement below */
/* 先取得最高值再進行比較 */
WITH HighestSalary AS (
    SELECT MAX(salary) AS salary
    FROM Employee
)
SELECT (
    SELECT MAX(salary)
    FROM Employee
    WHERE salary < (SELECT salary FROM HighestSalary)
)
AS SecondHighestSalary;