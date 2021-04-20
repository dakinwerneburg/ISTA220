# C Sharp Homework 23

-- Dakin Werneburg   
-- MSSA Cloud Application Developer Certification   
-- 4/18/2021

## 1 List two reasons for multitasking, and explain the rationale for them.
- Multitasking allows a program to run more efficiently by maximizing resources such as utilizing more each processing core to handle a task.  Another reason is to prevent long running process from locking up or blocking other tasks such as in graphical user interface freezing while performing a CPU intensive operation.

## 2 Explain Moore’s law. What does Moore’s law have to do with multitasking?
- Moore Law states that the amount of transistors that can fit on a chip would double every two years and has held up for several years, but do to limitations of physics, there needs to be other ways of increasing throughput or speed, so multicore have been supplemented and by programming using multitasking, we can harness these extra cores.

## 3 In UWP, what namespace is used as the container for the multitasking methods?
- System.Threading.Tasks is the namespace for multitasking in UWP.

## 4 What is the difference between tasks and threads? Explain.
- Threads are low level control of sending request to obtain CPU time to execute some code.  This is a very delicate resource and must be balanced with how many CPU they way they are scheduled.  Tasks provide a high level approach by creating an action delegate and queuing it in the ThreadPool to be ran concurrently.  

## 5 What is the ThreadPool?
- The ThreadPool is what manages threads.  Because creation of threads is an expensive operation, .NET ThreadPool finds the optimal number of threads to create and instead of destroying them and recreating them it provides an optimized scheduler that reuses these threads for other tasks.

## 6 What parameters does the Task() constructor take?
- Task constructor takes an Action delegate, which is delegate that takes no parameters and has no return value.

## 7 How do you start a thread?
- To start a thread you invoke the Start() method of the Task class which schedules the task to execute.

## 8 What is the difference between the Start() and Run() methods?
- In order for a task to be scheduled it must be started, and this can be done by either the Start() or Run () methods.  The difference is when the tasks should be scheduled.  Task.Run() will create and start the task to be scheduled implicitly, whereas Task.Start() is called explicitly.  For the most part, Task.Run() should be used unless you are deferring the scheduling.

## 9 What is the difference between creating independent tasks with Tasks and parallelization with Parallel? Explain.
- Independent tasks with Task class allows complete control over the task such as the number and when they are started, but using Parallel, this abstracts this from you but does .NET does have optimizing techniques and can prevent synchronization mistakes from the user.

## 10 Explain how manual cancellation works using a cancellation token.
- Task should be cancelled gracefully and this can be done by using the CancellationToken.  This provides a Boolean property that will get and set the cancelled state.  This is then used by the .NET to find the optimal time to stop the thread execution.  By checking for this flag it allows you to do some clean up and reverse any changes that may have occurred.