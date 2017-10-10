<Query Kind="Expression">
  <Connection>
    <ID>613f289d-4e6f-494f-8138-720948994a90</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// Customers grouped by Country
from row in Customers
group row by row.Country into customers
orderby customers.Count() descending
select new
{
    Country = customers.Key,
    Customer = from customer in customers
               select new
               {
                   Company = customer.CompanyName,
                   City = customer.City,
                   Region = customer.Region
               }
}