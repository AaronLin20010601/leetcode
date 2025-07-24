function addBinary(a: string, b: string): string {
    let lengthA: number = a.length - 1;
    let lengthB: number = b.length - 1;
    let carry: number = 0;
    let result: string[] = [];

    // 從字串尾端開始加算
    while (lengthA >= 0 || lengthB >= 0 || carry > 0) {
        // 取得該位數字並和進位一起加算
        const digitA: number = lengthA >= 0 ? parseInt(a[lengthA]) : 0;
        const digitB: number = lengthB >= 0 ? parseInt(b[lengthB]) : 0;
        const sum: number = digitA + digitB + carry;

        result.push((sum % 2).toString());
        carry = Math.floor(sum / 2);
        lengthA--;
        lengthB--;
    }
    return result.reverse().join('');
};