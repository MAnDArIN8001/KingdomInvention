using UnityEngine;

namespace Factory 
{
    public interface IFactory<T>
    {
        public T Create(Vector2 position, Quaternion rotation);
    }
}
