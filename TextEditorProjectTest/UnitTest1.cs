using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextEditingProject.Components;
using System.Text.RegularExpressions;
namespace TextEditorProjectTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            string path = @"c:\Users";
                   path = @"c:\1Users";
                   path = @"c:\";
                   path = @"C:\Users4\4AppData";
            var regx = new Regex(@"^(?:[a-zA-Z]\:)\\(?:[\w]+\\)*\w([\w.])+$");
            //var regx = new Regex(@"[a-zA-Z]?:\\(\w|\d){0,}");

            var Match = regx.Match(path);
                Assert.IsTrue(Match.Success);
            
        }
    }
}
