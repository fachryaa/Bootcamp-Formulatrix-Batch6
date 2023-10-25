# Day11

## Materi
1. [Single Collection](#Single-Collection)
1. [Pair Collection](#Pair-Collection)

## Single Collection
1. Array
    - Array adalah sebuah tipe data yang dapat menyimpan banyak data dengan tipe data yang sama.
    - Array memiliki index yang dimulai dari 0.
    - Array memiliki panjang yang tetap.
    - contoh
        ```csharp
        int[] numbers = new int[5];
        numbers[0] = 1;
        numbers[1] = 2;
        numbers[2] = 3;
        numbers[3] = 4;
        numbers[4] = 5;
        ```
1. List
    - List adalah sebuah tipe data yang dapat menyimpan banyak data dengan tipe data yang sama.
    - List memiliki panjang yang dinamis.
    - contoh
        ```csharp
        List<int> numbers = new List<int>();
        numbers.Add(1);
        numbers.Add(2);
        
        // print all numbers
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
        ```
1. Stack
    - Stack memiliki panjang yang dinamis.
    - Stack menggunakan konsep LIFO (Last In First Out).
    - Memiliki method :
        - Push() : menambahkan data ke dalam stack.
        - Pop() : mengambil data terakhir dari stack.
        - Peek() : melihat data terakhir dari stack.
    - contoh
        ```csharp
        Stack<int> numbers = new Stack<int>();
        numbers.Push(1);
        numbers.Push(2);
        numbers.Push(3);
        
        // Pop
        Console.WriteLine(numbers.Pop()); // 3 || Stack : 1, 2

        // Peek
        Console.WriteLine(numbers.Peek()); // 2 || Stack : 1, 2
        ```
1. Queue
    - Queue memiliki panjang yang dinamis.
    - Queue menggunakan konsep FIFO (First In First Out).
    - Memiliki method :
        - Enqueue() : menambahkan data ke dalam queue.
        - Dequeue() : mengambil data pertama dari queue.
        - Peek() : melihat data pertama dari queue.
    - contoh
        ```csharp
        Queue<int> numbers = new Queue<int>();
        numbers.Enqueue(1);
        numbers.Enqueue(2);
        numbers.Enqueue(3);

        // Dequeue
        Console.WriteLine(numbers.Dequeue()); // 1 || Queue : 2, 3

        // Peek
        Console.WriteLine(numbers.Peek()); // 2 || Queue : 2, 3
        ```

## Pair Collection
1. Dictionary
    - Dictionary adalah sebuah tipe data yang dapat menyimpan banyak data dengan tipe data yang sama.
    - Dictionary memiliki panjang yang dinamis.
    - Dictionary memiliki key dan value.
    - Type safety.
    - contoh
        ```csharp
        Dictionary<string, int> numbers = new Dictionary<string, int>();
        numbers.Add("one", 1);
        numbers.Add("two", 2);
        numbers.Add("three", 3);

        // print all numbers
        foreach (KeyValuePair<string, int> number in numbers)
        {
            Console.WriteLine(number.Key + " : " + number.Value);
        }
        ```
1. Hash Table
    - Hash Table tidak direkomendasikan karena bisa menampung objek apa saja.
    - Hash Table memiliki panjang yang dinamis.
    - Hash Table memiliki key dan value.
    - Type unsafty karena menggunakan object.
    - contoh
        ```csharp
        Hashtable numbers = new Hashtable();
        numbers.Add("one", 1);
        numbers.Add(2, "two");
        numbers.Add(true, 3);

        // print all numbers
        foreach (DictionaryEntry number in numbers)
        {
            Console.WriteLine(number.Key + " : " + number.Value);
        }
        ```