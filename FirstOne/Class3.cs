using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FirstOne
{   
    [TestFixture]
    public class Workshop03Tests
    {
        private string testUrl = "https://suvroc.github.io/selenium-mail-course/03/workshop.html";

        [Test]
        public void ShouldCheckSelectedBookName()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);

            IWebElement book = null;

            #region TEST CODE

            book = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div/ul/li[4]/h4[1]"));

            #endregion

            Assert.NotNull(book);
            Assert.AreEqual(book.TagName, "h4");
            Assert.AreEqual(book.Text, "MORT");

            driver.Quit();
        }

        [Test]
        public void ShouldCheckNumberOfBooks()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);

            IReadOnlyCollection<IWebElement> books = null;

            #region TEST CODE

            var BookList = driver.FindElement(By.ClassName("list-group"));
            books = BookList.FindElements(By.CssSelector(".list-group-item.book"));

            #endregion

            Assert.NotNull(books);
            Assert.AreEqual(books.Count, 6);
            Assert.IsTrue(books.All(x => x.TagName == "li"));
            driver.Quit();
        }

        [Test]
        public void ShouldCheckLinksDomain()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);

            IReadOnlyCollection<IWebElement> links = null;

            #region TEST CODE

            var LinkList = driver.FindElement(By.ClassName("list-group"));
            links = LinkList.FindElements(By.CssSelector(".btn.btn-default"));

            #endregion

            Assert.NotNull(links);
            Assert.AreEqual(links.Count, 6);
            Assert.IsTrue(links.All(x => x.TagName == "a"));
            Assert.IsTrue(links.All(x => x.GetAttribute("href").StartsWith("https://www.terrypratchettbooks.com")));

            driver.Quit();
        }
    }
}

