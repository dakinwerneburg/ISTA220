# C Sharp Homework 20

-- Dakin Werneburg   
-- MSSA Cloud Application Developer Certification   
-- 3/28/2021

---
## 1. What is a delegate? Explain delegates in terms of pointers and reference types.
- A Delegate is a reference to a method.  A delegate is a reference type that holds a collection of reference and is similar to a function pointer but are type safe.

## 2. How do you declare a delegate? Include a discussion of types, return values, names, and parameters.
- You first write "delegate" then return type the name of the delegate and any parameters.

## 3. How do you create instances of delegates and assign values to the instance? What are the values?
- After you have declared the delegate, you can create an instance and make it refer to a matching method by using the += compound assignment operator.

## 4. How do you invoke a method that has been added to a delegate?
- A method can be invoked using the Invoke() method or the () operator.

## 5. What is an event? Why do we have events?
- The .NET Framework provides events, which you can use to define and trap significant actions and arrange for a delegate to be called to handle the situation.  Events provide a way to call a function when some condition exists like a GUI.

## 6. How do you declare events?
- Just like a field except you use "event" keyword followed by the delegateTypeName and the eventName.

## 7. How do delegates recognize event subscriptions? How do you unsubscribe an event from a delegate?
- delegates recognize event subscriptions by using the += operator and unsubscribe by using the -= operator.

## 8. How do you raise an event? How do you declare code that raises an event?
-You can raise an event by calling it like a method. When you raise an event, all the attached delegates are called in sequence

## 9. Explain with specificity what happens when an event fires and that event has been attached to a delegate.
- Once an event fires it will call the method that was subscribed.