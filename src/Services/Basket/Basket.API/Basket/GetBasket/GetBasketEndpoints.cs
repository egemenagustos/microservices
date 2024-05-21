﻿namespace Basket.API.Basket.GetBasket
{
    //public record GetBasketQuery(string UserName) :
    //    IQuery<GetBasketQueryResult>;

    public record GetBasketQueryResponse(ShoppingCart ShoppingCart);

    public class GetBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
            {
                var result = await sender.Send(new GetBasketQuery(userName));

                var response = result.Adapt<GetBasketQueryResponse>();

                return Results.Ok(response);
            })
              .WithName("GetBasket")
              .Produces<GetBasketQueryResponse>(StatusCodes.Status201Created)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .WithSummary("Get Basket")
              .WithDescription("Get Basket");
        }
    }
}
