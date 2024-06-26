namespace Source.Codebase.Infrastructure.Pool.Abstract
{
    public interface IPoolable
    {
        public void SetPool(IPool pool);
        public void BackToPool();
    }
}
