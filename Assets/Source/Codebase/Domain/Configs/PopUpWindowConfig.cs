using UnityEngine;

namespace Source.Codebase.Domain.Configs
{
    [CreateAssetMenu(fileName = "New Pop-Up Config", menuName = ("Clicker/New Pop-Up Config"), order = 59)]
    public class PopUpWindowConfig : ScriptableObject
    {
        [SerializeField][TextArea] private string _description;
        public string Description => _description;
    }
}
