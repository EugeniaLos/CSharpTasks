using System;
using System.Collections.Generic;
using System.Text;


public class Lecture: StudyClass
{
    public string Topic { get; set; }

    public Lecture(string topic, string description = null): base(description)
    {
        Topic = topic;
    }
}