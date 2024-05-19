namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) :
        ICommand<UpdateProductCommandResult>;

    public record UpdateProductCommandResult(bool IsSuccess);

    public class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger) :
        ICommandHandler<UpdateProductCommand, UpdateProductCommandResult>
    {
        public async Task<UpdateProductCommandResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("UpdateProductCommandHandler.Handle called by with {@Command}", request);

            var product = await session.LoadAsync<Product>(request.Id, cancellationToken);

            if (product is null)
                throw new ProductNotFoundException();

            product.Name = request.Name;
            product.Category = request.Category;
            product.Description = request.Description;
            product.ImageFile = request.ImageFile;
            product.Price = request.Price;

            session.Update(product);
            await session.SaveChangesAsync();

            return new(true);
        }
    }
}
