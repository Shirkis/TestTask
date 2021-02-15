using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class FileWork
    {
        public List<string> ReadFile()
        {
            try
            {
                string path = @"..\..\..\..\input.txt";

                List<string> res = new List<string>();
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        res.Add(line);
                    }
                }
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async public Task WriteFile(string poinT, bool IsNew, bool IsSimul)
        {
            try
            {
                string writePath;
                if (IsSimul)
                {
                    writePath = @"..\..\..\..\output_sim.txt";
                }
                else
                {
                    writePath = @"..\..\..\..\output.txt";
                }
                using (StreamWriter sw = new StreamWriter(writePath, IsNew, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync(poinT);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
