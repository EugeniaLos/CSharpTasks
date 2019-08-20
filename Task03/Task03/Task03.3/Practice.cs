using System;
using System.Collections.Generic;
using System.Text;


public class Practice: StudyClass
{
    public string TaskPt { get; set; }
    public string SolutionPt { get; set; }

    public Practice(string taskPt, string solutionPt, string description = null): base(description)
    {
        TaskPt = taskPt;
        SolutionPt = solutionPt;
    }
}

