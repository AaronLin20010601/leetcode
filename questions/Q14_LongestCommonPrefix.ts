function longestCommonPrefix(strs: string[]): string {
    if (strs.length === 0) return "";

    // 排序後僅比較最頭和最尾字串
    strs.sort();
    const first: string = strs[0];
    const last: string = strs[strs.length - 1];

    let i: number = 0;
    while (i < first.length && first[i] === last[i]) {
        i++;
    }
    return first.substring(0, i);
};