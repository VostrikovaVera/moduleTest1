using System;

var consoleInput = Console.ReadLine();

int arrLength = 0;

char[] aplhabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

if (string.IsNullOrEmpty(consoleInput))
{
    Console.WriteLine("There was no value passed, please, enter a number!");
}
else if (!int.TryParse(consoleInput, out arrLength))
{
    Console.WriteLine("Please, enter a number!");
}
else
{
    int[] initialArr = InitArray(1, 26, arrLength);

    int[] evenValuesArr = new int[arrLength];

    int[] oddValuesArr = new int[arrLength];

    int evenCount = 0;

    int oddCount = 0;

    for (int i = 0; i < arrLength; i++)
    {
        if (initialArr[i] % 2 == 0)
        {
            evenValuesArr[evenCount] = initialArr[i];
            evenCount++;
        }
        else
        {
            oddValuesArr[oddCount] = initialArr[i];
            oddCount++;
        }
    }

    char[] evenArrEncoded = EncodeArrAlphabetically(evenValuesArr, evenCount, out var uppercaseCountEven);

    char[] oddArrEncoded = EncodeArrAlphabetically(oddValuesArr, oddCount, out var uppercaseCountOdd);

    if (uppercaseCountEven == uppercaseCountOdd)
    {
        Console.WriteLine("Array with encoded even numbers contains same number of uppercase letters as array with encoded odd numbers");
    }
    else
    {
        Console.WriteLine($"Array with encoded {(uppercaseCountEven > uppercaseCountOdd ? "even" : "odd")} numbers contains more uppercase letters then array with encoded {(uppercaseCountEven > uppercaseCountOdd ? "odd" : "even")} numbers");
    }

    Console.WriteLine(string.Join(" ", evenArrEncoded));
    Console.WriteLine(string.Join(" ", oddArrEncoded));
}

int[] InitArray(int minValue, int maxValue, int arrLength)
{
    int[] array = new int[arrLength];

    for (int i = 0; i < arrLength; i++)
    {
        array[i] = new Random().Next(minValue, maxValue);
    }

    return array;
}

char[] EncodeArrAlphabetically(int[] arrayRaw, int arrLength, out int uppercaseCount)
{
    uppercaseCount = 0;
    char[] arr = new char[arrLength];

    for (int i = 0; i < arrLength; i++)
    {
        arr[i] = aplhabet[arrayRaw[i] - 1];

        if (arr[i] == 'a' || arr[i] == 'e' || arr[i] == 'i' || arr[i] == 'd' || arr[i] == 'h' || arr[i] == 'j')
        {
            arr[i] = char.ToUpper(arr[i]);
            uppercaseCount++;
        }
    }

    return arr;
}