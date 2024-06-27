namespace Source.Codebase.Domain.Models
{
    public class ClickEffect
    {
        public ClickEffect(float lifeTime)
        {
            LifeTime = lifeTime;
        }

        public float LifeTime { get; private set; }
    }
}
