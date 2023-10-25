# Day05

## Types
1. [Value Type](#value-type)
1. [Reference Type](#reference-type)
1. [var](#var)
1. [object](#object)
1. [dynamic](#dynamic)
1. [generic](#generic)
1. [generic constraint](#generic-constraint)
1. [operator overloading](#operator-overloading)

### Value Type
- data type :
    - short
    - long
    - float
    - decimal
    - double
    - bool
    - int
    - struct
- data akan masuk di stack memory
- ada 2 jenis
    - primitive : data yang sudah ditentukan oleh bahasa pemrograman
    - user defined : data yang dibuat oleh user



### Reference Type
- data type :
    - string
    - class
    - array
    - list
    - dictionary
- data akan masuk di heap memory
- ada 2 jenis
    - mutable : data di memori bisa dirubah
    - immutable : data di memori tidak bisa dirubah, sehingga harus membuat data baru
- string termasuk immutable, dia akan membuat data baru di memori jika datanya berubah. Oleh karena itu akan memakan waktu compile
- waktu compile lama karena terdapat Garbage Collector, data yang lama akan dihapus dari memori
- StringBuilder merupakan jenis string yang mutable
- untuk string manipulation disarankan menggunakan StringBuilder karena akan jauh lebih cepat jika dibandingkan dengan string
- jika ingin membuat string yang immutable, maka harus menggunakan `string` keyword
- jika ingin membuat string yang mutable, maka harus menggunakan `StringBuilder` keyword
- jika ingin membuat string yang mutable, namun tidak ingin menggunakan `StringBuilder` keyword, maka harus menggunakan `char[]` keyword

### var
- mengikuti nilai yang di assign di variable
- setelah di assign, tidak bisa ganti tipe data
- tidak bisa digunakan di parameter method
- contoh : `var name = "John";`

### object
- sama seperti var, namun bisa ganti tipe data
- namun harus di konversi dulu (boxing dan unboxing)
- contoh :
    ```csharp
    object name = "John";
    name = 10;
    ```

### generic
- keyword `<T>`, ie : `class Item<T>`
- digunakan untuk membuat class yang bisa menerima tipe data apapun
- jika ingin membuat generic method, maka harus membuat generic class terlebih dahulu

### generic constraint
- digunakan untuk membatasi tipe data yang bisa digunakan di generic class
- ie : `class Item<T> where T : class`
- ada beberapa constraint
    - class : hanya bisa menggunakan class
    - struct : hanya bisa menggunakan struct
    - new() : hanya bisa menggunakan class yang memiliki constructor default
    - class1, class2 : hanya bisa menggunakan class1 atau class2
    - class1, struct : hanya bisa menggunakan class1 atau struct
    - class1, struct, new() : hanya bisa menggunakan class1 atau struct yang memiliki constructor default
- jika ingin membuat generic constraint, maka harus membuat generic class terlebih dahulu

### others
- class stopwatch untuk melihat running time. using System.Diagnostic;
- object biasa digunakan untuk return value
- object -> int dinamakan boxing
- int -> object dinamakan unboxing