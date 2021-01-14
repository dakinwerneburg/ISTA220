Dakin T. Werneburg
C# Programming Homework 01
1/12/2021

Discussion Questions

Answer the discussion questions in writing for chapter 1
1.	* What is a console app?
		* A console app is an application that runs in a command prompt window instead of providing a graphical user interface (GUI).  

2. 	-Q.	List two differences between .NET Framework and .NET Core. Note that in this class, we will be
		writing C# applications in .NET Framework and ASP.NET applications in NET Core.
	-A.	1.  .NET Core is cross-platform whereas .NET Framework is windows-only version
	    2.  .NET Core doesn't support desktop applications whereas .NET Framework is used for both desktop and web developement.
	
3.	Q.	What does Main() (the main method) do in a console application?
	A.	The main method is the entry point into an application.
	
4.	Q.	Describe these three files: TextHello.sln, TextHello.csproj, and AssemblyInfo.cs.
	A.	1.	TextHello.sln is a solution file that contains congiguration that is used to organize multiple projects and is the top-level file. 
		2.	TextHello.csproj is c# project file that contains XML configuration information about the project.
		3.  AssemblyInfo.cs is a C# file that you can use to add attributes to a program such as author and date of program.
	
5.	Q.	What is the purpose of a namespace?
	A.	"namespace" is used to organize classes to prevent naming conflicts.  
	
6.	Q.	Describe specifically what using statements do.
	A.	The using statement lets the compiler know specifically what namespace and class is being used which prevents having to enter the fully qualified name within the code.
		
7.	Q.	What is the entry point for a console app? What is the entry point for a UWP app?
	A.  The entry point for a console app is Main(), or the main method.  The entry point for an UWP app is the App() method within the App.xaml.cs file but the "OnLaunched()" method is normally launced by the end user when the application loads. 
	
8.	Q.	What is an assembly?
	A.	An assembly contains compiled coded and is collection of types and resources that are built to work together and form a logical unit of functionality.  It has an .dll extension if there is no entry and .exe if there is entry point.
	
9.	Q.	How many different versions of the WriteLine() method does the Console class contain?
	A.  In the .Net Framework there are 19 and in the .Net Core there are 18 (with the overloaded float being the difference)
	
10.	Q.	What is the relationship between an assembly and a namespace?
	A.	Both are used for grouping code.  a namespace is used to group classes, enums, structs, etc to prevent naming conflicts.  An assembly is collection of functionality and contain many namespaces that is compiled and deployed as a single implementation unit such as .exe or .dll	

11.	Q.	What is a graphical app?
	A.  A graphical application allows users to interact with a graphical user interface (GUI) such as windows, icons, controls, etc. 

12.	Q.	What does Build do?
	A.	Build compiles the source code and if configured with a build manager will package all the necessary librarys and deploy it. 

13.	Q.	(Not in book) What is bytecode? What is Microsoft CIL? Do you think that CIL is bytecode? Why or why not?
	A.	Bytecode is an intermediate language; meaning that it falls in between the source code and machine code.  This allows for protablitly between different plattforms and is run on a virtual machine.  Microsoft CIL is an intermediate language used in the .NET framework that is created by the Just-In-Time (JIT) compiler and is ran on the Virtual Execution System (VES).  I do believe that bytecode and CIL are one in the same because they are both intermediate languages, and meant not to be platform or CPU dependent;  However, bytecode is more associated with Java's intermediate language and managed code is more associated with CIL. 

14. Q.	What does Debug do?
	A.	Debug is software feature in many IDE that allow you step into the execution of the program step by step to view it's state.  This is used to troubleshoot a program if there is a bud or defect in the program, hence the term debug.
