function restoreIpAddresses(s: string): string[] {
    const result: string[] = [];

    // 使用回溯法進行符合的組合查找
    function backtrack(index: number, ip: string[]) {
        // 達成 ip 組合條件
        if (ip.length === 4 && index === s.length) {
            result.push(ip.join('.'));
            return;
        }
        // 不符合條件
        if (ip.length === 4 || index > s.length) {
            return;
        }
        
        // 進行 ip 數字組合嘗試
        for (let ipLength: number = 1; ipLength <= 3; ipLength++) {
            if (index + ipLength > s.length) {
                break;
            }
            const currentIp: string = s.substring(index, index + ipLength);
            // 0 開頭時長度不可大於一
            if (currentIp.startsWith('0') && currentIp.length > 1) {
                continue;
            }

            // ip 不可大於 255
            const num: number = parseInt(currentIp);
            if (num > 255) {
                continue;
            }

            ip.push(currentIp);
            backtrack(index + ipLength, ip);
            // 回溯至上一層
            ip.pop();
        }
    }
    backtrack(0, []);
    return result;
};