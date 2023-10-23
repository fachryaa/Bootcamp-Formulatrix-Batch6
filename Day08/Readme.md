# Day08

## Contents
1. [Func](#func)
1. [Exception](#exception)
1. [Extension Method](#extension-method)
1. [Params](#params)
1. [Anonymous Delegate](#anonymous-delegate)
1. [Enum](#enum)

## Func
- Func adalah delegate yang sudah disediakan oleh .NET
- Func bisa digunakan untuk menggantikan delegate yang memiliki return value
- Func bisa digunakan untuk menggantikan delegate yang memiliki parameter
- Return value harus ada
- Parameter bisa 0, 1, 2, 3, sampai 16
- Generic terakhir merupakan return value
- contoh: `Func<int, int, int>` artinya delegate memiliki 2 parameter bertipe `int` dan return value bertipe `int`

## Exception
- Exception adalah error yang terjadi saat program dijalankan
- Exception bisa terjadi karena kesalahan programmer, kesalahan user, atau kesalahan sistem
- Exception bisa dihandle dengan menggunakan `try-catch`
- `try` digunakan untuk menandai blok kode yang mungkin terjadi exception
- `catch` digunakan untuk menangkap exception
- `finally` digunakan untuk menandai blok kode yang akan dijalankan setelah `try` atau `catch` selesai dijalankan

## Extension Method
- Extension method adalah method yang bisa ditambahkan ke class yang sudah ada
- Extension method harus berada di dalam class static
- Extension method harus berada di dalam namespace yang sama dengan class yang akan ditambahkan method nya
- Extension method harus memiliki parameter pertama dengan keyword `this` dan bertipe class yang akan ditambahkan method nya
- Extension method bisa dipanggil seperti method biasa
- Extension method bisa dipanggil dengan menggunakan method chaining
- contoh
    ```csharp
    public static class MyExtension
    {
        public static void Cetak(this string str)
        {
            Console.WriteLine(str);
        }
    }
    ```

## Params
- Params digunakan untuk membuat method yang bisa menerima parameter sebanyak apapun
- Params harus berada di parameter terakhir
- Params harus bertipe array
- Params bisa diisi dengan 0, 1, 2, 3, sampai N parameter
- Params bisa diisi dengan array
- Params bisa diisi dengan array dan parameter
- contoh
    ```csharp
    public static void Cetak(params string[] strs)
    {
        foreach (var str in strs)
        {
            Console.WriteLine(str);
        }
    }
    ```
- usage
    ```csharp
    Cetak("Hello", "World");
    Cetak(new string[] { "Hello", "World" });
    ```

## Anonymous Delegate (Lambda Expression)
- Digunakan untuk mempersingkat penulisan delegate
- Digunakan untuk membuat delegate tanpa harus membuat method terlebih dahulu
- Contoh
  ```csharp
    // (parameter) => return value
    Func<int, int, int> add = (a, b) => a + b;

    // or
    var add = (a, b) => a + b;
  ```

## Enum
- Enum adalah tipe data yang berisi kumpulan konstanta
- Enum bisa digunakan untuk membuat konstanta yang berurutan
- Enum bisa digunakan untuk membuat konstanta yang berisi pilihan
- Contoh untuk membuat pesan status
    ```csharp
    public enum Status
    {
        Success,
        Error,
        Warning
    }
    ```
- Bisa juga ditambahkan nilai
    ```csharp
    public enum HTTPStatus
    {
        OK = 200,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500
    }
    ```
- Contoh penggunaan
    ```csharp
    var status = Status.Success;
    var httpStatus = HTTPStatus.OK;
    ```
- Contoh penggunaan dengan casting
    ```csharp
    var status = (Status)1;
    var httpStatus = (HTTPStatus)200;
    ```