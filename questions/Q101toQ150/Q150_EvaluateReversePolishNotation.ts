function evalRPN(tokens: string[]): number {
    const stack: number[] = [];
    for (const token of tokens) {
        if (isOperator(token)) {
            const num2: number = stack.pop()!;
            const num1: number = stack.pop()!;
            let result: number = 0;

            // 取出數字並進行計算
            switch (token) {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    result = Math.trunc(num1 / num2);
                    break;
            }
            // 將計算後的數字重新記錄
            stack.push(result);
        }
        else {
            // 將數字紀錄進 stack
            stack.push(Number(token));
        }
    }
    return stack.pop()!;
};
// 檢查是否為計算符號
function isOperator(token: string): boolean {
    return token === '+' || token === '-' || token === '*' || token === '/';
}