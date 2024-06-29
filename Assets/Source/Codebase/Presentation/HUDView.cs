using Source.Codebase.Presentation.Abstract;
using UnityEngine;

namespace Source.Codebase.Presentation
{
    public class HUDView : ViewBase
    {
        [field: SerializeField] public Transform ButtonGroup { get; private set; }
        [field: SerializeField] public Canvas Canvas { get; private set; }
    }
}
