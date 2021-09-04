using MediatR.BehaviorProfiles.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

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

        protected abstract void Configure();

        /// <summary>
        /// Register an implementation of IPipelineBehavior for all handlers.
        /// </summary>
        /// <param name="type">The behavior type to register.</param>
        protected void Register(Type type)
        {
            var behavior = new Behavior(type);

            RegisterBehavior(behavior);
        }

        /// <summary>
        /// Register an implementation of IPipelineBehavior for specific handlers.
        /// </summary>
        /// <param name="type">The behavior type to register.</param>
        /// <param name="handlersAction">A list of handlers to include.</param>
        protected void Register(Type type, Action<IHandlers> handlersAction)
        {
            var handlers = new Handlers();
            
            handlersAction?.Invoke(handlers);
            
            var behaviors = new Behaviors(type, handlers);

            RegisterBehaviors(behaviors);
        }

        private void RegisterBehaviors(Behaviors behaviors) =>
            behaviors
                .ToList()
                .ForEach(RegisterBehavior);

        private void RegisterBehavior(Behavior behavior) =>
            services.AddTransient(
                behavior.InterfaceType,
                behavior.ImplementationType);
    }
}