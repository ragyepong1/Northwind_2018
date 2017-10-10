<Query Kind="Expression">
  <Connection>
    <ID>613f289d-4e6f-494f-8138-720948994a90</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// Suppliers, by country
from row in Suppliers
group row by row.Country into vendors
select new
{
   Country = vendors.Key,
   Companies = from vendor in vendors
               select vendor.CompanyName
}