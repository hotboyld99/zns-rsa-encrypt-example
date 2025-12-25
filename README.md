# RSA OAEP Cross‑Language Encryption Demo

Dự án này minh hoạ **mã hoá RSA OAEP** (OAEP + MGF1) và **tương thích đa ngôn ngữ** giữa **PHP, Node.js, Java, Python và .NET**.

Mục tiêu chính:

-   Đảm bảo **ciphertext được tạo ở một ngôn ngữ có thể giải mã ở ngôn ngữ khác**
-   Thống nhất cấu hình **RSA OAEP (hash + mgfHash)**

---

## 📁 Cấu trúc thư mục

```
.
├── dotnet/
│   ├── Program.cs
│   └── dotnet.csproj
│
├── java/
│   ├── pom.xml
│   └── src/main/java/zalo/zns/Main.java
│
├── nodejs/
│   ├── app.js
│   └── package.json
│
├── php/
│   ├── app.php
│   └── composer.json
│
├── python/
│   ├── app.py
│   └── requirements.txt
│
├── public_key.pem.example
└── .gitignore
```

---

## 🔐 Thuật toán & Cấu hình chung

Tất cả các ngôn ngữ đều sử dụng **RSA Encryption** với cấu hình thống nhất:

| Thành phần | Giá trị  |
| ---------- | -------- |
| Padding    | RSA OAEP |
| Hash       | SHA‑256  |
| MGF1 Hash  | SHA‑1    |
| Output     | Base64   |

---

## 🔑 Chuẩn bị Public Key

1. Copy file mẫu:

```bash
cp public_key.pem.example public_key.pem
```

2. Nội dung public key (ví dụ):

```pem
-----BEGIN PUBLIC KEY-----
MIIBIjANBgkq...
-----END PUBLIC KEY-----
```

> 🔒 **Private key không được commit vào repo**

---

## ▶️ Chạy từng ngôn ngữ

### 🐘 PHP

```bash
cd php
composer install
php app.php
```

---

### 🟢 Node.js

```bash
cd nodejs
npm install
node app.js
```

---

### ☕ Java

```bash
cd java
mvn clean package
mvn exec:java -Dexec.mainClass="zalo.zns.Main"
```

---

### 🐍 Python

```bash
cd python
pip install -r requirements.txt
python app.py
```

---

### 🔵 .NET

```bash
cd dotnet
dotnet add package BouncyCastle.NetCore
dotnet run
```

---

## 👤 Tác giả

**Trung Hiếu**
Backend Engineer

---

## 📄 License

MIT License
