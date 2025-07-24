function isNumber(s: string): boolean {
    // 去除空格
    s = s.trim();
    if (s.length === 0) {
        return false;
    }

    let hasNum: boolean = false;
    let hasDot: boolean = false;
    let hasExponent: boolean = false;
    for (let i: number = 0; i < s.length; i++) {
        const ch: string = s[i];

        // 檢查是否為數字
        if (ch >= '0' && ch <= '9') {
            hasNum = true;
        }
        // 檢查正負號位置是否合理
        else if (ch === '+' || ch === '-') {
            if (i !== 0 && s[i - 1].toLowerCase() !== 'e') {
                return false;
            }
        }
        // 檢查小數點位置是否合理
        else if (ch === '.') {
            if (hasDot || hasExponent) {
                return false;
            }
            hasDot = true;
        }
        // 檢查指數位置是否合理
        else if (ch.toLowerCase() === 'e') {
            if (hasExponent || !hasNum) {
                return false;
            }
            hasExponent = true;
            hasNum = false;
        }
        // 非法字元
        else {
            return false;
        }
    }
    return hasNum;
};