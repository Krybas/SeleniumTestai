using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestai.testai
{
    public class DarbuotojoPakeitimai
    {
        Functions funkcijos = new Functions();
        public void DarbuotojoPakeitimoTestas(string userURL)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                try
                {
                    Random random = new Random();
                    // Atidaromas OrangeHRM ir prisigiama
                    funkcijos.LoginToOrangeHRM(driver, "https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");

                    // Atidaroma darbuotojo asmeninis puslapis
                    Console.WriteLine("\nAtidaromas darbuotojo asmeninių duomenų puslapis");
                    driver.Navigate().GoToUrl(userURL);
                    Thread.Sleep(3000);

                    // Pakeičiame darbuotojo asmeninius duomenis
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[2]/div[1]/div[2]/div/div[2]/input")).SendKeys($"{random.Next(1, 100)}");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[2]/div[2]/div[1]/div/div[2]/input")).SendKeys($"{random.Next(100000,999999)}");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[2]/div[2]/div[2]/div/div[2]/div/div/input")).SendKeys("2022-11-16");

                    funkcijos.comboBoxSelection(driver, "//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[3]/div[1]/div[1]/div/div[2]/div/div", 5);
                    funkcijos.comboBoxSelection(driver, "//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[3]/div[1]/div[2]/div/div[2]/div/div", 1);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[3]/div[2]/div[1]/div/div[2]/div/div/input")).SendKeys("2010-12-16");

                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[3]/div[2]/div[2]/div/div[2]/div[1]/div[2]/div/label")).Click();

                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[4]/button")).Click();
                    Console.WriteLine("\nDarbuotojo duomenys pakeisti sėkmingai!");
                    Thread.Sleep(2000);

                    // Papildomi laukeliai
                    funkcijos.comboBoxSelection(driver, "//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[2]/div/form/div[1]/div/div[1]/div/div[2]/div/div", 1);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[2]/div/form/div[2]/button")).Click();
                    Console.WriteLine("\nPapildomi laukeliai pakeisti sėkmingai!");
                    Thread.Sleep(2000);

                    // Pridedami du failai 
                    for (int i = 0; i <= 1; i++) {
                        driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/div/div[2]/div[3]/div[1]/div/button")).Click();  
                        Thread.Sleep(3000);
                        driver.FindElement(By.CssSelector("input[type='file']")).SendKeys("C:/Users/arnas/Downloads/employee.jpg");
                        Thread.Sleep(1000);
                        driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/div/div[2]/div[3]/div/form/div[3]/button[2]")).Click();
                        Thread.Sleep(3000);
                    }
                    Thread.Sleep(2000);
                    Console.WriteLine("\nFailai pridėti sėkmingai!");

                    // Atnaujinti informacija apie faila
                    int count = 0;
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[3]/div[3]/div/div[2]/div[1]/div/div[8]/div/button[1]")).Click();
                    Thread.Sleep(3000);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[3]/div/form/div[3]/div/div/div/div[2]/textarea")).SendKeys("Atnaujintas aprasas");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[3]/div/form/div[4]/button[2]")).Click();
                    Console.WriteLine("\nInformacija apie failą atnaujinta sėkmingai!");
                    Thread.Sleep(3000);
                    count++;

                    // Istrinti faila
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[3]/div[3]/div/div[2]/div[2]/div/div[8]/div/button[2]")).Click();
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[3]/div/div/div/div[3]/button[2]")).Click();
                    Console.WriteLine("Failas sekmingai istrintas!");
                    Thread.Sleep(3000);
                    count++;

                    // Atsiusti faila
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[3]/div[3]/div/div[2]/div[1]/div/div[8]/div/button[3]")).Click();
                    string downloadFileName = "employee (1).jpg";
                    int waitTime = 10;
                    bool fileExists = funkcijos.WaitForFile("C:/Users/arnas/Downloads", downloadFileName, waitTime);
                    if (fileExists)
                    {
                        Console.WriteLine("Failas atsiustas!");
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("Filas nerastas.");
                    }

                    // Rezultatas
                    if (count == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nTestas sėkmingai atliktas! Darbuotojo informacija atnaujinta.");
                    } 
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nTestas nepavyko! Darbuotojo informacija nebuvo atnaujinta.");
                    }
                    Thread.Sleep(3000);
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
}
