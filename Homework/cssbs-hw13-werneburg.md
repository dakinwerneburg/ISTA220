# C Sharp Homework 13

-- Dakin Werneburg   
-- MSSA Cloud Application Developer Certification   
-- 2/21/2021

---

## 1. What is an interface as the term is used on object-oriented programming?
- An interface is a contract between a class that extends or implements the interface and the interface.  An interface does not provide any implementation detail just a blue print as to what needs to be present if used.

## 2. How do you define an interface?
- Just like defining a class but replace the keyword "class" with the keyword "interface", the name of the interface and normal naming convention is to use a Capitol "I" as the first character in the name.

## 3. Can an interface have variables, fields, or properties?
- Interfaces cannot have field or variables, but can have properties as long as they are not assigned any value.  Because a property is just two types of methods.

## 4. How do you define a method in an interface?
- Methods must public and have no method body.  So it is public followed by return type or void, the name of the method, any parameters if any, and then a semicolon.

## 5. Can you instantiate an object through an interface? Why or why not?  
- A interface cannot be instantiated but you could use an interface as the data type and instantiate an object that implements the interface and assign it to the interface.

## 6. Using the new keyword, can you declare a reference to an interface?
- No. Because a interface cannot be instantiated as there is no implementation in an interface.

## 7. Can an object inherit from multiple interfaces? Can a class implement multiple interfaces? If so, how can it do so?
- Yes.  That's the true power of interfaces is the ability to inherit from multiple classes where you can only inherit from one base class.  If there is two interfaces with the same name, it will compile but it is up to the user to explicitly state which interface it is referring to.

## 8. What does it mean to explicitly implement an interface?
- To explicitly implement an interface is to precede an implemented method with the name of the interface it is referring to.

## 9. What are the restrictions on interfaces?

> You’re not allowed to define any fields in an interface, not even static fields.
 
> You’re not allowed to define any constructors or deconstructors in an interface. 

> You cannot specify an access modifier for any method. 

> You cannot nest any types (such as enumerations, structures, classes, or interfaces) inside an interface.

 
## 10. What is the difference between an abstract class and an interface?
- An abstract class has some implementation detail whereas an interface has NO implementation detail.

## 11. What is an abstract method?
- An abstract method has the keyword "abstract" in it's signature and does not provide any method body or implementation.

## 12. What is an sealed class?
- A sealed class means that the class can no longer be inherited from other classes or that the class becomes final.

## 13. What is an sealed method?
- Seal method is like turning a method from read-write to just read.  It means that no other class can override this method and it becomes final.