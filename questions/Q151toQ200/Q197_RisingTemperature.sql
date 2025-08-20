/* Write your T-SQL query statement below */
SELECT Today.id
FROM Weather Today
JOIN Weather Yesterday
ON Today.recordDate = DATEADD(day, 1, Yesterday.recordDate)
WHERE Today.temperature > Yesterday.temperature;