# C# Programming Homework 09

---
Dakin T. Werneburg  
2/9/2021

----

1. What is an enum?
- **An enum is a special "class" that represents a group of constants (unchangeable/read-only variables)**  Searias on names given to numbers.


2. Declare an enum for military ranks, either officer or enlisted. Name it Ranks. What are the symbols, like Private, Corporal, Sergeant or Lieutenant, Captain, Major?

```c#
enum Ranks
{
	Private, 
	PrivateFirstClass,
	LanceCorporal,
	Corporal,
	Sergeant,
	StaffSergeant,
	GunnerySergeant,
	FirstSergeant,
	SergeantMajor
}

```

3. Using the Ranks enum, assign a rank to yourself and a friend.
- **Rank werneburg = Rank.GunnerySergeant;**
- **Rank vaughan = Rank.FirstSergeant;**

4. Determine the numeric index of particular ranks, using the Ranks enum.
- **{0,1,2,3,4,5,6,7,8}**

5. How do you select the type of an enum?
- **State the enum name followed colon and the definition**

6. What is a struct?
- **Struct is a structure similar to a class but is value type**


7. List some differences between classes and structs.
- **Classes are reference types - Structs are Value Type**
- **Classes you can declare default constructors - Structs do not**
- **Classes support inheritance - Structs do not**


8. Are structs stored on the stack or on the heap? What about enums?
- **Structs will typically live on the stack depending on how it is used, Where a enum is always stored on the stack**


9. Review the documentation for the C# System.Int32 struct. List the fields. List the methods.
- **Fields: MaxValue, MinValue**
- **Methods: CompareTo(), Equals(), GetHashCode(), GetTypeCode(), Parse(), ToString(), TryParse()**
			

10. Declare a struct named DOD with four branches.

```c#
struct DOD
{
	private string _Airforce;
	private string _Army;
	private string _Navy;
	private string _Marines;
	
	public DOD(string airforce, string army, string navy, string marines)
	{
		_Airforce = airforce;
		_Army = army;
		_Navy = navy;
		_Marines = marines;
	}
}

DOD dod = new DOD("Airforce",....)

```

11. Why can’t you create a default constructor for a struct?
- **A struct is a value type and a value type must have a default value as soon as it is declared**


12. What is CIL? What does the CLR do to the CIL?
- **CIL stands for Common Intermediate Language and is the bytecode of MSIL for the .NET platform.  The CLR converts the MSIL code to machine code**