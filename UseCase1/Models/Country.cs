﻿using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UseCase1.Models;

public class Country
{
    public string Name { get; set; }
    public int Population { get; set; }
}
