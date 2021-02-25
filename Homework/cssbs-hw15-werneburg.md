# C Sharp Homework 15

-- Dakin Werneburg   
-- MSSA Cloud Application Developer Certification   
-- 2/24/2021

---
## 1. What is the difference between a property and a field?
- A field is a variable that stores a state within a class and to maintain encapsulation it should be private.  Properties provide read, write, or read and write access to the field.  It does this using syntax sugar by using short syntax for the access methods that are normally used to access a private field.


## 2. What is the difference between a property and a method?
- Properties are meant to provide encapsulation while still being able to read and write to the data.  Because it is only a read or write it prevents side effects.  Where as methods are meant to perform a sequence of logical operations that could result in a field being modified.


## 3. What is your understanding of encapsulation?
- Encapsulation is hiding the implementation details from the end-user.  For example I don't kneed to know how Console.WriteLine() displays a message to me. I just know that I pass in a parameter in the WriteLine method, it will just print to console.

## 4. Some languages are case insensitive, that is, an `a" and an \A" are considered to be the same letter. C# is case sensitive. What implications does this have regarding the naming of variables, methods, and other identifiers? Do you think that the difference in case in the initial character of two different identifiers is sufficient to distinguish them.
- In my opinion, I do believe that having variables, methods, and other identifiers as case sensitive does have negative implications.  Case sensitive is so slight that it might be very easy to overlook while debugging.  An example of this is the properties variable using uppercase and perhaps a static field using lower case with the same name.  It might have similar syntax and would compile but they are two different variable


## 5. Give an example that is not in the book of an instance where you might want to use a read-only property. Give an example not in the book of an instance where you might want to use s write-only property.
- You would use a read-only property where it doesn't make any sense to modify the field.  For example once you set the field DOB(Date of Birth) it would not make any sense to modify it.

## 6. Can you think of a reason why you might ever want to make getters and setters private? Give an example. Also, make a case why getters and setters should never be private.
- I don't see why it would be used, but if there was one, my only guess is that you need an immutable object and the fields are only being accessed internally to assist in performing some function within a method.  But this could be done using Delegates..   

## 7. What are restrictions on the use of properties?
> Can't assign an uninitialized variable to a property.

> Can’t use "ref" or "out" when passing a property as an argument.

> Can only use one getter and one setter

> Properties can not take any parameters

> Can't declare a property as a Constant


## 8. What is an object initializer? What is the syntax for an object initializer?
- Object initializer is assigning a value to field that has a default value when construction an object and using the optional parameter to set the field.

```c#

    ...
        public static void Main(String[] args){
            Triangle triangle = new Triangle{ A = 2, B = 3, C=5 };
        }

    class Triangle
    {
        public int A {set => this.A = value;}
        public int B {set => this.A = value;}
        public int C {set => this.A = value;}
        
    }

```
	
	