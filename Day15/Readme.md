# Day15

## Materi
1. Task
1. Async await
1. Cancelation Token

## Task
- Menanggulangi exception, namanya aggregate exception
- Bisa mengambil return value
- Terdapat cancelation token
- Default background
- Async - await
- Thread pool, dari awal program berjalan
    - multiple background Thread
- Thrad.join -> wait;
- return value Tas<int> task = Task.Run(())
- 

## Async await
- Async digunakan untuk menandakan bahwa method tersebut akan dijalankan secara asynchronous
- Await digunakan untuk menunggu method yang dijalankan secara asynchronous selesai dijalankan
- Async await digunakan untuk menggantikan Task.Run(() => { ... }) dan Task.WaitAll(...)

```csharp
public async Task<int> AddAsync(int a, int b)
{
    return await Task.Run(() => a + b);
}
```


## Cancelation Token
- CancellationTokenSource digunakan untuk mengirim sinyal cancel ke CancellationToken
- CancellationTokenSource.Cancel() digunakan untuk mengirim sinyal cancel ke CancellationToken
- CancellationToken.ThrowIfCancellationRequested() digunakan untuk melempar exception OperationCanceledException jika CancellationToken sudah di cancel
- CancellationToken.Register(Action) digunakan untuk menambahkan action yang akan dijalankan ketika CancellationToken di cancel
- CancellationToken.Register(Action) akan dijalankan di thread yang berbeda dengan thread yang menjalankan CancellationTokenSource.Cancel()
- Penggunaan
```csharp
CancellationTokenSource cts = new CancellationTokenSource();
CancellationToken ct = cts.Token;

Task.Run(() =>
{
    while (true)
    {
        if (ct.IsCancellationRequested)
        {
            Console.WriteLine("Cancelation requested");
            break;
        }
        else
        {
            Console.WriteLine("Task is running");
            Thread.Sleep(1000);
        }
    }
}, ct);

Console.WriteLine("Press any key to cancel");
Console.ReadKey();
cts.Cancel();


```