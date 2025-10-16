function isValidSerialization(preorder: string): boolean {
    const nodes: string[] = preorder.split(',');
    let nodeSlot: number = 1;

    // 歷遍每個節點
    for (const node of nodes) {
        // 節點無法滿足二元樹結構
        if (nodeSlot === 0) {
            return false;
        }
        // 空節點占用一個分支點空間
        if (node === '#') {
            nodeSlot -= 1;
        }
        // 非空節點占用一個分支點空間,同時拓展兩個子節點空間
        else {
            nodeSlot += 1;
        }
    }
    // 歷遍所有節點後沒有剩餘空間即滿足二元樹
    return nodeSlot === 0;
};