# Day17

## Materi
1. [File Handling](#file-handling)

## File Handling
- File handling adalah proses untuk melakukan operasi pada file, seperti membaca, menulis, menghapus, dan lain-lain.
- Untuk melakukan operasi pada file, kita perlu membuka file terlebih dahulu.
- Mengakses file memerlukan path dari file tersebut.
- Jenis path
    - Relative path
        - Path yang dihitung dari direktori kerja saat ini.
        - Contoh: `./Day17/Readme.md`
        - Biasa digunakan ketika ingin mengakses konfigurasi file
    - Absolute path
        - Path yang dihitung dari root direktori.
        - Contoh: `C:/Users/ASUS/Documents/Day17/Readme.md`
        - Biasa digunakan ketika ingin mengakses file yang berada di luar direktori kerja saat ini.
- Dalam file handling ada 2 class yang digunakan
    - FileStream
    - File

### FileStream
- Secara performance lebih cepat
- Bersifat streaming
- Membaca dan Menulis data menggunakan byte, ie. `byte[]`
- Bisa menggunakan Stream Reader dan Stream Writer untuk membaca dan menulis data menggunakan string, 
- Contoh
    ```csharp
    FileStream fs = new FileStream("path", FileMode.OpenOrCreate, FileAccess.ReadWrite);
    ```
- Parameter
    - Path, path dari file yang akan diakses
    - FileMode, mode akses file
        - Append, menambahkan data ke akhir file
        - Create, membuat file baru
        - CreateNew, membuat file baru, jika file sudah ada akan menghasilkan error
        - Open, membuka file
        - OpenOrCreate, membuka file, jika file tidak ada akan membuat file baru
        - Truncate, membuka file, jika file tidak ada akan menghasilkan error
    - FileAccess, hak akses file
        - Read, hak akses hanya untuk membaca
        - ReadWrite, hak akses untuk membaca dan menulis
        - Write, hak akses hanya untuk menulis
    - (optional) FileShare, hak akses file untuk aplikasi lain
        - None, tidak ada aplikasi lain yang bisa mengakses file
        - Read, aplikasi lain bisa membaca file
        - ReadWrite, aplikasi lain bisa membaca dan menulis file
        - Write, aplikasi lain bisa menulis file
        - Delete, aplikasi lain bisa menghapus file
        - Inheritable, aplikasi lain bisa mengakses file dengan hak akses yang sama