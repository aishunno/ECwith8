
using Catalog.Query.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Query.API.Products.GetProducts;

public record GetProductsRequest(string? SearchKey);

public record GetProductsResponse(IEnumerable<Product> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var products = await sender.Send(new GetProductsQuery());

            var response = products.Adapt<GetProductsResponse>();

            return Results.Ok(response);
        });
    }
}
