function summaryRanges(nums: number[]): string[] {
    const numbers: number = nums.length;
    const result: string[] = [];
    if (numbers === 0) {
        return result;
    }

    let start = nums[0];
    for (let i: number = 0; i < numbers; i++) {
        // 檢查是否為連續數字範圍並記錄
        if (i === numbers - 1 || nums[i + 1] !== nums[i] + 1) {
            if (start === nums[i]) {
                result.push(`${start}`);
            }
            else {
                result.push(`${start}->${nums[i]}`);
            }
            if (i < numbers - 1) {
                start = nums[i + 1];
            }
        }
    }
    return result;
};