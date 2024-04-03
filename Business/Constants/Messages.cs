using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {//sadece mesaj ve sabit olduğu ve newlememek için static yapıyoruz
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime="Sistem bakımda";
        public static string ProductsListed="Ürünler Listelendi";
        public static string ProductDeleted="Ürün Silindi";
        public static string ProductUpdated="Ürün güncellendi";
        public static string ProductCountCategoryIdLimit="Bu categoride en fazla 10 ürün olabilir";
        public static string CategoryLimitExceded ="Category limit aşılıd ürün eklenemez";
        public static string AuthorizationDenied="Yetkiniz Yok";
        public static string UserRegistered="Kullanıcı kayıt oldu";
        public static string UserNotFound= "Kullanıcı bulunamadı";
        public static string PasswordError="pasaword hatalı";
        public static string SuccessfulLogin="Başarılı kayıt";
        public static string UserAlreadyExists="kullanıcı mevcut";
        public static string AccessTokenCreated="Token oluşturuldu";
        public static string SuccessfulLog="Başarılı bir giriş yapıldı";
    }
}
