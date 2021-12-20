﻿using Mono.Options;
using System.Drawing;
using TagsCloudContainer.Abstractions;

namespace TagsCloudContainer.Defaults.SettingsProviders;

public class LayouterSettingsProvider : ICliSettingsProvider
{
    private static readonly Point defaultCenter = new(300, 100);

    public Point Center { get; private set; } = defaultCenter;
    public OptionSet GetCliOptions()
    {
        var options = new OptionSet()
        {
            { "center=", $"Coordinates of center for CircularLayouter, separated by ','. Defaults to {defaultCenter}", v => Center = Parse(v) }
        };

        return options;
    }

    private static Point Parse(string v)
    {
        var coords = v.Split(',');
        if (coords.Length != 2)
            throw new FormatException($"String {v} was in incorrect format, should be two ints separated by ','");
        return new Point(int.Parse(coords[0]), int.Parse(coords[1]));
    }
}