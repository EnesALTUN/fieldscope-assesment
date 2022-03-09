# Robotların 1 Boyutlu Düzlem Üzerinde Birbirlerini Bulma Algoritması

Algoritma çözümüm için öncelikle sistem içerisinde robotları temsil edecek olan “FieldRobot” isimli sınıfı oluşturdum. Bu sınıf içerisinde robota ait özellik ve metot tanımları yer almaktadır. Bunlar;

##	Özellikler
-	**Location:** Robotun düzlem üzerinde anlık olarak bulunduğu konumu gösterir.

- **LandingLocation:** Robotun düzleme iniş yaptığı (paraşütünü bıraktığı) konumu gösterir.

- **IsFoundParachute:** Robotun, diğer robota ait paraşütü bulup bulmadığını gösterir.

- **IsFoundRobot:** Robutun, diğer robotu bulup bulmadığını gösterir.

- **FoundParachuteDirection:** Diğer robota ait paraşüt bulunduysa, hangi yöne doğru ilerlerken paraşütün bulunduğunu gösterir. Bu özellik kullanılarak robot hareket ettirilirken diğer robota ait bir iz bulunduğunu ve sonrasında bu yönde arama işlemini gerçekleştirmesi sağlanır.

- **RobotCount:** Sistemde kaç adet robotun bulunduğunu gösterir. Bu özellik sadece robot oluşturulurken ekranda kaçıncı robutun oluşturulduğu bilgisi göstermek amacıyla kullanılmıştır.

## Metotlar
- **Constructor:** Robotların düzleme iniş işlemi yapılmaktadır. İniş noktası rastgele olarak atanır ve bu atanan değer iniş noktası (LandingLocation) olarak belirlenir.

- **MoveLeft:** Robotun bulunduğu konumdan sola doğru hareket etmesini sağlar. İlgili metot parametre olarak kaç adım atacağını, atacağı adım sayısının kaç adetinin öncesinde adım atmadığı mesafe olduğunu ve sistemde bulunan diğer robotu alır. Burada öncelikle robot başlangıç noktasına götürülür. Ardından öncesinde taradığı noktalar tekrardan taramaması için “MoveWithoutScanning” metodu çalıştırılır ve robot düzlemle tarama işlemi yapmadan ilerletilir. Ardından her bir adımında 1 birim olacak şekilde çevresini tarama işlemini gerçekleştirir. Tarama işlemi sırasında diğer robot bulunmuş ise ilerleme o noktada kesilir.

- **MoveRight:** Robotun bulunduğu konumdan sola doğru hareket etmesini sağlar. İlgili metot parametre olarak kaç adım atacağını, atacağı adım sayısının kaç adetinin öncesinde adım atmadığı mesafe olduğunu ve sistemde bulunan diğer robotu alır. Burada öncelikle robot başlangıç noktasına götürülür. Ardından öncesinde taradığı noktalar tekrardan taramaması için “MoveWithoutScanning” metodu çalıştırılır ve robot düzlemle tarama işlemi yapmadan ilerletilir. Ardından her bir adımında 1 birim olacak şekilde çevresini tarama işlemini gerçekleştirir. Tarama işlemi sırasında diğer robot bulunmuş ise ilerleme o noktada kesilir.

- **ResetLocation:** Robotu, iniş yaptığı noktaya gönderir.

- **MoveWithoutScanning:** Robotun, öncesinde taradığı noktaları tekrardan taramadan ilerlemesi için kullanılmaktadır.

- **FirstScanning:** Robotlar düzleme iniş yaptıktan sonra çevresini taramaları için kullanılmaktadır. Robotlar yan yana indikleri taktirde direkt olarak sonuç gösterilir.

- **LeftsScanning:** Robot, 1 birim solunda paraşüt veya diğer robotun olup olmadığını belirleyebilmek için kullanılmaktadır.

- **RightScanning:** Robot, 1 birim solunda paraşüt veya diğer robotun olup olmadığını belirleyebilmek için kullanılmaktadır.

## Algoritma Çalışma Düzeni
1.	Sistemin ne kadar sürede işlem gerçekleştirdiğini hesaplayabilmek için StopWatch sınıfından “timer” instance’ ı oluşturuldu.
2.	Robotların başlangıç noktasının sağını ve solunu kontrol etmesi tek bir işlem olarak hesaplanır ve bu değer “countOfDirectionChanges” isimli değişken içerisinde tutulur.
3.	Robotların, keşif yaparken kaç adım ilerleyeceği “stepsCount” isimli değişken içerisinde tutulur.
4.	Sistemde robotlar oluşturulur.
5.	Robotlar iniş yaptıkları noktada etrafını taraması için “FirstScanning” metodu çalıştırılır.
6.	Tek bir yönde ilerleyeceği adım sayısı “stepsCount” ile “countOfDirectionChanges” değerlerinin çarpımı sonucunda bulunur. Hesaplama sonucu bize ilerlenecek yönde kaç adım atılacağı bilgisini verir.
7.	İlk robot sola doğru ilerler ve bu ilerleme sırasında diğer robot bulunursa işlem sonlandırılır.
8.	İlerleme sonucunda ikinci robota rastlamadığı taktirde, ikinci robot sağa doğru ilerler ve ilk robotu arar.
9.	İkinci robot, ilk robotu bulamadıysa bu sefer ilk robot sağa doğru ilerler.
10.	İlk robot tarafından ikinci robot bulunamadıysa, ikinci robot sola doğru ilerlemesini gerçekleştirir.
11.	Adım 6 ve adım 10, robotlar birbirlerini bulana dek sırasıyla çalıştırılır.
12.	Timer durdurularak işlemin ne kadar süre içerisinde gerçekleştirildiği ekrana yazdırılır.
