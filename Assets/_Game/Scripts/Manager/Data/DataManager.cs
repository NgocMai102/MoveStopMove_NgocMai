using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using _Framework.Singleton;
using UnityEditor;

namespace _Game.Scripts.Data
{
    public class DataManager : Singleton<DataManager>
    {
        private void Awake()
        {
            LoadData();
//            DontDestroyOnLoad(gameObject);
        }

        public bool isLoaded = false;
        public PlayerData playerData;

        public const string PLAYER_DATA = "PLAYER_DATA";
        // public List<int> list_IDHairNonVIP;
        // public List<int> list_IDHairMan;
        // public List<int> list_IDHairWoman;
        // public List<int> list_IDBodyMan;
        // public List<int> list_IDBodyWoman;
        // public List<int> list_IDHairVIP;

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
            string d = PlayerPrefs.GetString(PLAYER_DATA, "");
            if (d != "")
            {
                playerData = JsonUtility.FromJson<PlayerData>(d);
            }
            else
            {
                playerData = new PlayerData();
            }

            //loadskin
            //load pet

            // sau khi hoàn thành tất cả các bước load data ở trên
            isLoaded = true;
            //FirebaseManager.Ins.OnSetUserProperty();  
        }

        public void SaveData()
        {
            if (!isLoaded) return;
            string json = JsonUtility.ToJson(playerData);
            PlayerPrefs.SetString(PLAYER_DATA, json);
        }

        public void ResetData()
        {
            
        }

        public int[] PantsStatus
        {
            set { playerData.pantsStatus = value; }
            get => playerData.pantsStatus;
        }

        public void SetPantsStatus(int i)
        {
            //playerData.pantsStatus[i] = 
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(DataManager))]
    public class DataManagerEditor : Editor
    {
        private DataManager _dataManager;
        
        private void OnEnable()
        {
            _dataManager = (DataManager) target;
        }
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            if (GUILayout.Button("Clear Data"))
            {
                //_dataManager.ResetData();
                //EditorUtility.SetDirty(_dataManager);
            }
            
            if (GUILayout.Button("Upload Data"))
            {
                //_dataManager.UploadDataOnInspector();
                //EditorUtility.SetDirty(_dataManager);
            }
            
            if (GUILayout.Button("Load Data Test"))
            {
                //_dataManager.LoadDataTest();
                //EditorUtility.SetDirty(_dataManager);
            }
        }
    }
#endif
}




