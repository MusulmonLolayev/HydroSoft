// Decompiled with JetBrains decompiler
// Type: HydroDemo.Models.RiverClass
// Assembly: HydroDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E6B423-C642-4D32-8211-26843BE94D82
// Assembly location: D:\Programmes\Projects\C#\HydroDemo\Debug — копия\HydroDemo.exe

namespace HydroDemo.Models
{
  public class RiverClass
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public int Number { get; set; }

    public byte Status { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
