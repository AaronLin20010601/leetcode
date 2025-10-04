function removeDuplicateLetters(s: string): string {
    const sLength: number = s.length;
    const ascii: number = "a".charCodeAt(0);

    // 紀錄每個字元最後出現的位置
    const charLastIndex: number[] = new Array(26).fill(-1);
    for (let i: number = 0; i < sLength; i++) {
        charLastIndex[s.charCodeAt(i) - ascii] = i;
    }

    const visited: boolean[] = new Array(26).fill(false);
    const stack: string[] = [];
    // 逐一檢查字串內字元
    for (let i: number = 0; i < sLength; i++) {
        const char: string = s[i];
        const index: number = char.charCodeAt(0) - ascii;

        // 結果中已有該字元則跳過
        if (visited[index]) {
            continue;
        }
        while (stack.length > 0) {
            const topChar: string = stack[stack.length - 1];
            const topCharIndex: number = topChar.charCodeAt(0) - ascii;

            // 將後續還會出現且排序較靠後的字元取出
            if (topChar > char && charLastIndex[topCharIndex] > i) {
                stack.pop();
                visited[topCharIndex] = false;
            }
            else {
                break;
            }
        }
        // 將字元放入並標記為已使用
        stack.push(char);
        visited[index] = true;
    }
    return stack.join("");
};