using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class Storage
    {
        Dictionary<Type, Dictionary<Guid, Object>> repository =
            new Dictionary<Type, Dictionary<Guid, Object>>();

        public T Create<T>()
            where T : class, new()
        {
            T repositoryObject = new T();
            if (!repository.ContainsKey(typeof(T)))
                repository[typeof(T)] = new Dictionary<Guid, Object>(); ;
            repository[typeof(T)][Guid.NewGuid()] = repositoryObject;
            return repositoryObject;
        }

        public IEnumerable<KeyValuePair<Guid, T>> PairType<T>()
            where T : class
        {
            if (repository.ContainsKey(typeof(T)))
                return repository[typeof(T)].Select(p => new KeyValuePair<Guid, T>(p.Key, p.Value as T));
            return Enumerable.Empty<KeyValuePair<Guid, T>>();
        }

        public T ObjectGuid<T>(Guid id)
            where T : class
        {
            object result;
            if (repository.ContainsKey(typeof(T)))
                if (repository[typeof(T)].TryGetValue(id, out result))
                    return result as T;
            return null;
        }
    }
}
