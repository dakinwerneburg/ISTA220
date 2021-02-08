# C# Programming Homework 08

---
Dakin T. Werneburg  
2/3/2021

----

1. What is the difference between deep copy and shallow copy?
- **Deep Copy, is coping actual values of a refernece type for every field and method.  Shallow Copy only copies the refernce**


2. What is the value of a reference after you declare and initialize it?
- **NULL**

3. How do you declare a value type?
- ** data type, followed by name, equal sign, then value to be assigned that is not of nullable.**


4. How do you declare a reference type?
- ** data type, followed by name, equal sign, then value to be assigned that is of nulluable.**


5. Does C# allow you to assign NULL to a value type?
- **Yes if you use a put  a question mark after the value type to indicate that the value type is a nullable**

6. Can you assign a nullable value type to a non-nullable variable of the same type? Why or why not?
- **No. Because the are incompatible value types and will throw a compiler error.**

7. What is the difference between the stack and the heap?
- **Heap is a pool of memory assigned by the operating system for C#.  It stores refernece types, dynamically allocates memory and has a indetermine lifespan.  Where as stack is allocated from the heap, is short lived or is released back to the heap once the method is complete.*

8. What does it mean when we say that all classes are specialized types?
- **It means that they are all derived from System.Object type**

9. What does ref do?
- **Instead a new variable being creating in the parameter it will reference the caller's argument variable**

10. What does out do?
- **"Out does the same thing as ref does which refernces the value of the parameter as the same value as the caller's value but with out, you don't need to initialize it, it must be initialized before the end of the method.**

11. Describe boxing and unboxing in your own words.
- **Boxing is the copying of value in the stack to the heap and Unboxing is the reverse.** 


12. What does cast do?
- **Checks whether converting an item of one type to another is safe before actually assigning a value.  To obtained a boxed copy, you must use what is known as a cast.**