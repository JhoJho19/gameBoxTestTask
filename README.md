# gameBoxTestTask


I. Экран главного меню.
Тут все просто. Логотип Image и одна кнопка. По нажатию кнопки запускается скрипт SceneSwitcher, который переносит нас на сцену Meta. Скрипт работает по индексу сцены, что сделано для предотвращения нарушения работы скрипта при изменении наименования сцены.

Индексы:
0. StartScreen.
1. Meta.
2. GameScene.

II. Экран Meta.
Здесь изображена карта мира. Для глубины использована камера с перспективой. Кнопки выбора уровня обозначены кристаллами. У активного уровня кристалл двигается и подсвечивается. Движение осуществляется по скрипту UpAndDown, который плавно изменяет Transform объекта. Скорость и амплитуда движения настраиваются из редактора.

III. Игровой экран.
Движение персонажа осуществляется через скрипт CharacterMover. В редакторе можно настроить скорость и силу прыжка, а так же радиус, в котором определяется земля для персонажа. В поле Ground Check можно присвоить самого персонажа или пустой объект, который должен быть дочерним по отношению к персонажу или иметь с ним одного родителя . Скрипт привязан к объекту Mage, который является дочерним пустому объекту Character.
Кристаллы на поле генерируются кнопкой Button Crystal Bag. На кнопке скрипт ItemLoader, который генерирует на каждом из Field Parent случайный объект из Game Objects. В настоящий момент скрипт устанавливает случайный объект только из первых четырех элементов массива, чтобы генерировались только мини кристаллы .
Каждому из кристаллов скрипт EnumItems устанавливает тип, который в дальнейшем используется в скрипте MergeSystem.
Скрипт MergeSystem управляет логикой перетаскивания и слияния предметов. Перетаскивание осуществляется через интерфейсы семейства IPointerHandler. Слияние происходит в конце перетаскивания по результатам сравнения enum типов предметов во время коллизии.
При совпадении кристаллов оба уничтожаются и создается новый объект.
Данный скрипт располагается на всех предметах предназначенных для слияния. Скрипт так же через редактор принимает предметы, которые будут созданы в результате слияния .
Преимуществом использования скриптов  MergeSystem и ItemLoader на мой взгляд является возможность произвольно расширять игровое поле. Оно не привязано к сетке. Любую часть поля можно в любой момент добавить или перенести любое место на игровом экране.
