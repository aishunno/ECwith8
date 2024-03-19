using BuildingBlocks.CQRS;
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
    public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
