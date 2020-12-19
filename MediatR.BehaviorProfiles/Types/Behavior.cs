using System;

namespace MediatR.BehaviorProfiles.Types
{
    internal class Behavior
    {
        private readonly Type interfaceType = typeof(IPipelineBehavior<,>);

        public Behavior(Type type)
        {
            InterfaceType = interfaceType;
            ImplementationType = type;
        }

        public Behavior(Type type, Handler handler)
        {
            var arguments = handler.Arguments;

            InterfaceType = interfaceType
                .MakeGenericType(arguments);

            ImplementationType = type
                .MakeGenericType(arguments);
        }

        public Type InterfaceType { get; }

        public Type ImplementationType { get; }
    }
}