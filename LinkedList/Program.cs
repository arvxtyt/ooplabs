using LinkedListClass;

public static class Program
{
    public static void Main()
    {
        var linkedList = new LinkedList();
        bool flag = true;
        int idx = 0;
        double val = 0;
        do
        {
            Console.WriteLine(linkedList.ShowList());

            Console.WriteLine(
                "Choose option:\n" +
                "a) Add element\n" +
                "b) Remove element\n" +
                "c) Clear list\n" +
                "d) Get sum of elements greater than value\n" +
                "e) Get new linked list of elements less than average\n" +
                "f) Remove elements on even positions\n" +
                "ESC) Exit"
                );

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.A:
                    Console.Write("Enter value: ");
                    if (double.TryParse(Console.ReadLine(), out val))
                    {
                        linkedList.Add(val);
                    }
                    break;
                case ConsoleKey.B:
                    Console.Write("Enter index: ");
                    if (int.TryParse(Console.ReadLine(), out idx) && idx >= 0)
                    {
                        linkedList.Delete(idx);
                    }
                    break;
                case ConsoleKey.C:
                    linkedList.Clear();
                    break;
                case ConsoleKey.D:
                    Console.Write("Enter value: ");
                    if (double.TryParse(Console.ReadLine(), out val))
                    {
                        Console.WriteLine(linkedList.GetSumOfElementsGreaterThanValue(val));
                    }
                    break;
                case ConsoleKey.E:
                    Console.WriteLine("Result: " + linkedList.GetLinkedListOfElementsLessThanAverage().ShowList());
                    break;
                case ConsoleKey.F:
                    linkedList.RemoveElementsOnEvenPositions();
                    break;
                case ConsoleKey.Escape:
                    flag = false;
                    break;
            }
        } while (flag);
    }
}
