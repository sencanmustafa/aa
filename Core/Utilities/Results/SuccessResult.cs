using System;
namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        //bu sinif basarili resultlari otomatik dondurmek icin var her turlu message alacak , true succes degerini ise Result tan alacak base() => result demek
        public SuccessResult(string message):base(true,message)
        {

        }
    }
}

