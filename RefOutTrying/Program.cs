class Program
{


    static void arrtir(ref int x)
    {
        x++;
    }
    static void Main (string[] args)
    {
        int a = 9;
        arrtir(ref a);
        Console.WriteLine(a);
    Console.ReadLine();
    }
}