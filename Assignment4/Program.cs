using System;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("==== Functions: 1-8 | Enum & Struct: 9-15 | 0 to exit ====");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: Function1(); break;
                    case 2: Function2(); break;
                    case 3: Function3(); break;
                    case 4: Function4(); break;
                    case 5: Function5(); break;
                    case 6: Function6(); break;
                    case 7: Function7(); break;
                    case 8: Function8(); break;
                    case 9: EnumStruct1(); break;
                    case 10: EnumStruct2(); break;
                    case 11: EnumStruct3(); break;
                    case 12: EnumStruct4(); break;
                    case 13: EnumStruct5(); break;
                    case 14: EnumStruct6(); break;
                    case 15: EnumStruct7(); break;
                    case 0: Console.WriteLine("Goodbye!"); break;
                    default: Console.WriteLine("Invalid choice."); break;
                }

            } while (choice != 0);
        }

        // ======================= FUNCTIONS SECTION =======================

        #region Function 1 - Value type: by value vs by reference
        static void SwapByValue(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void SwapByRef(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void Function1()
        {
            int x = 5, y = 10;

            // By value: the method receives a COPY, so changes don't affect x and y here.
            SwapByValue(x, y);
            Console.WriteLine("After SwapByValue: x = " + x + ", y = " + y);

            // By reference (ref): the method receives the ACTUAL variables, so changes persist.
            SwapByRef(ref x, ref y);
            Console.WriteLine("After SwapByRef: x = " + x + ", y = " + y);
        }
        #endregion

        #region Function 2 - Reference type: by value vs by reference
        class Box
        {
            public int Value;
        }

        static void ChangeByValue(Box b)
        {
            b.Value = 100;                  // affects caller: same object in memory
            b = new Box { Value = 999 };     // does NOT affect caller: b now points to a new object, only locally
        }

        static void ChangeByRef(ref Box b)
        {
            b.Value = 100;
            b = new Box { Value = 999 };     // DOES affect caller: b itself is passed by reference
        }

        static void Function2()
        {
            Box box1 = new Box { Value = 1 };
            ChangeByValue(box1);
            Console.WriteLine("After ChangeByValue: " + box1.Value);

            Box box2 = new Box { Value = 1 };
            ChangeByRef(ref box2);
            Console.WriteLine("After ChangeByRef: " + box2.Value);
        }
        #endregion

        #region Function 3 - Sum and difference of two numbers
        static void SumAndSubtract(int a, int b, out int sum, out int difference)
        {
            sum = a + b;
            difference = a - b;
        }

        static void Function3()
        {
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());

            SumAndSubtract(a, b, out int sum, out int difference);

            Console.WriteLine("Sum = " + sum);
            Console.WriteLine("Difference = " + difference);
        }
        #endregion

        #region Function 4 - Sum of individual digits
        static int SumOfDigits(int number)
        {
            int sum = 0;
            number = Math.Abs(number);

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }

        static void Function4()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            int sum = SumOfDigits(number);
            Console.WriteLine("The sum of the digits of the number " + number + " is: " + sum);
        }
        #endregion

        #region Function 5 - IsPrime
        static bool IsPrime(int number)
        {
            if (number < 2) return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        static void Function5()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(IsPrime(number) ? "Prime" : "Not Prime");
        }
        #endregion

        #region Function 6 - MinMaxArray with reference parameters
        static void MinMaxArray(int[] arr, ref int min, ref int max)
        {
            min = arr[0];
            max = arr[0];

            foreach (int num in arr)
            {
                if (num < min) min = num;
                if (num > max) max = num;
            }
        }

        static void Function6()
        {
            Console.Write("Enter number of elements: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter element " + (i + 1) + ": ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            int min = 0, max = 0;
            MinMaxArray(arr, ref min, ref max);

            Console.WriteLine("Min = " + min);
            Console.WriteLine("Max = " + max);
        }
        #endregion

        #region Function 7 - Iterative factorial
        static long Factorial(int n)
        {
            long result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;

            return result;
        }

        static void Function7()
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(n + "! = " + Factorial(n));
        }
        #endregion

        #region Function 8 - ChangeChar
        static string ChangeChar(string text, int position, char newChar)
        {
            char[] chars = text.ToCharArray();
            chars[position] = newChar;
            return new string(chars);
        }

        static void Function8()
        {
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();
            Console.Write("Enter position (0 based): ");
            int position = int.Parse(Console.ReadLine());
            Console.Write("Enter new character: ");
            char newChar = Console.ReadLine()[0];

            string result = ChangeChar(text, position, newChar);
            Console.WriteLine("Result: " + result);
        }
        #endregion

        // ======================= ENUM AND STRUCT SECTION =======================

        #region EnumStruct 1 - WeekDays enum
        enum WeekDays { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

        static void EnumStruct1()
        {
            foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
                Console.WriteLine(day);
        }
        #endregion

        #region EnumStruct 2 - Person struct (array of 3)
        struct Person
        {
            public string Name;
            public int Age;
        }

        static void EnumStruct2()
        {
            Person[] persons = new Person[3];

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter name of person " + (i + 1) + ": ");
                persons[i].Name = Console.ReadLine();
                Console.Write("Enter age of person " + (i + 1) + ": ");
                persons[i].Age = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("Persons details:");
            foreach (Person p in persons)
                Console.WriteLine(p.Name + " - " + p.Age + " years old");
        }
        #endregion

        #region EnumStruct 3 - Season enum
        enum Season { Spring, Summer, Autumn, Winter }

        static void EnumStruct3()
        {
            Console.Write("Enter a season (Spring, Summer, Autumn, Winter): ");
            string input = Console.ReadLine();

            if (Enum.TryParse(input, true, out Season season))
            {
                switch (season)
                {
                    case Season.Spring:
                        Console.WriteLine("March to May");
                        break;
                    case Season.Summer:
                        Console.WriteLine("June to August");
                        break;
                    case Season.Autumn:
                        Console.WriteLine("September to November");
                        break;
                    case Season.Winter:
                        Console.WriteLine("December to February");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid season name.");
            }
        }
        #endregion

        #region EnumStruct 4 - Permissions enum (Flags)
        [Flags]
        enum Permissions
        {
            None = 0,
            Read = 1,
            Write = 2,
            Delete = 4,
            Execute = 8
        }

        static void EnumStruct4()
        {
            Permissions userPermissions = Permissions.Read | Permissions.Write;
            Console.WriteLine("Initial permissions: " + userPermissions);

            userPermissions |= Permissions.Execute; // add
            Console.WriteLine("After adding Execute: " + userPermissions);

            userPermissions &= ~Permissions.Write; // remove
            Console.WriteLine("After removing Write: " + userPermissions);

            bool hasDelete = (userPermissions & Permissions.Delete) == Permissions.Delete;
            Console.WriteLine("Has Delete permission? " + hasDelete);

            bool hasRead = (userPermissions & Permissions.Read) == Permissions.Read;
            Console.WriteLine("Has Read permission? " + hasRead);
        }
        #endregion

        #region EnumStruct 5 - Colors enum
        enum Colors { Red, Green, Blue }

        static void EnumStruct5()
        {
            Console.Write("Enter a color (Red, Green, Blue): ");
            string input = Console.ReadLine();

            if (Enum.TryParse(input, true, out Colors color))
                Console.WriteLine(color + " is a primary color.");
            else
                Console.WriteLine(input + " is not a primary color.");
        }
        #endregion

        #region EnumStruct 6 - Point struct (distance)
        struct Point
        {
            public double X;
            public double Y;
        }

        static void EnumStruct6()
        {
            Point p1 = new Point();
            Point p2 = new Point();

            Console.Write("Enter X of first point: ");
            p1.X = double.Parse(Console.ReadLine());
            Console.Write("Enter Y of first point: ");
            p1.Y = double.Parse(Console.ReadLine());

            Console.Write("Enter X of second point: ");
            p2.X = double.Parse(Console.ReadLine());
            Console.Write("Enter Y of second point: ");
            p2.Y = double.Parse(Console.ReadLine());

            double distance = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            Console.WriteLine("Distance = " + distance);
        }
        #endregion

        #region EnumStruct 7 - Person struct (oldest)
        static void EnumStruct7()
        {
            Person[] persons = new Person[3];

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter name of person " + (i + 1) + ": ");
                persons[i].Name = Console.ReadLine();
                Console.Write("Enter age of person " + (i + 1) + ": ");
                persons[i].Age = int.Parse(Console.ReadLine());
            }

            Person oldest = persons[0];
            foreach (Person p in persons)
            {
                if (p.Age > oldest.Age)
                    oldest = p;
            }

            Console.WriteLine("Oldest person: " + oldest.Name + ", Age: " + oldest.Age);
        }
        #endregion
    }
}