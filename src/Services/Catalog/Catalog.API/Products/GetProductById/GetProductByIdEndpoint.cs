namespace Catalog.API.Products.GetProductById
{
    //public record GetProductByIdQuery(Guid Id) :
    //    IQuery<GetProductByIdResult>;

    public record GetProductByIdResponse(Product Product);

    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                var product = await sender.Send(new GetProductByIdQuery(id));

                var response = product.Adapt<GetProductByIdResponse>();

                return Results.Ok(response);
            })
              .WithName("GetProductById")
              .Produces<GetProductByIdResponse>(StatusCodes.Status201Created)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .WithSummary("Get Product By Id")
              .WithDescription("Get Product By Id");
        }
    }
}
