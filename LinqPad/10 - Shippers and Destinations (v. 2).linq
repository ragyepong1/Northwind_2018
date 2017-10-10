<Query Kind="Expression">
  <Connection>
    <ID>613f289d-4e6f-494f-8138-720948994a90</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>


// Shippers, and the countries they ship to
from row in Shippers
select new
{
    Shipper = row.CompanyName,
    Countries = from order in row.ShipViaOrders
                orderby order.ShipCountry
                group order by order.ShipCountry into countries
                select countries.Key
}