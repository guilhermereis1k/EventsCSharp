using System.Linq;

class Program
{

    public event EventHandler<string> Name;

    static void Main()
    {

        Program program = new Program();

        Console.WriteLine("Please insert your name...\n");
        Console.Write("Name: ");

        program.Name += RevertNameHandler;
        program.Name += SpellNameHandler;
        program.Name += BinaryNameHandler;
        program.Name += IsPalindrome;

        program.OnNameEnter(Console.ReadLine());

        Console.ReadKey();

    }

    public static void RevertNameHandler(object Program, string name)
    {
        char[] nameArray = name.ToCharArray();
        Array.Reverse(nameArray);

        string reversedName = new string(nameArray);

        Console.WriteLine("\nYour inverted name is: " + reversedName + "\n");
    }

    public static void SpellNameHandler(object Program, string name)
    {
        Console.Write("Your spelled name is: ");

        char[] nameArray = name.ToCharArray();

        for (int i = 0; i < nameArray.Length; i++)
        {
            if (i == nameArray.Length - 1)
            {
                Console.Write(nameArray[i]);
            }
            else
            {
                Console.Write(nameArray[i] + " - ");
            }
        }
    }

    public static void BinaryNameHandler(object Program, string name)
    {
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(name);

        Console.Write("\n\nYour name in binary is: ");

        foreach (byte b in bytes)
        {
            Console.Write(Convert.ToString(b, 2).PadLeft(8, '0') + " ");
        }

    }

    public static void IsPalindrome(object Program, string name)
    {
        char[] nameArray = name.ToCharArray();
        string reversedName = new string(nameArray);

        bool isPalindromeBool = reversedName.ToLower().Equals(name.ToLower()) ? true : false;

        Console.WriteLine("\n\nIs this name a palindrome? " + isPalindromeBool);
    }

    protected virtual void OnNameEnter(string name)
    {
        Console.WriteLine("\n----------------------\n     Informations\n----------------------");
        Name?.Invoke(this, name);
    }
}