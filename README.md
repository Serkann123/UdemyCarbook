<div align="center">

# CarBook Araç Kiralama Projesi

**Asp.Net Core Api 8.0 ve Onion Architecture kullanılarak geliştirilen Araç Kiralama Projesi**

[Hakkında](#hakkında) • [Görseller](#görseller)

</div>

## 🪶 Projenin Amacı;

Proje bir araç kiralama uygulamasıdır. Kullanıcılar lokasyona göre araçları filtreleyebilir ve seçilen araçlar için rezervasyon oluşturabilirler. Bununla birlikte blogları görüp okuyabilir, etiket sistemine, yazarlara ve kategorilere göre bloglarda listeleme yapabilmektedirler. Okudukları bloglara ve aldıkları araca yorum yapabilmektedirler. İletişim formundan sistem yöneticisine mesaj atabilmektedir. Bununla birlikte güçlü bir yönetim arayüzü olan uygulamada bütün bu sistem rol bazlı yönetim sistemiyle kontrol edilmektedir.

## 🛠️ Kullanılan Bazı Teknolojiler

- 🧅 Proje Onion Architecture mimarisi kullanılarak geliştirildi.
- ⚙️ Proje CQRS ve Mediator Design Patterns üzerine kuruldu.
- 🗄️ DbCodeFirst ile MSSQL veritabanı oluşturulup yönetimi sağlandı.
- 🔗 Entity Framework 8.0 Veritabanı etkileşimi ve ORM için kullanıldı.
- 🔐 JWT Token ile süre bazlı token oluşturup POSTMAN ile testleri yapıldı.
- 👥 Üyelik sistemi Jwt ile kontrol edilip rol bazlı yetkilendirme sağlanmıştır.
- 🌐 Bütün proje RESTful API'larla bütün CRUD işlemlerini yapabilir şekilde oluşturuldu.
- 🛠️ Proje Admin adlı bir Area vardır ve ana ekrandan ayrılmaktadır.
- 📐 Bütün proje SOLID prensipleriyle ve folder structure yapısıyla oluşturuldu.
- 📦 DTO katmanıyla veri yönetimi kolaylaştırıldı.
- 🎨 HTML-CSS Bootstrap ile arayüzler tasarlandı.
- 🛡️ Fluent Validation - kontrol sistemi kullanılarak verilerin belli kurallara göre alınması sağlandı.
- 🧩 Projede bol bol iç içe layout ve ViewComponent yapısı kullanıldı.

## Görseller

### Veritabanı
<img width="1437" height="697" alt="Ekran görüntüsü 2026-01-01 225356" src="https://github.com/user-attachments/assets/024e6d7d-fc70-4f6c-955e-41b244d15b51" />

---

### Kullanıcı Giriş Sayfası

<img width="1917" height="923" alt="Login" src="https://github.com/user-attachments/assets/7b2161da-30ef-4ad8-a606-8612e0de7573" />

### Ana Sayfa

<img width="1906" height="927" alt="Anasayfa1" src="https://github.com/user-attachments/assets/e4286d57-879b-4bfb-ae8d-1c9eb4740399" />

### Araç Kiralama Fiyatları

<img width="1897" height="917" alt="AraçFiyatları" src="https://github.com/user-attachments/assets/3b4d9ba8-8019-499a-835e-b57467e56b1d" />

### Öne Çıkan Araçlar

<img width="1897" height="915" alt="Arabalar" src="https://github.com/user-attachments/assets/e200cbab-a3f9-48d2-b266-0937547cad6e" />

### Araç Detayları

<img width="1895" height="915" alt="AraçDetayları" src="https://github.com/user-attachments/assets/78befbe7-b290-4c7c-a352-451e37c90462" />

### Bloglar

<img width="1898" height="917" alt="Bloglar" src="https://github.com/user-attachments/assets/49c73178-6fe7-4e1b-bb6a-e7961bbe6c34" />

### Sistem İstatistikleri

<img width="1897" height="921" alt="İstatistikler" src="https://github.com/user-attachments/assets/4e6afbe0-03e9-4c68-a554-1bead74e8d33" />

### Bekleyen Rezervasyonlar

<img width="1900" height="921" alt="RezervasyonOnay" src="https://github.com/user-attachments/assets/0f55e57d-e261-40e3-b761-c5acfbcbc13c" />

### Lokasyonlar

<img width="1915" height="920" alt="Lokasyonlar" src="https://github.com/user-attachments/assets/4d8c6f4f-96f1-4d13-8438-5b275ec612b1" />

### Admin Panel – Blog Yönetimi

<img width="1897" height="921" alt="AdminBlog" src="https://github.com/user-attachments/assets/77831d81-f4d9-42fe-b670-3a493dd88de8" />

