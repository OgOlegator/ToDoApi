# ToDoApi

Приложение реализовано в формате Minimal Api

Api поддерживает вызов по 5 маршрутам (endpoint):
- GET api/todo - get all;
- GET api/todo/{id} - get todo by id;
- POST api/todo - create todo, на вход нужно отправить JSON с полями модели ToDo (Id, Name);
- PUT api/todo - edit todo,, на вход нужно отправить JSON с полями модели ToDo;
- DELETE api/todo/{id} - delete todo; 

В данном проекте реализованы различные архитектурные эксперименты:

 # ToDoApi 
 Максимально упрощенная реализация Minimal Api где все endpoint хранятся в классе Program.cs

# ToDoApiV2
Содержит более подробную структуру. 

В папке Data реализованы классы для конекта с БД.

Работа с endpoint каждого типа (в данном проекте 1 тип - ToDo) содержится в папке Modules.

Класс Modules/ModuleExtensions.cs выполняет регистрацию в приложении enpoints и Services всех типов.

Папка Modules/ToDos содержит:
- Репозиторий для работы с данными ToDo
- Модель ToDo
- Классы реализующие логику работы endpoints 

Реализация проекта подобной структуры была вдохновлена статьей: https://habr.com/ru/companies/skbkontur/articles/723840/

# ToDoApiV3
В данной реализации для работы с БД используется паттерн обобщенный репозиторий (generic repository).

В качестве Unit of work используется DbContext.
