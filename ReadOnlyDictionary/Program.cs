using System;
using System.Collections.Generic;

namespace ReadOnlyDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Configs configs = new Configs();
            System.Collections.ObjectModel.ReadOnlyDictionary<int, string> dictionary = configs.Config;
            string
            value = dictionary[1];
            value = dictionary[2];
            value = dictionary[3];
            value = dictionary[4];
            value = dictionary[5];
        }

        public class Configs
        {
            private Dictionary<int, string> config;
            private System.Collections.ObjectModel.ReadOnlyDictionary<int, string> readOnlyConfig;

            public System.Collections.ObjectModel.ReadOnlyDictionary<int, string> Config
            {
                get
                {
                    return readOnlyConfig;
                }
            }

            public Configs()
            {
                config = new Dictionary<int, string>()
                {
                    { 1, "A"},
                    { 2, "B"},
                    { 3, "C"},
                    { 4, "D"},
                    { 5, "E"},
                };
                readOnlyConfig = new System.Collections.ObjectModel.ReadOnlyDictionary<int, string>(config);
            }
        }
    }
}
