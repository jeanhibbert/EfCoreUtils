using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace EfCoreUtils.TestUtilities
{
    public class TestStoreIndex
    {
        private readonly HashSet<string> _createdDatabases = new HashSet<string>();

        private readonly ConcurrentDictionary<string, object> _creationLocks
            = new ConcurrentDictionary<string, object>();

        private readonly object _hashSetLock = new object();

        public virtual void CreateShared(string name, Action initializeDatabase)
        {
            // ReSharper disable once InconsistentlySynchronizedField
            if (!_createdDatabases.Contains(name))
            {
                var creationLock = _creationLocks.GetOrAdd(name, new object());

                lock (creationLock)
                {
                    if (!_createdDatabases.Contains(name))
                    {
                        initializeDatabase?.Invoke();

                        lock (_hashSetLock)
                        {
                            _createdDatabases.Add(name);
                        }

                        _creationLocks.TryRemove(name, out _);
                    }
                }
            }
        }
    }
}
