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
        [SerializeField, Header("動畫參數")]
        private string[] parameters =
        {
            "觸發攻擊","觸發防禦","觸發死亡"
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
