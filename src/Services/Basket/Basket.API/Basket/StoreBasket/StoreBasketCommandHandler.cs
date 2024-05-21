namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart ShoppingCart) :
        ICommand<StoreBasketCommandResult>;

    public record StoreBasketCommandResult(string UserName);

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.ShoppingCart).NotNull().WithMessage("Cart can not be null.");
            RuleFor(x => x.ShoppingCart.UserName).NotEmpty().WithMessage("UserName is required.");
        }
    }

    public class StoreBasketQueryHandler(IBasketRepository basketRepository) :
        ICommandHandler<StoreBasketCommand, StoreBasketCommandResult>
    {
        public async Task<StoreBasketCommandResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
        { 
            await basketRepository.StoreBasket(request.ShoppingCart,cancellationToken);

            return new(request.ShoppingCart.UserName);
        }
    }
}
