function largestNumber(nums: number[]): string {
    const number: string[] = nums.map(String);
    number.sort(compareNumber);

    if (number[0] === "0") {
        return "0";
    }
    return number.join("");
};
function compareNumber(num1: string, num2: string): number {
    // 比較不同排序方式的數字大小
    const order1: string = num1 + num2;
    const order2: string = num2 + num1;

    if (order1 > order2) {
        return -1;
    }
    if (order2 > order1) {
        return 1;
    }
    return 0;
};