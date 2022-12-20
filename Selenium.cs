using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
namespace Instagram_follower_dumper
{

    public class Selenium
    {
        IWebDriver krom = new ChromeDriver();
        public void Instagram()
        {

            krom.Navigate().GoToUrl(@"https://www.instagram.com");
        }
        public void SifreGir(string kullanici_adi, string sifre)
        {

            krom.FindElement(By.CssSelector("input[name='username']")).SendKeys(kullanici_adi);
            krom.FindElement(By.CssSelector("input[name='password']")).SendKeys(sifre);
        }
        public void giris_yap()
        {
            krom.FindElement(By.CssSelector("[class='_ab8w  _ab94 _ab99 _ab9f _ab9m _ab9p _abcm']")).Click();
        }
        public void profili_ac(string kullanici_adi)
        {
            krom.Navigate().GoToUrl("https://www.instagram.com/" + kullanici_adi + "/");
        }
        public void takipci_gir()
        {
            string urlm = krom.Url;
            krom.Navigate().GoToUrl(urlm + "followers");
        }
        public void takipcileri_cek()
        {
            //js code
            string jscommand = "" + "sayfa=document.querySelector('._aano');" + "sayfa.scrollTo(0,sayfa.scrollHeight);" + "var sayfasonu=sayfa.scrollHeight;" + "return sayfasonu;";
            //
            IJavaScriptExecutor js = (IJavaScriptExecutor)krom;
            Console.Clear();

            var sayfasonu = Convert.ToInt16(js.ExecuteScript(jscommand));
            while (true)
            {
                var son = sayfasonu;
                Thread.Sleep(1500);
                sayfasonu = Convert.ToInt16(js.ExecuteScript(jscommand));
                if (son == sayfasonu)
                {
                    break;
                }
            }
            
            IReadOnlyCollection<IWebElement> takipci = krom.FindElements(By.CssSelector("[class='_aacl _aaco _aacw _aacx _aad7 _aade']"));
            int sayac = 1;
            string username = "C:\\Users\\"+Environment.UserName+"\\Desktop\\takipci_listesi.txt";
            
            
            StreamWriter sw = new StreamWriter(username);
            foreach (IWebElement takipciler in takipci)
            {
                Console.WriteLine(sayac + "==>" + takipciler.Text);
                sw.WriteLine(takipciler.Text + "");

                sayac++;
            }
            sw.Close();

        }
        public void following_gir(string kullanici_adi)
        {
            krom.Navigate().GoToUrl("https://www.instagram.com/" + kullanici_adi + "/following/");
        }
        public void following_cek()
        {
            string jscommand = "" + "sayfa=document.querySelector('._aano');" + "sayfa.scrollTo(0,sayfa.scrollHeight);" + "var sayfasonu=sayfa.scrollHeight;" + "return sayfasonu;";
            //
            IJavaScriptExecutor js = (IJavaScriptExecutor)krom;
            Console.Clear();

            var sayfasonu = Convert.ToInt16(js.ExecuteScript(jscommand));
            while (true)
            {
                var son = sayfasonu;
                Thread.Sleep(1500);
                sayfasonu = Convert.ToInt16(js.ExecuteScript(jscommand));
                if (son == sayfasonu)
                {
                    break;
                }
            }
            
            IReadOnlyCollection<IWebElement> takipci = krom.FindElements(By.CssSelector("[class=' _ab8y  _ab94 _ab97 _ab9f _ab9k _ab9p _abcm']"));
            int sayac = 1;
            string username = "C:\\Users\\" + Environment.UserName + "\\Desktop\\takip_edilen_listesi.txt";
            StreamWriter sw = new StreamWriter(username);
            foreach (IWebElement takipciler in takipci)
            {

                Console.WriteLine(sayac + "==>" + takipciler.Text);
                sw.WriteLine(takipciler.Text + "");

                sayac++;
            }
            sw.Close();
            krom.Close();
        }
        public void karsilastir()
        {
            string username = "C:\\Users\\" + Environment.UserName + "\\Desktop\\Gt_Atmayanlar_Listesi.txt";
            StreamWriter sw = new StreamWriter(username);

            string username1 = "C:\\Users\\" + Environment.UserName + "\\Desktop\\takipci_listesi.txt";
            string[] dizi = File.ReadAllLines(username1);
            string username2 = "C:\\Users\\" + Environment.UserName + "\\Desktop\\takip_edilen_listesi.txt";
            string[] dizi2 = File.ReadAllLines(username2);
              
            Array.Sort(dizi);
            Array.Sort(dizi2);

            if (dizi.Length > dizi2.Length)
            {
                for (int i = 0; i < dizi2.Length; i++)
                {
                    if (Array.IndexOf(dizi, dizi2[i]) == -1)
                    {
                        sw.WriteLine(dizi2[i]);
                    }
                }

            }
            else
            {
                for (int i = 0; i < dizi2.Length; i++)
                {
                    if (Array.IndexOf(dizi, dizi2[i]) == -1)
                    {
                        sw.WriteLine(dizi2[i]);
                    }
                }
            }
            sw.Close();
            
        }


    }
}
/*js code
string jscommand = "" + "sayfa=document.querySelector('._aano');" + "sayfa.scrollTo(0,sayfa.scrollHeight);" + "var sayfasonu=sayfa.scrollHeight;" + "return sayfasonu;";
//
IJavaScriptExecutor js = (IJavaScriptExecutor)chrome;
Console.Clear();

var sayfasonu = Convert.ToInt16(js.ExecuteScript(jscommand));
while (true)
{
    var son = sayfasonu;
    Thread.Sleep(1500);
    sayfasonu = Convert.ToInt16(js.ExecuteScript(jscommand));
    if (son == sayfasonu)
    {
        break;
    }
}

IReadOnlyCollection<IWebElement> takipci = chrome.FindElements(By.CssSelector("[class='_aacl _aaco _aacw _aacx _aad7 _aade']"));
int sayac = 1;
StreamWriter sw = new StreamWriter("C:\\Users\\Batuhan\\Desktop\\takipci_listesi.txt");
foreach (IWebElement takipciler in takipci)
{
    Console.WriteLine(sayac + "==>" + takipciler.Text);
    sw.WriteLine(takipciler.Text + "");

    sayac++;
}
sw.Close();
Console.ReadKey();
*/
