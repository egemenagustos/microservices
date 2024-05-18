namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new(
                name: request.Name,
                category: request.Category,
                description: request.Description,
                imageFile: request.ImageFile,
                price: request.Price
                );

            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            return new(product.Id);
        }
    }
}
