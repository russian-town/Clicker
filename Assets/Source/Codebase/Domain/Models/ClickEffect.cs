namespace Source.Codebase.Domain.Models
{
    public class ClickEffect
    {
        public ClickEffect(float lifeTime, float fadeDuration, float clickForce)
        {
            LifeTime = lifeTime;
            FadeDuration = fadeDuration;
            ClickForce = clickForce;
        }

        public float LifeTime { get; private set; } = 1f;
        public float FadeDuration { get; private set; } = 1f;
        public float ClickForce { get; private set; } = 1f;
    }
}
