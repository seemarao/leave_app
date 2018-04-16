using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UItests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void loginWithEmptyCredentials()
        {
            app.Tap("UsernameField");
            app.EnterText(("UsernameField"), "");
            app.DismissKeyboard();
            app.EnterText(("PasswordField"), "");
            app.DismissKeyboard();
            app.Tap(("Sign In"));
            var alertTitle = app.Query(c => c.Text("Warning"))[0].Text;
            Assert.AreEqual("Warning", alertTitle);
            var alertText = app.Query(x => x.Marked("User Name Text Field Is Empty"))[0].Text;
            Assert.AreEqual("User Name Text Field Is Empty", alertText);
            app.Tap("ok");
        }


        [Test]
        public void loginWithInvalidCredentials()
        {
            app.EnterText(("UsernameField"), "invalid123");
            app.DismissKeyboard();
            app.EnterText(("PasswordField"), "123");
            app.DismissKeyboard();
            app.Tap("Sign In");
            app.WaitForElement(c => c.Text("Warning"));
            app.WaitForElement(x => x.Marked("Wrong User Name Or Password"));
            app.Tap("ok");
        }


        [Test]
        public void loginWithValidCredentials()
        {
            app.EnterText(("UsernameField"), "seema@prueba.io");
            app.DismissKeyboard();
            app.EnterText(("PasswordField"), "test");
            app.DismissKeyboard();
            app.Tap(("Sign In"));


        }





    }
}