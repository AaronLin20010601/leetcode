function findRepeatedDnaSequences(s: string): string[] {
    const dnaLength: number = 10;
    const existDna: Set<string> = new Set();
    const repeatDna: Set<string> = new Set();

    // 逐一依照 10 個字元長度檢查字串
    for (let i: number = 0; i <= s.length - dnaLength; i++) {
        const dnaSlice: string = s.slice(i, i + dnaLength);

        // 把已出現過的重複片段加入結果
        if (existDna.has(dnaSlice)) {
            repeatDna.add(dnaSlice);
        }
        else {
            existDna.add(dnaSlice);
        }
    }
    return Array.from(repeatDna);
};