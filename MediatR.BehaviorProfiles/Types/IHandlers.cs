using System;
using System.Collections.Generic;

namespace MediatR.BehaviorProfiles.Types
{
    public interface IHandlers
    {
        /// <summary>
        /// Include a handler for registration.
        /// </summary>
        /// <typeparam name="THandler">The handler to include.</typeparam>
        void Include<THandler>();

        /// <summary>
        /// Include a handler for registration.
        /// </summary>
        /// <param name="type">The type of the handler to include.</param>
        void Include(Type type);

        /// <summary>
        /// Include handlers for registration.
        /// </summary>
        /// <param name="types">The types of the handlers to include.</param>
        void Include(IEnumerable<Type> types);
    }
}