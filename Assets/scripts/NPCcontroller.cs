using UnityEngine;

namespace Zack
{
    /// <summary>
    /// NPC 控制器
    /// </summary>>       
    public class NPCcontroller : MonoBehaviour
    {
        [SerializeField, Header("NPC資料")]
        private DataNPC dataNPC;

        private Animator ani;

        public DataNPC data => dataNPC;

        private void Awake()
        {
            ani = GetComponent<Animator>();
        }
    }
}
