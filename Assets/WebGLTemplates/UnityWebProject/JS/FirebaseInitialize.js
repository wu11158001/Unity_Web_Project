// Firebase初始化
function initializeFirebase() {
    // Firebase 配置
    const firebaseConfig = {

        apiKey: "AIzaSyDVLaxjSoeSJStG4TgMp4a5qdXthE31wp8",
        authDomain: "unitywebproject.firebaseapp.com",
        databaseURL: "https://unitywebproject-default-rtdb.asia-southeast1.firebasedatabase.app",
        projectId: "unitywebproject",
        storageBucket: "unitywebproject.firebasestorage.app",
        messagingSenderId: "940434477550",
        appId: "1:940434477550:web:677bfc58e72913ffb73eff",
        measurementId: "G-XTGN73QBVQ"
    };

    // 初始化 Firebase
    const app = firebase.initializeApp(firebaseConfig);
    const db = firebase.firestore();
    const auth = firebase.auth();
    auth.useDeviceLanguage();
}

//當文檔加載完成時
document.addEventListener('DOMContentLoaded', (event) => {
    initializeFirebase();
});