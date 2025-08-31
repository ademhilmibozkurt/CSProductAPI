# ProductApi Kurulum ve Çalıştırma Rehberi

Bu rehber, **ProductApi** projesini başka bir bilgisayara taşıyıp çalıştırmak için gerekli adımları içerir. Proje, **ASP.NET Core Web API** ve **Entity Framework Core** ile geliştirilmiştir ve veritabanı olarak **MSSQL LocalDB** kullanır.

---

## Gereksinimler

* [.NET 6 SDK veya daha yeni](https://dotnet.microsoft.com/download/dotnet/6.0)
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) veya VS Code
* SQL Server LocalDB (Visual Studio ile gelir)

> LocalDB yüklü değilse terminalden çalıştırabilirsiniz:

```powershell
sqllocaldb create "ProductApiDB"
sqllocaldb start "ProductApiDB"
```

---

## Projeyi Klonlama

```bash
git clone <REPO_URL>
cd ProductApi
```

---

## appsettings.json Düzenleme

`appsettings.json` dosyasını LocalDB için şu şekilde ayarlayın:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ProductApiDb;Trusted_Connection=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

> Eğer özel bir LocalDB instance adı kullanıyorsanız `(localdb)\\<INSTANCE_NAME>` olarak değiştirin.

---

## EF Core Migration ve Database Oluşturma

Projede **Entity Framework Core** kullanılıyor, database oluşturmak için:

```bash
dotnet tool install --global dotnet-ef  # Eğer ef yüklü değilse
dotnet restore                           # Paketleri yükle
dotnet ef database update                # Migrationları uygula ve DB oluştur
```

> Eğer migration eklemek gerekirse:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## Projeyi Çalıştırma

Terminal veya Visual Studio üzerinden:

```bash
dotnet run
```

> Çalıştırdıktan sonra API varsayılan olarak `https://localhost:5001` veya `http://localhost:5000` üzerinde açılır.

---

## Swagger ile API Testi

Proje Swagger ile belgelenmiştir. Çalıştıktan sonra tarayıcıda:

```
https://localhost:5001/swagger
```

adresine giderek tüm endpointleri test edebilirsiniz.

---

## Önemli Notlar

* Eğer LocalDB çalışmıyorsa:

```powershell
sqllocaldb start MSSQLLocalDB
```

* Database bağlantısı hatası alırsanız connection string ve LocalDB instance adını kontrol edin.
* Tüm async metotlar `await` ile çağrılmalıdır, aksi halde NullReference veya deadlock hatası alabilirsiniz.