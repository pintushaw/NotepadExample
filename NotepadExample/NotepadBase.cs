using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace NotepadExample
{
    [TestClass]
    public class NotepadBase
    {
        // Note: append /wd/hub to the URL if you're directing the test at Appium

        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/wd/hub";
        protected static WindowsDriver<WindowsElement> NotepadSession;

        [ClassInitialize]
        public static void NotepadBaseSetup(TestContext testcontext)
        {
            if (NotepadSession == null)
            {
                //launch the Notepad app
                DesiredCapabilities appCapabilities = new DesiredCapabilities();

               appCapabilities.SetCapability("deviceName", "WindowsPC");
               appCapabilities.SetCapability("app", @"C:\Windows\System32\notepad.exe");
               NotepadSession = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            }

        }
        [TestMethod]
        public void TestMethod1()
        {

           
          NotepadSession.FindElementByClassName("Edit").SendKeys("This is an automated text......");
          Assert.IsNotNull(NotepadSession);
        }

        [ClassCleanup]
        public static void NotepadBaseTearDown()
        {
            if (NotepadSession != null)
            {
                NotepadSession.Dispose();
                NotepadSession = null;
            }
        }
    }
}
