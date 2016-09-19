using System;
using System.Globalization;

namespace CalculateEasterDate
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("le 12/4/2009 doit être paques");
      Console.WriteLine(GetPaquesDate(2009).ToString(CultureInfo.CurrentCulture));
      Console.WriteLine("Paques en 2016 est le ");
      Console.WriteLine(GetPaquesDate(2016).ToString(CultureInfo.CurrentCulture));
      Console.ReadKey();
    }

    private static DateTime GetPaquesDate(int annee)
    {
      //a % = An % Mod 19                               //'a = 2009 modulo 19 = 14
      //b % = An % \ 100                                //'b = 2009 / 100 = 20
      //C % = An % Mod 100                              //'c = 2009 modulo 100 = 09
      //d % = b % \ 4                                   //'d = 20 / 4 = 5
      //e % = b % Mod 4                                 //'e = 20 modulo 4 = 0
      //f % = (b % +8) \ 25                            //'f = 28 / 25 = 1
      //g % = (b % -f % +1) \ 3                        //'g = (20 - 1 + 1) / 3 = 6
      //h % = (19 * a % +b % -d % -g % +15) Mod 30     //'h = (19 * 14 + 20 - 5 - 6 + 15 ) modulo 30 = 20
      //i % = C % \ 4                                  // 'i = 09 / 4 = 2
      //k % = C % Mod 4                                // 'k = 09 modulo 4 = 1
      //l % = (32 + 2 * e % +2 * i % -h % -k %) Mod 7  // 'l = ( 32 + 2 * 0 + 2 * 2 - 20 - 1) modulo 7 = 1
      //m % = (a % +11 * h % +22 * l %) \ 451          // 'm = (14 + 11 * 20 + 22 * 1) / 451 = 0
      //n % = (h % +l % -7 * m % +114) \ 31            //'n = (20 + 1 - 7 * 0 + 114) / 31 = 4
      //p % = (h % +l % -7 * m % +114) Mod 31          //'p = (20 + 1 - 7 * 0 + 114) modulo 31 = 11
      //fPaques = DateSerial(An %, n %, p % +1)        // 'Pâques = (2009, 04, 12)

      int a = annee % 19;
      int b = annee / 100;
      int c = annee % 100;
      int d = b / 4;                                    // 'd = 20 / 4 = 5
      int e = b % 4;                                      // 'e = 20 modulo 4 = 0
      int f = (b + 8) / 25;                               //'f = 28 / 25 = 1
      int g = (b - f + 1) / 3;                            //'g = (20 - 1 + 1) / 3 = 6
      int h = (19 * a + b - d - g + 15) % 30;             //'h = (19 * 14 + 20 - 5 - 6 + 15 ) modulo 30 = 20
      int i = c / 4;                                      // 'i = 09 / 4 = 2
      int k = c % 4;                                      // 'k = 09 modulo 4 = 1
      int l = (32 + 2 * e + 2 * i - h - k) % 7;           // 'l = ( 32 + 2 * 0 + 2 * 2 - 20 - 1) modulo 7 = 1
      int m = (a + 11 * h + 22 * l) / 451;                // 'm = (14 + 11 * 20 + 22 * 1) / 451 = 0
      int n = (h + l - 7 * m + 114) / 31;              //'n = (20 + 1 - 7 * 0 + 114) / 31 = 4
      int p = (h + l - 7 * m + 114) % 31;                //'p = (20 + 1 - 7 * 0 + 114) modulo 31 = 11
      return new DateTime(annee, n, p + 1);
    }
  }
}