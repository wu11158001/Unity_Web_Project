using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

public class DatabaseController : UnitySingleton<DatabaseController>
{
    [DllImport("__Internal")]
    private static extern bool JS_WriteDataToDatabase(string refPathPtr, string jsonDataPtr, string objNamePtr = null, string callbackFunPtr = null);
    /// <summary>
    /// 寫入資料
    /// </summary>
    /// <param name="refPathPtr">資料路徑</param>
    /// <param name="data">資料</param>
    public void WriteDataToDatabase(string refPathPtr, Dictionary<string, object> data, string objNamePtr = null, string callbackFunPtr = null)
    {
        string jsonData = JsonConvert.SerializeObject(data);
        JS_WriteDataToDatabase(
            refPathPtr,
            jsonData,
            objNamePtr,
            callbackFunPtr);
    }

    [DllImport("__Internal")]
    private static extern bool JS_UpdateDataToDatabase(string refPathPtr, string jsonDataPtr, string objNamePtr = null, string callbackFunPtr = null);
    /// <summary>
    /// 修改與擴充資料
    /// </summary>
    /// <param name="refPathPtr">資料路徑</param>
    /// <param name="data">資料</param>
    public void UpdateDataToDatabase(string refPathPtr, Dictionary<string, object> data, string objNamePtr = null, string callbackFunPtr = null)
    {
        string jsonData = JsonConvert.SerializeObject(data);
        JS_UpdateDataToDatabase(
            refPathPtr,
            jsonData,
            objNamePtr,
            callbackFunPtr);
    }

    [DllImport("__Internal")]
    private static extern bool JS_ReadDataFromDatabase(string refPathPtr, string objNamePtr, string callbackFunPtr);
    /// <summary>
    /// 讀取資料
    /// </summary>
    /// <param name="refPathPtr">資料路徑</param>
    /// <param name="objNamePtr">回傳物件名</param>
    /// <param name="callbackFunPtr">回傳方法名</param>
    public void ReadDataFromDatabase(string refPathPtr, string objNamePtr, string callbackFunPtr)
    {
        JS_ReadDataFromDatabase(
            refPathPtr,
            objNamePtr,
            callbackFunPtr);
    }

    [DllImport("__Internal")]
    private static extern bool JS_RemoveDataFromDatabase(string refPathPtr, string objNamePtr, string callbackFunPtr);
    /// <summary>
    /// 移除資料
    /// </summary>
    /// <param name="refPathPtr">資料路徑</param>
    /// <param name="objNamePtr">回傳物件名</param>
    /// <param name="callbackFunPtr">回傳方法名</param>
    public void RemoveDataFromDatabase(string refPathPtr, string objNamePtr, string callbackFunPtr)
    {
        JS_RemoveDataFromDatabase(
            refPathPtr,
            objNamePtr,
            callbackFunPtr);
    }
}
