function lengthOfLongestSubstring(s: string): number {
    // 使用 set 和左右端點檢查子字串
    const subString: Set<string> = new Set();
    let left: number = 0;
    let maxLength: number = 0;

    for (let right: number = 0; right < s.length; right++) {
        // 有重複字元則左端前移
        while (subString.has(s[right])) {
            subString.delete(s[left]);
            left++;
        }

        // 更新子字串 set 和最大長度
        subString.add(s[right]);
        maxLength = Math.max(maxLength, right - left + 1);
    }
    return maxLength;
};