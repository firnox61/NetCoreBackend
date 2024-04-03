using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {//Result sınıfı base sınıf
        public SuccessResult(string message):base(true,message)//base bişey göndermek istiyorsak mesaj
        {

        }
        public SuccessResult():base(true)//mesaj vermek istemiyorsak productmanagerdeki succesresula içine true sunu burda yazacağız
        {

        }
    }
}
