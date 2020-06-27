// Decompiled with JetBrains decompiler
// Type: HydroDemo.Metods.WriteXml
// Assembly: HydroDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E6B423-C642-4D32-8211-26843BE94D82
// Assembly location: D:\Programmes\Projects\C#\HydroDemo\Debug — копия\HydroDemo.exe

using HydroDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace HydroDemo.Metods
{
  public static class WriteXml
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

    public static uint InsertCopyDBClass(CopyDBClass newElement)
    {
      XDocument xmlDocument = WriteXml.GetXMLDocument("Data\\CopyDBList.xml");
      if (xmlDocument == null)
      {
        new XDocument(new XDeclaration("1.0", "utf-8", "Yes"), new object[3]
        {
          (object) new XProcessingInstruction("xml-stylesheet", "href='Style.css' title='Zarplata' type='txt/css'"),
          (object) new XComment("Документ для резервное копирование баз данных"),
          (object) new XElement((XName) "CopyDocument")
        }).Save("Data\\CopyDBList.xml");
        xmlDocument = WriteXml.GetXMLDocument("Data\\CopyDBList.xml");
      }
      List<XElement> list = xmlDocument.Element((XName) "CopyDocument").Elements().ToList<XElement>();
      uint num1 = 0;
      for (int index = 0; index < list.Count; ++index)
      {
        uint num2 = uint.Parse(list[index].Element((XName) "Id").Value.ToString());
        if (num1 < num2)
          num1 = num2;
      }
      uint num3 = num1 + 1U;
      newElement.Id = (int) num3;
      XElement xelement = new XElement((XName) "CopyDb", new object[3]
      {
        (object) new XElement((XName) "Id", (object) newElement.Id),
        (object) new XElement((XName) "Display", (object) newElement.Display),
        (object) new XElement((XName) "Sana", (object) newElement.Vaqt.ToString())
      });
      xmlDocument.Descendants((XName) "CopyDocument").First<XElement>().Add((object) xelement);
      xmlDocument.Save("Data\\CopyDBList.xml");
      return num3;
    }

    public static void DeleteCopyDBClass(string Id)
    {
      XDocument xmlDocument = WriteXml.GetXMLDocument("Data\\CopyDBList.xml");
      if (xmlDocument == null)
        return;
      List<XElement> list1 = xmlDocument.Element((XName) "CopyDocument").Elements().ToList<XElement>();
      List<XElement> xelementList = new List<XElement>();
      List<XElement> list2 = list1.Where<XElement>((Func<XElement, bool>) (x => x.Element((XName) nameof (Id)).Value != Id)).Select<XElement, XElement>((Func<XElement, XElement>) (x => x)).ToList<XElement>();
      XDocument xdocument = new XDocument(new XDeclaration("1.0", "utf-8", "Yes"), new object[3]
      {
        (object) new XProcessingInstruction("xml-stylesheet", "href='Style.css' title='Zarplata' type='txt/css'"),
        (object) new XComment("Документ для резервное копирование баз данных"),
        (object) new XElement((XName) "CopyDocument")
      });
      xdocument.Descendants((XName) "CopyDocument").First<XElement>().Add((object) list2);
      xdocument.Save("Data\\CopyDBList.xml");
    }
  }
}
