using MediatR.BehaviorProfiles.Lists.Unique;
using MediatR.BehaviorProfiles.Types;
using System;
using System.Linq;

namespace MediatR.BehaviorProfiles.Lists
{
    internal class Handlers : UniqueList<Handler>, IHandlers
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

        public void Include(Type[] types)
        {
            var handlers = types
                .Select(type => new Handler(type));

            AddRange(handlers);
        }
    }
}