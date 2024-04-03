using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)//params verdiğimiz zaman istediğimiz kadar parametre olarak Iresult verebiliyoruz arraye atıyor
        {//logics kural
            foreach (var logic in logics)
            {
                if (!logic.Success ) //başarısızzsa
                {
                    return logic;
                }
               
            }
            return null;
        }
    }
}
