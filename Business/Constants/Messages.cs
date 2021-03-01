using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Eklendi";
        public static string Updated = "Güncellendi";
        public static string Deleted = "Silindi";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarInvalid = "Geçersiz Bilgi";
        public static string Listed = "Listelendi";
        public static string Exception = "Hata";
        public static string ImageLimitExceeded = "Görüntü Sınırı Aşıldı !";
        public static string AuthorizationDenied = "Yetkiniz Yok.";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi.";
        public static string SuccesfulLogin = "Giriş başarılı.";
        public static string PasswordError = "Parola hatası.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut.";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu.";
    }
}
