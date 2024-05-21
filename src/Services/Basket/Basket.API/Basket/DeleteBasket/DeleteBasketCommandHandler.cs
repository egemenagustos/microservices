namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) :
        ICommand<DeleteBasketCommandResult>;

    public record DeleteBasketCommandResult(bool IsSuccess);

    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required.");
        }
    }

    public class DeleteBasketCommandHandler(IBasketRepository basketRepository) : 
        ICommandHandler<DeleteBasketCommand, DeleteBasketCommandResult>
    {
        public async Task<DeleteBasketCommandResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            bool resultBasket = await basketRepository.DeleteBasket(request.UserName,cancellationToken);
            return new(resultBasket);
        }
    }
}
