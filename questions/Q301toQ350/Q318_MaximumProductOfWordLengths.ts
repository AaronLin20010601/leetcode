function maxProduct(words: string[]): number {
    const n: number = words.length;
    const sets: Set<string>[] = words.map(word => wordToSet(word));
    const lengths: number[] = words.map(w => w.length);

    let max: number = 0;
    // 逐 set 檢查是否有相同字元
    for (let i: number = 0; i < n; i++) {
        for (let j: number = i + 1; j < n; j++) {
            // 無相同字元則進行乘積比較
            if (!haveSameChar(sets[i], sets[j])) {
                const product: number = lengths[i] * lengths[j];
                if (product > max) {
                    max = product;
                }
            }
        }
    }
    return max;
};
// 將字串轉換至 set
function wordToSet(word: string): Set<string> {
    return new Set(word.split(''));
}
// 檢查兩個字串 set 中是否有相同字元
function haveSameChar(a: Set<string>, b: Set<string>): boolean {
    for (const char of a) {
        if (b.has(char)) {
            return true;
        }
    }
    return false;
}