using Source.Codebase.Presentation.Abstract;
using UnityEngine;

namespace Source.Codebase.Presentation.Windows
{
    public class UpgradeWindow : Window
    {
        [field: SerializeField] public Transform ItemContainer { get; private set; }
    }
}
