using System.Collections.Generic;

namespace Motocliclisti.Repo
{
    public interface Repo<T>
    {
        List<T> GetAll();
        void Add(T obj);
        void Remove(T obj);
        void Modify(T obj);
        T Search(T obj);
    }
}