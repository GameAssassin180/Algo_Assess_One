using System;
using System.Linq;
using System.IO;

namespace Algorithms_Complexity_Assessment_One
{
    class Program
    {
        // This function loads the files into an array. 
        static int[] fileLoad(string text) // The function accepts one argument, a string. This string is the files name. 
        {
            string[] t = File.ReadAllLines(text); // Here the code reads each line of the file into a string arry.
            int[] ints = Array.ConvertAll(t, int.Parse); // Here the array is converted from string to integer. 
            return ints; // This returns the integer array. 
        }

        // This function is a bubble sort it will sort the array passed to it from smallest value to biggest value.
        // Complexity ((n**2 + 2) / 2) or O(n**2).
        static int[] bubbleSortAscending(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)  
            {
                for (int j = 0; j < arr.Length - 1 - i; j++) 
                {
                    if (arr[j] > arr[j+1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }
        // This function is a bubble sort it will sort the array passed to it from biggest value to smallest value
        // Complexity ((n**2 + 2) / 2) or O(n**2).
        static int[] bubbleSortDescending(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] < arr[j+1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }

        // This function is an insertion sort it will sort the array passed to it from smallest value to biggest value.
        // Complexity ((n**2 + 2) / 2) or O(n**2).
        static int[] insertionSortAscending(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }
        // This function is an insertion sort it will sort the array passed to it from biggest value to smallest value. 
        // Complexity ((n**2 + 2) / 2) or O(n**2).
        static int[] insertionSortDescending(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (arr[j - 1] < arr[j])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }
        
        // The next three functions are all part of a merge sort, this first function handles the entry of an arry into the sort. 
        // These functions will return the array in the order of smallest to biggest. 
        // Complexity is O(NlogN).
        static void mergeSortAscending(int[] arr)
        {
            int n = arr.Length;
            int[] temp = new int[n];
            mergeSortRecursiveAscending(arr, temp, 0, n - 1);
        }
        // This function handles the recursion needed for a merge sort.
        static void mergeSortRecursiveAscending(int[] arr, int[] temp, int min, int max)
        {
            int n = max - min + 1;
            int middle = min + n / 2;
            int i; 
            if (n < 2) return;
            for (i = min; i < middle; i++)
            { 
                temp[i] = arr[i]; 
            }
            mergeSortRecursiveAscending(temp, arr, min, middle - 1);
            mergeSortRecursiveAscending(arr, temp, middle, max);
            mergeAscending(arr, temp, min, middle, max);
        }
        // This final function handles the merging part of a merge sort.
        static void mergeAscending(int[] arr, int[] temp, int min, int middle, int max)
        {
            int ri = min;
            int ti = min;
            int di = middle;

            while (ti < middle && di <= max)
            {
                if (arr[di] < temp[ti])
                {
                    arr[ri++] = arr[di++];
                }
                else
                {
                    arr[ri++] = temp[ti++];
                }
            }
            while (ti < middle)
            {
                arr[ri++] = temp[ti++];
            }
        }
        // The next three functions are all part of a merge sort, this first function handles the entry of an arry into the sort. 
        // These functions will return the array in the order of biggest to smallest. 
        // Complexity is O(NlogN).
        static void mergeSortDescending(int[] arr)
        {
            int n = arr.Length;
            int[] temp = new int[n];
            mergeSortRecursiveDescending(arr, temp, 0, n - 1);
        }
        // This function handles the recursion needed for a merge sort.
        static void mergeSortRecursiveDescending(int[] arr, int[] temp, int min, int max)
        {
            int n = max - min + 1;
            int middle = min + n / 2;
            int i; 
            if (n < 2) return;
            for (i = min; i < middle; i++)
            {
                temp[i] = arr[i];
            }
            mergeSortRecursiveDescending(temp, arr, min, middle - 1);
            mergeSortRecursiveDescending(arr, temp, middle, max);
            mergeDescending(arr, temp, min, middle, max);
        }
        // This final function handles the merging part of a merge sort.
        static void mergeDescending(int[] arr, int[] temp, int min, int middle, int max)
        {
            int ri = min;
            int ti = min;
            int di = middle;

            while (ti < middle && di <= max)
            {
                if (arr[di] < temp[ti])
                {
                    arr[ri++] = temp[ti++];
                }
                else
                {
                    arr[ri++] = arr[di++];
                }
            }
            while (ti < middle)
            {
                arr[ri++] = temp[ti++];
            }
        }

        // The two functions bellow handle a quicksort that sorts the array into ascending order.
        // Complexity ((n**2 + 2) / 2) or O(n**2).
        // This first function handles entry of an array.
        static void quick_SortAcsending(int[] arr)
        {
            quickSortAscending(arr, 0, arr.Length - 1);
        }
        // This function handles the sorting and merging of the array.
        static void quickSortAscending(int[] arr, int left, int right)
        {
            int i, j;
            int pivot, temp;
            i = left;
            j = right;
            pivot = arr[(left + right) / 2];
            do
            {
                while ((arr[i] < pivot) && (i < right)) i++;
                while ((pivot < arr[j]) && (j > left)) j--;
                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp; i++;
                    j--;
                }
            }
            while (i <= j);
            if (left < j) quickSortAscending(arr, left, j);
            if (i < right) quickSortAscending(arr, i, right);
        }
        // The two functions bellow handle a quicksort that sorts the array into descending order.
        // Complexity ((n**2 + 2) / 2) or O(n**2).
        // This first function handles entry of an array.
        static void quick_SortDescending(int[] arr)
        {
            quickSortDescending(arr, 0, arr.Length - 1);
        }
        // This function handles the sorting and merging of the array.
        static void quickSortDescending(int[] arr, int left, int right)
        {
            int i, j;
            int pivot, temp;
            i = left;
            j = right;
            pivot = arr[(left + right) / 2];
            do
            {
                while ((arr[i] > pivot) && (i < right)) i++;
                while ((pivot > arr[j]) && (j > left)) j--;
                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp; i++;
                    j--;
                }
            }
            while (i <= j);
            if (left < j) quickSortDescending(arr, left, j);
            if (i < right) quickSortDescending(arr, i, right);
        }

        // Bellow are 2 searching algoritms, a linear and binary search.
        // Complexity for a linear search is O(n).
        static void linearSearch(int[] arr, int value)
        {
            for(int i =0; i < arr.Length; i++)
            {
                if(arr[i] == value)
                {
                    Console.WriteLine("\nThe value " + value + " was found at location " + (i + 1));
                    amountCheck(arr, value, i);
                    break;
                }
                else if(i== arr.Length-1)
                {
                    Console.WriteLine("\nThe Value " + value + " was not found");
                    if(value <= arr[arr.Length/2])
                    {
                        Console.WriteLine("\nNow looking for " + (value + 1));
                        linearSearch(arr, (value + 1));
                    }
                    else if(value > arr[arr.Length/2])
                    {
                        Console.WriteLine("\nNow looking for " + (value - 1));
                        linearSearch(arr, (value - 1));
                    }
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        // Complexity for a binary search is O(n**2).
        static void binarySearchAscending(int[] arr, int value)
        {
            int lower = 0;
            int upper = arr.Length - 1;
            int midPoint = (lower + upper) / 2;

            while(value != arr[midPoint])
            {
                if(upper < lower)
                {
                    Console.WriteLine("\nThe Value " + value + " was not found");
                    if (value <= arr[arr.Length / 2])
                    {
                        Console.WriteLine("\nNow looking for " + (value + 1));
                        binarySearchAscending(arr, (value + 1));
                    }
                    else if (value > arr[arr.Length / 2])
                    {
                        Console.WriteLine("\nNow looking for " + (value - 1));
                        binarySearchAscending(arr, (value - 1));
                    }
                    break;
                }
                midPoint = (lower + upper) / 2;
                if(arr[midPoint]<value)
                {
                    lower = midPoint + 1;
                }
                else if(arr[midPoint] > value)
                {
                    upper = midPoint - 1;
                }
                else if(arr[midPoint] == value)
                {
                    Console.WriteLine("\nThe value " + value + " was found at location " + (midPoint + 1));
                    amountCheck(arr, value, midPoint);
                    break;
                }
            }
        }
        // This search bellow run if the list is in decennding order.
        static void binarySearchDescending(int[] arr, int value)
        {
            int lower = 0;
            int upper = arr.Length - 1;
            int midPoint = (lower + upper) / 2;

            while (value != arr[midPoint])
            {
                if (upper < lower)
                {
                    Console.WriteLine("\nThe Value " + value + " was not found");
                    if (value <= arr[arr.Length / 2])
                    {
                        Console.WriteLine("\nNow looking for " + (value + 1));
                        binarySearchDescending(arr, (value + 1));
                    }
                    else if (value > arr[arr.Length / 2])
                    {
                        Console.WriteLine("\nNow looking for " + (value - 1));
                        binarySearchDescending(arr, (value - 1));
                    }
                    break;
                }
                midPoint = (lower + upper) / 2;
                if (arr[midPoint] < value)
                {
                    upper = midPoint + 1;
                }
                else if (arr[midPoint] > value)
                {
                    lower = midPoint - 1;
                }
                else if (arr[midPoint] == value)
                {
                    Console.WriteLine("\nThe value " + value + " was found at location " + (midPoint + 1));
                    amountCheck(arr, value, midPoint);
                    break;
                }
            }
        }

        // This function checks how many times a certain item appears in the array.
        static void amountCheck(int[] arr, int value, int i)
        {
            int amount = 1;
            while(true)
            {
                if(arr[i-1] == value)
                {
                    i--;
                    continue;
                }
                else
                {
                    break;
                }
            }
            while(true)
            {
                if (arr[i] == value)
                {
                    i++;
                    amount++;
                    continue;
                }
                else if (arr[i] != value)
                {
                    Console.WriteLine("The value " + value + " appears " + amount + " times.");
                    break;
                }
            }
        }

        // Main program.
        static void Main(string[] args)
        {
            // The follwing lines of code create arrays that are then filled with the values from the files. 
            int[] roadOne256 = fileLoad("Road_1_256.txt");
            int[] roadTwo256 = fileLoad("Road_2_256.txt");
            int[] roadThree256 = fileLoad("Road_3_256.txt");
            int[] roadOne2048 = fileLoad("Road_1_2048.txt");
            int[] roadTwo2048 = fileLoad("Road_2_2048.txt");
            int[] roadThree2048 = fileLoad("Road_3_2048.txt");
            
            // The next two arrays are concatinated using linq an array queery language. They use the arrays from above.
            int[] merge256 = (roadOne256.Concat(roadThree256).ToArray());
            int[] merge2048 = (roadOne2048.Concat(roadThree2048).ToArray());
            
            // This arrays value gets set when the user pick and array bellow and is then used through out.
            int[] arr = { };
            
            // This handles the users choice on what road they want to inspect. 
            while (true)
            {
                Console.WriteLine("Enter the road you wish to inspect\n(Road_1_256, Road_2_256, Road_3_256, Road_1_2048, Road_2_2048, Road_3_2048, Merged_256, Merged_2048): ");
                string road = Console.ReadLine();
                if (road == "Road_1_256")
                {
                    arr = roadOne256;
                    break;
                }
                else if (road == "Road_2_256")
                {
                    arr = roadTwo256;
                    break;
                }
                else if (road == "Road_3_256")
                {
                    arr = roadThree256;
                    break;
                }
                else if (road == "Road_1_2048")
                {
                    arr = roadOne2048;
                    break;
                }
                else if (road == "Road_2_2048")
                {
                    arr = roadTwo2048;
                    break;
                }
                else if (road == "Road_3_2048")
                {
                    arr = roadThree2048;
                    break;
                }
                else if (road == "Merged_256")
                {
                    arr = merge256;
                    break;
                }
                else if (road == "Merged_2048")
                {
                    arr = merge2048;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry\n");
                    continue;
                }
            }
            
            // This value gets set bellow but its outside a loop so it can be used later. 
            string order;
            while(true)
            {
                Console.Clear(); // Clears the console screen. 
                Console.WriteLine("What order would you like (Ascending or Descending) ");
                order = Console.ReadLine();
                if(order == "Ascending" || order == "ascending")
                {
                    mergeSortAscending(arr); // Sorts ascending.
                    break;
                }
                else if(order == "Descending" || order == "descending")
                {
                    mergeSortDescending(arr); // Sorts descending.
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry\n");
                    continue;
                }
            }

            // This will print out either every 10th or 50th value depending on teh array size. 
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr.Length == 256)
                {
                    if (i % 10 == 0)
                    {
                        Console.WriteLine(Convert.ToString(arr[i]));
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (arr.Length == 2048)
                {
                    if (i % 50 == 0)
                    {
                        Console.WriteLine(Convert.ToString(arr[i]));
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (arr.Length == 512)
                {
                    if (i % 10 == 0)
                    {
                        Console.WriteLine(Convert.ToString(arr[i]));
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (arr.Length == 4096)
                {
                    if (i % 50 == 0)
                    {
                        Console.WriteLine(Convert.ToString(arr[i]));
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            
            // This handles the users choice on wheather or not they want to search for a value. 
            while(true)
            {
                Console.WriteLine("If you would like to search for a value press enter, if not enter N");
                string enter = Console.ReadLine();
                if(enter =="")
                {
                    int value;
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter a number you wish to find in this array");
                        string search = (Console.ReadLine());
                        {
                            if (Int32.TryParse(search, out value)) // makes sure the user entry is a number. 
                            {
                                value = Convert.ToInt32(search);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid entry\n");
                                continue;
                            }
                        }
                    }
                    if (order == "Ascending" || order == "ascending")
                    {
                        binarySearchAscending(arr, value); 
                    }
                    else if (order == "Descending" || order == "descending")
                    {
                        binarySearchDescending(arr, value);
                    }
                }
                else if(enter == "N" || enter == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry\n");
                    continue;
                }
            }
        }
    }
}