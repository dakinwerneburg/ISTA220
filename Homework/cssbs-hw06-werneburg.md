# C# Programming Homework 06

---
Dakin T. Werneburg  
1/27/2021

----

1. What is an exception?
- **Exception is an object that is called when ever there is an error in the code, and depending on the Exception, allows you to gracefully handle what to do with that error.**  

2. What happens in a try block if the program executes without errors?
- **The Try Block is exited and program execution continues, first to the finally block if one exist and then to next line of code outside the try block**


3. How does the catch mechanism work for unhandled exceptions?
- **The exception is propagated up until it finds a caller that does handle the exception.**

4. What happens in a program if an exception block fails to handle an particular error?
- **If there is no caller that catches the exception, the program terminates.**

5. What is the parent class for all exceptions? How does this work?
- **Exception class***


6. How do you determine the type of an error?
- **You could call the method GetType() of the exception class or derived class.  You could check the InnerExcetpion property for null value.**


7. What is the purpose of integer checking?
- **To prevent integer overflow; which is when an integer is out of range and causes the value to be incorrect.**  


8. What is the range of values that a signed Int32 type can contain? State the lowest value and the highest value.
- **-2,147,483,648 to 2,147,483,647**


9. What is the range of values than an unsigned Int32 type can contain? State the lowest value and the highest value. What is the difference between a signed integer and an unsigned integer? Can signed integers and unsigned integers represent the same amount of numbers?
- **0 to 4,294,967,295**
- **UInt32 does not allow negative numbers, where Int32 can store both.  They represent the same amount of numbers but the range of values is what changes, that's why UInt32 can have larger positive values.**

10. What does the finally block do?
- **Finally block is a block of code executed after a Try block regardless if an exception was caught or not, and is usually meant to close resources.**


11. (Thought question) When would you not use a finally block in a try/catch construction? 
- **When you need to exit immediately and there are no resources to close**
