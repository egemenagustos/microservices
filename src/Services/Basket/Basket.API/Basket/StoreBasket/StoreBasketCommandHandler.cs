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

    public class StoreBasketQueryHandler :
        ICommandHandler<StoreBasketCommand, StoreBasketCommandResult>
    {
        public async Task<StoreBasketCommandResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
        {
            ShoppingCart cart = request.ShoppingCart;

            return new("cart.UserName");
        }
    }
}
