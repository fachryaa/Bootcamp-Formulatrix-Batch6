# Day12

## Materi
1. Garbage Collection
1. Garbage Collector
1. Managed and Unmanaged Memory

## Garbage Collection
- Garbage Collection adalah proses penghapusan objek yang tidak terpakai lagi pada memory
- Garbage Collection akan menghapus objek yang tidak terpakai lagi pada memory
- Tool : dotMemory
    - dotMemory adalah tool untuk memantau memory pada aplikasi .NET
- Cara kerja Garbage Collection
    - Garbage Collection akan menghapus objek yang tidak terpakai lagi pada memory
    - Garbage Collection akan menghapus objek yang tidak memiliki referensi
    - Garbage Collection akan menghapus objek yang tidak memiliki referensi yang aktif
    - Garbage Collection akan menghapus objek yang tidak memiliki referensi yang aktif dan tidak memiliki referensi yang aktif

## Garbage Collector
- Garbage Collector memiliki 3 fungsi :
    - Marking, Garbage Collector akan menandai objek yang masih alive atau aktif
    - Sweeping, Garbage Collector akan menghapus objek yang tidak terpakai lagi
    - Compacting, Garbage Collector akan menggeser objek yang masih aktif ke memory yang kosong
- Compacting berfungsi agar tidak terjadi memory fragmentation
- Memory Fragmentation adalah kondisi dimana memory yang kosong terpisah-pisah
- Memory Fragmentation dapat menyebabkan memory tidak dapat digunakan secara maksimal
- Gen0, Gen1, Gen2 adalah generasi pada Garbage Collector
- Object baru akan masuk ke Gen0
- Jika Gen0 penuh, maka akan dilakukan proses Garbage Collection
- Object yang masih aktif akan dipindahkan ke Gen1
- Jika Gen1 penuh, maka akan dilakukan proses Garbage Collection
- Object yang masih aktif akan dipindahkan ke Gen2

## Managed and Unmanaged Memory
- Managed Memory adalah memory yang dikelola oleh Garbage Collector
- Unmanaged Memory adalah memory yang tidak dikelola oleh Garbage Collector
- Unmanaged Memory adalah memory yang dikelola oleh programmer
- Unmanaged Memory harus dihapus oleh programmer
- Unmanaged Memory dapat menyebabkan memory leak
- Contoh dari Unmanaged Memory adalah :
    - File
    - Database
    - API
    - HTTP Request
    - dll

