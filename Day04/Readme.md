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
2. Interface
    1. Naming Interface : `IContract` `IUserRequest`
    1. fully method, tidak ada variable
    1. semuanya public, tidak ada Access Modifier 
    1. harus mengimplementasi semua member interface
    1. jika terdapat banyak interface, bisa di simplified dengan mengumpulkan semua Interface, `public interface IContract : IContrac1, IContrac1, IContrac3`
### Kapan menggunakan abstract dan interface
1. abstract
    - ketika terdapat default implementation dari method
2. Interface
    - ketika semuanya method dan tidak ada variable

### Others
1. Casting
    - upcasting : casting/mengubah data yang lebih kecil ke yang lebih besar, ie (int) -> (double)
    - downcasting : casting/mengubah data yang lebih besar ke yang lebih kecil, ie (double) -> (int)
2. Floating Point hanya terjadi di type data double