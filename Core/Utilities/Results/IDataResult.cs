using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{//<T> hangi dili döndüreceğini söyle demek :IResult sen aynı zamanda implementasyonusun ama senin dışında T türünde bir data olacak
    //inter interi implement ederse direk veriyi alır
    public interface IDataResult<T>:IResult
    {
        T Data { get; }//hereşeye erişebilir
    }
}
