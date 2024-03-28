using BuildingBlocks.Exceptions;

namespace Catalog.Query.API.Exceptions;

public class ProductNotFoundException(Guid Id) 
    : NotFoundException("Product", Id)
{
}
