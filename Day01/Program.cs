var input = File.ReadLines(".\\input.txt");

var current = 50;
var solution = 0;
foreach (var line in input)
{
    var direction = line[0];
    var distance = int.Parse(line[1..]);
    if (direction == 'R')
        current += distance % 100;
    else
        current -= distance % 100;
    switch (current)
    {
        case >= 100:
            current -= 100;
            break;
        case < 0:
            current += 100;
            break;
    }

    if (current == 0)
    {
        solution++;
    }
}
Console.WriteLine($"Part 1 Solution : {solution}");

// Part 2.
// Reset
var input2 = File.ReadLines(".\\input.txt");
current = 50; 
solution = 0;

foreach (var line in input2)
{
    var starting = current;
    var direction = line[0];
    var distance = int.Parse(line[1..]);
    if (direction == 'R')
        current += distance % 100;
    else
        current -= distance % 100;
    solution += distance / 100;

    switch (current)
    {
        case 0 when distance % 100 != 0:
            if (starting != 0)
                solution++;
            break;
        case < 0:
            if (starting != 0)
                solution++;
            current += 100;
            break;
        case >= 100:
            if (starting != 0)
                solution++;
            current -= 100;
            break;
    }
}

Console.WriteLine($"Part 2 Solution : {solution}");
