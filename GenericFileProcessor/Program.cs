namespace GenericFileProcessor
{
    public class Program
    {
        static void Main(string[] args)
        {
            string test = "Mark,Mostowiak,Hanka,";

            test = test.Trim(',');
            Console.WriteLine(test);

            Console.ReadLine();
        }
    }
}