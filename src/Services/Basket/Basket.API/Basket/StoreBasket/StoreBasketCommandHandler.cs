using Discount.Grpc.Protos;

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

    public class StoreBasketQueryHandler(IBasketRepository basketRepository, DiscountProtoService.DiscountProtoServiceClient discount) :
        ICommandHandler<StoreBasketCommand, StoreBasketCommandResult>
    {
        public async Task<StoreBasketCommandResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
        {
            await DecutDiscount(request, cancellationToken);

            await basketRepository.StoreBasket(request.ShoppingCart, cancellationToken);

            return new(request.ShoppingCart.UserName);
        }

        private async Task DecutDiscount(StoreBasketCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.ShoppingCart.Items)
            {
                var coupon = await discount.GetDiscountAsync(
                    new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken
                    );
                item.Price -= coupon.Amount;
            }
        }
    }
}
