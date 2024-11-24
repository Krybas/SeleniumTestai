using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestai.testai
{
    public class KandidatoPridėjimas
    {
        Functions funkcijos = new Functions();
        public void KandidatoPridejimoTestas(string url)
        {
            try
            {
                using (IWebDriver driver = new ChromeDriver())
                {
                    // Atidaromas OrangeHRM ir prisijungiama
                    funkcijos.LoginToOrangeHRM(driver, "https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");

                    // Atidaromas kandidato pridėjimo langas
                    Console.WriteLine("\nAtidaromas kandidato pridėjimo langas");
                    driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/recruitment/addCandidate");
                    Thread.Sleep(2000);

                    // Užpildomi kandidato duomenys
                    driver.FindElement(By.Name("firstName")).SendKeys("Test");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div/div/div[2]/div[2]/div[2]/input")).GetAttribute("Employee");
                    driver.FindElement(By.Name("lastName")).SendKeys("Tester");
                    funkcijos.comboBoxSelection(driver, "//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div/div/div[2]/div/div", 2);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[3]/div/div[1]/div/div[2]/input")).SendKeys("test@example.com");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[3]/div/div[2]/div/div[2]/input")).SendKeys($"+37011123456");
                    driver.FindElement(By.CssSelector("input[type='file']")).SendKeys("C:/Users/arnas/Downloads/resume.txt");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[5]/div/div[1]/div/div[2]/input")).SendKeys("Test,Tester");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[6]/div/div/div/div[2]/textarea")).SendKeys("Testuotojas");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[8]/button[2]")).Click();
                    Console.WriteLine("\nKandidato duomenys suvesti sekmingai!");
                    Thread.Sleep(6000);

                    // Atidaromas Shortlist
                    Console.WriteLine("\nAtidaromas Shortlist");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div[1]/form/div[2]/div[2]/button[2]")).Click();
                    Thread.Sleep(2000);

                    // Ivedamas note
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div/div/div[2]/textarea")).SendKeys("Automatinis pranesimas");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[3]/button[2]")).Click();
                    Console.WriteLine("\nNaujas uzrasas irasytas ir issaugotas");
                    Thread.Sleep(5000);

                    // Atidaromas Schedule interview
                    Console.WriteLine("\nAtidaromas schedule interview langas");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div[1]/form/div[2]/div[2]/button[2]")).Click();
                    Thread.Sleep(2000);

                    // Suvedama informacija
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[1]/div/div[2]/input")).SendKeys("Testuotojas");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[2]/div/div/div[2]/div/div/input")).SendKeys("a");
                    Thread.Sleep(3000);
                    Actions actions = new Actions(driver);
                    actions.SendKeys(Keys.ArrowDown).Perform();
                    actions.SendKeys(Keys.Enter).Perform();
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[3]/div/div[2]/div/div/input")).SendKeys("2024-11-25");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[4]/div/div[2]/div/div[1]/input")).Clear();
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[4]/div/div[2]/div/div[1]/input")).SendKeys("07:00 PM");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[5]/div/div[2]/textarea")).SendKeys("Automatinis pranesimas");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[3]/button[2]")).Click();
                    Console.WriteLine("\nDuomenys sekmingai suvesti ir issaugota");
                    Thread.Sleep(5000);

                    // Islaikoma kandidato aplikacija
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div[1]/form/div[2]/div[2]/button[3]")).Click();
                    Console.WriteLine("\nKandidato aplikacija patvirtinama, kaip islaikyta");
                    Thread.Sleep(3000);

                    // Apklausinejantis patvirtina
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div/div/div[2]/textarea")).SendKeys("Automatinis");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[3]/button[2]")).Click();
                    Console.WriteLine("\nIssaugoma informacija");
                    Thread.Sleep(5000);

                    // Siūlyti darbą
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div[1]/form/div[2]/div[2]/button[3]")).Click();
                    Console.WriteLine("\nPasiulomas Darbas");
                    Thread.Sleep(3000);

                    // Siulomo darbo issaugojimas
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div/div/div[2]/textarea")).SendKeys("Automatinis");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[3]/button[2]")).Click();
                    Console.WriteLine("\nIssaugoma informacija");
                    Thread.Sleep(5000);

                    // Darbuotojas samdomas
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div[1]/form/div[2]/div[2]/button[3]")).Click();
                    Console.WriteLine("\nDarbuotojas samdomas");
                    Thread.Sleep(3000);

                    // Samdymo issaugojimas
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div/div/div[2]/textarea")).SendKeys("Automatinis");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[3]/button[2]")).Click();
                    Console.WriteLine("Issaugoma informacija");
                    Thread.Sleep(7000);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nTestas sėkmingai atliktas! Kandidatas priimtas.");
                    Console.ResetColor();

                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nKlaida: {ex.Message}");
            }
            finally
            {
                Console.ResetColor();
            }
        }
    }
}
