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

}