function reverseWords(s: string): string {
    // 分割字串後去除空格,反轉內容再接上空格
    return s.trim().split(/\s+/).reverse().join(' ');
};