# C# Programming Homework 05

---
Dakin T. Werneburg  
1/26/2021

----

1. What is a compound assignment operator? How does it work?
> - **Compound assignment operator combines the assignment operator with an arithmetic operator.  It performs the calculation of the arithmetic to it's self and then assigns the new value to it's self.**


2. List all the compound assignment operators.
> - **\+=**
> - **\-=**
> - **\%=**
> - **\*=**
> - **\/=**


3. List two ways to increment a numeric variable by 5. List two ways to decrement a numeric variable by 50.  
> - **n = n + 5;**
> - **n += 5;**
> - **n = n - 5;**
> - **n -= 5;**


4. How long does a while loop run?
> - **It will first only run if the condition is true and continue indefinitely until the condition is false.**


5. What is an iteration variable? (Not in book)
> - **Iteration variable is variable that is updated on each iteration of the loop and is used to terminate a loop.** 


6. What happens if you don't change the loop variable in the body of the while loop block?
> - **The loop will repeat infinitely**


7. How many parts does a for loop statement have? Can you omit any of them? Can you omit all of them? What happens if you omit all of them?
> - **There are 3 parts:  Initialization, Boolean expression, and control variable or counter.  You could omit all three of them but this would result in an infinite loop.** 


8. How do you guarantee that a loop runs at least once?
> - **You would use a do While-Loop**


9. What does the break statement do?
> - **Breaks out of the loop and continues executing code outside of the loops curly braces**

10. What does the continue statement do?
> - **Continue breaks out of the current iteration, updates the loop variable, and proceeds to the next iteration.**


11. (Thought question) Can you think of any reason why you would want to have an infinite loop? An infinite loop" is a loop without an update variable that in effect runs forever. As you will see, these kinds of loops are written intentionally to perform various kinds of tasks.
> - **Typically would see this in user interfaces where you are continuously waiting for user input, and the while loops is constantly check for these events.**