function longestValidParentheses(s: string): number {
    let maxLength = 0;
    const stack: number[] = [];
    // 初始基準點
    stack.push(-1);

    // 使用 stack 紀錄當前對稱左右點長度
    for (let i: number = 0; i < s.length; i++) {
        if (s[i] === '(') {
            stack.push(i);
        }
        else {
            stack.pop();
            // 無法配對則更新基準點
            if (stack.length === 0) {
                stack.push(i);
            }
            else {
                maxLength = Math.max(maxLength, i - stack[stack.length - 1]);
            }
        }
    }
    return maxLength;
};