var input = File.ReadAllText(".\\input.txt");

var splitIds = input.Split(',');
List<long> invalidIds = [];

foreach (var id in splitIds)
{
    var min = long.Parse(id.Split('-')[0]);
    var max = long.Parse(id.Split('-')[1]);
    for (var i = min; i <= max; i++)
    {
        var stringId = i.ToString();
        if (stringId.Length % 2 != 0) // Odd can't be repeated sequence
            continue;

        var half = stringId.Length / 2;
        if (stringId[..half] == stringId[half..])
            invalidIds.Add(i);
    }
}

Console.WriteLine($"Part 1 Solution : {invalidIds.Sum()}");

invalidIds = [];

foreach (var id in splitIds)
{
    var min = long.Parse(id.Split('-')[0]);
    var max = long.Parse(id.Split('-')[1]);
    for (var i = min; i <= max; i++)
    {
        var stringId = i.ToString();
        var half = stringId.Length / 2;
        if (stringId[..half] == stringId[half..])
        {
            invalidIds.Add(i);
            continue; // Is invalid so no point on more checks.
        }

        for (var j = 1; j <= half; j++)

        {
            var isInvalid = false;

            if (j > 1 && stringId.Length % j != 0) // 
                continue;

            var addedIndex = j;
            while (j + addedIndex <= stringId.Length)
            {
                var p1 = stringId[..j];
                var p2 = stringId.Substring(addedIndex, j);
                isInvalid = p1 == p2;
                if (!isInvalid)
                    break;

                addedIndex += j;
            }

            if (isInvalid)
            {
                invalidIds.Add(i);
                break;
            }
        }
    }
}

Console.WriteLine($"Part 2 Solution : {invalidIds.Sum()}");