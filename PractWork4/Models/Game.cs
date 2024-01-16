﻿using System.Windows.Media;

namespace PractWork4.Models;

public partial class Game
{
    private string? imageFileName;

    public int GameId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    public short KeysCount { get; set; }

    public string? ImageFileName
    {
        get { return imageFileName; }
        set
        {
            imageFileName = value;
        }
    }

    public Uri? ImagePath
    {
        get
        {
            if (imageFileName == null) return null;
            return new Uri($@"Y:\images\{imageFileName}.png", UriKind.Absolute);
        }
    }

    public SolidColorBrush BackgroundColor =>
        new SolidColorBrush(Price < 500 ? Color.FromRgb(196, 255, 233) : Color.FromRgb(255, 255, 255));

    public string? CompositeProperty
        => $"Количество ключей: {KeysCount}\nИгра в наличии: {(KeysCount > 0 ? "да" : "нет")}\n{Category?.Name}";

    public virtual Category Category { get; set; } = null!;
}