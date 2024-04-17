using UnityEditor;
using UnityEngine;
using _Framework.Singleton;

namespace _Game.Scripts.Manager.Data
{
    public class DataManager : Singleton<DataManager>
    {
        private const string PlayerDataKey = "PlayerData";
        [SerializeField] private PlayerData playerData;
        public PlayerData PlayerData => playerData;

        private void OnApplicationPause(bool pause)
        {
            SaveData();
        }


        private void OnApplicationQuit()
        {
            SaveData();
        }

        public void LoadData()
        {
            string data = PlayerPrefs.GetString(PlayerDataKey, "");

            if (data != "")
            {
                playerData = JsonUtility.FromJson<PlayerData>(data);
            }
            else
            {
                playerData = new PlayerData();
            }
            playerData.OnInit();

        }

        public void SaveData()
        {
            playerData.ConvertDictionaryToListData();
            string json = JsonUtility.ToJson(playerData);
            PlayerPrefs.SetString(PlayerDataKey, json);
        }

#if UNITY_EDITOR
        [CustomEditor(typeof(DataManager))]
        public class DataManagerEditor : Editor
        {
            private DataManager _dataManager;

            private void OnEnable()
            {
                _dataManager = (DataManager)target;
            }

            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();

                if (GUILayout.Button("Clear Data"))
                {
                    PlayerPrefs.DeleteAll();
                    EditorUtility.SetDirty(_dataManager);
                }

                if (GUILayout.Button("Load Data Test"))
                {
                    PlayerPrefs.DeleteAll();
                    _dataManager.SaveData();
                    EditorUtility.SetDirty(_dataManager);
                }
            }
        }
#endif
    }
}