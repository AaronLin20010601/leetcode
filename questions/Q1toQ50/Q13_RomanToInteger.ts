function romanToInt(s: string): number {
    // 羅馬數字轉換表
    const roman: Record<string, number> = {
        I: 1,
        V: 5,
        X: 10,
        L: 50,
        C: 100,
        D: 500,
        M: 1000
    };
    let result: number = 0;

    // 依字元進行數字轉換
    for (let i: number = 0; i < s.length; i++) {
        const current: number = roman[s[i]];
        const next: number = roman[s[i + 1]];

        // 檢查是否為 4 或 9 的減法字串
        if (next > current) {
            result += next - current;
            i++;
        }
        else {
            result += current;
        }
    }
    return result;
};