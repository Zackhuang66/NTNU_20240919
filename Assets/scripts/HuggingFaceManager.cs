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
    ///�ҫ��޲z��
    ///</summary>
    public class HuggingFaceManager : MonoBehaviour
    {
        private string url = "https://api-inference.huggingface.co/models/sentence-transformers/all-MiniLM-L6-v2";
        private string key = "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";

        private TMP_InputField inputField;
        private string prompt;
        private string role = "�A�O�@���p��";
        private string[] npcSentence;

        [SerializeField, Header("NPC ����")]
        private NPCcontroller npc;

        //����ƥ� : �C�������|����@��
        private void Awake()
        {
            //�M������W�W�٬� ��J��� ������æs��� inputField �ܼƤ�
            inputField = GameObject.Find("��J���").GetComponent<TMP_InputField>();
            //���a�����s���J���ɷ|���� PlayerInput��k
            inputField.onEndEdit.AddListener(PlayerInput);
            //��oNPC�n���R���y�y
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

            //�N����ରjson �H�ΤW�Ǫ�byte[] �榡
            string json = JsonConvert.SerializeObject(inputs);
            byte[] postData = Encoding.UTF8.GetBytes(json);
            //�z�L POST �N��ƶǻ���ҫ����A���ó]�w���D
            UnityWebRequest request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(postData);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + key);

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                print($"<color=#f33>�n�D����:{request.error}</color>");
            }
            else
            {
                string responseText = request.downloadHandler.text;
                var response = JsonConvert.DeserializeObject<List<float>>(responseText);
                print($"<color=#3f3>����:{responseText}</color>");

                if (response != null && response.Count > 0)
                {
                    int best = response.Select((value, index ) => new
                    {
                        Value = value, Index = index
                    }).OrderByDescending(x => x.Value).First().Index;

                    print($"<color=#77f>�̨ε��G:{npcSentence[best]}</color>");
                    npc.PlayAnimation(best); 
                }

            }
            print(request.result);
        }
    }
}
