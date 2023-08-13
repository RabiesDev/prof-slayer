# ProjectF Internal Cheat

## What is this
BepInExを使用したProjectF用Mod  
未完成品

## How to use
[Release](https://github.com/RabiesDev/projectf-internal-cheat/releases/)から`start_protected_game.exe`をダウンロードして  
ゲームフォルダ内にあるものと置き換えてください

[BepInEx](https://github.com/BepInEx/BepInEx)から最新バージョンをダウンロードして一度起動した後  
`plugins`フォルダにビルドしたDLLを入れて起動します

## How to build
プロジェクトフォルダ内に`Libraries`フォルダを作成し  
ゲームフォルダ内から以下のDLLをコピーして`Libraries`フォルダ内に貼り付けてください  
その後プロジェクトを開いてビルドを実行します

```
ACTk.Runtime.dll
Assembly-CSharp.dll
Barracuda.Foundation.dll
DestMath.dll
Ganymede.Api.dll
Ganymede.Common.dll
Ganymede.IntegrityCheck.Runtime.dll
Ganymede.Recoiling.dll
netstandard.dll
Photon3Unity3D.dll
PhotonRealtime.dll
PhotonUnityNetworking.dll
UniTask.dll
```

## Notes
このツールの使用は自己責任です
