# Contract Testing for ZestEats Microservices

## Recommended Approach

- Use [Pact](https://docs.pact.io/) for consumer-driven contract tests between services (REST/gRPC).
- For .NET, use [PactNet](https://github.com/pact-foundation/pact-net).
- Define contracts for each service API (request/response, error cases).
- Integrate contract tests into CI pipeline.

## Example (PactNet, .NET)

```csharp
[Fact]
public async Task ItHonoursTheOrderApiContract()
{
    var pact = Pact.V3("order-consumer", "order-provider", new PactConfig());
    pact.UponReceiving("A valid order request")
        .WithRequest(HttpMethod.Post, "/api/order")
        .WithJsonBody(new { userId = "test", items = new[] { new { menuItemId = "item1", quantity = 2 } } })
        .WillRespond()
        .WithStatus(HttpStatusCode.OK)
        .WithJsonBody(new { orderId = "123", status = "created" });
    await pact.VerifyAsync(async ctx => {
        // Call your client here
    });
}
```

## Best Practices

- Version contracts and keep them in source control.
- Run contract tests in CI for every PR.
- Fail builds if contracts are broken.
