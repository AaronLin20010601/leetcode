function isIsomorphic(s: string, t: string): boolean {
    if (s.length !== t.length) {
        return false;
    }

    const sPairt: Map<string, string> = new Map();
    const tPairs: Map<string, string> = new Map();
    for (let i: number = 0; i < s.length; i++) {
        const sChar = s[i];
        const tChar = t[i];

        // 檢查對比兩字串對應字元對
        if (sPairt.has(sChar) && sPairt.get(sChar) !== tChar) {
            return false;
        }
        if (tPairs.has(tChar) && tPairs.get(tChar) !== sChar) {
            return false;
        }
        // 新增對應字元對
        sPairt.set(sChar, tChar);
        tPairs.set(tChar, sChar);
    }
    return true;
};