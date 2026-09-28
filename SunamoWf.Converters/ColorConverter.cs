namespace SunamoWf.Converters;

/// <summary>
/// Converts a System.Drawing.Color to/from a simple comma separated "A,R,G,B" string.
/// </summary>
public static class ColorConverter
{
    /// <summary>
    /// Parses a "A,R,G,B" comma separated string back into a Color.
    /// </summary>
    public static System.Drawing.Color ConvertTo(string text)
    {
        string[] parts = text.Split(',');
        return System.Drawing.Color.FromArgb(
            byte.Parse(parts[0]),
            byte.Parse(parts[1]),
            byte.Parse(parts[2]),
            byte.Parse(parts[3]));
    }

    /// <summary>
    /// Serializes a Color into a "A,R,G,B" comma separated string.
    /// </summary>
    public static string ConvertFrom(System.Drawing.Color color)
    {
        return string.Join(",", color.A, color.R, color.G, color.B);
    }
}
