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

    public class DeleteBasketCommandHandler : 
        ICommandHandler<DeleteBasketCommand, DeleteBasketCommandResult>
    {
        public async Task<DeleteBasketCommandResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            return new(true);
        }
    }
}
