namespace MediatR.BehaviorProfiles.Types;

internal class Behavior
{
    private readonly Type pipelineBehaviorInterface = 
        typeof(IPipelineBehavior<,>);

    public Behavior(Type type)
    {
        InterfaceType = pipelineBehaviorInterface;
        ImplementationType = type;
    }

    public Behavior(Type type, Handler handler)
    {
        var arguments = handler.Arguments;

        InterfaceType = pipelineBehaviorInterface
            .MakeGenericType(arguments);

        ImplementationType = type
            .MakeGenericType(arguments);
    }

    public Type InterfaceType { get; }

    public Type ImplementationType { get; }
}