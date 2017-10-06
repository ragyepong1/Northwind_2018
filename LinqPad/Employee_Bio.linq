<Query Kind="Expression">
  <Connection>
    <ID>89c496be-99ec-4a43-a58e-bd3835d45c82</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// Employee Bio
from person in Employees

select new 
{
	FullName = person.FirstName + " " + person.LastName,
	JobTitle = person.Title,
	CompanyPhoneExtension = person.Extension,
	Photo = person.Photo.ToImage(),
	MimeType = person.PhotoMimeType,
	Supervisor = person.ReportsToEmployee.FirstName + " " + person.ReportsToEmployee.LastName,
	Bio = person.Notes
}