# Day20

## Materi
1. Unit Test

## Unit Test
- Unit test adalah sebuah metode pengujian perangkat lunak dimana fungsi-fungsi individual dari program diuji. Unit test biasanya ditulis dan dijalankan oleh para pengembang perangkat lunak untuk memastikan bahwa unit atau bagian kecil dari program berjalan dengan baik.
- Tool : nUnit dan xUnit
- Proses Unit Test
    - Arrange : Menyiapkan objek yang akan diuji
    - Act : Melakukan aksi terhadap objek yang akan diuji
    - Assert : Memverifikasi hasil dari aksi yang dilakukan
- Attribute yang dipakai
    - nUnit :
        - [SetUp] - Menandakan bahwa method tersebut akan dijalankan sebelum unit test dijalankan
        - [OneTimeSetUp] - Menandakan bahwa method tersebut akan dijalankan sebelum semua unit test dijalankan
        - [Test] - Menandakan bahwa method tersebut adalah unit test
        - [TestCase] - Menandakan bahwa method tersebut adalah unit test dan dapat menerima parameter, contoh : [TestCase(1, 2, 3)]
    - xUnit :
        - [Fact] - Menandakan bahwa method tersebut adalah unit test
        - [Theory], [InlineData] - Menandakan bahwa method tersebut adalah unit test dan dapat menerima parameter, contoh : [Theory] [InlineData(1, 2, 3)]
- Naming Convention
    - nUnit : [MethodName]_[Scenario]_[ExpectedBehavior]
    - xUnit : [MethodName]_[Scenario]_[ExpectedBehavior]
- Contoh
    - nUnit
    ```csharp
    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }
    [Test]
    public void Test1()
    {
        // Arrange
        int a = 1;
        int b = 2;
        int expected = 3;

        // Act
        var actual = _calculator.Add(a, b);

        // Assert
        Assert.Equal(expected, actual);
    }
    ```