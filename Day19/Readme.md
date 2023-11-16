# Day19

## Materi
1. SOLID

## SOLID
- SOLID adalah prinsip yang digunakan untuk membuat kode yang baik dan mudah untuk dipelihara.
- SOLID adalah singkatan dari:
    - S: Single Responsibility Principle
    - O: Open-Closed Principle
    - L: Liskov Substitution Principle
    - I: Interface Segregation Principle
    - D: Dependency Inversion Principle

### Single Responsibility Principle
- Sebuah class harus bertanggung jawab atas satu hal, dan class tersebut harus memiliki satu alasan untuk berubah.
- Contoh:
    - Class `Person` bertanggung jawab untuk menyimpan data personal seseorang.
    - Class `Person` tidak bertanggung jawab untuk menyimpan data pekerjaan seseorang.
    - Class `Person` tidak bertanggung jawab untuk menyimpan data pendidikan seseorang.
    - Class `Person` tidak bertanggung jawab untuk menyimpan data hobi seseorang.

### Open-Closed Principle
- Sebuah class harus terbuka untuk ekstensi, namun tertutup untuk modifikasi.
- Menggunakan `abstract class` atau `interface` 
- Menggunakan overloading dan overridding 
- Menggunakan Extension method

### Liskov Substitution Principle
- Sebuah class turunan harus dapat digunakan sebagai pengganti class induknya tanpa mengubah fungsionalitas dari program tersebut.
- Contoh:
    - Class `Job` dan `Education` dapat digunakan sebagai pengganti class `Person` tanpa mengubah fungsionalitas dari program tersebut.

### Interface Segregation Principle
- Sebuah class tidak boleh dipaksa untuk mengimplementasikan interface yang tidak digunakan.
- Contoh:
    - Class `Person` tidak boleh mengimplementasikan interface `JobInterface` dan `EducationInterface`.
    - Class `Job` dan `Education` harus mengimplementasikan interface `JobInterface` dan `EducationInterface`.

### Dependency Inversion Principle
- Sebuah class tidak boleh bergantung pada class lain. Keduanya harus bergantung pada abstraksi.
- Contoh:
    - Class `Person` tidak boleh bergantung pada class `Job` dan `Education`.
    - Class `Person` harus bergantung pada interface `JobInterface` dan `EducationInterface`.
    - Class `Job` dan `Education` harus mengimplementasikan interface `JobInterface` dan `EducationInterface`.

### Refactoring
- Refactoring adalah proses mengubah kode yang sudah ada menjadi kode yang lebih baik tanpa mengubah fungsionalitas dari program tersebut.
- Refactoring dilakukan untuk mempermudah proses pengembangan dan pemeliharaan kode.
- Refactoring dilakukan setelah kode sudah diuji dan berjalan dengan baik.
- Refactoring dilakukan secara bertahap.
- Refactoring dilakukan dengan menggunakan prinsip SOLID.

