## Day13

## Materi
1. Dispose Pattern
1. Using Statement

## Dispose Pattern
- Dispose Pattern adalah pattern dari class yang mengimplementasikan interface IDisposable
- Kode program
```csharp
public class MyClass : IDisposable
{
	private bool disposedValue;
	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				// TODO: dispose managed state (managed objects)
			}

			// TODO: free unmanaged resources (unmanaged objects) and override finalizer
			// TODO: set large fields to null
			disposedValue = true;
		}
	}

	// TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
	~MyClass()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

}
```
- variable disposedValue adalah variable untuk menandai apakah class sudah di dispose atau belum
- method Dispose(bool disposing) adalah method untuk menghapus managed dan unmanaged resource
    - jika disposing bernilai true, maka akan menghapus managed resource dan unmanaged resource
    - jika disposing bernilai false, maka akan menghapus unmanaged resource saja
- method ~MyClass() adalah finalizer
- Finalizer ini berfungsi untuk safety net jika programmer lupa memanggil method Dispose()
- Jadi ketika class ini dihapus oleh Garbage Collector, maka Garbage Collector akan memanggil method ~MyClass()
- Di dalam finalizer ini, memanggil method Dispose()
- `GC.SuppressFinalize(this)` adalah method untuk menghapus finalizer