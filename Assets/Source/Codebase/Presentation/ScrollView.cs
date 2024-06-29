using Source.Codebase.Presentation.Abstract;
using UnityEngine;

namespace Source.Codebase.Presentation
{
    public class ScrollView : ViewBase
    {
        [field: SerializeField] public Transform Container { get; private set; }
    }
}
