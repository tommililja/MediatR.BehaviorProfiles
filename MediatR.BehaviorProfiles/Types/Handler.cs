namespace MediatR.BehaviorProfiles.Types;

internal class Handler : IEquatable<Handler>
{
    private readonly Type type;
        
    public Handler(Type handlerType)
    {
        var requestHandlerInterface = typeof(IRequestHandler<,>);

        Arguments = handlerType
            .GetInterface(requestHandlerInterface.Name)
            .GetGenericArguments();

        type = handlerType;
    }

    public bool Equals(Handler handler)
    {
        return handler?.type == type;
    }

    public Type[] Arguments { get; }
}