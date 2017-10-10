<Query Kind="Expression">
  <Connection>
    <ID>613f289d-4e6f-494f-8138-720948994a90</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// Employees, by Manager
from person in Employees
group person by person.ReportsToEmployee
    into managedEmployees
select new
{
    Manager = managedEmployees.Key.FirstName + " " + managedEmployees.Key.LastName,
    Photo = managedEmployees.Key.Photo.ToImage(),
    Employees = from employee in managedEmployees
                select new
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Photo = employee.Photo.ToImage()
                }
}

