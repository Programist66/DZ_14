using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_14
{
    internal class Program
    {
        struct ArrayOperations
        {
            private int[] arr;

            public ArrayOperations(int size)
            {
                arr = new int[size];
                Random rand = new Random();
                for (int i = 0; i < size; i++)
                {
                    arr[i] = rand.Next(1, 101);
                }
            }

            public int GetMax()
            {
                int max = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] > max)
                    {
                        max = arr[i];
                    }
                }
                return max;
            }

            public int GetMin()
            {
                int min = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] < min)
                    {
                        min = arr[i];
                    }
                }
                return min;
            }

            public double GetAverage()
            {
                int sum = 0;
                foreach (int num in arr)
                {
                    sum += num;
                }
                return (double)sum / arr.Length;
            }
        }
        struct TextStruct
        {
            public string text;

            public CharStruct GetCharacter(int index)
            {
                if (index >= 0 && index < text.Length)
                {
                    return new CharStruct { ch = text[index] };
                }
                else
                {
                    return new CharStruct { ch = '\0' };
                }
            }
        }
        struct IntStruct
        {
            public int value;

            public static IntDoubleStruct operator +(IntStruct a, IntStruct b)
            {
                return new IntDoubleStruct { value1 = a.value, value2 = b.value };
            }
        }

        struct IntDoubleStruct
        {
            public int value1;
            public int value2;

            public IntStruct[] Split()
            {
                return new IntStruct[] { new IntStruct { value = value1 }, new IntStruct { value = value2 } };
            }
        }
        struct CharStruct
        {
            public char ch;
        }
        static void Main(string[] args)
        {

            Console.Write("Введите размер массива: ");
            int size = int.Parse(Console.ReadLine());

            ArrayOperations arrOps = new ArrayOperations(size);

            Console.WriteLine("Максимальный элемент: " + arrOps.GetMax());
            Console.WriteLine("Минимальный элемент: " + arrOps.GetMin());
            Console.WriteLine("Среднее значение: " + arrOps.GetAverage());

            Console.ReadLine();


            TextStruct textStruct = new TextStruct { text = "Hello, World!" };
            Console.WriteLine("Текст: " + textStruct.text);

            Console.Write("Введите индекс символа: ");
            int index = int.Parse(Console.ReadLine());

            CharStruct charStruct = textStruct.GetCharacter(index);
            Console.WriteLine("Символ с индексом " + index + ": " + charStruct.ch);

            Console.ReadLine();


            IntStruct a = new IntStruct { value = 5 };
            IntStruct b = new IntStruct { value = 7 };

            IntDoubleStruct c = a + b;
            Console.WriteLine($"Сумма {a.value} и {b.value} = ({c.value1}, {c.value2})");

            IntStruct[] result = c.Split();
            Console.WriteLine("Разбиение ({c.value1}, {c.value2}) на два числа: {result[0].value} и {result[1].value}");

            Console.ReadLine();
        }
    }
}