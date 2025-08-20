/* Write your T-SQL query statement below */
/* 取得所有重複信箱再移除 */
WITH Duplicates AS (
    SELECT id, email, ROW_NUMBER() OVER (PARTITION BY email ORDER BY id) AS RowNum
    FROM Person
)
DELETE FROM Duplicates
WHERE RowNum > 1;