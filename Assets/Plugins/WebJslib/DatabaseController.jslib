mergeInto(LibraryManager.library, {

    /* 寫入資料
        refPathPtr = 資料路徑
        jsonDataPtr = json資料
        objNamePtr = 回傳方法的物件名稱
        callbackFunPtr = 回傳方法名稱
    */
    JS_WriteDataToDatabase: function(refPathPtr, jsonDataPtr, objNamePtr = null, callbackFunPtr = null) {
        const refPath = UTF8ToString(refPathPtr);
        const jsonData = UTF8ToString(jsonDataPtr);
        const data = JSON.parse(jsonData);

        let gameObjectName = null;
        let callbackFunctionName = null;
        if (objNamePtr && callbackFunPtr) {
            gameObjectName = UTF8ToString(objNamePtr);
            callbackFunctionName = UTF8ToString(callbackFunPtr);
        }

        firebase.database().ref(refPath).set(data, (error) => {
            if (error) {
                console.error("The write failed... : " + error);

                if (gameObjectName != null && callbackFunctionName != null) {
                    window.unityInstance.SendMessage(gameObjectName, callbackFunctionName, "false");
                }
            } else {
                if (gameObjectName != null && callbackFunctionName != null) {
                    window.unityInstance.SendMessage(gameObjectName, callbackFunctionName, "true");
                }
            }
        });
    },

    /* 修改與擴充資料
        refPathPtr = 資料路徑
        jsonDataPtr = json資料
        objNamePtr = 回傳方法的物件名稱
        callbackFunPtr = 回傳方法名稱
    */
    JS_UpdateDataToDatabase: function(refPathPtr, jsonDataPtr, objNamePtr = null, callbackFunPtr = null) {
        const refPath = UTF8ToString(refPathPtr);
        const jsonData = UTF8ToString(jsonDataPtr);

        let gameObjectName = null;
        let callbackFunctionName = null;
        if (objNamePtr && callbackFunPtr) {
            gameObjectName = UTF8ToString(objNamePtr);
            callbackFunctionName = UTF8ToString(callbackFunPtr);
        }

        const data = JSON.parse(jsonData);
        firebase.database().ref(refPath).update(data, (error) => {
            if (error) {
                console.error("The update failed... : " + error);
                if (gameObjectName != null && callbackFunctionName != null) {
                    window.unityInstance.SendMessage(gameObjectName, callbackFunctionName, "false");
                }
            } else {
                if (gameObjectName != null && callbackFunctionName != null) {
                    window.unityInstance.SendMessage(gameObjectName, callbackFunctionName, "true");
                }
            }
        });
    },

    /* 讀取資料
        refPathPtr = 資料路徑
        objNamePtr = 回傳方法的物件名稱
        callbackFunPtr = 回傳方法名稱
    */
    JS_ReadDataFromDatabase: function(refPathPtr, objNamePtr, callbackFunPtr) {
        const refPath = UTF8ToString(refPathPtr);
        const gameObjectName = UTF8ToString(objNamePtr);
        const callbackFunctionName = UTF8ToString(callbackFunPtr);

        firebase.database().ref(refPath).once('value').then(function(snapshot) {
            const data = snapshot.val();
            const jsonData = JSON.stringify(data);
            window.unityInstance.SendMessage(gameObjectName, callbackFunctionName, jsonData);
        }).catch(function(error) {
            console.error("The read failed... : " + error);
            window.unityInstance.SendMessage(gameObjectName, callbackFunctionName, JSON.stringify({ error: error.message }));
        });
    },

    /* 移除資料
        refPathPtr = 資料路徑
        objNamePtr = 回傳方法的物件名稱
        callbackFunPtr = 回傳方法名稱
    */
    JS_RemoveDataFromDatabase: function(refPathPtr, objNamePtr, callbackFunPtr) {
        const refPath = UTF8ToString(refPathPtr);
        const gameObjectName = UTF8ToString(objNamePtr);
        const callbackFunctionName = UTF8ToString(callbackFunPtr);

        firebase.database().ref(refPath).remove().then(function() {
            window.unityInstance.SendMessage(gameObjectName, callbackFunctionName, JSON.stringify({ success: true }));
        }).catch(function(error) {
            console.error("The delete failed... : " + error);
            window.unityInstance.SendMessage(gameObjectName, callbackFunctionName, JSON.stringify({ error: error.message }));
        });
    },

});