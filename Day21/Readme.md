# Day21

## Materi
1. [logging](./logging)
1. [log4net](./log4net)

## logging
- Logging adalah proses pencatatan aktivitas dalam sistem atau aplikasi
- membantu dalam debugging dan pemecahan masalah dengan menyediakan detail tentang apa yang terjadi selama eksekusi aplikasi
- Logging dapat dilakukan dengan berbagai cara, seperti menulis ke file, menulis ke database, atau menulis ke layanan cloud
- Logging dapat dilakukan dengan berbagai tingkat keparahan, seperti Informasi, Peringatan, dan Kesalahan

## log4net
- log4net adalah library logging yang populer untuk aplikasi .NET
- Dapat dikonfigurasi secara dinamis menggunakan file XML atau secara programatik dalam kode.
- log4net menyediakan berbagai jenis appender, seperti ConsoleAppender, FileAppender, dan RollingFileAppender
- Appender adalah komponen yang bertanggung jawab untuk menulis log ke sumber daya seperti file, database, atau layanan cloud
    - ConsoleAppender menulis log ke konsol
    - FileAppender menulis log ke file
    - RollingFileAppender menulis log ke file dan memungkinkan untuk membatasi ukuran file log
- Contoh penggunaan ConsoleAppender
    ```xml
    <appender name="ConsoleAppender" type="log4net.Appender.ConsoleAppender">
        <layout type="log4net.Layout.PatternLayout">
            <conversionPattern value="%date [%thread] %-5level %logger - %message%newline" />
        </layout>
    </appender>
    ```
- Contoh penggunaan FileAppender
    ```xml 
    <appender name="FileAppender" type="log4net.Appender.FileAppender">
        <file value="log-file.txt" />
        <appendToFile value="true" />
        <layout type="log4net.Layout.PatternLayout">
            <conversionPattern value="%date [%thread] %-5level %logger - %message%newline" />
        </layout>
    </appender>
    ```
- Contoh penggunaan RollingFileAppender
    ```xml
    <appender name="RollingFileAppender" type="log4net.Appender.RollingFileAppender">
        <file value="log-file.txt" />
        <appendToFile value="true" />
        <rollingStyle value="Size" />
        <maxSizeRollBackups value="5" />
        <maximumFileSize value="10MB" />
        <staticLogFileName value="true" />
        <layout type="log4net.Layout.PatternLayout">
            <conversionPattern value="%date [%thread] %-5level %logger - %message%newline" />
        </layout>
    </appender>
    ```

- log4net menyediakan berbagai jenis logger, seperti Logger, RootLogger, dan LogManager
- Memiliki fitur level logging
    - All : Semua level
    - Debug : Debugging
    - Info : Informasi
    - Warn : Peringatan
    - Error : Kesalahan
    - Fatal : Fatal
    - Off : Tidak ada level
- Contoh penggunaan level logging
    ```xml
    <root>
        <level value="ALL" />
        <appender-ref ref="ConsoleAppender" />
        <appender-ref ref="FileAppender" />
        <appender-ref ref="RollingFileAppender" />
    </root>
    ```

- log4net menyediakan berbagai jenis layout, seperti PatternLayout, SimpleLayout, dan XmlLayout
- Layout digunakan untuk menentukan format log
- log4net menyediakan berbagai jenis filter, seperti DenyAllFilter, LevelMatchFilter, dan LevelRangeFilter
- Filter digunakan untuk memfilter log
    - DenyAllFilter : Menolak semua log
    - LevelMatchFilter : Memfilter log berdasarkan level
    - LevelRangeFilter : Memfilter log berdasarkan range level
- Contoh penggunaan filter
    ```xml
    <filter type="log4net.Filter.LevelRangeFilter">
        <levelMin value="INFO" />
        <levelMax value="FATAL" />
    </filter>
    ```

- log4net menyediakan berbagai jenis konfigurasi, seperti FileConfigurationAttribute, XmlConfiguratorAttribute, dan ConfiguratorAttribute
- Konfigurasi digunakan untuk mengkonfigurasi log4net
    - FileConfigurationAttribute : Mengkonfigurasi log4net menggunakan file
    - XmlConfiguratorAttribute : Mengkonfigurasi log4net menggunakan XML
    - ConfiguratorAttribute : Mengkonfigurasi log4net menggunakan kode
- Contoh penggunaan konfigurasi
    ```xml
    <assembly>
        <file name="log4net.config" />
    </assembly>
    ```