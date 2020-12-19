using MediatR.BehaviorProfiles.Exceptions;
using MediatR.BehaviorProfiles.Lists;
using MediatR.BehaviorProfiles.Lists.Unique.Exceptions;
using MediatR.BehaviorProfiles.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MediatR.BehaviorProfiles
{
    public abstract class BehaviorProfile
    {
        private IServiceCollection services;

        internal IServiceCollection Configure(IServiceCollection services)
        {
            this.services = services;

            Configure();

            return services;
        }

        public abstract void Configure();

        /// <summary>
        /// Register an implemention of IPipelineBehavior for all handlers.
        /// </summary>
        /// <param name="type">The behavior type to register.</param>
        protected void Register(Type type)
        {
            var behavior = new Behavior(type);

            RegisterBehavior(behavior);
        }

        /// <summary>
        /// Register an implemention of IPipelineBehavior for specific handlers.
        /// </summary>
        /// <param name="type">The behavior type to register.</param>
        /// <param name="handlersAction">A list of handlers to include.</param>
        /// <exception cref="DuplicateHandlerException">Thrown when a handler has already been included.</exception>
        protected void Register(Type type, Action<IHandlers> handlersAction)
        {
            var handlers = new Handlers();

            try
            {
                handlersAction?.Invoke(handlers);
            }
            catch (DuplicateItemException e)
            {
                throw new DuplicateHandlerException(e.Name);
            }

            var behaviors = new Behaviors(type, handlers);

            RegisterBehaviors(behaviors);
        }

        private void RegisterBehaviors(Behaviors behaviors)
        {
            foreach (var behavior in behaviors)
            {
                RegisterBehavior(behavior);
            }
        }

        private void RegisterBehavior(Behavior behavior)
        {
            services.AddTransient(
                behavior.InterfaceType,
                behavior.ImplementationType);
        }
    }
}