using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;


public class Localized : DisplayNameAttribute
{
    private string DisplayNameKey { get; set; }
    private string ResourceSetName { get; set; }

    public Localized(string displayNameKey)
        : base(displayNameKey)
    {
        DisplayNameValue = displayNameKey;
        this.DisplayNameKey = displayNameKey;
    }


    public Localized(string displayNameKey, string resourceSetName)
        : base(displayNameKey)
    {
        DisplayNameValue = displayNameKey;
        this.DisplayNameKey = displayNameKey;
        this.ResourceSetName = resourceSetName;
    }

    public override string DisplayName
    {
        get
        {

            return Extention.GetResource(this.DisplayNameKey);

        }
    }
}


