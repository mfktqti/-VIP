using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight
{
    public class FlyweightFactory
    {
        static Dictionary<string, BaseWord> keyValuePairs = new Dictionary<string, BaseWord>();
        private static readonly object CreateLock = new object();

        public static BaseWord CreateBaseWord(WordType wordType)
        {
            var baseWord = default(BaseWord);
           // if (!keyValuePairs.ContainsKey(wordType.ToString()))
            {
              //  lock (CreateLock)
                {
                    if (!keyValuePairs.ContainsKey(wordType.ToString()))
                    {
                        switch (wordType)
                        {
                            case WordType.E:
                                baseWord = new E();
                                break;
                            case WordType.L:
                                baseWord = new L();
                                break;
                            case WordType.N:
                                baseWord = new N();
                                break;
                            default:
                                break;
                        }
                        keyValuePairs.Add(wordType.ToString(), baseWord);
                    }
                }
            }
            baseWord = keyValuePairs[wordType.ToString()];
            return baseWord;
        }

    }
    public enum WordType
    {
        E,
        L,
        N, 
    }
}
