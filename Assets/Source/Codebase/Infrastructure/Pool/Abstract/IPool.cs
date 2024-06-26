namespace Source.Codebase.Infrastructure.Pool.Abstract
{
    public interface IPool
    {
        public void Release(IPoolable poolable);
        public void Clear();
        public IPoolable Get();
    }
}
