using Source.Codebase.Presentation;
using UnityEngine;

namespace Source.Codebase.Domain.Configs
{
    [CreateAssetMenu(fileName = "New Scroll Config", menuName = ("Clicker/New Scroll Config"), order = 59)]
    public class ScrollConfig : ScriptableObject
    {
        [field: SerializeField] public ScrollType ScrollType { get; private set; }
        [field: SerializeField] public ScrollView ScrollViewTemplate { get; private set; }
        [field: SerializeField] public float MoveDuration { get; private set; }
    }
}
