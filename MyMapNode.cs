using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    //here we have declared a generic class with Key and Value pair as placeholder
    internal class MyMapNode<K, V>
    {
        internal int size;

        //We have declared a LinkedList array of KeyValuePairs named items
        internal LinkedList<KeyValue<K, V>>[] items;

        public MyMapNode(int size)
        {
            this.size = size;

            //array size of LinkedList is passed while creating objects in main program
            items = new LinkedList<KeyValue<K, V>>[size];
        }

        public int GetArrayPosition(K key)
        {
            //For calculating position, we get the hashcode of the object(here array) and mod it with the size of the array (done to prevent any conflict) 
            int position = key.GetHashCode() % size;
            //This returns a positive value of the position
            return Math.Abs(position);
        }

        //Method to create a list with nodes having key-value pair structure
        //This method/function returns a linkedlist
        public LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedlist = items[position];

            if (linkedlist == null)
            {
                linkedlist = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedlist;
            }
            return linkedlist;
        }
        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);

            //Looping thhrough our linkedlist
            foreach (KeyValue<K, V> item in linkedlist)
            {
                if (item.Key.Equals(key))
                {
                    //if key in item matches/notMatches with key return value of item
                    return item.Value;
                }
            }
            return default(V);
        }

        //For adding to our LinkedList
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);

            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };

            //add item to the end of linkedlist
            linkedlist.AddLast(item);
        }
        //The struct (structure) is like a class in C# that is used to store data. However, unlike classes, a struct is a value type.
        public struct KeyValue<k, v>
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }

        //Method for removal of values from our LinkedList using key
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);

            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);

            foreach (KeyValue<K, V> item in linkedlist)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            //if found value is removed from the linkedlist
            if (itemFound)
            {
                linkedlist.Remove(foundItem);
            }
        }
    }
}
