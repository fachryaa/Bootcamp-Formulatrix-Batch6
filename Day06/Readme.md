# Day06

## Materi
1. Ref, In, Out
1. Static
1. Delegate

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
- fungsi :
  - sebagai publisher dan subscriber
  - sebagai callback method
- return type dan parameter harus sama
  - Create Delegate
  - add method
  - invoke