// Decompiled with JetBrains decompiler
// Type: HydroDemo.Metods.ReadXml
// Assembly: HydroDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E6B423-C642-4D32-8211-26843BE94D82
// Assembly location: D:\Programmes\Projects\C#\HydroDemo\Debug — копия\HydroDemo.exe

using HydroDemo.Models;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace HydroDemo.Metods
{
  internal class ReadXml
  {
    private static XDocument GetXMLDocument(string path)
    {
      try
      {
        return XDocument.Load(path);
      }
      catch (Exception ex)
      {
        return (XDocument) null;
          
      }
    }

    public static List<CopyDBClass> SelectCopyDBClass(string where, string qiymat)
    {
      List<CopyDBClass> copyDbClassList = new List<CopyDBClass>();
      XDocument xmlDocument = ReadXml.GetXMLDocument("Data\\CopyDBList.xml");
      if (xmlDocument == null)
        return (List<CopyDBClass>) null;
      XElement xelement = xmlDocument.Element((XName) "CopyDocument");
      if (where != null && qiymat != null)
      {
        foreach (XElement element in xelement.Elements())
        {
          if (element.Element((XName) where).Value.ToString() == qiymat)
            copyDbClassList.Add(new CopyDBClass()
            {
              Id = int.Parse(element.Element((XName) "Id").Value),
              Vaqt = DateTime.Parse(element.Element((XName) "Sana").Value),
              Display = element.Element((XName) "Display").Value
            });
        }
      }
      else
      {
        foreach (XElement element in xelement.Elements())
          copyDbClassList.Add(new CopyDBClass()
          {
            Id = int.Parse(element.Element((XName) "Id").Value),
            Vaqt = DateTime.Parse(element.Element((XName) "Sana").Value),
            Display = element.Element((XName) "Display").Value
          });
      }
      return copyDbClassList;
    }
  }
}
