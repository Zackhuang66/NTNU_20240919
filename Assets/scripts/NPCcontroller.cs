using UnityEngine;

namespace Zack
{
    /// <summary>
    /// NPC ���
    /// </summary>>       
    public class NPCcontroller : MonoBehaviour
    {
        [SerializeField, Header("NPC���")]
        private DataNPC dataNPC;

        private Animator ani;

        public DataNPC data => dataNPC;

        private void Awake()
        {
            ani = GetComponent<Animator>();
        }
    }
}
