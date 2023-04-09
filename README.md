# ToDoApi

Приложение реализовано в формате Minimal Api

Api поддерживает вызов по 5 маршрутам (endpoint):
- GET api/todo - get all;
- GET api/todo/{id} - get todo by id;
- POST api/todo - create todo, на вход нужно отправить JSON с полями модели ToDo (Id, Name);
- PUT api/todo - edit todo,, на вход нужно отправить JSON с полями модели ToDo;
- DELETE api/todo/{id} - delete todo; 

В проекте реализовано ToDo Api в двух архитектурных вариантах:

 # ToDoApi 
 Максимально упрощенная реализация где все endpoint хранятся в классе Program.cs

# ToDoApiV2
Содержит более подробную структуру. Работа с endpoint каждого типа (в данном проекте 1 тип - ToDo) содержится в папке Modules.

В папке Data реализованы классы для конекта с БД.

Класс ModuleExtensions выполняет регистрацию enpoint и Services всех типов.

Папка Modules/ToDos содержит:
- Репозиторий для работы с данными ToDo
- Модель ToDo
- Endpoints 
