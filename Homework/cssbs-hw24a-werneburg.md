# C Sharp Homework 24

-- Dakin Werneburg   
-- 4/26/2021

## 1. What is an asynchronous method? When the book talks about a contract, what is the contract and who is it with?
- An asynchronous method is one that does not block the current thread on which it starts to run. The method is contracted to caller to return a value once its complete with the task.

## 2. What can be the problem with decomposing a series of discrete method calls into a set of tasks, such as we saw in chapter 23?
- There needs to be much greater planning as tasks need wait on other tasks to complete before it can start, or some tasks complete before other tasks and might execute out of order.  So order of execution is important.

## 3. What can be the problem with decomposing a series of discrete method calls into a set of continuations? When does the last continuation “complete” as compared to the previous continuations? What problem might this cause?
- It may cause it to block.

## 4. What might be the problem with implementing te previous solution as a continuation passing a delegate? What would be your interpretation with this error message: “The application called an interface that was marshaled for a different thread.”?
- It throws an exception becasue only the user interface thread can manipulate user interface controls.  It means that user interface has to know and control all events and if your doing it in another thread it will now know about it.

## 5. The book suggests a solution using a continuation delegate calling another continuation delegate via an anonymous function. What does the book ientify as a problem with this suggested solution?
- "It's is messy and difficult to maintain"

## 6. What does the async modifier do? What does the await operator do?
- The async modifier indicates that a method contains functionality that can be run asynchronously.  It means that somewhere in your method, you are awaiting a task to be completed.  So it need to notify the caller that it too needs to wait.

## 7. What is an awaitable object? Be specific.
- The await operator specifies the points at which this asynchronous functionality should be performed. an awaitable object is an object that is calling an async method.

## 8. In a method definition, how do you create and run a Task and return a reference to the Task? What is the type of such a method? What does the method return?
- You create a task by using the Task class and to run it you execute the run method and use the await keyword as reference to a task.  This is called an asynchoronous method and they will return a Task.

## 9. How do you define method calls in the implementation of an async method? Specifically, you must define a task, you must run the task, you must implement the task, and you must await the task. What is the syntax for doing this?

```c
 
 private async Task<int> calculateValueAsync(...)
 {    
	Task<int> generateResultTask = Task.Run(() => calculateValue(...));    
	await generateResultTask;    
	return generateResultTask.Result;
}


```

## 10. What is the difference between decomposing a series of method calls that do not return values, and a series of method calls that return values? What is the Result property of a method that returns a value? How do you use the await operator in this circumstance?
- If a method returns a value you must wrap it a Task such as Task<returnValue> and if there is no return value you just return the Task, but there is actually no return value, it just lets the compiler know this is asynchronous.

## 11. What is the difference between the await operator and the Wait method?
- Wait is synchronous and await is asynchronous.