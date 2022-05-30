using System;

namespace HashTables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t\tData Structure Problems in Hash tables");
            Console.WriteLine("1. To find frequency of words ");
            Console.Write("Enter the option : ");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    
                    //The string in the given UC to be checked
                    string checkPhrase = "To be or not to be";

                    List<string> compareList = new List<string>();
                    List<string> storeCountList = new List<string>();

                    //firstly split the phrase into an array of the component words
                    string[] phraseArr = checkPhrase.Split(' ');

                    //initialising a hastable of length phraseArr.Length
                    MyMapNode<int, string> HTObj = new MyMapNode<int, string>(phraseArr.Length);
                    for (int i = 0; i < phraseArr.Length; i++)
                    {
                        HTObj.Add(i, phraseArr[i]);
                        Console.Write(HTObj.Get(i) + " ");
                    }

                    Console.WriteLine();
                    for (int i = 0; i < phraseArr.Length; i++)
                    {
                        //declaring count to count number of occurances of the words
                        int count = 0;
                        for (int j = 0; j < phraseArr.Length; j++)
                        {
                            //if our phrase array contains same word
                            if (phraseArr[j].ToLower() == HTObj.Get(i).ToLower())
                            {
                                count++;
                                if (compareList.Contains(HTObj.Get(j).ToLower()))
                                {
                                    break;
                                }
                            }
                        }

                        if (compareList.Contains(HTObj.Get(i).ToLower()))
                        {
                            continue;
                        }
                        //Adding the word to compareList for further comparison for duplicates
                        compareList.Add(HTObj.Get(i));
                        //finally storing the word and its frequency in storeCountList list
                        storeCountList.Add(HTObj.Get(i) + "\t" + count);
                    }
                    //Printing each word in our sentence and its frequency stored in storeCountList
                    Console.WriteLine("Word and their frequencies shown below");
                    for (int i = 0; i < storeCountList.Count; i++)
                    {
                        Console.WriteLine(storeCountList[i]);
                    }
                    break;
                default:
                    Console.WriteLine("Enter the valid option!!!");
                    break;
            }
            Console.ReadKey();
        }
    }
}
