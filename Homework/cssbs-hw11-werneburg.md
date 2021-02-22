# C# Programming Homework 11

---
Dakin T. Werneburg  
2/18/2021

----
1. What is a parameter array?
- **Parameter array is a way to write a method that takes a variable number of arguments**

2. How do you define a method that takes an arbitrary number of arguments?
- **Use the *params* keyword as an array parameter**

3. How do you call a method that takes an arbitrary number of arguments?
- **Just pass the arbitary number of arguments into the method.**

4. Why can’t you use an array to pass an arbitrary number of arguments to a method?
- **Because behind the scenes, the compiler is already creating an array**


5. How many parameters can a method have?
- **2^16 (65,536) arguments or as many as your system will allow**

6. Do parameter arguments have to have the same type?
- **No, because it will just create an array of type object**.

7. What is the difference between a method that takes a parameter argument and one that takes optional arguments?
- **optional arguments are fixed in size and defaulted to their default values, where as parameter arguments can take an arbitrary number of arguments and will be will be assigned at compiled time based on the count and type that is passed from the calling method**.


8. How do you define a method that takes different (and arbitrary) types of arguments?

- **someType Method(params object[] paramList){    ...}**

9. Write a method that accepts any number of arguments of a given type.

```c#

    public int SumInts (params int[] n)
    {
        int sum =0;
        for(int i=0; i< n.Length; i++)
        {
            sum+=n[i];
        }
        return sum;
    }
```
10. Write a method that accepts any number of arguments of any type.

```c#

    public void SumInts (params object[] list)
    {
        
        for(int i=0; i< list.Length; i++)
        {
            Console.WriteLine(list[i].ToString());
        }
    }
```