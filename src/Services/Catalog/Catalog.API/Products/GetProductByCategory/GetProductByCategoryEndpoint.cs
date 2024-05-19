﻿namespace Catalog.API.Products.GetProductByCategory
{
    //public record GetProductByCategoryQuery(string Category) :
    //    IQuery<GetProductByCategoryResult>;

    public record GetProductByCategoryResponse(IEnumerable<Product> Products);

    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string Category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(Category));

                var response = result.Adapt<GetProductByCategoryResponse>();

                return Results.Ok(response);
            })
              .WithName("GetProductByCategory")
              .Produces<GetProductByCategoryResponse>(StatusCodes.Status201Created)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .WithSummary("Get Product By Category")
              .WithDescription("Get Product By Category");
        }
    }
}
