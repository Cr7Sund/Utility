using System;
using Cr7Sund.Collection.Generic;

namespace Cr7Sund.FrameWork.Util
{
    public class Factory<T>
    {
        private UnsafeUnOrderList<T> _containers = new();


        public void ReturnInstance(T instance)
        {
            _containers.Remove(instance);
        }

        public TInstance CreateInstance<TInstance>() where TInstance : T, new()
        {
            var instance = new TInstance();
            _containers.AddLast(instance);
            return instance;
        }
    }
}
