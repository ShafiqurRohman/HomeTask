
using XmlValidator;
public class Program
{

    static void Main()
    {
        string xmlString = "<root><element1></element1><element2></element2></root>";
        //string xmlStringX = "</img>";
        //xmlString = Console.ReadLine();

        if (XmlValidatorChecker.DetermineXml(xmlString))
        {
            Console.WriteLine("The XML is valid.");
        }
        else
        {
            Console.WriteLine("The XML is not valid.");
        }
    }
}
