﻿namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string UserName) : 
        IQuery<GetBasketQueryResult>;

    public record GetBasketQueryResult(ShoppingCart ShoppingCart);

    public class GetBasketQueryHandler : 
        IQueryHandler<GetBasketQuery, GetBasketQueryResult>
    {
        public async Task<GetBasketQueryResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            return new(new("sw"));
        }
    }
}
