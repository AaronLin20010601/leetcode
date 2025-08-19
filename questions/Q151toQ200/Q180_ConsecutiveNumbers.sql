/* Write your T-SQL query statement below */
/* 一次檢查數字和前面的兩個數字 */
WITH Consecutive AS (
    SELECT
        id, num,
        LAG(num, 1) OVER (ORDER BY id) AS prev1,
        LAG(num, 2) OVER (ORDER BY id) AS prev2
    FROM Logs
)
SELECT DISTINCT num AS ConsecutiveNums
FROM Consecutive
WHERE num = prev1 AND num = prev2;