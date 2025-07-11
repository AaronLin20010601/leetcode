function longestPalindrome(s: string): string {
    if (!s || s.length < 1) return "";

    // 開頭和結束位置
    let start: number = 0;
    let end: number = 0;

    // 尋找並更新對稱字串開頭和結束位置
    for (let i: number = 0; i < s.length; i++) {
        //偶數和奇數長度字串
        const oddLength: number = expandFromCenter(s, i, i);
        const evenLength: number = expandFromCenter(s, i, i + 1);
        const maxLength: number = Math.max(oddLength, evenLength);

        if (maxLength > end - start) {
            start = i - Math.floor((maxLength - 1) / 2);
            end = i + Math.floor(maxLength / 2);
        }
    }
    return s.substring(start, end + 1);
};

// 從中心位置開始檢查對稱字串
function expandFromCenter(s:string, left: number, right: number) {
    while (left >= 0 && right < s.length && s[left] == s[right]) {
        left--;
        right++;
    }
    return right - left - 1;
}