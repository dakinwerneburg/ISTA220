# C Sharp Homework 22

-- Dakin Werneburg   
-- MSSA Cloud Application Developer Certification   
-- 3/28/2021

## 1. Explain the difference between the concepts of associativity and precedence.
- associativity is how is it read either left to right or right to left, and precedence is the ranking or priority each operator is compared to the other operators.


## 2. Explain the difference between the concepts of binary and unary operators.
- Binary operators take two operands, where unary uses just one operand.


## 3. List four constraints imposed by C# with respect to operator overloading.
- You cannot change the precedence and associativity of an operator.
- You cannot change the multiplicity (the number of operands) of an operator.
- You cannot invent new operator symbols.
- You can’t change the meaning of operators when they are applied to built-in types


## 4. What is the syntax for overloading operators? Discuss access, scope, return value types, and parameter types and multiplicity.
- method-like syntax with a return type and parameters, but the name of the method is the keyword operator together with the operator symbol you are declaring.
- access is public
- scope is static
- Example: Hour Example(Hour a, Hour b) => a + b;

## 5. What are symmetric overloaded binary operators and how do they differ from non-symmetric overloaded binary operators?
- symmetric overloaded means that they are of the same type and non-symmetric is if they are of different types but it must be defined in a constructor; and if you can add A and B, you must be also be able to add B and A.


## 6. Can you overload compound assignment operators? If so, please state how you do so. If not, explain why not.
- You can't explicitly overload the compound assignment operators. You can however overload the main operator and the compiler expands it.

## 7. What is the difference between overloading increment and decrement operators for value types and reference types?
- Reference types will produce unexpected results becasue it refers to the same object.

## 8. Why do we overload some operators in pairs?
- Some operators naturally come in pairs.

## 9. What is the difference between widening conversion and narrowing conversion?
- Widening increase the size of memory and since the value will still fit in this larger size nothing is lost.  Narrowing is shoring the size of memory, and there is a possibilty that it will be cut off and informaiton is lost.

## 10. What is the difference between explicit conversion and implicit conversion?
- If a conversion is always safe, does not run the risk of losing information, and cannot throw an exception, it can be defined as an implicit conversion, otherwise you must use explicit conversion.