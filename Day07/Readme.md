# Day07

## Contents
1. [Event](#event)
1. [EventHandler](#eventhandler)
1. [Action](#action)

## Event
- Event digunakan untuk mengamankan delegate
- jika delegate menggunakan event, maka hanya bisa menggunakan operator `+=` dan `-=` untuk menambahkan dan mengurangi delegate
- tidak bisa menggunakan `=` untuk mengganti delegate

## EventHandler
- EventHandler adalah delegate yang sudah disediakan oleh .NET
- EventHandler memiliki 2 parameter, yaitu `object sender` dan `EventArgs e`
- `object sender` adalah object yang mengirim event
- `EventArgs e` adalah data yang dikirim oleh object
- `EventArgs` adalah class yang sudah disediakan oleh .NET
- `EventArgs` tidak memiliki data, hanya berisi method kosong
- jika ingin mengirim data, bisa menggunakan class turunan dari `EventArgs`
  - contoh: `class MyEventArgs : EventArgs`
- generic delegate `EventHandler<T>` bisa digunakan untuk mengganti `EventArgs`
  - contoh: `EventHandler<MyEventArgs>`

## Action
- Action adalah delegate yang sudah disediakan oleh .NET
- Action bisa digunakan untuk menggantikan delegate yang tidak memiliki return value
- Action bisa digunakan untuk menggantikan delegate yang memiliki parameter
