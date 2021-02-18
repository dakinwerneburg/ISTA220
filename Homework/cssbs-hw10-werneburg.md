# C# Programming Homework 10

---
Dakin T. Werneburg  
2/10/2021

----
1. What does an array look like in memory?
- **Contiguous block, or lego blocks stacked together**

2. Where is memory allocated to hold an array, on the stack or on the heap?
- **Heap**

3. Where is memory allocated to hold an array reference, on the stack or on the heap?
-**Stack**

4. Can an array hold values of different types? This is a trick question, the answer is, “It depends.” What determines the types that an array can hold?
- **According to Microsoft specifications arrays can hold any type as long as you specify object as the type.**


5. Describe the syntax of the condition for a foreach loop.
- ***foreach* followed by open and closed parenthesis.  Within the parenthesis you specify the data type followed by the IN keyword and the variable of a type that implements System.Collections.IEnumerable interface.** 

```c#
int[] numbers = new int[] {1,2,3,4,5,6};

foreach(int n in numbers)
{
    Console.WriteLine(n);
}
    
```
6. How do you make a deep copy of a array?
- **The provided methods in the array object do no allow deep copy.  You will have iterate through each element and copy each element.**


7. What is the difference in the syntax between a multi-dimensional array and an array of arrays?
- **The syntax for multi-dimensional array is to use a comma for each additional dimension and when initialize state the the size of each dimension.** 

```c#
     int[,] twoDemensions = new int[5,5];
 
     int[, ,] threeDemension = new int [5,5,5];

```

8. What is the difference in the uses for a multi-dimensional array and an array of arrays? In other words, what determines whether you would use one as opposed to the other?
- **Multidimensional arrays are rectangular and and jagged(array of arrays) arrays vary in length and own their own block in memory; whereas multi-dimensional arrays are stored linear as one long array.**

9. How do you “flatten” a multidimensional array? In other words, take something that looks like a matrix   
> [1 2 3  
  4 5 6  
  7 8 9] 
  
> and turn it into an array [1, 2, 3, 4, 5, 6, 7, 8, 9]? Write the code to do this in English.

- **One approach is to create an a single array with the size equal to the width times the height, then iterate through each element of the multi-dimensional array using nested for loops and assign it to the single array**


10. (Thought question) When we use a for loop, we can change the values of the array elements inside the loop. When we use a foreach loop, we cannot change the values of the array elements inside the loop. Why not? How is for different from foreach?
- **In a *foreach* the loop variable is read-only copy and doesn't work with the actual element itself**