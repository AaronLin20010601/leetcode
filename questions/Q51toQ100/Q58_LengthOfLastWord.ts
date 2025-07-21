function lengthOfLastWord(s: string): number {
    // 去除空格並分割字串
    const trimmed: string = s.trim();
    const words: string[] = trimmed.split(" ");
    return words[words.length - 1].length;
};