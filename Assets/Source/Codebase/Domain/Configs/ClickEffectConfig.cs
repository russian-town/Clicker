using UnityEngine;

namespace Source.Codebase.Domain.Configs
{
    [CreateAssetMenu(fileName = "New Click Effect Config", menuName = ("Clicker/New Click Effect Config"), order = 59)]
    public class ClickEffectConfig : ScriptableObject
    {
        [field: SerializeField] public float LifeTime { get; private set; }
        [field: SerializeField] public float FadeDuration { get; private set; }
    }
}
