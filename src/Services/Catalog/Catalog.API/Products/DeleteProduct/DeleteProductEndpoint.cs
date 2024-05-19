namespace Catalog.API.Products.DeleteProduct
{
    //public record DeleteProductRequest(Guid Id) :
    //    ICommand<DeleteProductCommandResult>;

    public record DeleteProductCommandResponse(bool IsSuccess);

    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result =  await sender.Send(new DeleteProductCommand(id));

                var response = result.Adapt<DeleteProductCommandResponse>();

                return Results.Ok(response);
            })
                .WithName("DeleteProduct")
                .Produces<DeleteProductCommandResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Delete Product")
                .WithDescription("Delete Product");
        }
    }
}
