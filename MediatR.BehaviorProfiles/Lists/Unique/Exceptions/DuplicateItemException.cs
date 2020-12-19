using System;

namespace MediatR.BehaviorProfiles.Lists.Unique.Exceptions
{
    internal class DuplicateItemException : Exception
    {
        public DuplicateItemException(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}