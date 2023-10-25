# Day03

## OOP
- Inheritance
- Encapsulation
- Polymorphism

### Encapsulation - Access Modifier (AM)
1. public
    - forbidden, have to create getter method
2. private
    - menambahkan awalan _ dan camelCase, contoh `_catAge`
    - hanya bisa digunakan di class yang sama
    - child class tidak bisa mengakses
3. protected
    - hanya bisa digunakan di class yang sama dan turunannya
    - tidak bisa digunakan di class lain
4. internal
    - hanya bisa digunakan di project yang sama    
5. protected internal
    - gabungan dari protected dan internal

### Polymorphism
1. Overloading
    - nama method sama, parameter berbeda
    - AM tidak boleh berbeda
2. Overriding
    - `virtual` keyword untuk parent class
    - `override` keyword untuk child class
    - AM private tidak bisa di override
    - `new` keyword untuk method hiding
        - jika tidak menggunakan `new` maka akan warning
        - jika menggunakan `new` maka akan mengabaikan method parent class
        - jika menggunakan `new` dan `virtual` maka akan warning
        - jika menggunakan `new` dan `override` maka akan error
        - contoh: `public new void Eat()`
    - `base` keyword untuk mengakses method parent class
        - contoh: `base.Eat()`


## Others
1. Property
    - `get` dan `set` method
    - `value` keyword untuk mengambil nilai dari parameter
    - contoh: `public int Age { get; set; }`
1. `readonly` keyword
    - variable hanya bisa di assign di constructor
    - contoh: `readonly int _age;`
1. `const` keyword
    - variable konstant, contoh phi
    - tidak bisa di assign di constructor
    - contoh: `const double phi = 3.14;`
1. `static` keyword
    - variable dan method yang bisa diakses tanpa membuat instance
    - contoh: `public static int Age { get; set; }`
1. `this` keyword
    - mengakses variable dan method di class yang sama
    - contoh: `this.Age = 10;`
1. `base` keyword
    - mengakses variable dan method di parent class
    - contoh: `base.Eat();`
1. Default AM class adalah internal
1. Default AM method dan variable adalah private 
1. Private variable dan method di parent class tidak diturunkan di child class
