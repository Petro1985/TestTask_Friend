**Данный репозиторий представляетт собой решение тестового задания для платформы "Друг"**

Для решения задачи использовалась база данных postgresql верссии 14.4

SQL скрипт для создания БД и таблиц находится ./TestTask_Friend.DAL/DataBaseScripts/CreateUsersTable.sql

Приложение берет параметры подключения к базе данных из "ConnectionString". Значение это параметра задать следующими способами:
1. Через переменную среды ConnectionString
2. Файл appsettings.json
3. Используя утилиту dotnet user-secrets

Правила валидации вводимых данных:
1. Пароль должен содержать маленькие и большие буквы, спец символы и цифры и иметь длину не менее 8 символов.
2. Если значение Email отлично от NULL то он должен полностью соответствовать всем требованиям для адреса электронной почты.

# Варианты запуска
## 1. С использованием Docker (пердпочтительный)
- Из корневой папки выполнить следующую команду
```
docker compose up
```
или 
```
docker-compose up
```
После этого будет доступен web-server по адресу http://localhost:8080/swagger

## 2. Запуск вручную
- выполнить скрипт из файла TestTask_Friend.DAL/DataBaseScripts/CreateUsersTable.sql
- Запустить проект TestTask_Friend
```
dotnet run dotnet run --project .\TestTask_Friend
```
В случае если параметр ConnectionString не был указан заранее, для запуска проекта используйти команду:
```
dotnet run dotnet run --ConnectionString="<строка подключения>" --project .\TestTask_Friend
```
После этого будет доступен web-server по адресу http://localhost:5265/swagger

