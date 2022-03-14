using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP
{
    public class StringStatistics
    {
       private string data;
       private int resultSize;

       private static char[] wordSeparators = {' ',',','\n'};
       private static char[] punctuation = { '.', ',', ':', ';', '?', '!', '(', ')' };
       private static char[] sentenceEndings = { '.', '?', '!' };

       public StringStatistics(string dataIn)
       {
           if (dataIn.Length == 0) throw new Exception("Cannot construct string statistics with no input");
           data = dataIn;
       }
       private string removeAny(string data, char[] letters) //removes specified letters from input string
       {
           string result = this.data;
           foreach (char letter in letters)
           {
               result = result.Replace(letter.ToString(), String.Empty);
           }
           return result;
       }
       private string[] splitWords()
       {
           return removeAny(data, punctuation).Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);
       }
       public int WordCount()
       {
           return splitWords().Length;
       }
       public int LineCount()
       {
           return data.Split("\n").Length;
       }
       public int SentenceCount()
       {
           string[] stringSplit = data.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);
           int result = 1;
           for(int wordIndex = 0; wordIndex < stringSplit.Length-1; wordIndex++)
           {
               if(sentenceEndings.Contains(stringSplit[wordIndex].Last())&& Char.IsUpper(stringSplit[wordIndex + 1].First()))
               {
                   result++;
               }
           }
           return result;
       }
       public string[] LongestWords()
       {
           string[] stringSplit = splitWords();
           int maxLength = 0;
           resultSize = 1;
           foreach(string word in stringSplit) //najde dlzku najdlhsich slov a pocet tychto slov
           {
               if(word.Length > maxLength)
               {
                   maxLength = word.Length;
                   resultSize = 1;
               }
               else if(word.Length == maxLength) resultSize++;
           }
           string[] result = new string [resultSize];
           int resultIndex = 0;
           foreach(string word in stringSplit) //nacita odpovede do listu s dlhsimi slovami
           {
               if(word.Length == maxLength)
               {
                   result[resultIndex] = word;
                   resultIndex++;
               }
           } 
           return result;
       }
        public string[] MostCommonWords()
        {
            string[] stringSplit = splitWords();
            string uniqueWordsString = "";
            int uniqueWordCount = 0;
            foreach(string word in stringSplit) //konvertuj pole retazcov do retazca unikatnych slov
            {
                if(!uniqueWordsString.Contains(" " + word + " "))
                {
                    uniqueWordCount++;
                    uniqueWordsString += word + " ";
                }
            }
            int[] wordCounts = new int[uniqueWordCount];
            string[] uniqueWords = uniqueWordsString.Substring(1 , uniqueWordsString.Length - 2).Split(' ');
            foreach (string word in stringSplit) //spocitaj pocet slov v originalych datach
            {
                wordCounts[Array.IndexOf(uniqueWords, word)]++;
            }
            int maxCount = 0;
            resultSize = 1;
            for(int wordIndex = 0; wordIndex < wordCounts.Length; wordIndex++) //napln result najcastejsimi slovami
            {
                if(wordCounts[wordIndex] == maxCount)
                {
                    result[resultIndex] = uniqueWords[wordIndex];
                    resultIndex++;
                }
            }
            return result;
        }
        public string[] AlphabeticalOrder()
        {
            string[] stringSplit = splitWords();
            Array.Sort(stringSplit);
            return stringSplit;
        }
    }
}
