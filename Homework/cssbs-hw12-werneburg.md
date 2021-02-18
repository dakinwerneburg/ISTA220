# C# Programming Homework 12

---
Dakin T. Werneburg  
2/17/2021

----

1. How does inheritance promote the principle of don’t repeat yourself (DRY)?
- **Inheritance allows us use code that is very similar in structure because they share similar properties and methods and differ implementation.**

2. What is the syntax of a derived class that inherits from a base class?

```c#
     class DerivedClass : BaseClass
	 {    
	 ...
	 }

```


3. Do all user defined types (classes and structs) inherit from some base class? If so, what is it?
- **Yes.  Everthing is a derived class from Object Class**


4. What happens if you do not have a default constructor in a base class when creating a derived class?
- **One will automatically be created for you as long as you have defined one**


5. Can you assign a variable of a derived class to another variable of its base class? Why or why not?
- **Yes, becaue the base derived class has at minimum all the properties and methods that are apart of the base class**


6. Can you assign a variable of a derived class to another variable of of a derived class of its base class? Why or why not?
- **Yes as long as you type check using the AS or IS operator becuase there each derived class contains the properties and methods of the base, but could have added additional properties or methods or implementation is different causing different results.**


7. Can you assign a variable of a base class to another variable of a derived class? Why or why not?
- **No. Becasue the derived classs may have extra information that doesn't exist in the base class**


8. Under what circumstances would you want to use the new keyword when defining a method in a derived class?
- **You would use the new keyword when you want to hide the base class method if you reference the base classs object.**


9. What is a virtual method? Why would you want to define a virtual method?
- **A virtual method is a method that allows the derived class to override the base class method using the virutal keyword in the base class.  It pretty much gives modify permisions to any class that inheritance from it.**


10. What does override do? Why does it do it?
- **Override provides polymorphism which means that a derived class can provide their own implementation of the method that has the same signiture of the base, and at compile time will it take on a different behavior.**


11. How do you define an extension type?
- **You define an extension method in a static class and specify the type to which the method applies as the first parameter to the method, along with the this keyword.**


12. Why do you define an extension type?
- **When you need to add functionality statically without redefining a new derived type**


13. (Not in book) Explain the Liskov substitution principle.
 - **The Liskov Substitution Principle in practical software development. The principle defines that objects of a superclass shall be replaceable with objects of its subclasses without breaking the application. That requires the objects of your subclasses to behave in the same way as the objects of your superclass**
 
 OR 
 
 "IF IT LOOKS LIKE A DUCT, QUACKS LIKE A DUCK, BUT NEEDS BATTERIES - YOU PROBABLY HAVE THE WRONG ABSTRACTION"