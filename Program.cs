namespace DigitalDesignTestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsToCount = new Dictionary<string, int>();

            string[] textStrings;
            textStrings = File.ReadAllLines(args[0]);

            GetWordsCount(wordsToCount, textStrings);

            WriteWordsToFile(wordsToCount);
        }

        private static void GetWordsCount(Dictionary<string, int> wordsToCount, string[] textStrings)
        {
            string[] splitSymbols = { " ", ",", ".", ":", ";", "!", "?", "-", "(", ")", "<p>", "</p>", "[", "]", "<empty", "line/>", "\"" };

            foreach (string textString in textStrings)
            {
                string[] words = textString.Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    if (wordsToCount.ContainsKey(word))
                    {
                        wordsToCount[word]++;
                    }
                    else
                    {
                        wordsToCount[word] = 1;
                    }
                }
            }
        }

        private static void WriteWordsToFile(Dictionary<string, int> wordsToCount)
        {
            var sortedDict = from entry in wordsToCount orderby entry.Value descending select entry;

            using (StreamWriter streamWriter = new StreamWriter("UniqueWords.txt"))
            {
                foreach (var word in sortedDict)
                {
                    streamWriter.WriteLine(word.Key + "-" + word.Value);
                }
            }
        }
    }
}