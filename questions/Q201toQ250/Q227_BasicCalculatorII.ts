function calculate(s: string): number {
    const stack: number[] = [];
    let num: number = 0;
    let sign: string = '+';

    for (let i = 0; i < s.length; i++) {
        const char: string = s[i];
        // 取出完整數字
        if (char >= '0' && char <= '9') {
            num = num * 10 + (char.charCodeAt(0) - '0'.charCodeAt(0));
        }

        // 進行數字紀錄或符號運算
        if ((char !== ' ' && (char < '0' || char > '9')) || i === s.length - 1) {
            if (sign === '+') {
                stack.push(num);
            }
            else if (sign === '-') {
                stack.push(-num);
            }
            else if (sign === '*') {
                const previous: number = stack.pop()!;
                stack.push(previous * num);
            }
            else {
                const previous: number = stack.pop()!;
                stack.push(previous / num > 0 ? Math.floor(previous / num) : Math.ceil(previous / num));
            }
            sign = char;
            num = 0;
        }
    }
    // 返回所有乘除法外數字加總
    return stack.reduce((a, b) => a + b, 0);
};