**Шаблонное .NET 5 приложение** - пример реализации проекта используя ядро


Директория Core - непосредтвенно ядро. [Основной репозиторий](https://github.com/MoHcTpUk/Core) 

- **ExsampleProject.DAL** - Data Access Layer, содержит репозитории, миграции и контекст

- **ExsampleProject.BLL** - Business Logic Layer, содержит сервисы (работа с репозиториями, преобразование доменной модели в DTO)

- **ExsampleProject.App** - содержит команды медиатора (самая высокоуровневая часть, реализует логику приложения)

- **ExsampleProject.ConsoleApp** - Пример консольного приложения

- **ExsampleProject.WebAPI** - Пример WebAPI
