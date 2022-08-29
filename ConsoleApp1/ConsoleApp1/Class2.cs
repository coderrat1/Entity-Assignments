using System;
using System.Collections.Generic;

namespace Asssignments_C_sharp
{
    class Lib_Books
    {
        enum bookType { Magazine = 0, Novel = 1, RefernceBook = 2, Miscellenious = 3 }
        public static void Main(string[] args)
        {
            Books Book1;
            Books Book2;
            Books Book3;

            Book1.bookID = 210;
            Book1.title = "The Alchemist";
            Book1.price = 259;
            //string type = Convert.ToString((int)bookType.Magazine);
            Enum type = bookType.Novel;

            //Book1 specification
            Console.WriteLine("Book1 ID: {0}", Book1.bookID);
            Console.WriteLine("Book1 Title: {0}", Book1.title);
            Console.WriteLine("Book1 Price: {0}", Book1.price);
            Console.WriteLine("Book1 bookType : {0}", type.ToString());
        }
    }
    struct Books
    {
        public int bookID;
        public string title;
        public int price;
        //public void GetValue(int ID,string title,int price)
        //{
        //    this.bookID = ID;
        //    this.title = title;
        //    this.price = price;
        //}

    }
}