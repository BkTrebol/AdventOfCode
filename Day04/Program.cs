var input = File.ReadAllLines(".\\input.txt").Select(line => line.ToCharArray()).ToArray();

var solution = 0;
var solution2 = 0;
var MAX_PAPERS = 4;
for (var lineIndex = 0; lineIndex < input.Length;lineIndex++)
{
    var line = input[lineIndex];
    for (var i = 0; i < line.Length; i++)
    {
        if (line[i] != '@')
            continue;
        
        var adjacentPapers = 0;
        if (lineIndex > 0)
        {
            var prevLine = input[lineIndex - 1];
            if (i > 0 && prevLine[i - 1] == '@') adjacentPapers++;
            if (prevLine[i] == '@') adjacentPapers++;
            if (i < line.Length - 1 && prevLine[i + 1] == '@') adjacentPapers++;
        }
        
        if(i > 0 && line[i - 1] == '@') adjacentPapers++;
        if(line.Length > i + 1 && line[i + 1] == '@') adjacentPapers++;

        if (lineIndex < input.Length -1)
        {
            var nextLine = input[lineIndex + 1];
            if (i > 0 && nextLine[i - 1] == '@') adjacentPapers++;
            if (nextLine[i] == '@') adjacentPapers++;
            if (i < line.Length - 1 && nextLine[i + 1] == '@') adjacentPapers++;
        }
        
        if(adjacentPapers < MAX_PAPERS) solution++;
            
    }
}

Console.WriteLine($"Part 1 Solution : {solution}");

var papersRemovedThisLoop = 0;
do
{
    solution2 += papersRemovedThisLoop;
    papersRemovedThisLoop = 0;

    for (var lineIndex = 0; lineIndex < input.Length;lineIndex++)
    {
        var locations = input[lineIndex];
        for (var i = 0; i < locations.Length; i++)
        {
            if (locations[i] != '@')
                continue;
        
            var adjacentPapers = 0;
            if (lineIndex > 0)
            {
                var prevLine = input[lineIndex - 1];
                if (i > 0 && prevLine[i - 1] == '@') adjacentPapers++;
                if (prevLine[i] == '@') adjacentPapers++;
                if (i < locations.Length - 1 && prevLine[i + 1] == '@') adjacentPapers++;
            }
        
            if(i > 0 && locations[i - 1] == '@') adjacentPapers++;
            if(locations.Length > i + 1 && locations[i + 1] == '@') adjacentPapers++;

            if (lineIndex < input.Length -1)
            {
                var nextLine = input[lineIndex + 1];
                if (i > 0 && nextLine[i - 1] == '@') adjacentPapers++;
                if (nextLine[i] == '@') adjacentPapers++;
                if (i < locations.Length - 1 && nextLine[i + 1] == '@') adjacentPapers++;
            }

            if (adjacentPapers < MAX_PAPERS)
            {
                input[lineIndex][i] = 'x';
                papersRemovedThisLoop++;
            }
            
        }
    }
} while (papersRemovedThisLoop > 0);

Console.WriteLine($"Part 2 Solution : {solution2}");