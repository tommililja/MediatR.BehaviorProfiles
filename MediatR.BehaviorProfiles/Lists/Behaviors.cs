using MediatR.BehaviorProfiles.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatR.BehaviorProfiles.Lists
{
    internal class Behaviors : List<Behavior>
    {
        public Behaviors(Type type, Handlers handlers)
        {
            var behaviors = handlers
                .Select(handler => new Behavior(type, handler));

            AddRange(behaviors);
        }
    }
}