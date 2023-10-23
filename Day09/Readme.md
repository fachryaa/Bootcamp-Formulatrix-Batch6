# Day09

## Materi
1. [Enumerable](#enumerable)
1. [Enumerator](#enumerator)
1. [Equality Comparisons](#equality-comparisons)
1. [Partial Class](#partial-class)

## Enumerable
- Enumerable adalah interface yang digunakan untuk mengakses data secara berurutan
- Enumerable memiliki method :
  - `GetEnumerator()` : Mengembalikan enumerator
  - `OfType<T>()` : Mengembalikan IEnumerable yang berisi elemen yang memiliki tipe T
  - `Reverse()` : Mengembalikan IEnumerable yang berisi elemen yang diurutkan secara terbalik
  - `Where()` : Mengembalikan IEnumerable yang berisi elemen yang memenuhi kondisi
  - `Select()` : Mengembalikan IEnumerable yang berisi hasil transformasi dari elemen
  - `SelectMany()` : Mengembalikan IEnumerable yang berisi hasil transformasi dari elemen yang memiliki IEnumerable
  - `OrderBy()` : Mengembalikan IEnumerable yang berisi elemen yang diurutkan berdasarkan kondisi
  - `OrderByDescending()` : Mengembalikan IEnumerable yang berisi elemen yang diurutkan secara terbalik berdasarkan kondisi
  - ... dan masih banyak lagi

## Enumerator
- Enumerator adalah interface yang digunakan untuk mengakses data secara berurutan
- Enumerator memiliki method :
  - `Current` : Mengembalikan elemen saat ini
  - `MoveNext()` : Memindahkan enumerator ke elemen berikutnya
  - `Reset()` : Memindahkan enumerator ke elemen pertama

## Equality Comparisons
- Equality Comparisons adalah operator yang digunakan untuk membandingkan kesamaan antara dua objek
- Equality Comparisons memiliki operator :
  - `==` : Membandingkan kesamaan antara dua objek
  - `!=` : Membandingkan ketidaksamaan antara dua objek
- Equality Comparisons memiliki method :
    - `Equals()` : Membandingkan kesamaan antara dua objek
    - `ReferenceEquals()` : Membandingkan kesamaan antara dua objek

## Partial Class
- Partial Class adalah class yang terdiri dari beberapa file
- Partial Class digunakan untuk memisahkan implementasi class yang besar

## Others
1. is
    - `is` digunakan untuk mengecek apakah sebuah objek merupakan instance dari sebuah class
    - Contoh :
        ```csharp
        if (obj is string) {
        // do something
        }
        ```
1. as
    - `as` digunakan untuk mengkonversi tipe data
    - Contoh :
        ```csharp
        string str = obj as string;
        if (str != null) {
        // do something
        }
        ```