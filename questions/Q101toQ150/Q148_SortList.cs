/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode SortList(ListNode head) {
        if (head == null || head.next == null) {
            return head;
        }

        int listLength = 0;
        for (ListNode i = head; i != null; i = i.next) {
            listLength++;
        }
        ListNode front = new ListNode(0);
        front.next = head;

        for (int step = 1; step < listLength; step *= 2) {
            ListNode previous = front;
            ListNode current = front.next;

            // 進行分割成子 list 後再進行合併排序
            while (current != null) {
                ListNode left = current;
                ListNode right = SplitList(left, step);
                ListNode nextHead = SplitList(right, step);

                previous = MergeList(left, right, previous);
                current = nextHead;
            }
        }
        return front.next;
    }
    // 將 list 分割
    private ListNode SplitList(ListNode head, int index) {
        if (head == null) {
            return null;
        }

        ListNode current = head;
        for (int i = 1; i < index && current.next != null; i++) {
            current = current.next;
        }
        // 將 list 從該位置切割
        ListNode nextHead = current.next;
        current.next = null;
        return nextHead;
    }
    // 將分割的子 list 重新連接
    private ListNode MergeList(ListNode list1, ListNode list2, ListNode previous) {
        ListNode tail = previous;
        while (list1 != null && list2 != null) {
            // 依照節點值進行排序連接
            if (list1.val <= list2.val) {
                tail.next = list1;
                list1 = list1.next;
            }
            else {
                tail.next = list2;
                list2 = list2.next;
            }
            tail = tail.next;
        }
        // 接上剩餘 list 並回傳尾端
        tail.next = (list1 != null) ? list1 : list2;
        while (tail.next != null) {
            tail = tail.next;
        }
        return tail;
    }
}