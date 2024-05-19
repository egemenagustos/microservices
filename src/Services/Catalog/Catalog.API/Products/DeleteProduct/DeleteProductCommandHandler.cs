namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : 
        ICommand<DeleteProductCommandResult>;

    public record DeleteProductCommandResult(bool IsSuccess);

    public class DeleteProductCommandHandler(IDocumentSession session, ILogger<DeleteProductCommandHandler> logger) :
        ICommandHandler<DeleteProductCommand, DeleteProductCommandResult>
    {
        public async Task<DeleteProductCommandResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("DeleteProductCommandHandler.Handle called by with {@Query}", request);

            var product = await session.LoadAsync<Product>(request.Id, cancellationToken);

            if (product is null)
                throw new ProductNotFoundException();

            session.Delete<Product>(request.Id);
            await session.SaveChangesAsync(cancellationToken);

            return new(true);
        }
    }
}
