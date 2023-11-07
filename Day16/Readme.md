# Day16

## Materi
1. Conditional Compilation
1. Debugging
1. Basic Logging

## Conditional Compilation
- Diguakan untuk mengkompilasi kode berdasarkan kondisi tertentu
- Contoh kondisinya ketika kita ingin mengkompilasi kode untuk development dan production
- Di c# kita bisa menggunakan `#define` untuk mendefinisikan kondisi
- Bisa juga mengatur di csproj
- Default kondisi yang ada di c# adalah `DEBUG` dan `TRACE`
- case sensitive
- 3 cara menggunakan coditional compilation
    - `#define` 
    - .csproj
    - Command line, `dotnet build -c DEBUG`
- Contoh
    ```csharp
    #define DEBUG
    #define MYTEST
    #define RELEASE
    using System;
    public class TestClass 
    {
        static void Main() 
        {
            #if (DEBUG && !MYTEST)
                Console.WriteLine("DEBUG is defined");
            #elif (!DEBUG && MYTEST)
                Console.WriteLine("MYTEST is defined");
            #elif (DEBUG && MYTEST)
                Console.WriteLine("DEBUG and MYTEST are defined");
            #else
                Console.WriteLine("DEBUG and MYTEST are not defined");
            #endif
        }
    }
    ```

## Debugging
- Debugging adalah proses untuk menemukan bug di aplikasi
- Terdapat 2 error di aplikasi
    - Compile time error
    - Logic error
- Logic error yang susah ditemukan
- Untuk menemukan logic error kita bisa menggunakan debugger
- Debug tool : breakpoint
- Breakpoint adalah titik dimana kita bisa melihat nilai dari variabel
- Breakpoint bisa diatur di baris kode
- Tool :
    - continue : melanjutkan eksekusi program
    - step over : melanjutkan eksekusi program dan tidak masuk ke dalam method
    - step into : melanjutkan eksekusi program dan masuk ke dalam method
    - step out : keluar dari method
    - stop debugging : menghentikan debugging
    - restart : restart debugging

## Basic Logging
- Logging adalah proses untuk mencatat informasi yang terjadi di aplikasi
- Logging bisa digunakan untuk mengetahui apa yang terjadi di aplikasi
- Terdapat 6 level logging
    - Trace
    - Debug
    - Information
    - Warning
    - Error
    - Critical
- For development, kita bisa menggunakan level `Debug` dan `Trace`
- `using System.Diagnostics;`
- 3rd party untuk logging di NuGet
    - Serilog
    - NLog
    - Log4Net

