function diffWaysToCompute(expression: string): number[] {
    // 紀錄已有的運算組合
    const existExpression: Map<string, number[]> = new Map();

    // 檢查是否為運算符號
    function isOperator(char: string): boolean {
        return char === '+' || char === '-' || char === '*';
    }

    // 取得數值計算組合
    function calculate(leftValues: number[], rightValues: number[], operation: string): number[] {
        const result: number[] = [];
        for (const left of leftValues) {
            for (const right of rightValues) {
                if (operation === '+') {
                    result.push(left + right);
                }
                else if (operation === '-') {
                    result.push(left - right);
                }
                else if (operation === '*') {
                    result.push(left * right);
                }
            }
        }
        return result;
    }

    // 取得子運算字串的所有可能運算數值
    function getResult(expression: string): number[] {
        // 直接取得已有運算式結果
        if (existExpression.has(expression)) {
            return existExpression.get(expression)!;
        }

        const results: number[] = [];
        for (let i: number = 0; i < expression.length; i++) {
            const char: string = expression[i];

            if (isOperator(char)) {
                // 切割遞迴檢查子字串運算結果
                const leftExpression = expression.slice(0, i);
                const rightExpression = expression.slice(i + 1);
                const leftValues = getResult(leftExpression);
                const rightValues = getResult(rightExpression);

                const combined = calculate(leftValues, rightValues, char);
                results.push(...combined);
            }
        }

        // 沒有運算子則直接存為數值
        if (results.length === 0) {
            results.push(parseInt(expression, 10));
        }
        existExpression.set(expression, results);
        return results;
    }
    return getResult(expression);
};