function compareVersion(version1: string, version2: string): number {
    const version1Array: string[] = version1.split('.');
    const version2Array: string[] = version2.split('.');
    const versionLength: number = Math.max(version1Array.length, version2Array.length);

    // 歷遍比較版本數字陣列
    for (let i: number = 0; i < versionLength; i++) {
        const ver1 = i < version1Array.length ? Number(version1Array[i]) : 0;
        const ver2 = i < version2Array.length ? Number(version2Array[i]) : 0;

        if (ver1 > ver2) {
            return 1;
        }
        if (ver1 < ver2) {
            return -1;
        }
    }
    return 0;
};