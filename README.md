# CarRouteWebApplication
Araç rotası uygulaması
<hr>

Bu projede Google Maps API kullanarak araçların rotalarını oluşturan bir uygulama geliştirilmiştir. Projede MSSQL ve ASP.NET MVC altyapısı kullanılmıştır.

<br>

## Database <br>
*İlk olarak veri tabanında bir tablo oluşturarak araçların hangi rotaları takip edeceğinin bilgisi girilmiştir. Burada* <b>startLocationLat</b> *ve* <b>startLocationLng</b> *kolonları rotanın başlangıç şehrinin koordinatlarını belirtmektedir. Rotanın bitiş şehrinin 
koordinatları ise* <b>endLocationLat</b> *ve* <b>endLocationLng</b> *kolonlarında tutulur. Bu kolonlar kısaca şehirlerin enlem ve boylamlarını tutar ve daha sonradan rotayı oluşturmak için kullanılır.*

<img src="https://github.com/onurakcakale/CarRouteWebApplication/blob/main/screenshots/tablo.jpg" width="auto"> <br> <br>

## Proje <br>
*Tablo ekleme işleminden sonra MVC projesinde bu tablonun model olarak içeri aktarılması gerekir. Burada DBFirst mantığı yer aldığı için MVC tarafında ADO.NET kullanılmıştır. Bu sayede veri tabanı modeli hızlı bir şekilde projeye aktarılmıştır*

<img src="https://github.com/onurakcakale/CarRouteWebApplication/blob/main/screenshots/adonet.jpg" width="auto"> <br> <br>

*Araçların rotalarını harita üzerinde oluşturmak için Google'ın sunmuş olduğu Maps API'den faydalanabiliriz. Google Cloud Console üzerinden bir adet API key almamız gerekiyor. Bu API key bize Google'ın sunmuş olduğu hizmetten faydalanabilmemiz için gereklidir. API key'i
aldıktan sonra* <b>Enable</b> *edip* <b>Guides</b> *üzerinden gerekli dökümanları inceleyip bilgi sahibi olabilirsiniz*.

<img src="https://github.com/onurakcakale/CarRouteWebApplication/blob/main/screenshots/maps_api2.png" width="auto"> <br> <br>
<img src="https://github.com/onurakcakale/CarRouteWebApplication/blob/main/screenshots/maps_api.jpg" width="auto"> <br> <br>

*API keyi aldıktan sonra proje içerisinde gerekli olan* <b><script></b> *eklememiz gerekiyor. Google Cloud Console üzerinden almış olduğumu API keyi script tagleri içerisinde* <b>YOUR_API_KEY_HERE</b> *kısmına yapıştır yaptıktan sonra API'yi kullanılmaya hazırdır.*

<img src="https://github.com/onurakcakale/CarRouteWebApplication/blob/main/screenshots/apikey.jpg" width="auto"> <br> <br>

<br>

*Rotamızı harita üzerinde gösterebilmemiz için javascript kodlarıyla haritamızı oluşturmamız ve harita üzerinde belirlenen rotayı otomatik olarak oluşturmamız gerekiyor. Haritayı oluşturmakla işe başlayalım.*

<img src="https://github.com/onurakcakale/CarRouteWebApplication/blob/main/screenshots/initmap.jpg" width="auto"> <br> <br>

*DirectionsService nesnesini kullanarak yol tariflerini (çeşitli ulaşım yöntemlerini kullanarak) hesaplayabilirsiniz. Bu nesne, yön isteğini alan ve etkili bir yol döndüren Google Haritalar API Yol Tarifi Hizmeti ile iletişim kurar. Bu yön sonuçlarını kendiniz 
işleyebilir veya aynısını oluşturmak için DirectionsRenderer nesnesini kullanabilirsiniz. InitMap fonksiyonuna şehirlerin konunm bilgileri parametre olarak gönderilmektedir. Bu parametreler html sayfasındaki grid içerisinden gönderilmektedir. Harita oluşturulur fakat 
sayfa ilk açıldığı anda herhangi bir konum bilgisi almadığı için harita boş görünecektir. Daha sonradan grid üzerinden konum bilgileri buraya gönderildiğinde gönderilen konumlara göre harita kendini şekillendirecektir.* <br> <br>

<img src="https://github.com/onurakcakale/CarRouteWebApplication/blob/main/screenshots/calculateRoute.jpg" width="auto"> <br> <br>

*Burada initMap fonksiyonundan gönderilern parametrelerle iki lokasyon arasındaki rota oluşturulur. directionService içerisinde* <b>origin</b> *başlangıç lokasyonunu,* <b>destination</b> *ise varış lokasyonunun enlem ve boylam bilgilerini alır.* <b>TravelMode</b> 
*burada* <b>'DRIVING'</b> *olarak ayarlanmıştır çünkü bu proje için araçlara bir rota çizmek istiyoruz. Bunun için olan en uygun mod ise DRIVING modudur. Eğer siz daha farklı bir mod ile rotanızı oluşturmak istiyorsanız dökümanları inceleyerek size uygun olan seyahat
modunu buraya girebilirsiniz.* <br> <br> <br>

*Artık başlangıç ve bitiş lokasyonlarımızın enlem ve boylam bilgileri girildi ve seyahat modunu da ayarladık. Bu bilgileri directionsService'e gönderdikten sonra gelen response değerine göre eğer rota başarılı bir şekilde oluşturlursa*
<b>directionsRenderer.SetDirections(response)</b> *diyerek rotayı harita üzerinde oluşturabiliriz. İki rota arasındaki mesafe ve süre bilgileri gelen response içerisinde mevcut. Bu bilgleri response içerisinden alarak haritanın üzerindeki alanlara yerleştirerek rotanın
uzunluğunu ve süresini de böylece görebilirsiniz* <br>

<img src="https://github.com/onurakcakale/CarRouteWebApplication/blob/main/screenshots/build.jpg" width="auto">
