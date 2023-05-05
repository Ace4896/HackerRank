namespace HackerRank.OneWeek
{
    // https://www.hackerrank.com/challenges/one-week-preparation-kit-merge-two-sorted-linked-lists/problem
    public partial class Result
    {
        // Provided Implementation
        class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode? next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

#nullable disable

        static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            // Base case - First list is empty
            if (head1 == null)
            {
                return head2;
            }

            // Base case - Second list is empty
            if (head2 == null)
            {
                return head1;
            }

            // Main case - At least one list contains an element
            // Initialise the head node
            SinglyLinkedListNode headMerged;
            SinglyLinkedListNode currentMerged;
            SinglyLinkedListNode current1;
            SinglyLinkedListNode current2;

            if (head1.data < head2.data)
            {
                headMerged = new SinglyLinkedListNode(head1.data);
                currentMerged = headMerged;
                current1 = head1.next;
                current2 = head2;
            }
            else
            {
                headMerged = new SinglyLinkedListNode(head2.data);
                currentMerged = headMerged;
                current1 = head1;
                current2 = head2.next;
            }

            // Merge values from both lists until one of them is depleted
            while (current1 != null && current2 != null)
            {
                if (current1.data < current2.data)
                {
                    currentMerged.next = new SinglyLinkedListNode(current1.data);
                    currentMerged = currentMerged.next;
                    current1 = current1.next;
                }
                else
                {
                    currentMerged.next = new SinglyLinkedListNode(current2.data);
                    currentMerged = currentMerged.next;
                    current2 = current2.next;
                }
            }

            // Check which of the two lists still has elements left
            if (current1 != null)
            {
                currentMerged.next = current1;
            }
            else
            {
                currentMerged.next = current2;
            }

            return headMerged;
        }

#nullable restore
    }
}
