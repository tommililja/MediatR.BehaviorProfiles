using MediatR.BehaviorProfiles.Lists.Unique.Exceptions;
using System;
using System.Collections.Generic;

namespace MediatR.BehaviorProfiles.Lists.Unique
{
    internal abstract class UniqueList<T> : List<T> where T : IEquatable<T>, IUniqueListItem
    {
        protected UniqueList()
        {

        }

        protected UniqueList(IEnumerable<T> collection)
        {
            AddRange(collection);
        }

        public new void Add(T item)
        {
            CheckForDuplicate(item);

            base.Add(item);
        }

        public new void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        private void CheckForDuplicate(T item)
        {
            if (Contains(item))
            {
                throw new DuplicateItemException(item.Name);
            }
        }
    }
}