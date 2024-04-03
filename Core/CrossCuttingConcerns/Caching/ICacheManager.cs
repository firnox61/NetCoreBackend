using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{//bizim basimiz oluak bağımmısz bir interface
    public interface ICacheManager
    {
        T Get<T>(string key);//sana bir key vereyim bellekte karşılkık olan atayı ver
        object Get(string key);
        void Add(string key, object value,int duration);//gelecek data value ve herşeyin şeyi object, cache de ne kadar duracağını belirleyece duration
        //veritaabnındanm ı yoksa cacheden mi getireceğimi karar verecek şey
        bool IsAdd(string key);//veritaabnındanm ı yoksa cacheden mi getireceğimi karar verecek şey
        void Remove(string key);
        void RemoveByPattern(string pattern);//içinde mesela get olanaları

    
    
    }







}
