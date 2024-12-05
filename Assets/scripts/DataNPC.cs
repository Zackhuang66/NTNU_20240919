using UnityEngine;

namespace Zack
{
    /// <summary>
    /// NPC 資料
    /// </summary>
    [CreateAssetMenu(menuName = "Zack/NPC")]
    public class DataNPC : ScriptableObject
    {
        [Header("NPC AI 要分析的句子")]
        public string[] sentences;

    }

}
