using DG.Tweening;
using Source.Codebase.Presentation.Abstract;
using TMPro;
using UnityEngine;

namespace Source.Codebase.Presentation
{
    public class PopUpWindowView : PopUpWindowBase 
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private float _duration = .35f;
        [SerializeField] private TMP_Text _descriptionText;

        public void StartMoveAnimation()
            => _rectTransform.DOLocalMoveY(350f, _duration);

        public void SetDescription(string description)
            => _descriptionText.text = description;
    }
}
