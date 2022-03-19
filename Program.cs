string[] letters = { "M", "R", "G" };

List<string> words = WordMaker(letters);

foreach (var word in words)
{
    Console.Write(word + "\t");
}



List<string> WordMaker(string[] letters)
{
    var nameLength = letters.Length;

    var scenarios = CalculateScenarios(letters);

    List<List<string>> lettersLists = new();

    var lettersListCount = scenarios;

    List<string> lettersList = RepeatLettersForScenarios(scenarios, letters);

    while (lettersListCount != 1)
    {
        lettersLists.Add(lettersList.Take(lettersListCount).ToList());
        lettersList.RemoveRange(0, lettersListCount);
        lettersListCount = lettersListCount / nameLength;
    }

    List<List<string>> namesList = EqualizingListsMembersCount(lettersLists, nameLength);

    List<string> names = MatchLetters(scenarios, namesList);

    return names;
}

List<string> MatchLetters(int scenarios, List<List<string>> namesList)
{
    List<string> names = new();

    for (var i = 0; i < scenarios; i++)
    {
        var name = string.Empty;
        foreach (var list in namesList)
        {
            name += list[i];
        }
        names.Add(name);
        name = string.Empty;
    }
    return names;
}

List<List<string>> EqualizingListsMembersCount(List<List<string>> lettersLists, int wordLength)
{
    var coefficient = 1;

    List<List<string>> namesList = new();

    foreach (var list in lettersLists)
    {
        List<string> newList = new();
        for (var i = 0; i < coefficient; i++)
        {
            newList.AddRange(list);
        }
        coefficient *= wordLength;
        namesList.Add(newList);
    }

    return namesList;
}

List<string> RepeatLettersForScenarios(int scenarios, string[] words)
{
    List<string> wordsList = new();
    var repeatWords = scenarios;
    var nameLength = words.Length;
    while (repeatWords != 1)
    {
        repeatWords = repeatWords / nameLength;

        for (var i = 0; i < nameLength; i++)
        {
            for (var _ = 0; _ < repeatWords; _++)
            {
                wordsList.Add(words[i]);
            }
        }
    }
    return wordsList;
}

int CalculateScenarios(string[] words)
{
    var nameLength = words.Length;

    var scenarios = 1;
    for (int i = 0; i < nameLength; i++)
    {
        scenarios *= nameLength;
    }
    return scenarios;
}