function countAndSay(n: number): string {
    let say: string = "1";
    // 進行字串疊加
    for (let i: number = 1; i < n; i++) {
        let current: string[] = [];
        let count: number = 1;
        // 計算數字和其個數
        for (let j: number = 0; j < say.length; j++) {
            if (say[j] === say[j + 1]) {
                count++;
            }
            else {
                current.push(count.toString(), say[j]);
                count = 1;
            }
        }
        say = current.join('');
    }
    return say;
};