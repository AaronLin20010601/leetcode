/* Write your T-SQL query statement below */
/* 篩選出有效紀錄 */
WITH ValidTrips AS (
    SELECT t.id, t.request_at, t.status
    FROM Trips t
    /* 取得未被封鎖用戶的紀錄 */
    JOIN Users c
    ON t.client_id = c.users_id
    AND c.banned = 'No'
    /* 取得未被封鎖駕駛的紀錄 */
    JOIN Users d
    ON t.driver_id = d.users_id
    AND d.banned = 'No'
    WHERE t.request_at BETWEEN '2013-10-01' AND '2013-10-03'
)
SELECT v.request_at AS Day,
/* 取到小數後兩位 */
CAST(
    /* 計算行程取消率 */
    ROUND(
        /* 計算被取消的行程數 */
        SUM(
            CASE WHEN v.status IN ('cancelled_by_driver', 'cancelled_by_client')
            THEN 1 ELSE 0 END
            ) 
        * 1.0 / COUNT(*), 2) 
    AS DECIMAL(10,2)
) AS [Cancellation Rate]
FROM ValidTrips v
GROUP BY v.request_at
ORDER BY v.request_at;