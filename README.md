# Справочник выпускников и тем дипломных работ студентов

![WPF](https://img.shields.io/badge/Technology-WPF-brightgreen) ![C#](https://img.shields.io/badge/Language-C%23-blue) ![SQL Server](https://img.shields.io/badge/Database–SQL_Server-red)

## Описание

Небольшое WPF-приложение для автоматизации учёта и анализа информации о выпускниках образовательного учреждения и их дипломных работах.  

Позволяет:
- Хранить и редактировать данные о **пользователях** (администраторы, студенты, научные руководители)
- Управлять справочниками **ролей**, **кафедр**, **научных руководителей**
- Вводить и изменять сведения о **выпускниках**, их **дипломных работах** и **наградах**
- Назначать выпускникам **навыки**
- Импортировать и экспортировать данные в базу данных

Приложение использует Entity Framework 6 (Database-First) поверх Microsoft SQL Server и имеет продуманную модель целостности данных.

---

## Функциональные возможности

- **CRUD** (Create, Read, Update, Delete) для всех сущностей:
  - Users (Пользователи)
  - Roles (Роли)
  - Departments (Кафедры)
  - ScientificAdvisors (Научные руководители)
  - Graduates (Выпускники)
  - DiplomaWorks (Дипломные работы)
  - Awards (Награды)
  - Skills (Навыки)
- **Обновление данных** нажатием кнопки Refresh
- **Поиск и сортировка** в DataGrid по ключевым полям
- **Обработка ошибок** и валидация ввода на уровне UI и модели

---

## Структура проекта

```text
UniversityManager/
├── App.xaml
├── MainWindow\.xaml
├── MainWindow\.xaml.cs
├── UniversityDB.edmx
├── UniversityDB.Context.cs
├── Views/
│   ├ Users/
│   │   ├ AddUserWindow\.xaml(.cs)
│   │   └ EditUserWindow\.xaml(.cs)
│   ├ Roles/
│   │   ├ AddRoleWindow\.xaml(.cs)
│   │   └ EditRoleWindow\.xaml(.cs)
│   ├ Departments/…
│   ├ ScientificAdvisors/…
│   ├ Graduates/…
│   ├ DiplomaWorks/…
│   ├ Awards/…
│   ├ Skills/…
│   └ GraduateSkills/…
└── README.md
```

---

## Используемые технологии

- **.NET Framework 4.7.2**  
- **WPF** (Windows Presentation Foundation)  
- **C#**  
- **Entity Framework 6** (Database-First)  
- **Microsoft SQL Server**  
- **Visual Studio 2022**

---

## Установка и запуск

1. **Клонировать репозиторий**  
   ```sh
   git clone https://github.com/Cyber-Drag0n/Kursovaya_WPF.git
   cd Kursovaya_WPF
   ```

2. **Открыть решение** в Visual Studio.
3. **Настроить строку подключения** в `App.config` или непосредственно в EDMX:

   ```xml
   <connectionStrings>
     <add name="UniversityDBEntities"
          connectionString="metadata=res://*/UniversityDB.csdl|res://*/UniversityDB.ssdl|res://*/UniversityDB.msl;provider=System.Data.SqlClient;provider connection string=&quot;Data Source=YOUR_SERVER;Initial Catalog=UniversityDB;Integrated Security=True;MultipleActiveResultSets=True;&quot;"
          providerName="System.Data.EntityClient" />
   </connectionStrings>
   ```
4. **Восстановить пакеты NuGet** (EntityFramework).
5. **Собрать** и **запустить** проект (F5).

---

## Модель данных

![ER-диаграмма](https://github.com/user-attachments/assets/b105bc51-1efd-478f-866e-392a5d5e9904)

Основные сущности и связи:

* **Users** — хранит учётные записи пользователей
* **Roles** — роли (Администратор, Студент, Руководитель)
* **Departments** — кафедры
* **ScientificAdvisors** — привязка пользователей-руководителей к кафедрам
* **Graduates** — выпускники и их кафедра
* **DiplomaWorks** — темы дипломных работ и привязка к руководителю
* **Awards** — награды выпускников
* **Skills** — справочник навыков

---

## Лицензия

Этот проект распространяется под лицензией MIT. Подробности см. [LICENSE](LICENSE).

---

## Автор

**Нуруллин А.М.**
Казанский национальный исследовательский технический университет — КАИ
Группа 4235, колледж «КИТ»
