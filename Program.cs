using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace onCenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputpath = "D:\\solutionsForSpaceApp\\2047\\input.txt";
            string outputpath = "D:\\solutionsForSpaceApp\\2047\\output.txt";

            FileStream fs = new FileStream(inputpath, FileMode.OpenOrCreate);
            fs.Close();
            FileStream fsout = new FileStream(outputpath, FileMode.OpenOrCreate);
            fsout.Close();
            int z = 0;
            using (StreamReader reader = new StreamReader(inputpath))
            {
                while (reader.ReadLine() != null)
                    z++;
            }
            int maxlength = 0;
            string[] line = new string[z];
            using (StreamReader reader = new StreamReader(inputpath))
            {
                for (int i = 0; i < line.Length; i++)
                {
                    line[i] = reader.ReadLine();

                    if (maxlength < line[i].Length)
                    {
                        maxlength = line[i].Length;
                    }

                }
            }

            maxlength = maxlength + 2;
            for (int i = 0; i < line.Length; i++)
            {
                while (maxlength - line[i].Length > 2)
                {
                    if (maxlength - line[i].Length == 3)
                    {
                        line[i] = line[i].Insert(0, ' '.ToString());
                    }
                    else
                    {
                        line[i] = line[i].Insert(0, ' '.ToString());
                        line[i] = line[i].Insert(line[i].Length, ' '.ToString());
                    }
                }
                if (maxlength - line[i].Length == 2)
                {
                    line[i] = line[i].Insert(0, '*'.ToString());
                    line[i] = line[i].Insert(maxlength - 1, '*'.ToString());
                }
            }


            string star = "*";
            string stars = "";
            using (StreamWriter writer = new StreamWriter(outputpath))
            {
                for(int i=0;i<maxlength;i++)
                {
                    stars = stars + star;
                }
                writer.WriteLine(stars);
                for (int i = 0; i < line.Length; i++)
                {
                    writer.WriteLine(line[i]);
                }
                writer.WriteLine(stars);
            }


        }
    }
}
