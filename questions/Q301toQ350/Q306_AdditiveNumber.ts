function isAdditiveNumber(num: string): boolean {
    const length: number = num.length;
    for (let i: number = 1; i <= length - 2; i++) {
        // 避免數字開頭為 0
        if (num[0] === '0' && i > 1) {
            break;
        }

        for (let j: number = 1; j <= length - i - 1; j++) {
            // 避免數字開頭為 0
            if (num[i] === '0' && j > 1) {
                break;
            }

            // 將字串切割為兩數字
            let num1: bigint = BigInt(num.slice(0, i));
            let num2: bigint = BigInt(num.slice(i, i + j));
            let nextCutPosition: number = i + j;

            while (nextCutPosition < length) {
                const sum: bigint = num1 + num2;
                const sumString: string = sum.toString();

                // 檢查總和和字串是否相同
                if (!num.startsWith(sumString, nextCutPosition)) {
                    break;
                }
                nextCutPosition += sumString.length;
                num1 = num2;
                num2 = sum;
            }
            // 到達字串長度尾端即符合條件
            if (nextCutPosition === length) {
                return true;
            }
        }
    }
    return false;
};