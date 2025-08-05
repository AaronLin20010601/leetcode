function isPalindrome(s: string): boolean {
    // 轉小寫和去除符號和空格
    const filtered: string = s.toLowerCase().replace(/[^a-z0-9]/g, '');
    // 檢查字串反轉後是否和原本相同
    return filtered === filtered.split('').reverse().join('');
};