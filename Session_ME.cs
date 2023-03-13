// Decompiled with JetBrains decompiler
// Type: Session_ME
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class Session_ME : ISession
{
  protected static Session_ME instance = new Session_ME();
  private static NetworkStream dataStream;
  private static BinaryReader dis;
  private static BinaryWriter dos;
  public static IMessageHandler messageHandler;
  public static bool isMainSession = true;
  private static TcpClient sc;
  public static bool connected;
  public static bool connecting;
  private static Session_ME.Sender sender = new Session_ME.Sender();
  public static Thread initThread;
  public static Thread collectorThread;
  public static Thread sendThread;
  public static int sendByteCount;
  public static int recvByteCount;
  private static bool getKeyComplete;
  public static sbyte[] key = (sbyte[]) null;
  private static sbyte curR;
  private static sbyte curW;
  private static int timeConnected;
  private long lastTimeConn;
  public static string strRecvByteCount = string.Empty;
  public static bool isCancel;
  private string host;
  private int port;
  public static int count;
  public static MyVector recieveMsg = new MyVector();

  public Session_ME() => Debug.Log((object) "init Session_ME");

  public void clearSendingMessage() => Session_ME.sender.sendingMessage.Clear();

  public static Session_ME gI()
  {
    if (Session_ME.instance == null)
      Session_ME.instance = new Session_ME();
    return Session_ME.instance;
  }

  public bool isConnected() => Session_ME.connected;

  public void setHandler(IMessageHandler msgHandler) => Session_ME.messageHandler = msgHandler;

  public void connect(string host, int port)
  {
    if (Session_ME.connected || Session_ME.connecting)
      return;
    if (Session_ME.isMainSession)
      ServerListScreen.testConnect = -1;
    this.host = host;
    this.port = port;
    Session_ME.getKeyComplete = false;
    Session_ME.sc = (TcpClient) null;
    Debug.Log((object) "connecting...!");
    Debug.Log((object) ("host: " + host));
    Debug.Log((object) ("port: " + (object) port));
    Session_ME.initThread = new Thread(new ThreadStart(this.NetworkInit));
    Session_ME.initThread.Start();
  }

  private void NetworkInit()
  {
    Session_ME.isCancel = false;
    Session_ME.connecting = true;
    Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
    Session_ME.connected = true;
    try
    {
      this.doConnect(this.host, this.port);
      Session_ME.messageHandler.onConnectOK(Session_ME.isMainSession);
    }
    catch (Exception ex)
    {
      if (Session_ME.messageHandler == null)
        return;
      this.close();
      Session_ME.messageHandler.onConnectionFail(Session_ME.isMainSession);
    }
  }

  public void doConnect(string host, int port)
  {
    Session_ME.sc = new TcpClient();
    Session_ME.sc.Connect(host, port);
    Session_ME.dataStream = Session_ME.sc.GetStream();
    Session_ME.dis = new BinaryReader((Stream) Session_ME.dataStream, (Encoding) new UTF8Encoding());
    Session_ME.dos = new BinaryWriter((Stream) Session_ME.dataStream, (Encoding) new UTF8Encoding());
    new Thread(new ThreadStart(Session_ME.sender.run)).Start();
    Session_ME.MessageCollector messageCollector = new Session_ME.MessageCollector();
    Cout.LogError("new -----");
    Session_ME.collectorThread = new Thread(new ThreadStart(messageCollector.run));
    Session_ME.collectorThread.Start();
    Session_ME.timeConnected = Session_ME.currentTimeMillis();
    Session_ME.connecting = false;
    Session_ME.doSendMessage(new Message(-27));
  }

  public void sendMessage(Message message)
  {
    ++Session_ME.count;
    Res.outz("SEND MSG: " + (object) message.command);
    Session_ME.sender.AddMessage(message);
  }

  private static void doSendMessage(Message m)
  {
    sbyte[] data = m.getData();
    try
    {
      if (Session_ME.getKeyComplete)
      {
        sbyte num = Session_ME.writeKey(m.command);
        Session_ME.dos.Write(num);
      }
      else
        Session_ME.dos.Write(m.command);
      if (data != null)
      {
        int length = data.Length;
        if (Session_ME.getKeyComplete)
        {
          int num1 = (int) Session_ME.writeKey((sbyte) (length >> 8));
          Session_ME.dos.Write((sbyte) num1);
          int num2 = (int) Session_ME.writeKey((sbyte) (length & (int) byte.MaxValue));
          Session_ME.dos.Write((sbyte) num2);
        }
        else
          Session_ME.dos.Write((ushort) length);
        if (Session_ME.getKeyComplete)
        {
          for (int index = 0; index < data.Length; ++index)
          {
            sbyte num = Session_ME.writeKey(data[index]);
            Session_ME.dos.Write(num);
          }
        }
        Session_ME.sendByteCount += 5 + data.Length;
      }
      else
      {
        if (Session_ME.getKeyComplete)
        {
          int num3 = 0;
          int num4 = (int) Session_ME.writeKey((sbyte) (num3 >> 8));
          Session_ME.dos.Write((sbyte) num4);
          int num5 = (int) Session_ME.writeKey((sbyte) (num3 & (int) byte.MaxValue));
          Session_ME.dos.Write((sbyte) num5);
        }
        else
          Session_ME.dos.Write((ushort) 0);
        Session_ME.sendByteCount += 5;
      }
      Session_ME.dos.Flush();
    }
    catch (Exception ex)
    {
      Debug.Log((object) ex.StackTrace);
    }
  }

  public static sbyte readKey(sbyte b)
  {
    sbyte[] key = Session_ME.key;
    int curR;
    Session_ME.curR = (sbyte) ((curR = (int) Session_ME.curR) + 1);
    int index = curR;
    sbyte num = (sbyte) ((int) key[index] & (int) byte.MaxValue ^ (int) b & (int) byte.MaxValue);
    if ((int) Session_ME.curR >= Session_ME.key.Length)
      Session_ME.curR %= (sbyte) Session_ME.key.Length;
    return num;
  }

  public static sbyte writeKey(sbyte b)
  {
    sbyte[] key = Session_ME.key;
    int curW;
    Session_ME.curW = (sbyte) ((curW = (int) Session_ME.curW) + 1);
    int index = curW;
    sbyte num = (sbyte) ((int) key[index] & (int) byte.MaxValue ^ (int) b & (int) byte.MaxValue);
    if ((int) Session_ME.curW >= Session_ME.key.Length)
      Session_ME.curW %= (sbyte) Session_ME.key.Length;
    return num;
  }

  public static void onRecieveMsg(Message msg)
  {
    if (Thread.CurrentThread.Name == Main.mainThreadName)
      Session_ME.messageHandler.onMessage(msg);
    else
      Session_ME.recieveMsg.addElement((object) msg);
  }

  public static void update()
  {
    while (Session_ME.recieveMsg.size() > 0)
    {
      Message message = (Message) Session_ME.recieveMsg.elementAt(0);
      if (Controller.isStopReadMessage)
        break;
      if (message == null)
      {
        Session_ME.recieveMsg.removeElementAt(0);
        break;
      }
      Session_ME.messageHandler.onMessage(message);
      Session_ME.recieveMsg.removeElementAt(0);
    }
  }

  public void close() => Session_ME.cleanNetwork();

  private static void cleanNetwork()
  {
    Session_ME.key = (sbyte[]) null;
    Session_ME.curR = (sbyte) 0;
    Session_ME.curW = (sbyte) 0;
    try
    {
      Session_ME.connected = false;
      Session_ME.connecting = false;
      if (Session_ME.sc != null)
      {
        Session_ME.sc.Close();
        Session_ME.sc = (TcpClient) null;
      }
      if (Session_ME.dataStream != null)
      {
        Session_ME.dataStream.Close();
        Session_ME.dataStream = (NetworkStream) null;
      }
      if (Session_ME.dos != null)
      {
        Session_ME.dos.Close();
        Session_ME.dos = (BinaryWriter) null;
      }
      if (Session_ME.dis != null)
      {
        Session_ME.dis.Close();
        Session_ME.dis = (BinaryReader) null;
      }
      Session_ME.sendThread = (Thread) null;
      Session_ME.collectorThread = (Thread) null;
      if (!Session_ME.isMainSession)
        return;
      ServerListScreen.testConnect = 0;
    }
    catch (Exception ex)
    {
    }
  }

  public static int currentTimeMillis() => Environment.TickCount;

  public static byte convertSbyteToByte(sbyte var) => var > (sbyte) 0 ? (byte) var : (byte) ((uint) var + 256U);

  public static byte[] convertSbyteToByte(sbyte[] var)
  {
    byte[] numArray = new byte[var.Length];
    for (int index = 0; index < var.Length; ++index)
      numArray[index] = var[index] <= (sbyte) 0 ? (byte) ((uint) var[index] + 256U) : (byte) var[index];
    return numArray;
  }

  public class Sender
  {
    public List<Message> sendingMessage;

    public Sender() => this.sendingMessage = new List<Message>();

    public void AddMessage(Message message) => this.sendingMessage.Add(message);

    public void run()
    {
      while (Session_ME.connected)
      {
        try
        {
          if (Session_ME.getKeyComplete)
          {
            while (this.sendingMessage.Count > 0)
            {
              Session_ME.doSendMessage(this.sendingMessage[0]);
              this.sendingMessage.RemoveAt(0);
            }
          }
          try
          {
            Thread.Sleep(5);
          }
          catch (Exception ex)
          {
            Cout.LogError(ex.ToString());
          }
        }
        catch (Exception ex)
        {
          Res.outz("error send message! ");
        }
      }
    }
  }

  private class MessageCollector
  {
    public void run()
    {
      try
      {
        while (Session_ME.connected)
        {
          Message message = this.readMessage();
          if (message != null)
          {
            try
            {
              if (message.command == (sbyte) -27)
                this.getKey(message);
              else
                Session_ME.onRecieveMsg(message);
            }
            catch (Exception ex)
            {
              Cout.println("LOI NHAN  MESS THU 1");
            }
            try
            {
              Thread.Sleep(5);
            }
            catch (Exception ex)
            {
              Cout.println("LOI NHAN  MESS THU 2");
            }
          }
          else
            break;
        }
      }
      catch (Exception ex)
      {
        Debug.Log((object) "error read message!");
        Debug.Log((object) ex.Message.ToString());
      }
      if (!Session_ME.connected)
        return;
      if (Session_ME.messageHandler != null)
      {
        if (Session_ME.currentTimeMillis() - Session_ME.timeConnected > 500)
          Session_ME.messageHandler.onDisconnected(Session_ME.isMainSession);
        else
          Session_ME.messageHandler.onConnectionFail(Session_ME.isMainSession);
      }
      if (Session_ME.sc == null)
        return;
      Session_ME.cleanNetwork();
    }

    private void getKey(Message message)
    {
      try
      {
        sbyte length = message.reader().readSByte();
        Session_ME.key = new sbyte[(int) length];
        for (int index = 0; index < (int) length; ++index)
          Session_ME.key[index] = message.reader().readSByte();
        for (int index = 0; index < Session_ME.key.Length - 1; ++index)
          Session_ME.key[index + 1] ^= Session_ME.key[index];
        Session_ME.getKeyComplete = true;
        GameMidlet.IP2 = message.reader().readUTF();
        GameMidlet.PORT2 = message.reader().readInt();
        GameMidlet.isConnect2 = message.reader().readByte() != (sbyte) 0;
        if (!Session_ME.isMainSession || !GameMidlet.isConnect2)
          return;
        GameCanvas.connect2();
      }
      catch (Exception ex)
      {
      }
    }

    private Message readMessage2(sbyte cmd)
    {
      int num1 = (int) Session_ME.readKey(Session_ME.dis.ReadSByte()) + 128;
      int num2 = (int) Session_ME.readKey(Session_ME.dis.ReadSByte()) + 128;
      int count = (((int) Session_ME.readKey(Session_ME.dis.ReadSByte()) + 128) * 256 + num2) * 256 + num1;
      Cout.LogError("SIZE = " + (object) count);
      sbyte[] numArray = new sbyte[count];
      Buffer.BlockCopy((Array) Session_ME.dis.ReadBytes(count), 0, (Array) numArray, 0, count);
      Session_ME.recvByteCount += 5 + count;
      int num3 = Session_ME.recvByteCount + Session_ME.sendByteCount;
      Session_ME.strRecvByteCount = (num3 / 1024).ToString() + "." + (object) (num3 % 1024 / 102) + "Kb";
      if (Session_ME.getKeyComplete)
      {
        for (int index = 0; index < numArray.Length; ++index)
          numArray[index] = Session_ME.readKey(numArray[index]);
      }
      return new Message(cmd, numArray);
    }

    private Message readMessage()
    {
      try
      {
        sbyte num1 = Session_ME.dis.ReadSByte();
        if (Session_ME.getKeyComplete)
          num1 = Session_ME.readKey(num1);
        if (num1 == (sbyte) -32 || num1 == (sbyte) -66 || num1 == (sbyte) 11 || num1 == (sbyte) -67 || num1 == (sbyte) -74 || num1 == (sbyte) -87 || num1 == (sbyte) 66)
          return this.readMessage2(num1);
        int count;
        if (Session_ME.getKeyComplete)
        {
          sbyte b1 = Session_ME.dis.ReadSByte();
          sbyte b2 = Session_ME.dis.ReadSByte();
          count = ((int) Session_ME.readKey(b1) & (int) byte.MaxValue) << 8 | (int) Session_ME.readKey(b2) & (int) byte.MaxValue;
        }
        else
          count = (int) Session_ME.dis.ReadSByte() & 65280 | (int) Session_ME.dis.ReadSByte() & (int) byte.MaxValue;
        sbyte[] numArray = new sbyte[count];
        Buffer.BlockCopy((Array) Session_ME.dis.ReadBytes(count), 0, (Array) numArray, 0, count);
        Session_ME.recvByteCount += 5 + count;
        int num2 = Session_ME.recvByteCount + Session_ME.sendByteCount;
        Session_ME.strRecvByteCount = (num2 / 1024).ToString() + "." + (object) (num2 % 1024 / 102) + "Kb";
        if (Session_ME.getKeyComplete)
        {
          for (int index = 0; index < numArray.Length; ++index)
            numArray[index] = Session_ME.readKey(numArray[index]);
        }
        return new Message(num1, numArray);
      }
      catch (Exception ex)
      {
        Debug.Log((object) ex.StackTrace.ToString());
      }
      return (Message) null;
    }
  }
}
