# Тестовое задание справочник автомобилей. 

Необходимо реализовать сервис справочника автомобилей с хранением
данных в базе или файле.

Минимальная информация по объекту:
- Номер (регистрационный знак, например АА999А96);
- Марка;
- Цвет;
- Год выпуска.

## Описание архитектуры:

REST-API архитектура

## Стэк технологий:
Frontend: 
- Angular
- Angular Material
- RxJs

Backend: 
- ASP.NET Core (version 6)

DataBase:
- MongoDB

## Описание API:

1. Список всех возвращаемых объектов:
```sh
[GET] localhost:44406/caritems
```

2. Добавление автомобиля в список:
```sh
[POST] localhost:44406/caritems
```

3. Удаление автомобиля из списка: 
```sh
[DELETE] localhost:44406/caritems/{id}
```

4. Количество записей в базе данных:
```sh
[GET] localhost:44406/caritems
```

5. Фильтрация списка по марке автомобиля:
```sh
[GET] localhost:44406/caritems/{brand}
```
