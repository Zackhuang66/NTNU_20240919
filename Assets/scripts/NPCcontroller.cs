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
        [SerializeField, Header("�ʵe�Ѽ�")]
        private string[] parameters =
        {
            "Ĳ�o����","Ĳ�o���m","Ĳ�o���`"
        };

        private Animator ani;

        public DataNPC data => dataNPC;

        private void Awake()
        {
            ani = GetComponent<Animator>();
        }
        public void PlayAnimation(int index)
        {
            ani.SetTrigger(parameters[index]);
        }
    }
}
