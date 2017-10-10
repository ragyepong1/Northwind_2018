<Query Kind="Expression">
  <Connection>
    <ID>613f289d-4e6f-494f-8138-720948994a90</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// TODO: 4) Suppliers and their Products (with category photo and category name)

from vendor in Suppliers
select new 
{
	SupplierName = vendor.CompanyName,
	Products = from item in vendor.Products
				select new
				{
					item.ProductName,
					item.Category.CategoryName,
					Photo = item.Category.Picture.ToImage()
				}
}