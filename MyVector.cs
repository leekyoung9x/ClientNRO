// Decompiled with JetBrains decompiler
// Type: MyVector
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System.Collections;

public class MyVector
{
  private ArrayList a;

  public MyVector() => this.a = new ArrayList();

  public MyVector(string s) => this.a = new ArrayList();

  public MyVector(ArrayList a) => this.a = a;

  public void addElement(object o) => this.a.Add(o);

  public bool contains(object o) => this.a.Contains(o);

  public int size() => this.a == null ? 0 : this.a.Count;

  public object elementAt(int index) => index > -1 && index < this.a.Count ? this.a[index] : (object) null;

  public void set(int index, object obj)
  {
    if (index <= -1 || index >= this.a.Count)
      return;
    this.a[index] = obj;
  }

  public void setElementAt(object obj, int index)
  {
    if (index <= -1 || index >= this.a.Count)
      return;
    this.a[index] = obj;
  }

  public int indexOf(object o) => this.a.IndexOf(o);

  public void removeElementAt(int index)
  {
    if (index <= -1 || index >= this.a.Count)
      return;
    this.a.RemoveAt(index);
  }

  public void removeElement(object o) => this.a.Remove(o);

  public void removeAllElements() => this.a.Clear();

  public void insertElementAt(object o, int i) => this.a.Insert(i, o);

  public object firstElement() => this.a[0];

  public object lastElement() => this.a[this.a.Count - 1];
}
