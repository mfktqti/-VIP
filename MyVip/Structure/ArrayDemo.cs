using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Structure
{
    /// <summary>
    /// Array:连接的（节约空间，查找快），定长,增删慢
    /// 
    /// 
    /// </summary>
    public class ArrayDemo
    {
        public static void Show()
        {

            {
                Console.WriteLine("**************Array****************");

                int[] intArr = new int[3];
                intArr[0] = 123;
                string[] strArr = new string[2] { "123", "456" };

            }
            {
                Console.WriteLine("***********多维数组******************");
                int[,] a = new int[3, 4] {
                { 1,4,3,5},{ 1,4,3,5},{ 1,4,3,5}
                };

            }
            {
                Console.WriteLine("***********锯齿数组******************");

                int[][] a = new int[2][];
                a[0] = new int[] { 123,3,4};
                a[1] = new int[] { 123, 3, 4 ,4,5,};
                //ArrayList list = new `();
            }

        }

    }
}
