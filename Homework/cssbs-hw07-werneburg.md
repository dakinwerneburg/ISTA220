# C# Programming Homework 07

---
Dakin T. Werneburg  
2/2/2021

----

1. What is a class? According to the book, what does a class “arrange?”
- **Class is the root word of the term classification. When you design a class, you systematically arrange information and behavior into a meaningful entity.**

2. What are the two purposes of encapsulation?
- **To combine methods and data within a class; in other words, to support classification**
- **To control the accessibility of the methods and data; in other words, to control the use of the class**

3. How do you instantiate an instance of a class? How do you access that instance?
- **Using the "new" keyword is how to instantiate an instance, you have access to that instance based on the access modifier assigned to the class.**
 
4. What is the default access of the fields and methods of a class? How do you change the default?
- **Private is the default and to change that you need to assign a access modifier**

5. What is the syntax for writing a constructor?
- **Use public access modifier, followed by th name of class, followed by open and closing parenthesis, and 0 or more parameters, then open and closing curly braces**

6. What is the difference between class fields and methods, and instance fields ad methods? How do you create class fields and methods?
- **Class fields and methods are defined within a class and can be access by declaring the class static, and instance fields and methods belong to objects that have a reference to a memory location.**

7. How do you bring a static class in scope? Why would you want to bring a static class in scope?
- **Static using statements enable you to bring a class into scope.  You would want to bring a static class in scope when you only need one instance and can just reference the methods and fields without using the class name.**

 
8. Can you think of a good reason to create an anonymous class? What is it?
- **When you are implementing an interface such as an event handler or anytime that you don't plan to reuse the class.  It is a class with no reference name.**

9. What is polymorphism as this term is used in computer science? This is not in the book.
- **Polymorphism is a change in behavior at runtime.  That is achieved by the number and type of parameters in the method signature.**
  
10. What is message passing as this term is used in computer science? This is not in the book.
- **Message passing is using a return in one method as a parameter in another method**

11. What was the first object-oriented programming language?
- **Simula**
12. Consider this quote by Alexander Stepanov:
> *I find OOP technically unsound. It attempts to decompose the world in terms of interfaces that vary on a single type. To deal with the real problems you need multisorted algebras—families of interfaces that span multiple types. I find OOP philosophically unsound. It claims that everything is an object. Even if it is true it is not very interesting — saying that everything is an object is saying nothing at all.*


Who is Alexander Stephanov? What do you think about this quote?
- **He Co-Coined the term Generic Programming which rely on data types and the idea of removing redundancy in code through functions.  As a student of Object Oriented Programming languages such as C# and Java, it is difficult how to view everything that is not an object, though it appears a hybrid of functional and OOP is the new standard with recent version implementing Delegates and Lambdas** 