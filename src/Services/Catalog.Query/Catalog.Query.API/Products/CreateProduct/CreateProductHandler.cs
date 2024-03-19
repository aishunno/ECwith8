using BuildingBlocks.CQRS;
using Catalog.Query.API.Models;
using MediatR;

namespace Catalog.Query.API.Products.CreateProduct;

public record CreateProductCommand(
    string Name, 
    string Description,
    List<string> Category,
    string ImageFile,
    decimal Price) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // Create Product entity from command 
        var product = new Product
        {
            Name = command.Name,
            Description = command.Description,
            Category = command.Category,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        // TODO: Save to database 

        // return CreateProductResult 
        return new CreateProductResult(Guid.NewGuid());
    }
}
