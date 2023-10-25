# Day 04

## OOP
    1. Abstraction


### Abstraction
1. abstract
    1. ada 2 absta
    1. keyword `abstract`, ie: `abstract class Parent {}`
    1. Wajib menggunakan `abstract` jika terdapat method abstract
    1. Method abstract merupakan method yang tidak ada implementasi nya, `public abstract void MyMethod();`
    1. `abstract` tidak bisa dibuat object
    1. `abstract` harus diimplementasi di child class, `public override void MyMethod() { }`
    1. `abstract` bisa di override di child class
    1. contoh
        ```csharp
        public abstract class Parent
        {
            public abstract void MyMethod();
        }

        public class Child : Parent
        {
            public override void MyMethod()
            {
                Console.WriteLine("Hello World");
            }
        }
        ```
2. Interface
    1. Naming Interface : `IContract` `IUserRequest`
    1. fully method, tidak ada variable
    1. semuanya public, tidak ada Access Modifier 
    1. harus mengimplementasi semua member interface
    1. jika terdapat banyak interface, bisa di simplified dengan mengumpulkan semua Interface, `public interface IContract : IContrac1, IContrac1, IContrac3`
    1. contoh
        ```csharp
        public interface IContract
        {
            void MyMethod();
        }
        public class MyClass : IContract
        {
            public void MyMethod()
            {
                Console.WriteLine("Hello World");
            }
        }
        ```
3. Interface vs Abstract (table)
### Interface vs Abstract (table)

| Interface | Abstract |
| --- | --- |
| Semua method | Bisa memiliki method dengan implementasi default |
| Tidak memiliki implementasi | Bisa memiliki implementasi method |
| Semua public | Bisa memiliki access modifier |
| Tidak bisa memiliki variable | Bisa memiliki variable |
| Harus diimplementasi semua member interface | harus diimplementasi method abstract |

### Kapan menggunakan abstract dan interface
1. Interface
    1. jika ingin membuat contract
    1. jika ingin membuat library
    1. jika ingin membuat plugin
    1. jika ingin membuat framework
1. Abstract
    1. jika ingin membuat base class
    1. jika ingin membuat class yang memiliki implementasi default
    1. jika ingin membuat class yang memiliki variable
    1. jika ingin membuat class yang memiliki method abstract

### Others
1. Casting
    - upcasting : casting/mengubah data yang lebih kecil ke yang lebih besar, ie (int) -> (double)
    - downcasting : casting/mengubah data yang lebih besar ke yang lebih kecil, ie (double) -> (int)
2. Floating Point hanya terjadi di type data double
