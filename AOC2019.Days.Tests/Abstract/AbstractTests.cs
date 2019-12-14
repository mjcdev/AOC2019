using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC2019.Days.Tests.Abstract
{
    public abstract class AbstractTests
    {
        public IEnumerable<T> ReadLineSeperatedFile<T>(string fileName, Func<string, T> function)
        {
            return File.ReadAllLines(FilePath(fileName)).Select(function);
        }

        public IEnumerable<T> ReadCommaSeperatedLine<T>(string fileName, Func<string, T> function)
        {
            return File.ReadAllText(FilePath(fileName)).Split(',').Select(function);
        }

        public IEnumerable<T> ReadFromCharArray<T>(string fileName, Func<char, T> function)
        {
            return File.ReadAllText(FilePath(fileName)).ToCharArray().Select(function);
        }

        private string FilePath(string fileName) => Path.Combine("Inputs", fileName);
    }
}
