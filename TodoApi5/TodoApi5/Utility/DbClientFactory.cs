using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime;

namespace TodoApi5.Utility
{
    public class DbClientFactory<T>
    {
        private static Lazy<T> _factoryLazy =
            new Lazy<T>(() =>
               (T)Activator.CreateInstance(typeof(T)), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

        public static T Instance
        {
            get
            {
                return _factoryLazy.Value;
            }
        }
    }
}
