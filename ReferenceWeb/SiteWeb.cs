using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Text;

namespace ApplicatioStagez.ReferenceWeb
{
    abstract class SiteWeb
    {


        public abstract string getSiteWeb();
        public void invoke()
        {
            Process p = new Process();
            p.StartInfo.FileName =getSiteWeb();
            p.Start();
        }
    }
}
