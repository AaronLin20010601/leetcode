function isAnagram(s: string, t: string): boolean {
    if (s.length !== t.length) {
        return false;
    }

    // 計算字母出現抵銷次數
    const alphabetCount: number[] = new Array(26).fill(0);
    for (let i: number = 0; i < s.length; i++) {
        alphabetCount[s.charCodeAt(i) - 97]++;
        alphabetCount[t.charCodeAt(i) - 97]--;
    }

    // 字母出現次數沒有不平衡即為相同
    for (const c of alphabetCount) {
        if (c !== 0) {
            return false;
        }
    }
    return true;
};