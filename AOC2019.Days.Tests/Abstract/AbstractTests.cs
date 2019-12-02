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
            var filePath = Path.Combine("Inputs", fileName);

            return File.ReadAllLines(filePath).Select(function);
        }
    }
}
