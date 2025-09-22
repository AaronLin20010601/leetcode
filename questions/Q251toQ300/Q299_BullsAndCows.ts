function getHint(secret: string, guess: string): string {
    const length: number = secret.length;
    let bulls: number = 0;
    const secretCount: Array<number> = new Array(10).fill(0);
    const guessCount: Array<number> = new Array(10).fill(0);

    // 逐一檢查數字對應
    for (let i: number = 0; i < length; i++) {
        // 數字正確且位置正確
        if (secret[i] === guess[i]) {
            bulls++;
        }
        // 位置不正確的數字數量紀錄
        else {
            secretCount[Number(secret[i])]++;
            guessCount[Number(guess[i])]++;
        }
    }

    let cows: number = 0;
    for (let i: number = 0; i < 10; i++) {
        cows += Math.min(secretCount[i], guessCount[i]);
    }
    return `${bulls}A${cows}B`;
};