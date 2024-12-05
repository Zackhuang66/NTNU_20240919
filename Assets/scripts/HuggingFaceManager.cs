using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;


namespace Zack
{
    ///<summary>
    ///模型管理器
    ///</summary>
    public class HuggingFaceManager : MonoBehaviour
    {
        private string url = "https://api-inference.huggingface.co/models/sentence-transformers/all-MiniLM-L6-v2";
        private string key = "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";

        private TMP_InputField inputField;
        private string prompt;
        private string role = "你是一隻小狗";
        private string[] npcSentence;

        [SerializeField, Header("NPC 物件")]
        private NPCcontroller npc;

        //喚醒事件 : 遊戲播放後會執行一次
        private void Awake()
        {
            //尋找場景上名稱為 輸入欄位 的物件並存放到 inputField 變數內
            inputField = GameObject.Find("輸入欄位").GetComponent<TMP_InputField>();
            //當玩家結束編輯輸入欄位時會執行 PlayerInput方法
            inputField.onEndEdit.AddListener(PlayerInput);
            //獲得NPC要分析的語句
            npcSentence = npc.data.sentences;
        }

        private void PlayerInput(string input)
        {
            print($"<color=#3f3>{input}</color>");
            prompt = input;
            StartCoroutine(GetResult());
        }

        private IEnumerator GetResult()
        {
            var inputs = new         
            {
                source_sentence = prompt,
                sentences = npcSentence
            };

            //將資料轉為json 以及上傳的byte[] 格式
            string json = JsonConvert.SerializeObject(inputs);
            byte[] postData = Encoding.UTF8.GetBytes(json);
            //透過 POST 將資料傳遞到模型伺服器並設定標題
            UnityWebRequest request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(postData);
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + key);

            yield return request.SendWebRequest();

            print(request.result);
        }
    }
}
