using System;
using System.Collections.Generic;
using System.IO;

namespace Simple_Bytecounter
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var fs = File.OpenRead(args[0]);
            var buff = new byte[(int) fs.Length];
            fs.Read(buff, 0, (int) fs.Length);
            var map = ArrayListMultiMap<byte, uint> .Create(10);
            
            for (var i = 0; i < (int) fs.Length; i++)
            {
                map.Put(buff[i],1);
            }
            
            var sorted = new List<byte>(map.Dict.Keys);
            sorted.Sort();
            
            foreach (var baite in sorted)
            {
                Console.WriteLine("Variable: "+ BitConverter.ToString(new byte[]{baite}) + " Count: " + map.Get(baite).Count);
            }
        }
    }
}