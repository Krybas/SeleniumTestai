using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestai.testai
{
    public class DarbuotojoPridejimas
    {
        Functions funkcijos = new Functions();
        public string DarbuotojoPridėjimoTestas()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                try
                {
                    Random random = new Random();

                    // Atidaromas OrangeHRM ir Prisijungiama
                    funkcijos.LoginToOrangeHRM(driver, "https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");

                    // Darbuotojo pridėjimas
                    Console.WriteLine("\nAtidaromas darbuotojo pridėjimo langas");
                    driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/pim/addEmployee");
                    Thread.Sleep(2000);

                    driver.FindElement(By.Name("firstName")).SendKeys("Test");
                    driver.FindElement(By.Name("middleName")).SendKeys("Employee");
                    driver.FindElement(By.Name("lastName")).SendKeys("Tester");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[1]/div[2]/div[1]/div[2]/div/div/div[2]/input")).SendKeys($"{random.Next(1, 100)}");
                    driver.FindElement(By.CssSelector("input[type='file']")).SendKeys("C:/Users/arnas/Downloads/employee.jpg");


                    Console.WriteLine("\nDarbuotojo duomenys įvesti sėkmingai!");
                    Thread.Sleep(1000);

                    // Pažymime "Create Login Details"
                    driver.FindElement(By.CssSelector(".oxd-switch-input.oxd-switch-input--active.--label-right")).Click();
                    Thread.Sleep(500);

                    // Užpildome Login Details dalį
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[1]/div[2]/div[3]/div/div[1]/div/div[2]/input")).SendKeys($"Employee{random.Next(1, 100)}");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[1]/div[2]/div[4]/div/div[1]/div/div[2]/input")).SendKeys("Test@12345");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[1]/div[2]/div[4]/div/div[2]/div/div[2]/input")).SendKeys("Test@12345");
                    driver.FindElement(By.CssSelector("button[type='submit']")).Click();

                    Console.WriteLine("\nPrisijungimo duomenys įvesti sėkmingai!");
                    Thread.Sleep(7000);
                    string userURL = driver.Url;

                    // Atidaromas Job langas 
                    Console.WriteLine("\nAtidaromas Job langas.");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[1]/div[2]/div[6]/a")).Click();
                    Thread.Sleep(2000);

                    // Suvedama informacija
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[1]/div/div[1]/div/div[2]/div/div/input")).SendKeys("2024-10-15");

                    funkcijos.comboBoxSelection(driver, "//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[1]/div/div[2]/div/div[2]/div/div", 2);
                    funkcijos.comboBoxSelection(driver, "/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[1]/div[1]/div[6]/div[1]/div[2]/div[1]/div[1]", 1);

                    funkcijos.comboBoxSelection(driver, "//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[1]/div/div[4]/div/div[2]/div/div/div[1]", 3);

                    funkcijos.comboBoxSelection(driver, "//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[1]/div/div[7]/div/div[2]/div/div/div[1]", 3);

                    driver.FindElement(By.CssSelector("button[type='submit']")).Click();
                    Console.WriteLine("\nDarbuotojo informacija suvesta sėkmingai!");
                    Thread.Sleep(2000);

                    // Atidaromas ReportTo langas
                    Console.WriteLine("\nAtidaromas ReportTo langas.");
                    driver.FindElement(By.XPath("//a[normalize-space()='Report-to']")).Click();
                    Thread.Sleep(5000);

                    // Atidaromas Add Supervisor langas
                    Console.WriteLine("\nAtidaromas Add Supervisor langas.");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[2]/div[1]/div/button")).Click();
                    Thread.Sleep(1000);

                    // Suvedama informacija
                    driver.FindElement(By.XPath("//input[@placeholder='Type for hints...']")).SendKeys("a");
                    Thread.Sleep(4000);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[2]/div[1]/form/div[1]/div/div[1]/div/div[2]/div/div[2]/div[1]")).Click();

                    funkcijos.comboBoxSelection(driver, "//div[@class='oxd-select-text-input']", 3);

                    driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                    Console.WriteLine("\nDarbuotojo informacija suvesta sėkmingai!");
                    Thread.Sleep(3000);

                    //Atidaromas Employee List langas
                    Console.WriteLine("\nAtidaromas Employee List langas.");
                    driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/pim/viewEmployeeList");
                    Thread.Sleep(2000);

                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div[2]/form/div[1]/div/div[3]/div/div[2]/div/div")).Click();
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div[2]/form/div[1]/div/div[3]/div/div[2]/div/div[2]/div[4]")).Click();

                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div[2]/form/div[1]/div/div[5]/div/div[2]/div/div/input")).SendKeys("a");
                    Thread.Sleep(3000);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div[2]/form/div[1]/div/div[5]/div/div[2]/div/div[2]/div")).Click();

                    driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                    Console.WriteLine("\nPieškos duomenys suvesti sekmingai!");
                    Thread.Sleep(5000);
                    // Patikriname rezultatus
                    var result = driver.FindElements(By.CssSelector(".oxd-table-row")).Count > 0;
                    if (result)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nTestas sėkmingai atliktas! Darbuotojas rastas.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nTestas nepavyko. Darbuotojas nerastas.");
                    }
                    return userURL;
                    }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nKlaida: {ex.Message}");
                    return " ";
                }
                finally
                {
                    Console.ResetColor();
                }
            }
        }
    }
}
