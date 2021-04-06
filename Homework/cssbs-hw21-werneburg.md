# C Sharp Homework 21

-- Dakin Werneburg   
-- MSSA Cloud Application Developer Certification   
-- 3/28/2021

## 1. What is the difference in the purposes of SQL and LINQ? In other words, why do we need two different query languages? Does LINQ replace SQL? Does SQL make LINQ unnecessary?
- LINQ is more flexible than SQL and can handle a wider variety of logical data structures where SQL is specifically for relational data.

## 2. What is the one essential requirement for the data structures used with LINQ? Why is this requirement important?
- LINQ requires the data to be stored in a data structure that implements the IEnumerable or IEnumerable<T> interface

## 3. Were does the LINQ Select() method live?
- It is an extension method of the Enumerable class

## 4. (Select) Explain, token by token, each token in this line of code: IEnumerable<string> customerFirstNames = customers.Select(cust => cust.FirstName);
- Using a lambda expression it will retrieve the FirstName property for each row in the Customers data structure and assign it to customerFirstName variable, which is of type IEnumerable<string>.

## 5. (Filter) Explain, token by token, each token in this line of code: IEnumerable<string> usCompanies = addresses.Where(addr => String.Equals(addr.Country, "United States")).Select(usComp => usComp.CompanyName);
- Using a lambda expression, it will look at the addresses data structure for only data that where the country ="United States", then selects the Company name from the address data structure and assigns it to a 

## 6. (OrderBy) Explain, token by token, each token in this line of code: IEnumerable<string> companyNames = addresses.OrderBy(addr =>addr.CompanyName).Select(comp => comp.CompanyName);
- It looks in the addresses data collection, sorts it by Company name, then selects those rows and assigns it to the companyNames variable of type IEnumerable<string>

## 7. (Group) Explain, token by token, each token in this line of code: var companiesGroupedByCountry = addresses.GroupBy(addrs => addrs.Country);
- It looks in the addresses data collection and using a lambda it will return multiple collections.  Each collection will contain all data that matches by Country.

## 8. (Distinct) Explain, token by token, each token in this line of code: int numberOfCountries = addresses.Select(addr => addr.Country).Distinct().Count();
- It looks in the addresses data structure and selects only distinct rows of the addresses data collection and counts them and assigns the scalar value to the numberOfCountries variable.

## 9. (Join) Explain, token by token, each token in this line of code:var companiesAndCustomers = customers.Select(c => new { c.FirstName, c.LastName, c.CompanyName }).Join(addresses, custs => custs.CompanyName, addrs => addrs.CompanyName, (custs, addrs) => new {custs.FirstName, custs.LastName, addrs.Country });
- It looks in the customers collection, selects the FirstName, LastName,and CompanyName properties and creates a new Object with that has the properties of FirstName, LastName, and CompanyName and then looks in the addresses collection and selects FirstName, LastName, and Country where the CompanyName appear in both the customers collection and the addresses collection and then creates a new object with these new properties then joins the two new Objects into one row and assigns it to the companiesAndCustomers variable of type IEnumerable<string>

## 10. Explain the difference between a deferred collection and a static, cached collection.
- deferred collection means that the data is not retrieved or evaluated until you iterate through the new collection, where as cached collection uses a copy of the original data, which will not change in between the processing, while it retrieves or evaluates using LINQ. 