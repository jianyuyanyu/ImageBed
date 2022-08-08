﻿namespace North.Services.Storage
{
    public interface IStorage<T>
    {
        void Add(T item);   
        Task AddAsync(T item);
        void Clear();
        Task ClearAsync();
        void Remove(T item);
        Task RemoveAsync(T item);
        void Update(T item);
        Task UpdateAsync(T item);
        T? Find(Predicate<T> predicate);
        Task<T?> FindAsync(Predicate<T> predicate);
        IEnumerable<T> Get(Predicate<T> predicate);
        Task<IEnumerable<T>> GetAsync(Predicate<T> predicate);
    }
}
