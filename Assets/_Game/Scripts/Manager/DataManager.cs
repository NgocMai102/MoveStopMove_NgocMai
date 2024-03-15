using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using _Framework.Singleton;

public class DataManager : Singleton<DataManager>
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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

    //private void OnApplicationPause(bool pause) { SaveData(); FirebaseManager.Ins.OnSetUserProperty();  }
    //private void OnApplicationQuit() { SaveData(); FirebaseManager.Ins.OnSetUserProperty();  }


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
}


[System.Serializable]
public class PlayerData
{
    [Header("--------- Game Setting ---------")]
    public bool isNew = true;
    public bool isMusic = true;
    public bool isSound = true;
    public bool isVibrate = true;
    public bool isNoAds = false;
    public int starRate = -1;
    public float volumeSound = 80f;


    [Header("--------- Game Params ---------")]
    public int gold = 0;
    public int cup = 0;
    public int level = 0;//Level hiện tại
    public int season = 0;
    public int idSkin = 0; //Skin
    // public bool[] skinStatus = new bool[]{true, true,  true, true, true, true, true, 
    // true, true, true, true, true, true, true, 
    // true, true, true, true, true, true, true, true, true, true};
    // public bool[] skinStatus = new bool[]{true, false,  false, false, false, false, false, 
    // false, false, false, false, false, false, false, false,
    // false, false, false, false, false, false, false, false, false, false, false, false};
    
    public bool[] Hair = new bool[]{true, false,  false, false, false, false, false, 
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false, false, false, false, false};


    [Header("--------- Firebase ---------")]
    public string timeInstall;//Thời điểm cài game
    public int timeLastOpen;//Thời điểm cuối cùng mở game. Tính số ngày kể từ 1/1/1970
    public int timeInstallforFirebase; //Dùng trong hàm bắn Firebase UserProperty. Số ngày tính từ ngày 1/1/1970
    public int daysPlayed = 0;//Số ngày đã User có mở game lên
    public int sessionCount = 0;//Tống số session
    public int playTime = 0;//Tổng số lần nhấn play game
    public int playTime_Session = 0;//Số lần nhấn play game trong 1 session
    public int dieCount_levelCur = 0;//Số lần chết tại level hiện tại
    public int firstDayLevelPlayed = 0;  //Số level đã chơi ở ngày đầu tiên

    //--------- Others ---------

    public int rw_watched = 0;
    public int inter_watched = 0;
    public int level_played_1stday = 0;
}