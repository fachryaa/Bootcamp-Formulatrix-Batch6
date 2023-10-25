# Day07

## Contents
1. [Event](#event)
1. [EventHandler](#eventhandler)
1. [Action](#action)

## Event
- Event digunakan untuk mengamankan delegate
- jika delegate menggunakan event, maka hanya bisa menggunakan operator `+=` dan `-=` untuk menambahkan dan mengurangi delegate
- tidak bisa menggunakan `=` untuk mengganti delegate
- jika menggunakan `=` untuk mengganti delegate, maka akan error
- contoh
  ```csharp
  public class MyClass
  {
    public event MyDelegate MyEvent;
  }
  ```

## EventHandler
- EventHandler adalah delegate yang sudah disediakan oleh .NET
- EventHandler memiliki 2 parameter, yaitu `object sender` dan `EventArgs e`
- `object sender` adalah object yang mengirim event
- `EventArgs e` adalah data yang dikirim oleh object
- `EventArgs` adalah class yang sudah disediakan oleh .NET
- `EventArgs` tidak memiliki data, hanya berisi method kosong
- jika ingin mengirim data, bisa menggunakan class turunan dari `EventArgs`
  - contoh: `class MyEventArgs : EventArgs`
- generic delegate `EventHandler<T>` bisa digunakan untuk mengganti `EventArgs`
  - contoh: `EventHandler<MyEventArgs>`
- contoh
  ```csharp
  public class MyClass
  {
    public EventHandler<MyEventArgs> MyEvent;

    public void MyMethod()
    {
      MyEvent?.Invoke(this, new MyEventArgs());
    }
  }

  public class MyEventArgs : EventArgs
  {
    public string Message { get; set; }
  }

  public class Program
  {
    public static void Main()
    {
      MyClass myClass = new MyClass();
      myClass.MyEvent += MyMethod;
      myClass.MyMethod();
    }

    public static void MyMethod(object sender, MyEventArgs e)
    {
      Console.WriteLine(e.Message);
    }
  }
  ```

## Action
- Action adalah delegate yang sudah disediakan oleh .NET
- Action bisa digunakan untuk menggantikan delegate yang tidak memiliki return value
- Action bisa digunakan untuk menggantikan delegate yang memiliki parameter
- Return value harus void
- Parameter bisa 0, 1, 2, 3, sampai 16
- Action biasa dipakai untuk mengirimkan data nya saja, tanpa mengirim object yang mengirim event
- contoh
  ```csharp
  public class MyClass
  {
    public Action<string> MyEvent;

    public void MyMethod()
    {
      MyEvent?.Invoke("Hello World");
    }
  }

  public class Program
  {
    public static void Main()
    {
      MyClass myClass = new MyClass();
      myClass.MyEvent += MyMethod;
      myClass.MyMethod();
    }

    public static void MyMethod(string message)
    {
      Console.WriteLine(message);
    }
  }
  ```
