# Day05

## Types
1. Value Type
1. Reference Type
1. var
1. object
1. dynamic
1. generic
1. generic constraint
1. operator overloading

### Value Type
- data type : short, long, float, decimal, double, bool, int, struct
- data akan masuk di stack memory


### Reference Type
- data type : string, class, array, list, dictionary
- data akan masuk di heap memory
- ada 2 jenis
    - mutable : data di memori bisa dirubah
    - immutable : data di memori tidak bisa dirubah, sehingga harus membuat data baru
- string termasuk immutable, dia akan membuat data baru di memori jika datanya berubah. Oleh karena itu akan memakan waktu compile
- waktu compile lama karena terdapat Garbage Collector, data yang lama akan dihapus dari memori
- StringBuilder merupakan jenis string yang mutable
- untuk string manipulation disarankan menggunakan StringBuilder karena akan jauh lebih cepat jika dibandingkan dengan string

### var
- mengikuti nilai yang di assign di variable
- setelah di assign, tidak bisa ganti tipe data

### object
- sama seperti var, namun bisa ganti tipe data
- namun harus di konversi dulu (boxing dan unboxing)

### generic
- keyword `<T>`, ie : `class `

### others
- class stopwatch untuk melihat running time. using System.Diagnostic;
- object biasa digunakan untuk return value
- object -> int dinamakan boxing
- int -> object dinamakan unboxing