using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class IOHelper : IDisposable
    {
        StreamReader reader;
        StreamWriter writer;

        public IOHelper(string inputFile, string outputFile, Encoding encoding)
        {
            StreamReader iReader;
            StreamWriter oWriter;
            if (inputFile == null)
                iReader = new StreamReader(Console.OpenStandardInput(), encoding);
            else
                iReader = new StreamReader(inputFile, encoding);

            if (outputFile == null)
                oWriter = new StreamWriter(Console.OpenStandardOutput(), encoding);
            else
                oWriter = new StreamWriter(outputFile, false, encoding);

            reader = iReader;
            writer = oWriter;

            curLine = new string[] { };
            curTokenIdx = 0;

            AutoFlush = false;
        }


        string[] curLine;
        int curTokenIdx;

        char[] whiteSpaces = new char[] { ' ', '\t', '\r', '\n' };

        public string ReadNextToken()
        {
            if (curTokenIdx >= curLine.Length)
            {
                //Read next line
                string line = reader.ReadLine();
                if (line != null)
                    curLine = line.Split(whiteSpaces, StringSplitOptions.RemoveEmptyEntries);
                else
                    curLine = new string[] { };
                curTokenIdx = 0;
            }

            if (curTokenIdx >= curLine.Length)
                return null;

            return curLine[curTokenIdx++];
        }

        public int ReadNextInt()
        {
            return int.Parse(ReadNextToken());
        }

        public double ReadNextDouble()
        {
            return double.Parse(ReadNextToken());
        }

        public bool AutoFlush { get; set; }

        public void Write(string stringToWrite)
        {
            writer.Write(stringToWrite);
            if (AutoFlush)
                writer.Flush();
        }

        public void WriteLine(string stringToWrite)
        {
            writer.WriteLine(stringToWrite);
            if (AutoFlush)
                writer.Flush();
        }

        public void Dispose()
        {
            try
            {
                if (reader != null)
                {
                    reader.Dispose();
                }
                if (writer != null)
                {
                    writer.Dispose();
                }
            }
            catch { };
        }


        public void Flush()
        {
            if (writer != null)
            {
                writer.Flush();
            }
        }
    }

}
