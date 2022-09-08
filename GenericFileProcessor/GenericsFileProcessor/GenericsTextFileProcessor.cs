using System.Text;

namespace GenericFileProcessor.GenericsFileProcessor
{
    public class GenericsTextFileProcessor
    {
        public static List<T> LoadFromTextFile<T>(string filePath) where T : class, new()
        {
            var lines = System.IO.File.ReadAllLines(filePath).ToList();

            List<T> output = new List<T>();

            T entry = new T();

            var cols = entry.GetType().GetProperties();

            if (lines.Count() < 2)
            {
                throw new IndexOutOfRangeException("The file was either empty or missing");
            }

            var headers = lines[0].Split(',');

            lines.RemoveAt(0);

            foreach (var row in lines)
            {
                entry = new T();

                var vals = row.Split(',');
                for (int i = 0; i < headers.Length; i++)
                {
                    foreach (var col in cols)
                    {
                        if (col.Name == headers[i])
                            col.SetValue(entry, Convert.ChangeType(vals[i], col.PropertyType));

                    }
                }
                output.Add(entry);

            }
            return output;
        }
        public static void SaveToTextFile<T>(List<T> data, string filePath) where T : class
        {
            List<string> lines = new List<string>();
            StringBuilder line = new StringBuilder();

            if (data == null || data.Count == 0)
                throw new ArgumentNullException("data", "You must populate the data parameter with atleast one value");

            var cols = data.First().GetType().GetProperties();


            //Create the header
            foreach (var col in cols)
            {
                line.Append(col);
                line.Append(',');
            }
            lines.Add(line.ToString().Trim(','));

            foreach (var row in data)
            {
                line = new StringBuilder();
                foreach (var col in cols)
                {
                    line.Append(col);
                    line.Append(',');
                }
                lines.Add(line.ToString().Trim(','));
            }

            System.IO.File.WriteAllLines(filePath, lines);

        }



    }
}
