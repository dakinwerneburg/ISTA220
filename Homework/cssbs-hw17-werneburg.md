# C Sharp Homework 17

-- Dakin Werneburg   
-- MSSA Cloud Application Developer Certification   
-- 3/9/2021

---

## 1. What is a type parameter?
- A type parameter is a placeholder for a specific type and can be any legal identifier although C# convention is to use T for single items and for additional parameters prefix the with T and give meaningful names. 

## 2. What does a type parameter do?
- Type parameters remove the need for casting, improve type safety, reduce the amount of boxing required, and make it easier to create generalized classes and methods because the real type will be determined at compile time.

## 3. How many type parameters can a generic class have?
- There doesn't seem to be an upper limit on how many type parameters a generic class can have, but you are allow to have multiple type parameters.

## 4. What is the difference between a generic class and a generalized class?
- A generalized class is one that is of a supertype such as the Object class and working with derived classes, then having to do type checking before accessing them.  The compiler builds this with this data type only.  Whereas a generic class, the compiler will create the class with the specified data type that is assigned to the parameter as if it was written that way and only accepts that data type when referencing in the parameter.

## 5. What is a constraint? How do you specify a constraint?
- A constraint is a guard to limit what types can be used as arguments in the type parameter.  This is accomplished using "where T :" followed by the constraints such as base class or interface. 

## 6. What is a generic method? How do you define a generic method?
- A generic method is a method that takes type parameters for its parameters and/or the return type.  You define generic methods by using the same type parameter syntax you use when you create generic classes. 

## 7. What do we mean when we say that a generic type interface is invariant?
- Means that you can use only the type originally specified. An invariant generic type parameter is neither covariant nor contravariant. The type parameters must match exactly,

## 8. What do we mean when we cay that a generic type interface is covariant?
- Means the generic type can use a more derived type than originally specified.

## 9. Does covariance work with value types? Does it work with reference types?
- covariance works only with reference types. This is because value types cannot form inheritance hierarchies.

## 10. What do we mean when we cay that a generic type interface is contravariant?
- Means the generic type can use a more generic (less derived) type than originally specified.