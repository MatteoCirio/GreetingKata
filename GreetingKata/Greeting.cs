namespace GreetingKata
{
        public class Greeting
        {
        public static string Greet(string[] names)
        {
            if (names == null || names.Length == 0)
                return "Hello, my friend.";

            List<string> normalNames = new List<string>();
            List<string> shoutedNames = new List<string>();

            var splitNames = SplitNames(names);

            foreach (var name in splitNames)
            {
                if (name == name.ToUpper()) 
                {
                    shoutedNames.Add(name);
                }
                else
                {
                    normalNames.Add(name);
                }
            }

            string greeting = "";

            if (normalNames.Count == 1)
            {
                greeting = $"Hello {normalNames[0]}";
            }
            else if (normalNames.Count == 2)
            {
                greeting = $"Hello {normalNames[0]} and {normalNames[1]}";
            }
            else if (normalNames.Count > 2)
            {
                greeting = $"Hello {string.Join(", ", normalNames.Take(normalNames.Count - 1))} and {normalNames.Last()}";
            }

            if (shoutedNames.Count > 0)
            {
                var shoutedGreeting = $"HELLO {string.Join(" AND ", shoutedNames.Select(n => n.ToUpper()))}!";

                if (greeting.Length > 0)
                {
                    greeting += " and " + shoutedGreeting;
                }
                else
                {
                    greeting = shoutedGreeting;
                }
            }

            return greeting;
        }

        private static List<string> SplitNames(string[] names)
        {
            var result = new List<string>();
            foreach (var name in names)
            {
                var cleanedName = name.Replace("\"", "").Trim();
                if (cleanedName.Contains(","))
                {
                    result.AddRange(cleanedName.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(n => n.Trim()));
                }
                else
                {
                    result.Add(cleanedName);
                }
            }
            return result;
        }

    }

}


