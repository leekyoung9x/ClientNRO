// Decompiled with JetBrains decompiler
// Type: IMessageHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public interface IMessageHandler
{
  void onMessage(Message message);

  void onConnectionFail(bool isMain);

  void onDisconnected(bool isMain);

  void onConnectOK(bool isMain);
}
