var input = File.ReadAllLines(".\\input.txt").ToList();

long solution = 0;
long solution2 = 0;

foreach (var data in input.Select(line => line.ToCharArray().ToList()))
{
    solution += GetHighestNumberInLine(data, 2);
    solution2 += GetHighestNumberInLine(data, 12);
}

Console.WriteLine($"Part 1 Solution : {solution}");
Console.WriteLine($"Part 2 Solution : {solution2}");
return;

long GetHighestNumberInLine(List<char> line,int digits)
{
    List<char> numbers = [];
    var currentIndex = 0;
    for (var i = 0; i < digits; i++)
    {
        var highestIndex = GetHighestIndex(currentIndex, digits - i, line);
        currentIndex = highestIndex + 1;
        numbers.Add(line[highestIndex]);
    }

    return long.Parse(string.Concat(numbers));
}

int GetHighestIndex(int startIndex, int digits, List<char> line)
{
    var highestIndex = startIndex;
    var highestDigit = line[startIndex];
    var searchTo = line.Count - digits;
    for (var i = startIndex + 1; i <= searchTo; i++)
    {
        if (line[i] <= highestDigit) continue;
        
        highestDigit = line[i];
        highestIndex = i;
    }
    return highestIndex;
}