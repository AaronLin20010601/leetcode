function fractionToDecimal(numerator: number, denominator: number): string {
    // 被除數為零
    if (numerator === 0) {
        return "0";
    }

    // 檢查相除結果是否為負數
    const isNegative: boolean = (numerator < 0) !== (denominator < 0);
    let absNumerator: number = Math.abs(numerator);
    let absDenominator: number = Math.abs(denominator);

    // 處理整數部分
    const result: string[] = [];
    if (isNegative) {
        result.push("-");
    }

    const integer: number = Math.floor(absNumerator / absDenominator);
    result.push(integer.toString());
    let remainder: number = absNumerator % absDenominator;
    if (remainder === 0) {
        return result.join("");
    }

    // 處理小數部分
    result.push(".");
    const checkLoop: Map<number, number> = new Map();
    while (remainder !== 0) {
        // 出現循環小數
        if (checkLoop.has(remainder)) {
            // 找出循環起始位置並合併前面結果
            const start: number = checkLoop.get(remainder)!;
            const front: string = result.slice(0, start).join("");
            const loop = result.slice(start).join("");
            return front + "(" + loop + ")";
        }
        // 紀錄小數位置
        checkLoop.set(remainder, result.length);
        remainder *= 10;

        const digit: number = Math.floor(remainder / absDenominator);
        result.push(digit.toString());
        remainder %= absDenominator;
    }
    return result.join("");
};