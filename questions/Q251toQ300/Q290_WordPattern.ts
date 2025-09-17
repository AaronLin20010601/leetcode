function wordPattern(pattern: string, s: string): boolean {
    const words: string[] = s.split(' ');
    if (pattern.length !== words.length) {
        return false;
    }
    const patternToWord: Map<string, string> = new Map();
    const wordToPattern: Map<string, string> = new Map();

    // 建立及檢查單字和字元對應
    for (let i: number = 0; i < pattern.length; i++) {
        const char: string = pattern[i];
        const word: string = words[i];

        // 檢查已存在組合
        if (patternToWord.has(char) && patternToWord.get(char) !== word) {
            return false;
        }
        else {
            if (wordToPattern.has(word) && wordToPattern.get(word) !== char) {
                return false;
            }

            // 建立對應關係
            patternToWord.set(char, word);
            wordToPattern.set(word, char);
        }
    }
    return true;
};