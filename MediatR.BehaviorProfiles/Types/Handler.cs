using MediatR.BehaviorProfiles.Lists.Unique;
using System;

namespace MediatR.BehaviorProfiles.Types
{
    internal class Handler : IEquatable<Handler>, IUniqueListItem
    {
        public Handler(Type handlerType)
        {
            var interfaceName = typeof(IRequestHandler<,>)
                .Name;

            Arguments = handlerType
                .GetInterface(interfaceName)
                .GetGenericArguments();

            Type = handlerType;
        }

        public bool Equals(Handler handler)
        {
            return handler?.Type == Type;
        }

        public Type Type { get; }

        public Type[] Arguments { get; }

        public string Name => Type.FullName;
    }
}