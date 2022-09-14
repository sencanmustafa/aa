using System;
namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //{get; (read only demek)} read only ler ctor icinde set edilebilir !
        //eger messaj vermek ister ama success yollamaz ise this(success) ile otomatikmen line 15 deki success donuyor (success mutlaka set edilmeli)
        public Result(bool success, string message):this(success)
        {
            Message = message;
            

        }
        //overloading mesaj set etmek istemeyebiliriz ama succes etmeliyiz
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}

