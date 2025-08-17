function convertToTitle(columnNumber: number): string {
    let result: string = "";
    
    // 進行計算並更新字串
    while (columnNumber > 0) {
        let remainder: number = (columnNumber - 1) % 26;
        result = String.fromCharCode(remainder + 65) + result;
        columnNumber = Math.floor((columnNumber - 1) / 26);
    }
    return result;
};