# C Sharp Homework 18

-- Dakin Werneburg   
-- MSSA Cloud Application Developer Certification   
-- 3/10/2021

---

## 1. You are building a help ticket system. You want to ensure that the older the ticket, the sooner it will be handled by the team. For example, a ticket submitted a week ago has a higher priority than a ticked just submitted. What kind of data structure would you use, and why?
- Queue, because this is first-in, first-out.

## 2. You are building a tracking system for seasonal agricultural farm labor. The labor requirements vary widely, depending on the season. Your requirement is that the newest hires are terminated first, and that our more experienced hires are kept longer. What kind of data structure would you use, and why?
- Stack, because this is first-in, last-out.

## 3. You are building a transaction database. Your requirement is that the database adds data very quickly, and that deletions, updates, and searches happen infrequently. In other words, data is typically added in the order in which the transaction occurs. What kind of data structure would you use, and why?
- I would use a LinkedList (doubly) as this offers the most flexibility, for the reason that it doesn't coast anything to go beyond the capacity, which I am assuming will happen if your adding transaction very quickly and deletions don't happen very frequent. 

## 4. You are building an analytical database. Your requirement is that the database handle queries very quickly, but that the data never changes, i.e., there are no inserts, deletions, or updates. What kind of data structure would you use, and why?
- There is still some questions, I would have to ask such as how is this data stored and retrieved.  Such as "Is this data sorted", "How is the date queried", is it retrieved using a key, value or is the position in database known.  However, if I had to make a decision without this information, I would lean towards a HashSet because it does have fast lookup and each entry is unique, just like a database has a primary key.  However, if there is a collision, they this causes a much slower query.

## 5. You are building a personnel directory, where searches are performed by last name, first name, middle name. What kind of data structure would you use, and why?
- I am leaning towards Dictionary and thinking that the combination of Last, First, and middle could be a key and would find the value really quick.    

## 6. You are building a username/password database. Your requirement is that updates happen frequently (when users change their passwords) and that searches (to authenticate users) happens extremely quickly. What kind of data structure would you use, and why?
- The best solution in my opinion is a Dictionary because it make logical sense that the username and password follow the key,value concept.  

## 7. What is a lambda expression? Give an example. Why would we use a lambda expression?
- A lambda expression is an anonymous functions that is not associated with any class method.  These are meant typically for short blocks of code to perform some calculation.  It may or may not take parameters, and can be represented with very short syntax depending on how it is utilized.  In addition lambda expression could also be assigned to variable and executed later.  It's key signature is the lambda declaration operator '=>'.  One example is:
> int squared = (n) => n * n;

## 8. What is the difference between lambda expressions and anonymous methods? What are the advantages of each?
- Lambda expression and anonymous methods are very similar but lambda expression are syntactically shorter, such as anonymous methods require the use of the delegate keyword and a return, whereas lambdas are much shorter and only require certain syntax like the return if you have more than one statement.  Besides being more readable and concise, lambda expression can also be compiled to expression trees.