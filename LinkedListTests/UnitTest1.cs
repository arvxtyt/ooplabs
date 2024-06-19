using LinkedListClass;

namespace LinkedListTests
{
    public class SimpleMethodsTests
    {
        [Fact]
        public void LinkedListCreated()
        {
            var ll = new LinkedList();

            Assert.Null(ll.Head);
        }

        [Fact]
        public void LinkedListAddedElements()
        {
            var ll = new LinkedList();

            ll.Add(1);
            ll.Add(2);
            ll.Add(3);

            Assert.Equal(3, ll.Head.Value);
        }

        [Fact]
        public void LinkedListDeletedElements()
        {
            var ll = new LinkedList();
            ll.Add(1);
            ll.Add(2);

            ll.Delete(1);

            Assert.Equal(2, ll.Head.Value);
        }

        [Fact]
        public void LinkedListDeletedHead()
        {
            var ll = new LinkedList();
            ll.Add(1);
            ll.Add(2);

            ll.Delete();

            Assert.Equal(1, ll.Head.Value);
        }

        [Fact]
        public void LinkedListDeletedLast()
        {
            var ll = new LinkedList();
            ll.Add(1);
            ll.Add(2);
            ll.Add(3);

            ll.Delete(2);

            double sum = 0;

            foreach (Node item in ll)
            {
                sum += item.Value;
            }

            Assert.Equal(5, sum);
        }

        [Fact]
        public void LinkedListIterated()
        {
            var ll = new LinkedList();
            ll.Add(1);
            ll.Add(2);
            ll.Add(3);

            double sum = 0;

            foreach (Node item in ll)
            {
                sum += item.Value;
            }

            Assert.Equal(6, sum);
        }

        [Fact]
        public void LinkedListMovedNext()
        {
            var ll = new LinkedList();
            ll.Add(1);
            ll.Add(2);

            ll.MoveNext();

            Assert.Equal(2, ll.Current.Value);
        }

        [Fact]
        public void LinkedListClear()
        {
            var ll = new LinkedList();
            ll.Add(1);
            ll.Add(2);
            ll.Add(3);

            ll.Clear();

            double sum = 0;

            foreach (Node item in ll)
            {
                sum += item.Value;
            }

            Assert.Equal(0, sum);
        }

        [Fact]
        public void LengthOfEmptyListTest()
        {
            var ll = new LinkedList();

            Assert.Equal(0, ll.Length);
        }
    }


    public class TaskMethodsTests
    {
        [Fact]
        public void GetSumOfElementsGreaterThanValueTest()
        {
            var ll = new LinkedList();
            ll.Add(1);
            ll.Add(2);
            ll.Add(-1);
            ll.Add(3);
            ll.Add(100);
            ll.Add(17);

            var sum = ll.GetSumOfElementsGreaterThanValue(5);

            Assert.Equal(117, sum);
        }

        [Fact]
        public void GetLinkedListOfElementsLessThanAverageTest()
        {
            var ll = new LinkedList();
            ll.Add(1);
            ll.Add(2);
            ll.Add(2);
            ll.Add(2);
            ll.Add(3);
            ll.Add(3);
            ll.Add(3);
            ll.Add(3);
            ll.Add(3);
            ll.Add(3);
            ll.Add(100);
            ll.Add(200);

            var ll2 = ll.GetLinkedListOfElementsLessThanAverage();
            var sum = 0.0;

            foreach (Node v in ll2)
            {
                sum += v.Value;
            }

            Assert.Equal(25, sum);
        }

        [Fact]
        public void RemoveElementsOnEvenPositionsEvenTest()
        {
            var ll = new LinkedList();
            ll.Add(1);
            ll.Add(2);
            ll.Add(3);
            ll.Add(4);

            ll.RemoveElementsOnEvenPositions();

            var sum = 0.0;

            foreach (Node v in ll)
            {
                sum += v.Value;
            }

            Assert.Equal(6, sum);
        }

        [Fact]
        public void RemoveElementsOnEvenPositionsOddTest()
        {
            var ll = new LinkedList();
            ll.Add(1);
            ll.Add(2);
            ll.Add(3);
            ll.Add(4);
            ll.Add(5);

            ll.RemoveElementsOnEvenPositions();

            var sum = 0.0;

            foreach (Node v in ll)
            {
                sum += v.Value;
            }

            Assert.Equal(9, sum);
        }

        [Fact]
        public void FindFirstElementGreaterThanAverage()
        {
            var ll = new LinkedList();
            ll.Add(1);
            ll.Add(2);
            ll.Add(3);
            ll.Add(2);
            ll.Add(1);

            Assert.Equal(2, ll.FindFirstElementGreaterThanAverage());
        }
    }
}