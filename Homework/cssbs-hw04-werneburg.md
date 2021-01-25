# C# Programming Homework 04

---
Dakin T. Werneburg  
1/21/2021

----



1. What are all possible values of Boolean expression?
> - **true or false**
	
2. List the equality operators. List the relational operators. List the logical operators. How are they the
same? How are they different? 
> - **Equality Operators:**
>>> **==**(Doulble Equal)  
>>> **\!=** (Not Equal)

> - **Logical Operators**
>>> **\!** (Negation)    
>>> **&** (AND)    
>>> **|** (OR)    
>>> **^** (Excusive OR)   
>>> **&&** (Conditional logical AND)  
>>> **||** (Conditional Logical OR)
 

3. What is the general concept of short circuiting? This question has a short and simple answer and you do not need to have a detailed response.
> - **if an expression can be evalutaed by the first predicate it no longer needs to evalute the second prediccate.**
 
4. What are the difference in how short circuiting works for && and ||?
> - **Sort circuit for both will evaluted the first predicate but if it is false, the && will not evaluted the second but if it is || is will have to evalute the second, and reverse if the predicate is true.**

5. Look at the list of operators. What operator has the highest precedence? Which has the lowest?
>> **( ) Parentheses - Highest**  
>> **= Assignment - Lowest**

6. In an if or else construction using multiple lines of code, what effect does the use of curly braces have?
> **It isolates execution to a block of code dedepending on the condition, in which there is local scope of the variables.**

7. In a switch statement, what happens if you omit break?
> - **Accidental fallthrough is not allowed in C#.  Every switch statement needs a jump stamentent (break,return,goto, throw) or will not compile**.

8. The four keywords in a switch statement are switch, case, break, and default. Explain what each
keyword does.
> - **Switch is a selection statement that evalutes the argument within parenthesis, and passes control to the case statement that matches the argument.  If no case is a match then default statement will be executed.  A break statement jumps out of the switch statemenet block of code.** 


9. Look at the source listing below. It contains two methods: recurr1() and recurr2(). There is a significant difference between the two methods. What is it?
> - **One uses the return value from the recursive method then works it way back up to the first caller, and the other doesn't.  In recurr1, each recursive call is multiply by the return result until it reaches the base case which is one.  In recurr2, initial and product are multiplied and not the return value of the recursive method and the base case returns the current value of product at that point which is 120.


10. (Not in book) What is a recursive method? Using a language you know (such as English), write a recursive method that adds up the integers in a list of integers. The input to the method is a list of integers and the output is a scalar value representing a sum.
> - **A recursive method is a method that gets invoked by it's self.**   
>> **Initally the value of *sum* is 0, while there are no more numbers in the list, you will remove one, add it to sum, and replace sum with the new value.  Once all numbers have been removed you can stop and return current value of sum.


11. (Not in book) Read a short summary of De Morgan’s laws.  (a) Explain how this statement, ”It’s not snowing or raining,” is the same as this statement, ”It’s not snowing and it’s not raining.”  (b) Explain how this statement, ”I’m not running and walking,” is the same as this statement, ”I’m not running or I’m not walking.”
>
> **De Morgan's Law states that the negation of a disjunction is the conjunction of the negations; and the negation of a conjunction is the disjunction of the negations; ~(p^q) = ~p V ~q;   ~(pVq) = ~p ^ ~q**  
> **(a) Let p be the propositon "It's raining" and let q be the proposition "Its raining".  Therefore according to De Morgan's Law, if we add negation, then both propositon are negated and the operator is switch from OR to AND.
> **(b) Same logic as (a) Let p = "I'm running" and q = "I'm walking by adding negation, according to De Morgan's Law, both propostions are negated and the operator is flipped from AND to OR.  
 

```cs
using System;

namespace Recur_ch03_text
{
	class Program
	{
		static void Main( string [] args )
		{
			int initial = 5;
			Console . WriteLine($" Calling recurr1({ initial })");
			int recur = recurr1( initial );
			Console.WriteLine ($" recurr1 is {recur}");
			Console.WriteLine($" Calling recurr2({initial})");
			recur = recurr2 (1 , initial );
			Console . WriteLine ($" recurr2 is {recur}");
		}

		private static int recurr1( int initial )
		{
			if ( initial <= 1)
				return 1;
			else
				return initial * recurr1( -- initial );
		}

		private static int recurr2( int product , int initial )
		{
			if ( initial <= 1)
				return product ;
			else
				return recurr2 ( product * initial , -- initial ) ;
		}
	}
}
