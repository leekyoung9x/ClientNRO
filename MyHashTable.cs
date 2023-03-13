// Decompiled with JetBrains decompiler
// Type: MyHashTable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System.Collections;

public class MyHashTable
{
  public Hashtable h = new Hashtable();

  public object get(object k) => this.h[k];

  public void clear() => this.h.Clear();

  public IDictionaryEnumerator GetEnumerator() => this.h.GetEnumerator();

  public int size() => this.h.Count;

  public void put(object k, object v)
  {
    if (this.h.ContainsKey(k))
      this.h.Remove(k);
    this.h.Add(k, v);
  }

  public void remove(object k) => this.h.Remove(k);

  public void Remove(string key) => this.h.Remove((object) key);

  public bool containsKey(object key) => this.h.ContainsKey(key);
}
