namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : 
        ICommand<DeleteProductCommandResult>;

    public record DeleteProductCommandResult(bool IsSuccess);

    public class DeleteroductCommandValidator :
        AbstractValidator<DeleteProductCommand>
    {
        public DeleteroductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }

    public class DeleteProductCommandHandler(IDocumentSession session) :
        ICommandHandler<DeleteProductCommand, DeleteProductCommandResult>
    {
        public async Task<DeleteProductCommandResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(request.Id, cancellationToken);

            if (product is null)
                throw new ProductNotFoundException(request.Id);

            session.Delete<Product>(request.Id);
            await session.SaveChangesAsync(cancellationToken);

            return new(true);
        }
    }
}
