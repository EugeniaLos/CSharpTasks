using System;
using System.Collections.Generic;
using System.Text;


public class Training
{
    public string Description { get; set; }

    private Lecture[] lectures = new Lecture[0];
    private Practice[] practices = new Practice[0];


    public void Add(StudyClass studyClass)
    {
        if (studyClass == null)
        {
            return;
        }

        Lecture lecture = studyClass as Lecture;
        if (lecture != null)
        {
            Array.Resize(ref lectures, lectures.Length + 1);
            lectures[lectures.Length - 1] = lecture;
        }
        else
        {
            Practice practice = studyClass as Practice;
            Array.Resize(ref practices, practices.Length + 1);
            practices[practices.Length - 1] = practice;
        }
    }

    public bool IsPractical()
    {
        return lectures.Length == 0 && practices.Length != 0;
    }
}

