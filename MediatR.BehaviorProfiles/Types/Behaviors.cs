namespace MediatR.BehaviorProfiles.Types;

internal class Behaviors : HashSet<Behavior>
{
    public Behaviors(Type type, Handlers handlers)
    {
        var behaviors = handlers
            .Select(handler => new Behavior(type, handler));

        UnionWith(behaviors);
    }
}