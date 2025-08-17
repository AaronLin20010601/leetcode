function titleToNumber(columnTitle: string): number {
    let result: number = 0;

    // 逐一檢查並計算字母
    for (let i: number = 0; i < columnTitle.length; i++) {
        const value = columnTitle.charCodeAt(i) - 64;
        result = result * 26 + value;
    }
    return result;
};