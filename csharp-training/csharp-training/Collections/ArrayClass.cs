using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Models
{
    public class ArrayClass
    {
        public void Method_1()
        {
            int[] array = new[] { 1, 2, 3 };
            int[] array1 = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            string[] array2 = { "Monday", "Tuesday" };
            var index = Array.IndexOf(array2, "Monday", 1);
            Array.FindIndex(array2, 1, 1,x => x.StartsWith("M"));
            int[][] array3 = new int[5][] //jagged array
            {
                new int[] {1,2,3,5,6,7,8},
                new int[] {1,2,3},
                new int[] {1},
                new int[] {},
                new int[] {1,1,1,1,}
            };

            var array4 = new int[][]
            {
                new int[] {1,2,3,5,6,7,8},
                new int[] {1,2,3},
                new int[] {1},
                new int[] {},
                new int[] {1,1,1,1,},
                null
            };

            var array5 = new int[,]{ //rectangular arrays
                {1,2,3 },
                {1,2,3 },
                //{1,2,3, 4 } error
            };

            var array6 = new int[,,]
            {
                {
                    {1, 2, 3 },
                    {1, 2, 3 }
                },
                {
                    { 2, 3, 4 },
                    { 4, 5, 6 }
                }
            };

            _ = array6.Length;
            array6.GetLength(2);
            
            
        }
    }
}
