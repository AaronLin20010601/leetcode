public class MinStack {
    private Stack<int> stack;
    private Stack<int> min;

    public MinStack() {
        stack = new Stack<int>();
        min = new Stack<int>();
    }
    
    public void Push(int val) {
        stack.Push(val);
        if (min.Count == 0) {
            min.Push(val);
        }
        else {
            // 紀錄當前最小值
            min.Push(Math.Min(val, min.Peek()));
        }
    }
    
    public void Pop() {
        // 移除 stack 頂部
        stack.Pop();
        min.Pop();
    }
    
    public int Top() {
        // 回傳 stack 頂部
        return stack.Peek();
    }
    
    public int GetMin() {
        // 回傳當前最小值
        return min.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */