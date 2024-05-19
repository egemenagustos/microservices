namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) :
       ICommand<UpdateProductCommandResult>;

    public record UpdateProductCommandResponse(bool IsSuccess);

    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateProductCommandResponse>();

                return Results.Ok(response);
            })
                .WithName("UpdateProduct")
                .Produces<UpdateProductCommandResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Update Product")
                .WithDescription("Update Product");
        }
    }
}
