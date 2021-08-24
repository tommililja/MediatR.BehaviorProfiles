MediatR.BehaviorProfiles
=======

Profiles that simplify the registration of [MediatR](https://github.com/jbogard/MediatR) behaviors.

#### Usage

Create a profile:

```csharp

using MediatR.BehaviorProfiles;

public class MyBehaviorProfile : BehaviorProfile
{
    public override void Configure()
    {
        Register(typeof(LoggingBehavior<,>));

        Register(typeof(TransactionBehavior<,>), handlers =>
        {
            handlers.Include<CreateOrderHandler>();
            handlers.Include<DeleteOrderHandler>();
        });
    }
}

```

Add the profile in ConfigureServices:

```csharp

using MediatR.BehaviorProfiles.Extensions;

public void ConfigureServices(IServiceCollection services)
{
    services
        .AddMediatR()
        .AddBehaviorProfile<MyBehaviorProfile>();     
}

```

#### Dependencies

* [MediatR](https://www.nuget.org/packages/MediatR)
* [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection)
