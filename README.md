# GameDemo
This Demo made for Fabrika Games job application by Umut Karabuya
FABRIKA GAMES İŞ BAŞVURUSU İÇİN DEMO
Oyun Adı: Car-oh-Line
Oyun Motoru: Unity3D Engine 
Oyun platformu: Android 4.1+
Tür: Araba yarışı, 2D-3D platform
Oyun Geliştiricisi: Umut KARABUYA

Temel Oyun Mekaniği: 
Oyun ekranına çizilen çizimlerin araba haline dönüşüp rakibini ve engelleri geçerek finish noktasına ulaşması.
Aşamalar:
Çizgi Çizimi:
  LineRenderer ile ekrana çizgi çizimi.
  Çizilen çizgilere collider atama.
  Her çizgi için colliderı değiştirme.
  Bir çizgi çizilirken varolan diğer çizginin yok olması.
Tekerlek Ayarları:
  Çizgilerin baş ve son noktalarına tekerlek atama.
  Tekerleklere WheelJoint ve Collider verilmesi.
  Tekerleklerin Anchor noktalarını çizginin baş ve son noktası olarak ayarlama.
  WheelJoint motor ayarları.
 Level Dizaynı:
  Level tasarımı (SpriteShape ile eğri yollar tasarlama).
  Engel tasarımları (SpriteShape).
  Engellere Collider ve tag verme.
  Finish çizgisini oluşturma ve rakip ve oyuncu için ayrı trigger yazılımı.
Kullanışlı Arayüz tasarımı:
  Her android telefona uyumlu butonlar.
  Buton sesleri.
  Credits menüsü.
  Oyun müziği.
  Oyun müziğini kapatma butonu.
  Game Over menüsü.
  Önceki levelden başlama butonu.
  Pause menüsü.
Açıklamalar:
Ekrana çizgi çizme konsepti ile yeni tanıştığımdan ilk olarak çeşitli araştırmalar yaptım. Araştırmalar sonucunda ilk olarak TrailRenderer kullandım. Istediğim verimi alamayınca LineRenderer kullanmaya karar verdim.
Neden yok?
•	UI Kısmında çizerek araç oluşturma ekran kullanımını azalttığı için direk ekrana çizmeye karar verdim. 
o	(LineRenderer.Bakemesh ile Çizdiğim çizgilerin bodylerini atama yapıp aynı mekaniği sağlayabilirdim).

•	3D yollar, Yolları kendim yapmak istediğim için hazır Asset kullanmak istemedim ve zaman darlığından SpriteShape ile yolları 2D tasarladım.
o	AssetStore da birçok 3D yol için hazır Prefab bulunmakta.

•	Aracın bulunduğu şekilde kalması daha eğlenceli olduğunu düşündüğümden yaptım.
o	Line Rigidbody2D de Rotation Zyi açarsak aynı şekilde kalmayıp 2 tekerlekte aşağıya iniyor.
Neler yapabilirim?
	Rakip araç için Yapay Zekâ yazabilirim. (Birçok body’i Array olarak atama ve engellere takıldığında random olarak body değiştirme)
	Daha iyi kamera kontrolü.
	Geniş Level dizaynları.
	Yarışçı takip sistemi.
	Leveller menüsü.
	Çizdiğimiz çizginin rengini değiştirme.
	Farklı motorlar ekleme (Yavaş motor, hızlı motor)
	Tekerlek tipleri ekleme (Levele göre tekerlek tipleri)
	UI Ekranında çizim.


Teşekkür Edeirm.
UMUT KARABUYA
HKTECH Game Development.
