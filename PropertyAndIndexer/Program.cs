using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyAndIndexer
{
    class Program
    {
        static void Main(string[] args)
        {
            Property prop = new Property();
            //ใช้ getter setter ของ auto property
            int data = prop.i;
            prop.i = 1;
            data = prop.i;

            //ใช้ getter setter ของ property ปกติที่มี backing field อยู่ข้างหลัง
            data = prop.j;
            prop.j = 1;
            data = prop.j;

            Indexer index = new Indexer();
            if (index.Length > 0)
            {
                //ใช้ getter
                data = index[0];
                data = index[5];
                data = index[10];
                data = index[15];
                try
                {
                    data = index[20];   //index out of range exception
                }
                catch (IndexOutOfRangeException e)
                {
                }

                //ใช้ setter
                index[0] = -10;
                index[5] = -10;
                index[10] = -10;
                index[15] = -10;
                try
                {
                    index[20] = -10;   //index out of range exception
                }
                catch (IndexOutOfRangeException e)
                {
                }

                //ใช้ getter
                data = index[0];
                data = index[5];
                data = index[10];
                data = index[15];
                try
                {
                    data = index[20];   //index out of range exception
                }
                catch (IndexOutOfRangeException e)
                {
                }
            }

            string dataString;
            IndexerStringKey indexStringKey = new IndexerStringKey();
            if (indexStringKey.Length > 0)
            {
                //ใช้ getter
                dataString = indexStringKey["1"];
                dataString = indexStringKey["6"];
                dataString = indexStringKey["11"];
                dataString = indexStringKey["20"];
                try
                {
                    dataString = indexStringKey["21"];   //indexer returns null
                }
                catch (IndexOutOfRangeException e)
                {
                }

                //ใช้ setter
                indexStringKey["1"] = "-10";
                indexStringKey["6"] = "-10";
                indexStringKey["11"] = "-10";
                indexStringKey["20"] = "-10";
                try
                {
                    indexStringKey["21"] = "-10";   //indexer creates a new 21th key and value
                }
                catch (IndexOutOfRangeException e)
                {
                }

                //ใช้ getter
                dataString = indexStringKey["1"];
                dataString = indexStringKey["6"];
                dataString = indexStringKey["11"];
                dataString = indexStringKey["20"];
                try
                {
                    dataString = indexStringKey["21"];   //indexer returns "-10"
                }
                catch (IndexOutOfRangeException e)
                {
                }
            }
        }
    }

    class Property
    {
        public int i
        {//property แบบ auto
            get;
            set;
        }
        int jj;
        public int j
        {//property แบบปกติ (get set แล้วไปดึงจาก/เขียนลง backing field)
            get
            {
                return jj;
            }
            set
            {
                jj = value;
            }
        }
    }

    class Indexer
    {
        int[] data;
        public int this[int i]
        {//indexer
            get
            {
                return data[i];
            }
            set
            {
                data[i] = value;
            }
        }

        public int Length
        {//property แบบปกติ (get set แล้วไปดึงจาก backing field)
            get
            {
                return data.Length;
            }
        }

        public Indexer()
        {
            const int len = 20;
            data = new int[len];
            for (int i = 0; i < len; i++)
            {
                data[i] = i + 1;
            }
        }
    }

    class IndexerStringKey
    {
        System.Collections.Specialized.NameValueCollection nameValueCollection;
        public string this[string i]
        {//indexer
            get
            {
                return nameValueCollection[i];
            }
            set
            {
                nameValueCollection[i] = value;
            }
        }

        public int Length
        {//property แบบปกติ (get set แล้วไปดึงจาก backing field)
            get
            {
                return nameValueCollection.Count;
            }
        }

        public IndexerStringKey()
        {
            const int len = 20;
            nameValueCollection = new System.Collections.Specialized.NameValueCollection();
            for (int i = 0; i < len; i++)
            {
                string key=(i + 1).ToString();
                string value=((i + 1)*10).ToString();
                nameValueCollection.Add(key,value);
            }
        }
    }
}
