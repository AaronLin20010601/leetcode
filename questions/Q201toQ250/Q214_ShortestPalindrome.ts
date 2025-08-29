function shortestPalindrome(s: string): string {
    const sLength: number = s.length;
    if (sLength <= 1) {
        return s;
    }

    // 檢查字串是否對稱
    function isPalindrome(end: number): boolean {
        let left: number = 0, right: number = end;

        // 從左右兩端收斂檢查
        while (left < right) {
            if (s[left] !== s[right]) {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }

    // 找出最長回文前綴位置
    let longestPrefixEnd = sLength - 1;
    while (longestPrefixEnd >= 0) {
        if (isPalindrome(longestPrefixEnd)) {
            break;
        }
        longestPrefixEnd--;
    }

    // 從找到位置切割並反轉接上
    const suffix: string = s.substring(longestPrefixEnd + 1);
    const prefix: string = suffix.split('').reverse().join('');
    return prefix + s;
};