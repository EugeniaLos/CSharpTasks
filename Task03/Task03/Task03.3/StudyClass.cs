using System;
using System.Collections.Generic;
using System.Text;


public abstract class StudyClass
{
    public string Description { get; set; }

    public StudyClass(string description = null)
    {
        Description = description;
    }
}

