# C# Programming Homework 03

---
Dakin T. Werneburg
1/20/2021

---

1. What is a method?
    - **Method is function associated with a class.  It is a body of code that is surrounded in curly braces, with a sequence of statements, that are executed when the method is called, and may or may not return a value.  Primarily used to abstract and reuse the code rather that typing duplicate code.**

	"Named Block of Code that optionaly accepts input and output"

    
2. (Not in book) What is the difference between a function and a procedure/subprocedure/subroutine?
    - **A function takes in input, performs some calculation, and returns a value; whereas procedure/subprocedure/subroutine is a set of commands that are executed in order that doesn't return a value.  A function is a type of procedure but a procedure is not a function.** 

3. What does a return statement do?
    - **Return statement completes the execution of the method code block, which may or may not return a value, and reallocates memory back to the heap.** 

4. What is an expression bodied method?
    -**Expression bodied method is a concise method that is comprised of a single expression, that can still take parameters and return values, but instead of curly braces has an arrow directing it to the expression.  The value of the expression is used as the return value**

5. What is the scope of a variable?
    - **The scope of a variable is defined by the type of scope such as block scope, method scope, or class close; and provides access or visibility to the variable.**  

6. What is a field?
    - **A field is a variable defined within a class that maintains state of the object, whereas as methods do something.**

7. What is an overloaded method?
    -**An overloaded method is a method that has the same name but can differ by the number of parameters and or the type of parameters; and is resolved at compile time.
    > **myMethodName(int n)**
    > **myMethod(double n)**

8. How do you call a method that requires arguments?
    -**To call a method, an object must be instantiated or declared as static, in which case you call the access modifier for the object, followed by the method with the signature you want and then within parenthesis you add the actual values based on the number of arguments and the data type, in the order they are defined**
    
    > *method signature for myClass:* 			**myMethodName(int n)**
    > **myMethodName(5);**
    
9. How do you write a method, that is, specify the method definition, that requires a parameter list?
    - **To write a method you state the access level and or Optional modifiers, then the return type, followed by the name of the method and within parentheses state 0 or more parameters and thier type**
    > **private int myMethodName(String s, int n){}**

10. How do you specify a parameter as optional when defining a method?
    - **You specify a parameter as optional by defining it at the end of the parameter list, if any, and declare a variable with a default value.
    > **void myMethodName(int n, String default = "default"){}**

11. How do you pass a argument to a method as a named parameter?
    - **To pass an argument as a named parameter, you specify the name of the parameter, followed by a colon and the value to use**

12. How do you return values from a method? Can you return multiple values from a method, and if so, how?
    - **You return values from a method from the return statement.  You can return multiple values by returning a tuple.**
    >  **return(val1, val2);**

13. What is a tuple? How do you define a method that returns multiple values? Give an example of a method that returns multiple values other than the example in the book.
    - **A tuple is a small collection of values with 2 or more values with parenthesis separated by comma.**
    
    > **return("Something",5);**
    
    
14. Examine the method definition on page 83 of the book. Desk check the execution of this method. What do you discover? This is called recursion.

```cs
    long factorial( int dataValue )
    {
    if( dataValue == 1 ) return 1;
    else return dataValue * factorial( dataValue  - 1 );
    }
```  
    - **A string is parsed to an int and then passed to the factorial function.  It has a base case of 1 and decrements down by 1 each iteration and then for each return back to the caller it will multiply the value. so if the string literal "5" it will return 5\*4\*3\*2\*1 or 120 as a long data type.**

    
15. How does the compiler resolve an ambiguity between named arguments and optional parameters?
    - **The compiler will pick the one where the caller has specified all the arguments explicitly**

16. The book states: “A key feature of C# and other languages designed for the .NET Framework is the
ability to interoperate with applications and components written with other technologies.” What is
the COM and how is the CLR dependent on the COM?
    - **COM is Component Object Model which lets an object expose its functionality to other components and to host application on window platforms.  CLR is heavily dependent on COM.**

