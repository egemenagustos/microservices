namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id) :
        IQuery<GetProductByIdResult>;

    public record GetProductByIdResult(Product Product);

    public class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger) :
        IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByIdQueryHandler.Handle called by with {@Query}", request);

            var product = await session.LoadAsync<Product>(request.Id,cancellationToken);

            if (product is null)
                throw new ProductNotFoundException(request.Id);

            return new(product);
        }
    }
}
