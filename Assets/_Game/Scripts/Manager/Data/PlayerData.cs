using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Data
{
    public class KeyData
    {
        public const string PlayerHat = "playerHat";
        public const string PlayerPants = "playerPants";
        public const string PlayerAccessory = "playerAccessory";
        public const string PlayerSkin = "playerSkin";
    }
    [System.Serializable]
    public class PlayerData
    {
        // [Header("--------- Game Setting ---------")]
        // public bool isNew = true;
        // public bool isMusic = true;
        public bool isSound = true;
        public bool isVibrate = true;
        public bool isNoAds = false;
        // public int starRate = -1;
        // public float volumeSound = 80f;


        [Header("--------- Game Params ---------")]
        public int gold = 0;
        //public int cup = 0;
        public int level = 0;//Level hiện tại
        //public int season = 0;
        public int idSkin = 0; //Skin

        public int[] pantsStatus = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
        public int[] hairStatus = new int[]{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        public int[] accessoryStatus = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
        public int[] skinStatus = new int[] { 1, 0, 0, 0, 0, 0 };
        
      

        // [Header("--------- Firebase ---------")]
        // public string timeInstall;//Thời điểm cài game
        // public int timeLastOpen;//Thời điểm cuối cùng mở game. Tính số ngày kể từ 1/1/1970
        // public int timeInstallforFirebase; //Dùng trong hàm bắn Firebase UserProperty. Số ngày tính từ ngày 1/1/1970
        // public int daysPlayed = 0;//Số ngày đã User có mở game lên
        // public int sessionCount = 0;//Tống số session
        // public int playTime = 0;//Tổng số lần nhấn play game
        // public int playTime_Session = 0;//Số lần nhấn play game trong 1 session
        // public int dieCount_levelCur = 0;//Số lần chết tại level hiện tại
        // public int firstDayLevelPlayed = 0;  //Số level đã chơi ở ngày đầu tiên

        //--------- Others ---------
        //
        // public int rw_watched = 0;
        // public int inter_watched = 0;
        // public int level_played_1stday = 0;
    }
}

