# digi-tech-test-project

## Запуск и точка входа
Откройте директорию с проектом в Unity версии `2022.1.23f1` или выше, перейдите в сцену `Assets/Game/Scenes/Main.unity`, запустите режим игры.

## Инфраструктура
- Движок: Unity `2022.1.23f1`.
- Рендер: URP (`com.unity.render-pipelines.universal`).
- Ввод: New Input System (`com.unity.inputsystem`).
- UI: TextMeshPro + UGUI.

## Архитектура
- `Entrypoint` является точкой входа, создаёт `MultimeterModel` и эмитирует DI.
- `MultimeterBinder` связывает `Controller` и `View` с общей моделью.
- `ScrollMultimeterController` обрабатывает скролл и переключает режимы в модели.
- `MultimeterModel` реализует логику работы мультиметра.
- `MultimeterController` используется для связывания модели с `MultimeterView`/`HudMultimeterView`.
- `Hoverable` и `Highlighter` отвечают за активацию и подсветку мультиметра соответственно.

## Структура проекта
```text
Game/
  Configs/               # ScriptableObject-конфиги
  Prefabs/               # Префабы проекта
  Scenes/                # Сцены проекта
  Scripts/
    Controllers/         # Контроллеры по MVC
    Models/              # Модели по MVC
    Systems/
      Infrastructure/    # Инфраструктурная логика, точка входа и биндинг
      Interaction/       # Взаимодействие с объектами, наведение и подсветка
    Views/               # Представления по MVC
  Visuals/
    Fonts/
    Materials/
    Models/
    Shaders/
    Textures/
```
