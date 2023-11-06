# Day14

## Materi
1. Multi Threading


## Multi Threading
- Multi Threading adalah sebuah konsep dimana sebuah program dapat melakukan beberapa proses secara bersamaan dalam satu waktu.
- Multi Threading dapat digunakan untuk memaksimalkan penggunaan CPU.
- Thread adalah sebuah unit kecil dari sebuah proses yang dapat dijadwalkan oleh sistem operasi.
- Thread dapat berjalan secara bersamaan dengan thread lainnya dalam satu proses yang sama.
- Thread dapat berbagi memori dan resource dengan thread lainnya dalam satu proses yang sama.
- class Thread adalah class yang digunakan untuk membuat sebuah thread.
- Membuat instance dari class Thread tidak akan membuat sebuah thread baru, untuk membuat thread baru kita harus memanggil method start() dari instance tersebut.
- contoh
    ```csharp
    Thread thread = new Thread(MyMethod);
    thread.Start();
    thread.Join();
    ```
- `Thread.sleep()` digunakan untuk memberhentikan thread sementara.
- `.Start()` digunakan untuk menjalankan thread.
- `Thread.join()` digunakan untuk memberhentikan thread sementara sampai thread yang di join selesai dijalankan.
- Sifat dari thread adalah Foreground Thread dan Background Thread.
- Foreground Thread adalah thread yang akan tetap berjalan sampai selesai meskipun aplikasi sudah ditutup.
- Background Thread adalah thread yang akan berhenti ketika aplikasi ditutup.
- Untuk membuat sebuah thread menjadi background thread kita dapat menggunakan method `.IsBackground = true` pada instance dari class Thread.
- Thread priority adalah sebuah nilai yang digunakan untuk menentukan prioritas sebuah thread.
- Thread priority memiliki nilai dari 0 sampai 4.
- Abort() digunakan untuk menghentikan sebuah thread, namun method ini sudah obsolete dan tidak disarankan untuk digunakan.


