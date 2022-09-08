using GenericFileProcessor.GenericsFileProcessor;

namespace GenericFileProcessor
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Name = "Mohamed";
            p.Age = 23;
            p.CatCount = 5;

            Person p2 = new Person();
            p2.Name = "Salad";
            p2.Age = 17;
            p2.CatCount = 2;

            List<Person> persons = new();
            persons.Add(p);
            persons.Add(p2);

            string filepath = "C:\\TestGenerics\\test.csv";


            //GenericsTextFileProcessor.SaveToTextFile(persons, filepath);

            List<Person> load = new();

            load = GenericsTextFileProcessor.LoadFromTextFile<Person>(filepath);

            foreach (var cw in load)
            {
                Console.WriteLine($"{cw.Name},{cw.Age},{cw.CatCount}");
            }
            //Console.WriteLine(filepath);
            Console.ReadLine();
        }
    }
}