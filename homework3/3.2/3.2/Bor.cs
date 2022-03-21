using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BorSpace;

public class Bor
{
    private class Node
    {
        public Dictionary<byte, Node> dictionary = new Dictionary<byte, Node>();
        public bool isTerminal;
        public int index;
        public int countStringsContainPrefix = 0;
    }
    private int size = 0;
    private Node root = new Node();
    public bool Add(string element)
    {
        if (Contain(element))
        {
            return false;
        }
        Node current = root;
        for (int i = 0; i < element.Length; i++)
        {
            if (current == null)
            {
                return false;
            }
            char symbol = element[i];
            if (current != null && !current.dictionary.ContainsKey((byte)symbol))
            {
                current.dictionary[(byte)symbol] = new Node();
               // current.dictionary[(byte)symbol].index = size;
            }
            if (current != null && current.dictionary.ContainsKey((byte)symbol))
            {
                current = current.dictionary[(byte)symbol];
                current.countStringsContainPrefix++;
            }
        }
        if (current != null)
        {
            current.isTerminal = true;
        }
        size++;
        return true;
    }
    public bool Contain(string element)
    {
         Node current = root;
         for (int i = 0; i < element.Length; i++)
         {   
             if (!current.dictionary.ContainsKey((byte)element[i]))
             {
                 return false;
             }
             current = current.dictionary[(byte)element[i]];
             if (current == null)
             {
                 return false;
             }
         }
         return current.isTerminal;
    }

     public bool Remove(string element)
     {
         if (!Contain(element))
         {
             return false;
         }
         Node current = root;
        for (int i = 0; i < element.Length; i++)
        {
            if (current == null)
            {
                return false;
            }
            char symbol = element[i];
            if (current.dictionary[(byte)symbol] == null)
            {
                return false;
            }
            if (current.dictionary[(byte)symbol].countStringsContainPrefix > 1)
            {
                current.dictionary[(byte)symbol].countStringsContainPrefix--;
                current = current.dictionary[(byte)symbol];
            }
            else
            {
                var temporary = current.dictionary[(byte)symbol];
                current.dictionary[(byte)symbol] = null;
                current = temporary;

            }
        }
         size--;
         return true;
     }

     public int HowManyStartsWithPrefix(string prefix)
     {
         Node current = root;
         for (int i = 0; i < prefix.Length; i++)
         {
             var symbol = prefix[i];
             if (current != null)
             {
                 current = current.dictionary[(byte)symbol];
             }
             else
             {
                 return 0;
             }
         }
         return current.countStringsContainPrefix;
     }

     public int Size()
     {
         return size;
     }

     public int Index(string element)
     {   
         if (!Contain(element))
         {
             return -1;
         }
         Node current = root;
         for (int i = 0; i < element.Length; i++)
         {
             current = current.dictionary[(byte)element[i]];
         }
         return current.index;
     }

  /*  static void Main(string[] args)
    {
        Bor bor = new Bor();
        // string s = "C:/Users/Acer/source/repos/ConsoleApp1/text.txt";
        //string[] data = File.ReadAllLines(s);
        //foreach(var c in data)
        ///{
        //     bor.Add(c);
        //}

          bor.Add("he");
          bor.Add("his");
          bor.Add("she");
          bor.Add("hers");
          bor.Add("his")
         bor.Add("so");
         //bor.Contain("jhfijhifhdihf");
        //bor.Index("Leo");

    }
  */
}