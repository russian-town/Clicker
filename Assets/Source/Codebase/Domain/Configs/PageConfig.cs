using Source.Codebase.Presentation.Abstract;
using UnityEngine;

namespace Source.Codebase.Domain.Configs
{
    [CreateAssetMenu(fileName = "New Page Config", menuName = ("Clicker/New Page Config"), order = 59)]
    public class PageConfig : ScriptableObject
    {
        [field: SerializeField] public PageIndex PageIndex;
        [field: SerializeField] public Sprite ButtonIcon;
    }
}
