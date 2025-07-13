function isValid(s: string): boolean {
    const stack: string[] = [];
    const map: Record<string, string> = {
        ')': '(',
        ']': '[',
        '}': '{',
    };

    for (const char of s) {
        // 檢查為右括號則取出 stack
        if (char in map) {
            const top = stack.pop();
            // 檢查是否為同種類型
            if (top !== map[char]) {
                return false;
            }
        }
        else {
            stack.push(char);
        }
    }
    return stack.length === 0;
};