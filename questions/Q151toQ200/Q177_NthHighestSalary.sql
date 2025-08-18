CREATE FUNCTION getNthHighestSalary(@N INT) RETURNS INT AS
BEGIN
    DECLARE @result INT;
    /* 對薪資值進行排序 */
    SELECT @result = salary
    FROM (
        SELECT salary, DENSE_RANK() OVER (ORDER BY salary DESC) AS rnk
        FROM Employee
    ) ranked_salaries
    WHERE rnk = @N;

    RETURN @result;
END