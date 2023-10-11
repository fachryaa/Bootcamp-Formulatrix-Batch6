# Day03

## OOP
- Inheritance
- Encapsulation
- Polymorphism

### Encapsulation - Access Modifier (AM)
1. public
- forbidden, have to create getter method
2. private
- menambahkan awalan _ dan camelCase, contoh `_catAge`
3. protected
- hanya bisa digunakan di child class dan class itu sendiri
4. internal
- default class

### Polymorphism
1. Overloading
- nama method sama, parameter berbeda
2. Overriding
- `virtual` keyword untuk parent class
- `override` keyword untuk child class
- AM private tidak bisa di override
- `new` keyword untuk method hiding

## Others
1. Property
2. `readonly` keyword
- hanya bisa lewat constructor atau assign langsung
3. `const` keyword
- variable konstant, contoh phi
4. Default AM class adalah internal
5. Default AM method dan variable adalah private 
6. Private variable dan method di parent class tidak diturunkan di child class
