using Source.Codebase.Presentation;
using Source.Codebase.Presentation.Pages;
using UnityEngine;

namespace Source.Codebase.Domain.Configs
{
    [CreateAssetMenu(fileName = "New Game Config", menuName = ("Clicker/New Game Config"), order = 59)]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public ClickEffectView ClickEffectViewTemplate { get; private set; }
        [field: SerializeField] public LevelView LevelViewTemplate { get; private set; }
        [field: SerializeField] public ClickHandlerView ClickHandlerViewTemplate { get; private set; }
        [field: SerializeField] public PageButtonView PageButtonViewTemplate { get; private set; }
        [field: SerializeField] public ItemView ItemViewTemplate { get; private set; }
        [field: SerializeField] public Camera CameraTemplate { get; private set; }
        [field: SerializeField] public HUDView HUDViewTemplate { get; private set; }
        [field: SerializeField] public WalletView WalletViewTemplate { get; private set; }
        [field: SerializeField] public PopUpWindowView PopUpWindowViewTemplate { get; private set; }
        [field: SerializeField] public PageScrollView PageScrollViewTemplate { get; private set; }
        [field: SerializeField] public StartPageView StartPageViewTemplate { get; private set; }
        [field: SerializeField] public ShopPageView ShopPageViewTemplate { get; private set; }
        [field: SerializeField] public NewsPageView NewsPageViewTemplate { get; private set; }
        [field: SerializeField] public ItemSctollView ItemSctollViewTemplate { get; private set; }
        [field: SerializeField] public ClickEffectConfig ClickEffectConfig { get; private set; }
        [field: SerializeField] public ItemConfig[] ItemConfigs { get; private set; }
        [field: SerializeField] public PageConfig[] PageConfigs { get; private set; }
        [field: SerializeField] public PopUpWindowConfig[] PopUpWindowConfigs { get; private set; }
    }
}
