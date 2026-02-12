# 📚 Kütüphane Yönetim Sistemi API

Bu proje, bir kütüphanedeki kitap kiralama, kullanıcı yönetimi ve envanter takibi süreçlerini yönetmek için geliştirilmiş bir **Web API** çözümüdür.

## 🚀 Projenin Amacı
Kullanıcıların kütüphaneden kitap ödünç alabilmesini, alış/iade tarihlerinin takibini ve kitap stok yönetimini dijital bir platform üzerinden kolayca gerçekleştirmektir.

## 🛠️ Kullanılan Teknolojiler
* **Backend:** .NET / ASP.NET Core API
* **Veritabanı:** MSSQL (Manuel Bağlantı / SQL Client)
* **Mimari:** Katmanlı Mimari (N-Tier Architecture)

---

## 📊 Veritabanı Yapısı

Sistem, görseldeki planlama doğrultusunda şu 3 ana tablo üzerinden çalışmaktadır:

1. **Kullanıcılar (kullanici tablosu):** `Id`, `Ad`, `Email`, `Telefon` bilgilerini içerir.
2. **Kitaplar (kitaplar tablosu):** `Id`, `KitabinAdi`, `KitabinYazari`, `Adet` bilgilerini içerir.
3. **Alınan Kitaplar (alinan kitaplar tablosu):** Kullanıcı ve kitap eşleşmesini sağlar. `Alindigi Tarih` ve `Verildigi Tarih` alanları ile kiralama süresini takip eder.

---

## 🛣️ API Uç Noktaları (Endpoints)

### 👤 Kullanıcı İşlemleri
* `getAllKullanici`: Tüm kullanıcıları listeler.
* `getbyidkullanici`: ID'ye göre kullanıcı getirir.
* `createkullanici`: Yeni kullanıcı kaydı oluşturur.
* `updatekullanici`: Kullanıcı verilerini günceller.
* `deletekullanici`: Kullanıcı kaydını siler.

### 📖 Kitap İşlemleri
* `getallkitap`: Mevcut tüm kitapları listeler.
* `getkitapbysearch`: Kitap ismine veya yazarına göre arama yapar.
* `createkitap`: Yeni kitap ekler.
* `updatekitap` & `deletekitap`: Kitap düzenleme ve silme işlemleri.

### 🔄 Kiralama (Ödünç Alma) İşlemleri
* `getallalinankitap`: Aktif ve geçmiş kiralama listesini getirir.
* `createalinankitap`: Yeni bir kitap kiralama işlemi başlatır.
* `updatealinankitap`: İade tarihi veya durum güncellemesi yapar.

---

## ⚙️ Kurulum ve Yapılandırma

1.  **Veritabanı Kurulumu:** * SQL Server üzerinde görseldeki tablo yapılarını (Id, Ad, Email vb.) oluşturun.
2.  **Bağlantı Ayarı:** * Proje içerisindeki veritabanı bağlantı cümlesini (Connection String) kendi yerel SQL Server bilgilerinizle güncelleyin.
3.  **Çalıştırma:**
    ```bash
    dotnet run
    ```

---

### 🤝 İletişim
Geliştirici: **ÇağatayOk** Linkedin: (https://www.linkedin.com/in/cagatayok/)







