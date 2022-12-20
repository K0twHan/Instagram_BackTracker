using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
namespace Instagram_follower_dumper
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Instagram FB Program";
            Console.ForegroundColor= ConsoleColor.DarkRed;
            Console.WriteLine("Kulanıcı Adınızı Girin lütfen");
            Console.ForegroundColor= ConsoleColor.DarkGreen;
           string kullanici_adi = Console.ReadLine();
            Console.ForegroundColor= ConsoleColor.DarkRed;
            Console.WriteLine("Şifrenizi Girin Lütfen");
            Console.ForegroundColor= ConsoleColor.DarkCyan;
            string sifre = Console.ReadLine();
            Console.ResetColor();
            Selenium a = new Selenium();
            a.Instagram();
            Thread.Sleep(1500);
            a.SifreGir(kullanici_adi,sifre);
            a.Giris_yap();
            Thread.Sleep(5500);
            a.profili_ac(kullanici_adi);
            Thread.Sleep(1500);
            a.Takipci_gir();
            Thread.Sleep(1500);
            a.Takipcileri_cek();
            Thread.Sleep(1500);
            a.Following_gir(kullanici_adi);
            Thread.Sleep(2500);
            a.Following_cek();
            Thread.Sleep(2500);
            a.Karsilastir();
            Thread.Sleep(2500);
            
            
        }
    }
}