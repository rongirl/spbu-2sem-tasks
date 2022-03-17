using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1
{
    public class StackList : IStack
    {
        private StackElement? head;
        private class StackElement
        {
            public double value;
            public StackElement? next;
        }
        public bool IsEmpty()
        {
            return head == null;
        }
        public void Push(double value)
        {
            head = new StackElement { value = value, next = head };
        }
        public double Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Стек пуст");
            }
            if (head == null)
            {
                throw new Exception("Null");
            }
            double value = head.value;
            head = head.next;
            return value;
        }
    }
}