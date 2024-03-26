using UnityEditor;
using UnityEngine;
using _Framework.Singleton;

namespace _Game.Scripts.Manager.Data
{
    public class DataManager : Singleton<DataManager>
    {
        private const string PlayerDataKey = "PlayerData";

        [SerializeField] private bool isLoaded = false;
        [SerializeField] private PlayerData playerData;
        public PlayerData PlayerData => playerData;

        private void OnApplicationPause(bool pause)
        {
            SaveData();
            //FirebaseManager.Ins.OnSetUserProperty();
        }
        

        private void OnApplicationQuit()
        {
            SaveData();
            //FirebaseManager.Ins.OnSetUserProperty();
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
            
            isLoaded = true;
            //FirebaseManager.Ins.OnSetUserProperty();
        }

        public void SaveData()
        {
            if (!isLoaded)
            {
                return;
            }
            
            playerData.ConvertDictionaryToListData();
            string json = JsonUtility.ToJson(playerData);
            PlayerPrefs.SetString(PlayerDataKey, json);
        }

#if UNITY_EDITOR
        public void ResetData()
        {
            PlayerPrefs.DeleteAll();
            playerData = new PlayerData();
        }
        
        public void LoadDataTest()
        {
            playerData.LoadDataTest();
            
            isLoaded = true;
            SaveData();
        }
        
        public void UploadDataOnInspector()
        {
            playerData.ConvertDictionaryToListData();
        }
#endif
    }
    
#if UNITY_EDITOR
    [CustomEditor(typeof(DataManager))]
    public class DataManagerEditor : Editor
    {
        private DataManager dataManager;
        
        private void OnEnable()
        {
            dataManager = (DataManager) target;
        }
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            if (GUILayout.Button("Clear Data"))
            {
                dataManager.ResetData();
                EditorUtility.SetDirty(dataManager);
            }
            
            if (GUILayout.Button("Upload Data"))
            {
                dataManager.UploadDataOnInspector();
                EditorUtility.SetDirty(dataManager);
            }
            
            if (GUILayout.Button("Load Data Test"))
            {
                dataManager.LoadDataTest();
                EditorUtility.SetDirty(dataManager);
            }
        }
    }
#endif
}