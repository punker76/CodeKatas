﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataLocCounter.Vse12
    .LinesOfCodeCountTests
{
    [TestClass]
    public class Multiline_Comment_Scenarioss
    {
        [TestMethod]
        public void Multi_Comment_Line_Does_Not_Count()
        {
            LinesOfCode.Count("/* test */")
                .ShouldBe(0);
        }

        [TestMethod]
        public void Multi_Comment_Line_With_Succeeding_Literal_Does_Count()
        {
            LinesOfCode.Count("/* test */ using System;")
                .ShouldBe(1);
        }

        [TestMethod]
        public void Multi_Comment_Line_With_Preceeding_Literal_Does_Count()
        {
            LinesOfCode.Count("using System; /* test */")
                .ShouldBe(1);
        }

        [TestMethod]
        public void Multi_Comment_Line_Spanning_Lines_Do_Not_Count()
        {
            LinesOfCode.Count(@"/* test 
commented line
counted line */ using System;")
                .ShouldBe(1);
        }

        [TestMethod]
        public void Multi_Comment_Line_With_Interceptions_Count()
        {
            LinesOfCode.Count(@"/* test 
commented line */
using System; //works
using /* another */ System; /*
counted line */ using System;")
                .ShouldBe(3);
        }
    }
}
