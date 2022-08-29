using System;
using System.Collections;


namespace ExceptionHandling
{
    public class Exception2
    {
        public static void Main()
        {
            try
            {
                Stack st = new Stack();
                st.Push(1);
                st.Push(3);
                st.Push(5);
                st.Push(7);
                st.Push(10);
                foreach (Object obj in st)
                {
                    Console.WriteLine(obj);
                }
                Console.WriteLine("Total number of elements in stack : {0}", st.Count);
                //st.Pop();
                if (st.Count <= 0)
                {
                    throw new StackException("Stack is empty");
                }
                if (st.Count >= 5)
                {
                    throw new StackException("Stack is full you cant push elements");
                }
            }
            catch (StackException ex)
            {
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }
        }
        class StackException : Exception
        {
            public StackException() : base()
            {

            }
            public StackException(string message) : base(message)
            {

            }
        }
    }
}