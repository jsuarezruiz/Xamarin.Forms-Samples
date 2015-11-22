using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Calculator.UITests
{
    [TestFixture]
    public class CalculatorTests
    {
        static readonly Func<AppQuery, AppQuery> TwoButton = c => c.Marked("Digit2");
        static readonly Func<AppQuery, AppQuery> PlusButton = c => c.Marked("Operator+");
        static readonly Func<AppQuery, AppQuery> EqualsButton = c => c.Marked("OperatorEquals");

        private IApp _app;

        [SetUp]
        public void SetUp()
        {
            switch (TestEnvironment.Platform)
            {
                case TestPlatform.Local:
                    var appFile =
                    new DirectoryInfo(Path.Combine("..", "..", "testapps"))
                        .GetFileSystemInfos()
                        .OrderByDescending(file => file.LastWriteTimeUtc)
                        .First(file => file.Name.EndsWith(".app") || file.Name.EndsWith(".apk"));

                    _app = appFile.Name.EndsWith(".app")
                        ? ConfigureApp.iOS.AppBundle(appFile.FullName).StartApp() as IApp
                        : ConfigureApp.Android.ApkFile(appFile.FullName).StartApp();
                    break;
                case TestPlatform.TestCloudiOS:
                    _app = ConfigureApp.iOS.StartApp();
                    break;
                case TestPlatform.TestCloudAndroid:
                    _app = ConfigureApp.Android.StartApp();
                    break;
            }
        }

        [Test]
        public void TheTwoPlusTwoIsFourTest()
        {
            _app.WaitForElement(c => c.Marked("OperatorEquals"));

            _app.Tap(TwoButton);
            _app.Tap(PlusButton);
            _app.Tap(TwoButton);
            _app.Tap(EqualsButton);
            _app.Screenshot("When I get the result value");

            AppResult[] results = _app.WaitForElement(c => c.Marked("DisplayValue").Text("4"));

            Assert.IsTrue(results.Any());
        }
    }
}

