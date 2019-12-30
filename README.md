# Birds project

### How to run on ubuntu:

#### Backend

1) На порту 27017 должна висеть mongodb

2) Переименовываем папку src/api в srs/API

3) Заходим в папку с файлом Birds.sln

4) Собираем бэк

    > dotnet publish -c release -r ubuntu.18.04-x64

5) Заходим в папку с исполняемым файлом

    > cd srs/API/bin/Release/netcoreapp2.1/ubuntu.18.04-x64

6) Запуск

    > ./Birds.API
    
    Сервер будет доступен на localhost:5000

#### Frontend

1) Заходим в папку с фронтом

    > cd birds-frontend
    
2) Выкачиваем все зависимости и собираем проект

    > npm install
        
3) Запуск

    > npm start
    
    Development-сервер с фронтом будет доступен на localhost:3000