using System;

[AttributeUsage(AttributeTargets.Property)]
public class ParseAttribute : Attribute
{
    public string ParseName { get; set; }

    public ParseAttribute(string parseName)
    {
        ParseName = parseName;
    }
}
