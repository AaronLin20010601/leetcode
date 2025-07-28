function isScramble(s1: string, s2: string): boolean {
    const map: Map<string, boolean> = new Map();

    function isMatch(str1: string, str2: string): boolean {
        const key: string = str1 + '#' + str2;
        if (map.has(key)) {
            return map.get(key)!;
        }

        // 字串相同
        if (str1 === str2) {
            map.set(key, true);
            return true;
        }
        // 字串長度或字元內容不同
        if (str1.length !== str2.length || [...str1].sort().join('') !== [...str2].sort().join('')) {
            map.set(key, false);
            return false;
        }

        const length: number = str1.length;
        for (let i: number = 1; i < length; i++) {
            // 不交叉對比
            if (isMatch(str1.substring(0, i), str2.substring(0, i)) && 
                isMatch(str1.substring(i), str2.substring(i))) {
                map.set(key, true);
                return true;
            }
            // 交叉對比
            if (isMatch(str1.substring(0, i), str2.substring(length - i)) && 
                isMatch(str1.substring(i), str2.substring(0, length - i))) {
                map.set(key, true);
                return true;
            }
        }
        map.set(key, false);
        return false;
    }
    return isMatch(s1, s2);
};