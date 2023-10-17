# Day06

## Materi
1. [Ref, In, Out](#ref-out-in)
1. [Static](#static)
1. [Delegate](#delegate)

### Ref, Out, In
a. Ref
- keyword ref digunakan untuk Pass By Reference
  ```
  int a;
  multiple(ref a);

  void multiple(ref int a){}
  ```
b. Out
- pass by reference juga, tapi harus di assign di dalam method
- variable di dalam argument bisa digunakan diluar scope
  ```
  multiple(out int a);
  // a = 10

  void multiple(out int a){
    a = 10;
  }
  ```
c. In
- pass by reference juga, tapi read-only
  ```
  int a = 10;

  void multiple(in int a){
    a = 10; // error

    int b = a * 10; // OK
  }
  ```
d. Menggunakan Ref, In, Out dapat mempercepat proses komputasi karena hanya memanggil reference, dan tidak membuat data baru di memori

### Static
- penggunaan static :
  - dari class : semua methodnya harus static juga, tidak perlu buat instance baru
  - dari method  : perlu buat instance baru
- method static hanya bisa mengakses variable static, namun method non-static bisa mengakses variable static.
- method static hanya bisa dipanggil dari class nya langsung
- default Access Modifier static adalah global
- `const` termasuk static
```
void Main() {
  Calculator.Add(1,2);
  Calculator c = new();
  c.AddNonStatic(1,2);
}

class Calculator {
  static void Add(int left, int right){}
  public void AddNonStatic(int left, int right){}
}
```

### Delegate
- apa itu delegate :
  - sebuah tipe data yang bisa menyimpan method
  - bisa digunakan untuk membuat event
- kenapa menggunakan delegate :
  - untuk membuat event
  - untuk membuat callback method
- cara menggunakan delegate :
  - deklarasi delegate
    ```
    public delegate int MyDelegate(int x, int y);
    ```
  - add method
    ```
    MyDelegate myDelegate = Add;
    myDelegate += Substract;
    ```
  - invoke
    ```
    myDelegate(1,2);
    ```
    Argument yang di passing akan di passing ke semua method yang ada di delegate
- delegate bisa digunakan sebagai :
  - publisher
  - subscriber
  - callback method
- delegate harus memiliki return type dan parameter yang sama