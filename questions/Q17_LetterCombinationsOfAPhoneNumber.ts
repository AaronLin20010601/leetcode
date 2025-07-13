function letterCombinations(digits: string): string[] {
    if (!digits) return [];

    // 數字和字母表
    const phoneNumber: Record<string, string[]> = {
        '2': ['a', 'b', 'c'],
        '3': ['d', 'e', 'f'],
        '4': ['g', 'h', 'i'],
        '5': ['j', 'k', 'l'],
        '6': ['m', 'n', 'o'],
        '7': ['p', 'q', 'r', 's'],
        '8': ['t', 'u', 'v'],
        '9': ['w', 'x', 'y', 'z'],
    }
    let result: string[] = [''];

    // 逐數字進行字串疊加
    for (const digit of digits) {
        const letters: string[] = phoneNumber[digit];
        const newResult: string[] = [];

        // 對現有組合進行疊加
        for (const combination of result) {
            for (const letter of letters) {
                newResult.push(combination + letter);
            }
        }
        result = newResult;
    }
    return result;
};