using System.Text;

while (true)
{
    Console.WriteLine("Enter a string");
    var input = Console.ReadLine();
    var bytes = Encoding.UTF8.GetBytes(input);
    var base64String = Convert.ToBase64String(bytes);
    Console.WriteLine($"Based encoeded string :{base64String}");
    Console.WriteLine();

}