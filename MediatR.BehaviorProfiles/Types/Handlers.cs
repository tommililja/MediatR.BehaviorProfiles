using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatR.BehaviorProfiles.Types
{
    internal class Handlers : HashSet<Handler>, IHandlers
    {
        public void Include<THandler>()
        {
            Include(typeof(THandler));
        }

        public void Include(Type type)
        {
            var handler = new Handler(type);

            Add(handler);
        }

        public void Include(IEnumerable<Type> types)
        {
            var handlers = types
                .Select(type => new Handler(type));

            UnionWith(handlers);
        }
    }
}