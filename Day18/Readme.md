# Day18

## Materi
1. [Serialization](#serialization)

## Serialization
- Serialize
    - adalah proses mengubah objek menjadi bentuk yang dapat disimpan, seperti JSON atau XML
- Deserialize
    - adalah proses mengubah data yang telah diserialize menjadi objek kembali
- Format
    - JSON, hanya bisa untuk property dan public
    - XML, bisa untuk semua variable
- Library
    - DataContractJsonSerializer -> JSON
    - XmlSerializer -> XML
    - ProtoBuf -> Binary
- Menambahkan attribute `[DataContract]` pada class
- Menambahkan attribute `[DataMember]` pada variable
    - bisa untuk semua field
    - jika tidak ditambahkan maka variable tidak akan diserialize