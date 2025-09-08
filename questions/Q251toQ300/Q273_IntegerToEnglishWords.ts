const oneToNineteen: string[] = [
    "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", 
    "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
];
const twentyToNinety: string[] = [
    "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
];

// 取得數值段落字串
function getNumberString(num: number): string {
    if (num === 0) {
        return "";
    }
    if (num < 20) {
        return oneToNineteen[num] + " ";
    }
    // 當前值超過 20 則將剩餘部分遞迴加入
    if (num < 100) {
        return twentyToNinety[Math.floor(num / 10)] + " " + getNumberString(num % 10);
    }
    // 當前值超過 100 則將剩餘部分遞迴加入
    return oneToNineteen[Math.floor(num / 100)] + " Hundred " + getNumberString(num % 100);
}
function numberToWords(num: number): string {
    if (num === 0) {
        return "Zero";
    }

    let result: string = "";
    // 拆分成各單位部分
    const billion: number = Math.floor(num / 1000000000);
    const million: number = Math.floor((num % 1000000000) / 1000000);
    const thousand: number = Math.floor((num % 1000000) / 1000);
    const lessThanThousand: number = num % 1000;

    // 對各拆分部分進行字串加入
    if (billion) {
        result += getNumberString(billion) + "Billion ";
    }
    if (million) {
        result += getNumberString(million) + "Million ";
    }
    if (thousand) {
        result += getNumberString(thousand) + "Thousand ";
    }
    if (lessThanThousand) {
        result += getNumberString(lessThanThousand);
    }

    return result.trim();
};