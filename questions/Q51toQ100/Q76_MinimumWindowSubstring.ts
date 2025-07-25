function minWindow(s: string, t: string): string {
    if (t.length > s.length) {
        return "";
    }

    const included: Map<string, number> = new Map();
    const slidingWindow: Map<string, number> = new Map();
    // 計算需要的字元和數量
    for (const character of t) {
        included.set(character, (included.get(character) || 0) + 1);
    }

    let left: number = 0, right: number = 0;
    let validCount: number = 0;
    let start: number = 0, length: number = Infinity;

    while (right < s.length) {
        const character: string = s[right];
        right++;

        // 若為需要的字原則加入 window
        if (included.has(character)) {
            slidingWindow.set(character, (slidingWindow.get(character) || 0) + 1);
            // 該字元需求數量已到達
            if (slidingWindow.get(character) === included.get(character)) {
                validCount++;
            }
        }
        // 所有字元需求到達時開始嘗試調整縮小邊界
        while (validCount === included.size) {
            // 更新最小範圍
            if (right - left < length) {
                start = left;
                length = right - left;
            }

            // 縮小左邊界
            const leftCharacter = s[left];
            left++;
            if (included.has(leftCharacter)) {
                if (slidingWindow.get(leftCharacter) === included.get(leftCharacter)) {
                    validCount--;
                }
                slidingWindow.set(leftCharacter, slidingWindow.get(leftCharacter)! - 1);
            }
        }
    }
    return length === Infinity ? "" : s.substring(start, start + length);
};