using UnityEngine;

namespace Factory 
{
    public interface IFactory<T> where T : IPickable
    {
        public T Create(Vector2 position, Quaternion rotation);
    }
}
