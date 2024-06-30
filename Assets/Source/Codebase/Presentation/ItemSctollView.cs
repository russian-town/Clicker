using Source.Codebase.Presentation.Abstract;
using UnityEngine;

namespace Source.Codebase.Presentation
{
    public class ItemSctollView : ViewBase
    {
       [field: SerializeField] public Transform Content { get; private set; }
    }
}
