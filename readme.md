# Тестовое задание на программиста-стажера PHP от Infotecs
HTTP-сервер на PHP для предоставления информации по географическим объектам.
Данные взяты из географической базы данных GeoNames.
## city_id_info
Метод принимает идентификатор geonameid и возвращает информацию о городе.
Пример запроса:
http://localhost:8080/hello.php/api/city_id_info?geonameid={айди города}
http://localhost:8080/hello.php/api/city_id_info?geonameid=554234
```
{
  "id": "554234",
  "name": "Kaliningrad",
  "acsiiname": "Kaliningrad",
  "alternatenames": [
    "Caliningrado",
    "Calininopolis",
    "KGD",
    "Kalinin'nkrant",
    "Kaliningrad",
    "Kaliningrada",
    "Kaliningradas",
    "Kaliningrado",
    "Kaliningradum",
    "Kaliningrau",
    "Kaliningráu",
    "Kalininqrad",
    "Kalinjingrad",
    "Kalinyingrad",
    "Kalinyingrád",
    "Kalińingrad",
    "Kalíníngrad",
    "Karaliaucios",
    "Karaliaucius",
    "Karaliaučios",
    "Karaliaučius",
    "Kaļiņingrada",
    "Kenisberg",
    "Koenigsbarg",
    "Koenigsberg",
    "Koenigsberg in Preussen",
    "Korigsberg",
    "Krolewiec",
    "Królewiec",
    "Kënisberg",
    "Königsbarg",
    "Königsberg",
    "Königsberg in Preußen",
    "Körigsberg",
    "jia li ning ge lei",
    "kalininagrada",
    "kalliningeuladeu",
    "kalynynghrad",
    "kalynyngrad",
    "kariningurado",
    "qlynyngrd",
    "Καλίνινγκραντ",
    "Калининград",
    "Калињинград",
    "Калінінград",
    "Կալինինգրադ",
    "קלינינגרד",
    "كالينينغراد",
    "کالیننگراڈ",
    "کالینینگراد",
    "کیلننگراڈ",
    "कालिनिनग्राद",
    "ಕಲಿನಿನ್‍ಗ್ರಾಡ್",
    "კალინინგრადი",
    "カリーニングラード",
    "加里寧格勒",
    "칼리닌그라드"
  ],
  "latitude": "54.70649",
  "longitude": "20.51095",
  "feature class": "P",
  "feature code": "PPLA",
  "country code": "RU",
  "cc2": "",
  "admin1 code": "23",
  "admin2 code": "825118",
  "admin3 code": "",
  "admin4 code": "",
  "population": "475056",
  "elevation": "",
  "dem": "2",
  "timezone": "Europe/Kaliningrad",
  "modification date": "2023-10-20"
}
```
## page_cities
Метод принимает страницу и количество отображаемых на странице городов и возвращает список городов с их информацией.
http://localhost:8080/hello.php/api/page_cities?page={количество страниц}&count={количество городов на странице}
http://localhost:8080/hello.php/api/page_cities?page=3&count=5
```
[
  {
    "id": "451747",
    "name": "Zyabrikovo",
    "acsiiname": "Zyabrikovo",
    "alternatenames": [
      ""
    ],
    "latitude": "56.84665",
    "longitude": "34.7048",
    "feature class": "P",
    "feature code": "PPL",
    "country code": "RU",
    "cc2": "",
    "admin1 code": "77",
    "admin2 code": "",
    "admin3 code": "",
    "admin4 code": "",
    "population": "0",
    "elevation": "",
    "dem": "204",
    "timezone": "Europe/Moscow",
    "modification date": "2011-07-09"
  },
  {
    "id": "451748",
    "name": "Znamenka",
    "acsiiname": "Znamenka",
    "alternatenames": [
      ""
    ],
    "latitude": "56.74087",
    "longitude": "34.02323",
    "feature class": "P",
    "feature code": "PPL",
    "country code": "RU",
    "cc2": "",
    "admin1 code": "77",
    "admin2 code": "",
    "admin3 code": "",
    "admin4 code": "",
    "population": "0",
    "elevation": "",
    "dem": "215",
    "timezone": "Europe/Moscow",
    "modification date": "2011-07-09"
  },
  {
    "id": "451749",
    "name": "Zhukovo",
    "acsiiname": "Zhukovo",
    "alternatenames": [
      ""
    ],
    "latitude": "57.26429",
    "longitude": "34.20956",
    "feature class": "P",
    "feature code": "PPL",
    "country code": "RU",
    "cc2": "",
    "admin1 code": "77",
    "admin2 code": "",
    "admin3 code": "",
    "admin4 code": "",
    "population": "0",
    "elevation": "",
    "dem": "237",
    "timezone": "Europe/Moscow",
    "modification date": "2011-07-09"
  },
  {
    "id": "451750",
    "name": "Zhitovo",
    "acsiiname": "Zhitovo",
    "alternatenames": [
      ""
    ],
    "latitude": "57.29693",
    "longitude": "34.41848",
    "feature class": "P",
    "feature code": "PPL",
    "country code": "RU",
    "cc2": "",
    "admin1 code": "77",
    "admin2 code": "",
    "admin3 code": "",
    "admin4 code": "",
    "population": "0",
    "elevation": "",
    "dem": "247",
    "timezone": "Europe/Moscow",
    "modification date": "2011-07-09"
  },
  {
    "id": "451751",
    "name": "Zhitnikovo",
    "acsiiname": "Zhitnikovo",
    "alternatenames": [
      ""
    ],
    "latitude": "57.20064",
    "longitude": "34.57831",
    "feature class": "P",
    "feature code": "PPL",
    "country code": "RU",
    "cc2": "",
    "admin1 code": "77",
    "admin2 code": "",
    "admin3 code": "",
    "admin4 code": "",
    "population": "0",
    "elevation": "",
    "dem": "198",
    "timezone": "Europe/Moscow",
    "modification date": "2011-07-09"
  }
]
```
## two_cities_name_info
Метод принимает названия двух городов (на русском языке) и получает информацию о найденных городах, а также дополнительно: какой из них расположен севернее и одинаковая ли у них временная зона и разница во времени
http://localhost:8080/hello.php/api/two_cities_name_info?city1={название города 1}&city2={название города 2}
http://localhost:8080/hello.php/api/two_cities_name_info?city1=Калининград&city2=Владивосток
```
{
  "city1_id": "554234",
  "city1_name": "Kaliningrad",
  "city1_acsiiname": "Kaliningrad",
  "city1_alternatenames": [
    "Caliningrado",
    "Calininopolis",
    "KGD",
    "Kalinin'nkrant",
    "Kaliningrad",
    "Kaliningrada",
    "Kaliningradas",
    "Kaliningrado",
    "Kaliningradum",
    "Kaliningrau",
    "Kaliningráu",
    "Kalininqrad",
    "Kalinjingrad",
    "Kalinyingrad",
    "Kalinyingrád",
    "Kalińingrad",
    "Kalíníngrad",
    "Karaliaucios",
    "Karaliaucius",
    "Karaliaučios",
    "Karaliaučius",
    "Kaļiņingrada",
    "Kenisberg",
    "Koenigsbarg",
    "Koenigsberg",
    "Koenigsberg in Preussen",
    "Korigsberg",
    "Krolewiec",
    "Królewiec",
    "Kënisberg",
    "Königsbarg",
    "Königsberg",
    "Königsberg in Preußen",
    "Körigsberg",
    "jia li ning ge lei",
    "kalininagrada",
    "kalliningeuladeu",
    "kalynynghrad",
    "kalynyngrad",
    "kariningurado",
    "qlynyngrd",
    "Καλίνινγκραντ",
    "Калининград",
    "Калињинград",
    "Калінінград",
    "Կալինինգրադ",
    "קלינינגרד",
    "كالينينغراد",
    "کالیننگراڈ",
    "کالینینگراد",
    "کیلننگراڈ",
    "कालिनिनग्राद",
    "ಕಲಿನಿನ್‍ಗ್ರಾಡ್",
    "კალინინგრადი",
    "カリーニングラード",
    "加里寧格勒",
    "칼리닌그라드"
  ],
  "city1_latitude": "54.70649",
  "city1_longitude": "20.51095",
  "city1_feature class": "P",
  "city1_feature code": "PPLA",
  "city1_country code": "RU",
  "city1_cc2": "",
  "city1_admin1 code": "23",
  "city1_admin2 code": "825118",
  "city1_admin3 code": "",
  "city1_admin4 code": "",
  "city1_population": "475056",
  "city1_elevation": "",
  "city1_dem": "2",
  "city1_timezone": "Europe/Kaliningrad",
  "city1_modification date": "2023-10-20",
  "city2_id": "2013348",
  "city2_name": "Vladivostok",
  "city2_acsiiname": "Vladivostok",
  "city2_alternatenames": [
    "Bladibostok",
    "Uladzivastok",
    "VVO",
    "Vladivostok",
    "Vladivostoka",
    "Vladivostokas",
    "Vladivostokium",
    "Vlagyivosztok",
    "Wladiwostok",
    "Wladywostok",
    "Władywostok",
    "beulladiboseutokeu",
    "fladyfwstwk",
    "hai can wai",
    "hai can wei",
    "urajiosutoku",
    "vilativostok",
    "vladivastak",
    "vladivostoka",
    "w la di wx s txkh",
    "wladywstwk",
    "wldywwstwq",
    "Βλαδιβοστόκ",
    "Владивосток",
    "Уладзівасток",
    "Վլադիվոստոկ",
    "וולאדיוואסטאק",
    "ולדיווסטוק",
    "فلاديفوستوك",
    "ولادیوستوک",
    "ولادی‌وؤستؤک",
    "ولادی‌وستوک",
    "ولاڈیووسٹوک",
    "व्लादिवोस्तॉक",
    "व्लादिवोस्तोक",
    "விலாடிவொஸ்டொக்",
    "ವ್ಲಾಡಿವಾಸ್ಟಾಕ್",
    "วลาดีวอสตอค",
    "ვლადივოსტოკი",
    "ウラジオストク",
    "海参崴",
    "海參崴",
    "블라디보스토크"
  ],
  "city2_latitude": "43.10562",
  "city2_longitude": "131.87353",
  "city2_feature class": "P",
  "city2_feature code": "PPLA",
  "city2_country code": "RU",
  "city2_cc2": "",
  "city2_admin1 code": "59",
  "city2_admin2 code": "",
  "city2_admin3 code": "",
  "city2_admin4 code": "",
  "city2_population": "604901",
  "city2_elevation": "",
  "city2_dem": "40",
  "city2_timezone": "Asia/Vladivostok",
  "city2_modification date": "2024-11-09",
  "is_same_timezone": false,
  "hours_offset": 8,
  "more_northly": "Kaliningrad"
}
```
## cities_by_part_name
Метод, в котором пользователь передаёт часть названия города, а сервер в ответ возвращает пользователю список возможных вариантов продолжений
http://localhost:8080/hello.php/api/cities_by_part_name?part_name={название города}
http://localhost:8080/hello.php/api/cities_by_part_name?part_name=Калининград
```
{
  "554230": [
    "Калининград вел",
    "Калининград муж",
    "Калининград облаçĕ",
    "Калининград област",
    "Калининград обласьт",
    "Калининград улос",
    "Калининград уобалаhа",
    "Калининград өлкәсе",
    "Калининград өлкәһе",
    "Калининградан область",
    "Калининградонь ёнкс",
    "Калининградска област",
    "Калининградская Область",
    "Калининграды облæст"
  ],
  "554231": [
    "Калининград-Северный",
    "Станция Калининград-Северный"
  ],
  "554233": [
    "Калининград"
  ],
  "554234": [
    "Калининград"
  ],
  "825118": [
    "Город Калининград",
    "Калининградский Городской Округ"
  ],
  "825257": [
    "Калининградский Отводной Канал"
  ],
  "2609902": [
    "Калининградский Залив"
  ],
  "3233365": [
    "Калининградский Морской Канал"
  ],
  "8521441": [
    "Калининград"
  ],
  "11821427": [
    "Калининградская атомная электростанция; Калининградская АЭС"
  ]
}
```
