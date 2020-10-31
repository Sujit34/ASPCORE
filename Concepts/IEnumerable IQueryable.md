
## IEnumerable

* IEnumerable exists in the System.Collections namespace. 
* IEnumerable is suitable for querying data from in-memory collections like List, Array and so on.
* While querying data from the database, IEnumerable executes "select query" on the server-side, loads data in-memory on the client-side and then filters the data.
* IEnumerable is beneficial for LINQ to Object and LINQ to XML queries.

## IQueryable

* IQueryable exists in the System.Linq Namespace. 
* IQueryable is suitable for querying data from out-memory (like remote database, service) collections.
* While querying data from a database, IQueryable executes a "select query" on server-side with all filters.
* IQueryable is beneficial for LINQ to SQL queries.