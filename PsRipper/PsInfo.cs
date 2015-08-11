using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PsRipper
{
    public class PsInfo
    {
        public List<PsAuthor> Authors { get; set; }
        public List<string> Categories { get; set; }
        public List<PsCourse> Courses { get; set; }
        public List<PsModule> Modules { get; set; }
    }


    public class PsAuthor
    {
        public string DisplayName { get; set; }
        public string Handle { get; set; }
    }


    public class PsCourse
    {
        public int Category { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Level { get; set; }
        public string Modules { get; set; }
        public string Name { get; set; }
        public bool New { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return this.Title;
        }

        public List<PsModule> ModuleList { get; set; }

        public PsCourse()
        {
            ModuleList = new List<PsModule>();
        }
    }


    public class PsModule
    {
        public int Author { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public List<PsClip> Clips { get; set; }
    }


    public class PsClip
    {
        public string Title { get; set; }
        public int Duration { get; set; }
    }
}
