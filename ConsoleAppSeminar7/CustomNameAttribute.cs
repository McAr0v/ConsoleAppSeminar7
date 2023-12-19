using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[AttributeUsage(AttributeTargets.Property)]
public class CustomNameAttribute : Attribute
{
    public string CustomFieldName { get; }

    public CustomNameAttribute(string customFieldName)
    {
        CustomFieldName = customFieldName;
    }
}
