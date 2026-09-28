namespace SunamoWf.Converters;

/// <summary>
/// Converts a System.Drawing.Color to/from a "#AARRGGBB" hex string.
/// </summary>
public class StringHexDrawingColorConverter
{
    /// <summary>
    /// Formats a Color as a "#AARRGGBB" hex string.
    /// </summary>
    public static string ConvertTo(System.Drawing.Color color)
    {
        return $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
    }

    /// <summary>
    /// Parses a "#AARRGGBB" or "#RRGGBB" hex string (with or without leading #) back into a Color.
    /// Returns Color.Black when the string has an unsupported length.
    /// </summary>
    public static System.Drawing.Color ConvertFrom(string text)
    {
        text = text.TrimStart('#');
        if (text.Length == 8)
        {
            return System.Drawing.Color.FromArgb(GetGroup(0, text), GetGroup(1, text), GetGroup(2, text), GetGroup(3, text));
        }
        else if (text.Length == 6)
        {
            return System.Drawing.Color.FromArgb(255, GetGroup(0, text), GetGroup(1, text), GetGroup(2, text));
        }
        return System.Drawing.Color.Black;
    }

    private static byte GetGroup(int position, string text)
    {
        string groupText = position switch
        {
            0 => $"{text[0]}{text[1]}",
            1 => $"{text[2]}{text[3]}",
            2 => $"{text[4]}{text[5]}",
            _ => $"{text[6]}{text[7]}",
        };
        return Convert.ToByte(groupText, 16);
    }
}
