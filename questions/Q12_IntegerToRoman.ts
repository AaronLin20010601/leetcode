function intToRoman(num: number): string {
    // 羅馬數字轉換表
    const roman: [number, string][] = [
        [1000, "M"],
        [900, "CM"],
        [500, "D"],
        [400, "CD"],
        [100, "C"],
        [90, "XC"],
        [50, "L"],
        [40, "XL"],
        [10, "X"],
        [9, "IX"],
        [5, "V"],
        [4, "IV"],
        [1, "I"],
    ];
    let result: string = "";

    // 根據對應表減法轉換
    for (const [value, symbol] of roman) {
        while (num >= value) {
            result += symbol;
            num -= value;
        }
    }
    return result;
};