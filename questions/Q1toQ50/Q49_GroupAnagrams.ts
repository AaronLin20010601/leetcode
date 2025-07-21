function groupAnagrams(strs: string[]): string[][] {
    const map: Map<string, string[]> = new Map();

    for (const str of strs) {
        // 以排序後的字串是否相同作為分組依據
        const sortString: string = str.split('').sort().join('');
        // 沒有相同組別的字串則建立新組別
        if (!map.has(sortString)) {
            map.set(sortString, []);
        }
        map.get(sortString)!.push(str);
    }
    return Array.from(map.values());
};