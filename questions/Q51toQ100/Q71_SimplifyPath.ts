function simplifyPath(path: string): string {
    const stack: string[] = [];
    // 取得目錄路徑名稱
    const routes: string[] = path.split("/");

    for (const route of routes) {
        // 跳過空白目錄和當前目錄
        if (route === "" || route === ".") {
            continue;
        }
        // 移除上層目錄
        else if (route === "..") {
            if (stack.length > 0) {
                stack.pop();
            }
        }
        // 加入目錄
        else {
            stack.push(route);
        }
    }
    return "/" + stack.join("/");
};