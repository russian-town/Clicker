using Source.Codebase.Presentation;
using UnityEngine;

namespace Source.Codebase.Domain.Configs
{
    [CreateAssetMenu(fileName = "New Game Config", menuName = ("Clicker/New Game Config"), order = 59)]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public ClickEffectView ClickEffectViewTemplate { get; private set; }
        [field: SerializeField] public LevelView LevelViewTemplate { get; private set; }
        [field: SerializeField] public ClickHandlerView ClickHandlerViewTemplate { get; private set; }
        [field: SerializeField] public ItemView ItemViewTemplate { get; private set; }
        [field: SerializeField] public ItemConfig[] ItemConfigs { get; private set; }
    }
}
