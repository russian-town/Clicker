using System.Collections.Generic;

namespace Source.Codebase.Data
{
    [System.Serializable]
    public class PlayerData
    {
        public int CurrentClickForce;
        public int LastClickCount;
        public int CurrentLevel;
        public int NeedClickPerNextLevel;
        public List<ItemData> ItemsData;
    }
}
