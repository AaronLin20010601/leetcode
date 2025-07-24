function fullJustify(words: string[], maxWidth: number): string[] {
    const result: string[] = [];
    // 當前單字和單字總長度
    let line: string[] = [];
    let lineLength: number = 0;

    for (let i: number = 0; i < words.length; i++) {
        const word: string = words[i];

        // 檢查當前行加上新單字和單字總量後是否超過一行長度上限
        if (lineLength + word.length + line.length > maxWidth) {
            // 當前可用的空格量和單字間格量
            const currentMaxSpaces: number = maxWidth - lineLength;
            const lineSpaces: number = line.length - 1;

            // 該行只有一個單字則靠左對齊
            if (lineSpaces === 0) {
                result.push(line[0] + ' '.repeat(currentMaxSpaces));
            }
            else {
                // 計算每個單字間的空格分配量和多餘的空格量
                const spacePerGap: number = Math.floor(currentMaxSpaces / lineSpaces);
                const extraSpaces: number = currentMaxSpaces % lineSpaces;

                // 建立當前行並將空格分配
                let lineString: string = '';
                for (let j: number = 0; j < line.length; j++) {
                    lineString += line[j];
                    if (j < lineSpaces) {
                        lineString += ' '.repeat(spacePerGap + (j < extraSpaces ? 1 : 0));
                    }
                }
                result.push(lineString);
            }
            // 重置並繼續下一行
            line = [];
            lineLength = 0;
        }
        // 未達到一行上限則加入下一個單字
        line.push(word);
        lineLength += word.length;
    }
    // 將最後一行靠左對齊並補齊空格
    const lastLine: string = line.join(' ');
    result.push(lastLine + ' '.repeat(maxWidth - lastLine.length));
    return result;
};