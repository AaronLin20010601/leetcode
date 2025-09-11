// C# IEnumerator interface reference:
// https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=netframework-4.8

class PeekingIterator {
    private readonly IEnumerator<int> _iter;
    private int _next;
    private bool _hasNext;

    public PeekingIterator(IEnumerator<int> iterator) {
        if (iterator == null) {
            throw new ArgumentNullException(nameof(iterator));
        }
        _iter = iterator;

        // 檢查是否已有迭代點
        try {
            _next = _iter.Current;
            _hasNext = true;
        }
        // 移動至下一迭代點
        catch (InvalidOperationException) {
            _hasNext = _iter.MoveNext();
            if (_hasNext) {
                _next = _iter.Current;
            }
        }
    }

    // 回傳下一個迭代點
    public int Peek() {
        if (!_hasNext) {
            throw new InvalidOperationException("No more elements");
        }
        return _next;
    }

    // 回傳下一個迭代點並往後
    public int Next() {
        if (!_hasNext) {
            throw new InvalidOperationException("No more elements");
        }

        int result = _next;
        _hasNext = _iter.MoveNext();

        if (_hasNext) {
            _next = _iter.Current;
        }
        return result;
    }

    // 是否有後續迭代點
    public bool HasNext() {
        return _hasNext;
    }
}