using Task4_1;

string? inputString = Console.ReadLine();
if (inputString == null)
{
    Console.WriteLine(":(");
    return;
}
var tree = new Tree(inputString);
Console.WriteLine(tree.Calculate());
tree.Print();