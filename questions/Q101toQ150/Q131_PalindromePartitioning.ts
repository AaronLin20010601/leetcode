function partition(s: string): string[][] {
    const result: string[][] = [];
    const path: string[] = [];

    // 檢查子字串是否對稱
    function isPalindrome(str: string, left: number, right: number): boolean {
        while (left < right) {
            if (str[left] !== str[right]) {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
    // 使用回溯法檢查整個字串內可能的對稱子字串組合
    function backtrack(start: number) {
        // 將組合加入結果
        if (start === s.length) {
            result.push([...path]);
            return;
        }
        for (let end: number = start; end < s.length; end++) {
            // 檢查當前子字串是否對稱
            if (isPalindrome(s, start, end)) {
                path.push(s.slice(start, end + 1));
                backtrack(end + 1);
                // 回溯至上一層
                path.pop();
            }
        }
    }
    backtrack(0);
    return result;
};