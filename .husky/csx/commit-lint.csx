/// <summary>
/// a simple regex commit linter example
/// https://www.conventionalcommits.org/en/v1.0.0/
/// https://github.com/angular/angular/blob/22b96b9/CONTRIBUTING.md#type
/// </summary>

using System.Text.RegularExpressions;

//private var pattern = @"^(?=build|SPPP|merge|feat|ci|chore|docs|fix|perf|refactor|revert|style|test)(?:.{1,90}$)(?:\(.+\))*(?::).{4,}(?:#\d+)*(?<![\.\s])$";
private var pattern = @"^\[SPPP-\d{3}\]:\s.+";
private var msg = File.ReadAllLines(Args[0])[0];

if (Regex.IsMatch(msg, pattern))
    return 0;

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Invalid commit message");
Console.ResetColor();
Console.WriteLine("e.g: 'SPPP-(NoTicket): message'");
Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine("more info: https://www.conventionalcommits.org/en/v1.0.0/");

return 1;