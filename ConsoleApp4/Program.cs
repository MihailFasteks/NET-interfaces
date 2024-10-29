using System;



interface ICalc
{
    int Less(int valueToCompare);
    int Greater(int valueToCompare);
}
interface IOutput2
{
    void ShowEven();
    void ShowOdd();
}
interface ICalc2
{
    int CountDistinct();
    int EqualToValue(int valueToCompare);
}

public class MyArray : ICalc, IOutput2, ICalc2
{
    private int[] arrs;
    private int count;

    public MyArray(int size)
    {
        arrs = new int[size];
        count = 0;
    }
    public int Count
    {
        get { return count; }
    }
    public string this[int index]
    {
        get
        {
            if (index >= 0 && index < count)
                return arrs[index].ToString();
            return "Wrong index";
        }
    }
    public void ShowEven()
    {
        for (int i = 0; i < arrs.Length; i++)
        {
            if (arrs[i] % 2 == 0)
            {
                Console.WriteLine(arrs[i]);
            }
        }
    }
    public void ShowOdd()
    {
        for (int i = 0; i < arrs.Length; i++)
        {
            if (arrs[i] % 2 != 0)
            {
                Console.WriteLine(arrs[i]);
            }
        }
    }

    public int CountDistinct()
    {
        int temp = 0;
        bool flag;
        for (int i = 0; i < arrs.Length; i++)
        {
            flag = true;
            for (int j = 0; j < arrs.Length; j++)
            {
                if (i == j)
                {
                    break;
                }
                if (arrs[i] == arrs[j])
                {
                    flag = false;
                    break;
                }
            }

            if (flag == true)
            {
                temp++;
            }
        }
        return temp;
    }
    public int EqualToValue(int valueToCompare)
    {
        int temp = 0;
        for (int i = 0; i < arrs.Length; i++)
        {
            if (arrs[i] == valueToCompare)
            {
                temp++;
            }
        }
        return temp;
    }
    public int Less(int valueToCompare)
    {
        int temp = 0;
        for (int i = 0; i < arrs.Length; i++)
        {
            if (arrs[i] < valueToCompare)
            {
                temp++;
            }
        }
        return temp;
    }
    public int Greater(int valueToCompare)
    {
        int temp = 0;
        for (int i = 0; i < arrs.Length; i++)
        {
            if (arrs[i] > valueToCompare)
            {
                temp++;
            }
        }
        return temp;
    }
    public void Add(int book)
    {
        if (count == arrs.Length)
        {
            int[] newBooks = new int[arrs.Length + 1];
            for (int i = 0; i < arrs.Length; i++)
            {
                newBooks[i] = arrs[i];
            }
            arrs = newBooks;
        }
        arrs[count] = book;
        count++;
    }
    public bool Remove(int book)
    {
        for (int i = 0; i < count; i++)
        {
            if (arrs[i] == book)
            {
                for (int j = i; j < count - 1; j++)
                {
                    arrs[j] = arrs[j + 1];
                }
                count--;

                if (count > 0 && count < arrs.Length - 1)
                {
                    int[] newBooks = new int[arrs.Length - 1];
                    for (int k = 0; k < count; k++)
                    {
                        newBooks[k] = arrs[k];
                    }
                    arrs = newBooks;
                }
                return true;
            }
        }
        return false;
    }
    public bool Contains(int book)
    {
        for (int i = 0; i < count; i++)
        {
            if (arrs[i] == book)
            {
                return true;
            }
        }
        return false;
    }
    public void PrintList()
    {
        if (count == 0)
        {
            Console.WriteLine("List is empty");
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(arrs[i]);
            }
        }
    }
}


class Demo
{
    public static void Main()
    {
        MyArray myArray = new MyArray(5);


        myArray.Add(1);
        myArray.Add(2);
        myArray.Add(3);
        myArray.Add(4);
        myArray.Add(2);
        myArray.Add(5);

        Console.WriteLine("Array elements:");
        myArray.PrintList();


        Console.WriteLine("\nEven numbers:");
        myArray.ShowEven();

        Console.WriteLine("\nOdd numbers:");
        myArray.ShowOdd();


        Console.WriteLine($"\nCount of distinct numbers: {myArray.CountDistinct()}");


        int valueToCompare = 2;
        Console.WriteLine($"\nCount of numbers equal to {valueToCompare}: {myArray.EqualToValue(valueToCompare)}");


        valueToCompare = 3;
        Console.WriteLine($"\nCount of numbers less than {valueToCompare}: {myArray.Less(valueToCompare)}");


        valueToCompare = 3;
        Console.WriteLine($"\nCount of numbers greater than {valueToCompare}: {myArray.Greater(valueToCompare)}");


        int numberToRemove = 2;
        if (myArray.Remove(numberToRemove))
        {
            Console.WriteLine($"\nRemoved {numberToRemove} from the array.");
        }
        else
        {
            Console.WriteLine($"\n{numberToRemove} not found in the array.");
        }

        Console.WriteLine("\nArray elements after removal:");
        myArray.PrintList();


        int numberToCheck = 4;
        Console.WriteLine($"\nDoes the array contain {numberToCheck}? {myArray.Contains(numberToCheck)}");
    }
}

