using UnityEngine;

namespace Zack
{
    /// <summary>
    /// NPC ���
    /// </summary>
    [CreateAssetMenu(menuName = "Zack/NPC")]
    public class DataNPC : ScriptableObject
    {
        [Header("NPC AI �n���R���y�l")]
        public string[] sentences;

    }

}
