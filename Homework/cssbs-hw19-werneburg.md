# C Sharp Homework 19

-- Dakin Werneburg   
-- MSSA Cloud Application Developer Certification   
-- 3/21/2021

---
## 1. What is an enumerable collection?
- An enumerable collection is data type that implements the IEnumerable iterface.

## 2. What properties and methods does the IEnumerable interface contain?
- IEnumerable interface has only one method, GetEnumerator(), which returns an enumerator.

## 3. What properties and methods does the IEnumerator interface contain?
- IEnumerator iterface has one properties to store the current object, and has two methods: MoveNext() and Reset().  

## 4. What values does the MoveNext() method return? What does it do? 
- MoveNext() returns a bool value type.  MoveNext updates the pointer to the next reference and returns true if the next item is not null and false either wise.  


## 5. What values does the Reset() method return? What does it do?
- The Reset() doesn't return anything, it just moves the initial pointer before the first item in the list.

## 6. Are IEnumerable and IEnumerator type safe? Why or why not? If not, how do you implement type safety?
- The non-generic IEnumerable and IEnumerator are not type safe because the current property is of type object and would require type casting.  To implement type safety, use the generic version.

## 7. Why don’t recursive methods retain state when used with data structures like binary trees?
- Methods have local variables that are not available after it competes.  Because recursive calls are creating a new stack each time, each call is not aware of the other.

## 8. How do you define an enumerator?
- Enumerator is defined implementing the IEnumerator interface and adding a constraint that it the type must implement the IComparable<T> interface.

## 9. What is an iterator?
- An iterator is a block of code that yields an ordered sequence of values.

## 10. What does yield do?
- The yield keyword allows values to be returned one a time.  It will return the value it currently produces then returns to the caller and waits until it has another one to process then return that one.
