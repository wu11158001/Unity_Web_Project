using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Newtonsoft.Json;

public class UserView : MonoBehaviour
{
    [SerializeField] Button Write_Btn, Update_Btn, Read_Btn, Remove_Btn;

    private void Start()
    {
        // 寫入資料按鈕
        Write_Btn.onClick.AddListener(() =>
        {
            string refPathPtr = "root/user_data/user_Jimmy";
            Dictionary<string, object> data = new()
            {
                { "name", "Jimmy"},
                { "age", 34},
            };

            DatabaseController.I.WriteDataToDatabase(
                refPathPtr: refPathPtr,
                data: data,
                objNamePtr: gameObject.name,
                callbackFunPtr: nameof(OnWriteDataCallback));
        });

        // 修改與擴充資料按鈕
        Update_Btn.onClick.AddListener(() =>
        {
            string refPathPtr = "root/user_data/user_Jimmy";
            Dictionary<string, object> data = new()
            {
                { "name", "伍鈞遠" },
                { "age", 34},
            };

            DatabaseController.I.UpdateDataToDatabase(
                refPathPtr: refPathPtr,
                data: data,
                objNamePtr: gameObject.name,
                callbackFunPtr: nameof(OnUpdateDataCallback));
        });

        // 讀取資料按鈕
        Read_Btn.onClick.AddListener(() =>
        {
            string refPathPtr = "root/user_data/user_Jimmy";
            DatabaseController.I.ReadDataFromDatabase(
                refPathPtr: refPathPtr,
                objNamePtr: gameObject.name,
                callbackFunPtr: nameof(OnReadDataCallback));
        });

        // 移除資料
        Remove_Btn.onClick.AddListener(() =>
        {
            string refPathPtr = "root/user_data/user_Jimmy";
            DatabaseController.I.RemoveDataFromDatabase(
                refPathPtr: refPathPtr,
                objNamePtr: gameObject.name,
                callbackFunPtr: nameof(OnRemoveDataCallback));
        });
    }

    /// <summary>
    /// 寫入資料回傳
    /// </summary>
    /// <param name="isSuccess">true=成功, false=失敗</param>
    public void OnWriteDataCallback(string isSuccess)
    {
        Debug.Log($"寫入資料回傳 : {isSuccess}");
    }

    /// <summary>
    /// 修改與擴充資料回傳
    /// </summary>
    /// <param name="isSuccess">true=成功, false=失敗</param>
    public void OnUpdateDataCallback(string isSuccess)
    {
        Debug.Log($"修改與擴充資料回傳 : {isSuccess}");
    }

    [System.Serializable]
    public class UserData
    {
        public string name;
        public int age;
        public string error;
    }
    /// <summary>
    /// 讀取資料回傳
    /// </summary>
    /// <param name="jsonData">Json資料</param>
    public void OnReadDataCallback(string jsonData)
    {
        Debug.Log("讀取資料 Json: " + jsonData);

        var data = JsonConvert.DeserializeObject<UserData>(jsonData);

        if (!string.IsNullOrEmpty(data.error))
        {
            Debug.LogError($"讀取資料錯誤 : {data.error}");
        }
        else
        {
            Debug.Log($"名稱 : {data.name}");
            Debug.Log($"年齡 : {data.age}");
        }
    }

    public class RemoveCallbackData
    {
        public bool success;
        public string error;
    }
    /// <summary>
    /// 移除資料
    /// </summary>
    /// <param name="jsonData"></param>
    public void OnRemoveDataCallback(string jsonData)
    {
        Debug.Log("移除資料 Json: " + jsonData);

        var data = JsonConvert.DeserializeObject<RemoveCallbackData>(jsonData);

        if (!string.IsNullOrEmpty(data.error) || !data.success)
        {
            Debug.LogError($"移除資料錯誤 : {data.error}");
        }
        else
        {
            Debug.Log("移除資料成功!");
        }
    }
}
