using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1
{
    public class StackArray : IStack
    {
        private double[] stackElements;
        private int size;
        public StackArray()
        {
            stackElements = new double[10];
            size = 0;
        }
        public void Push(double value)
        {
            if (size == stackElements.Length)
            {
                Resize();
            }
            stackElements[size] = value;
            size++;
        }
        public void Resize()
        {
            Array.Resize(ref stackElements, stackElements.Length * 2);
        }
        public bool IsEmpty()
        {
            return size == 0;
        }
        public double Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Стек пуст");
            }
            size--;
            double headStack = stackElements[size];
            stackElements[size] = 0;
            return headStack;
        }
    }
}
