using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlValidator
{
    public class XmlValidatorChecker
    {
        public static bool DetermineXml(string xml)
        {

            Stack<string> stack = new Stack<string>();
            int idx = 0;
            while (idx < xml.Length)
            {
                if (xml[idx] == '<')
                {
                    if (xml[idx + 1] == '/')
                    {
                        idx += 2;
                        int lastIndex = xml.IndexOf('>', idx);
                        if (lastIndex == -1)
                        {
                            return false;
                        }

                        string closeTag = xml.Substring(idx, lastIndex - idx);
                        if (stack.Count == 0 || stack.Pop() != closeTag)
                        {
                            return false;
                        }

                        idx = lastIndex + 1;
                    }
                    else
                    {
                        idx++;
                        int endIndex = xml.IndexOf('>', idx);
                        if (endIndex == -1)
                        {
                            return false;
                        }

                        string openTag = xml.Substring(idx, endIndex - idx);
                        stack.Push(openTag);

                        idx = endIndex + 1;
                    }
                }
                else
                {
                    idx++;
                }
            }

            return stack.Count == 0;
        }
    }
}
