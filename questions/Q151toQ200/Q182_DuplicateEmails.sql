/* Write your T-SQL query statement below */
/* 以郵件計算出現次數 */
SELECT DISTINCT email
FROM (
    SELECT email, COUNT(*) OVER (PARTITION BY email) AS cnt
    FROM Person
) AS DuplicateEmail
WHERE cnt > 1;