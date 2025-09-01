function calculate(s: string): number {
    const sLength: number = s.length;
    const stack: number[] = [];
    let result: number = 0, sign: number = 1, index: number = 0;

    while (index < sLength) {
        const char: string = s[index];
        if (char === ' ') {
            index++;
            continue;
        }

        if (char >= '0' && char <= '9') {
            let num: number = 0;
            // 取出完整數字
            while (index < sLength && s[index] >= '0' && s[index] <= '9') {
                num = num * 10 + (s.charCodeAt(index) - 48);
                index++;
            }
            result += sign * num;
            continue;
        }

        // 紀錄加減正負號
        if (char === '+') {
            sign = 1;
            index++;
            continue;
        }
        if (char === '-') {
            sign = -1;
            index++;
            continue;
        }

        // 紀錄左右括號
        if (char === '(') {
            // 將當前總和和正負紀錄至 stack
            stack.push(result);
            stack.push(sign);
            result = 0;
            sign = 1;
            index++;
            continue;
        }
        if (char === ')') {
            // 完成括號內運算
            const previousSign: number = stack.pop()!;
            const previousResult: number = stack.pop()!;
            result = previousResult + previousSign * result;
            index++;
            continue;
        }
        index++;
    }
    return result;
};