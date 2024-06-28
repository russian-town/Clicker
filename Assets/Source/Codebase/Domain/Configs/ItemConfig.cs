using UnityEngine;

namespace Source.Codebase.Domain.Configs
{
    [CreateAssetMenu(fileName = "New Item", menuName = ("Clicker/New Item"), order = 59)]
    public class ItemConfig : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public float Price { get; private set; }
        [field: SerializeField] public int ClickForce { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public ClickType ClickType { get; private set; }
    }
}
