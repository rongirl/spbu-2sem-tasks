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
        public Node[] next = new Node[26];
        public bool isTerminal;
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
            if (current.next[symbol - 'a'] == null)
            {
                current.next[symbol - 'a'] = new Node();
            }
            if (current != null)
            {
                current = current.next[symbol - 'a'];
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
            current = current.next[element[i] - 'a'];
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
            if (current.next[symbol - 'a'] == null)
            {
                return false;
            }
            if (current.next[symbol - 'a'].countStringsContainPrefix > 1)
            {
                current.next[symbol - 'a'].countStringsContainPrefix--;
                current = current.next[symbol - 'a'];
            }
            else
            {
                var temporary = current.next[symbol - 'a'];
                current.next[symbol - 'a'] = null;
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
                current = current.next[symbol - 'a'];
            }
            else
            {
                return 0;
            }
        }
        return current.countStringsContainPrefix;
    }
    static void Main(string[] args)
    {
        Bor bor = new Bor();
        bor.Add("mik");
        bor.Remove("mik");
    }
}