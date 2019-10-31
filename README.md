# MMCS_332
## Lab1: Работа в графическом режиме
### Task1: Построение графика функции.
Задаются: диапазон значений, функция, необходимо построить график с возможностью масштабирования – в максимальных и минимальных точках график касается верхних и нижних границ графического окна. Обязательный тест – sin(x) и x^2.
Необходимо предусмотреть выбор функций из некоторого списка. В функцию построения графика функцию передавать как параметр.
Не использовать стандартные функции построения графиков.
## Lab2: Цветовые пространства. Преобразование цветовых пространств.
### Task1: 
Преобразовать изображение из RGB в оттенки серого. Реализовать два варианта формулы с учетом разных вкладов R, G и B в интенсивность (см презентацию). Затем найти разность полученных полутоновых изображений. Построить гистограммы интенсивности после одного и второго преобразования.
### Task2:
Выделить из полноцветного изображения один из каналов R, G, B  и вывести результат. Построить гистограмму по цветам.
### Task3:
Преобразовать изображение из RGB в HSV. Добавить возможность изменять значения оттенка, насыщенности и яркости. Результат сохранять в файл, предварительно преобразовав обратно.
## Lab3: Растровые алгоритмы.
### Task1: Рекурсивный алгоритм заливки на основе серий пикселов (линий).
1a) Заливка заданным цветом.

1b) Заливка рисунком из графического файла. Файл можно загрузить встроенными средствами и затем считывать точки изображения для использования в заливке.
### Task2: Выделение границы связной области.
На вход подается изображение. Граница связной области задается одним цветом. Имея начальную точку границы организовать ее обход, занося точки в список в порядке обхода.
Начальную точку границы можно получать любым способом. Для контроля полученную границу прорисовать поверх исходного изображения.
## Lab4: Аффинные преобразования на плоскости и вспомогательные алгоритмы.
В программе должны присутствовать следующие примитивы: точка, ребро (отрезок), полигон (мин требование - квадрат). Они рисуются мышкой.

Программа должна содержать следующие возможности:
* Задать текущий примитив.
* Очистить сцену.
* Применение аффинных преобразований к полигону: смещение, поворот вокруг произвольной точки (задается пользователем мышкой) и вокруг своего центра, масштабирование относительно произвольной точки (задается пользователем мышкой) и относительно своего центра. Все преобразования должны быть реализованы матрицами!
* Поворот ребра на 90 градусов вокруг своего центра.
* Поиск точки пересечения двух ребер (добавление второго ребра мышкой, динамически).

Программа должна позволять выполнить следующие проверки:
* Принадлежит ли точка выпуклому многоугольнику (задание точки мышкой).
* Принадлежит ли точка невыпуклому многоугольнику (задание точки мышкой).
* Классифицировать положение точки относительно ребра (задание точки мышкой).
## Individual1: Пересечение выпуклых полигонов.
## Lab5: L-системы. Diamond-square. Cплайны.
### Task1: L-системы.
Реализовать программу для построения фрактальных узоров посредством L-систем.
Описание L-систем задается в текстовом файле вида:
```
<атомарный символ> <угол поворота> <начальное направление> 
<правило №1>
<правило №2>
...
```
Реализовать возможность разветвления в системе (скобки).
Предусмотреть масштабирование получаемого набора точек (должен помещаться в окне).
### Task2: Diamond-square.
Реализовать алгоритм [midpoint displacement](https://habr.com/ru/post/111538/) для визуализации горного массива.
Необходимо отображать результаты последовательных шагов алгоритма. Программа должна позволять изменять параметры построения ломаной.
### Task3: Кубические сплайны Безье.
Реализовать программу для визуализации составной кубической кривой Безье. 
Программа должна позволять добавлять, удалять  и перемещать опорные точки. 
## Lab6: Аффинные преобразования в пространстве. Проецирование.
В программе должны присутствовать следующие классы: точка, прямая (ребро), многоугольник (грань), многогранник.
Программа должна содержать следующие возможности:
* Отображение одного из правильных многогранников: тетраэдр, гексаэдр, октаэдр, икосаэдр*, додекаэдр*.
* Применение аффинных преобразований: смещение, поворот, масштаб, с указанием параметров преобразования. Преобразования должны быть реализованы матрицами!
* Отражение относительно выбранной координатной плоскости.
* Масштабирование многогранника относительно своего центра.
* Вращение многогранника вокруг прямой проходящей через центр многогранника, параллельно выбранной координатной оси.
* Поворот вокруг произвольной (заданной координатами двух точек) прямой на заданный угол.

Программа должна позволять отобразить сцену в одной из заданных проекций (преобразования должны быть реализованы матрицами):
* перспективной;
* изометрической;
* ортографической (на выбранную координатную плоскость).

## Lab7: Построение трёхмерных моделей.
### Task1: Загрузка и сохранение модели многогранника из файла.
Формат модели должен содержать данные о гранях. Формат файла выбирается программистом.
Необходимо отобразить загруженную модель, позволить применять к ней аффинные преобразования. 
Для тестов можно использовать модели многогранников из Лаб. №6.
### Task2: Построение фигуры вращения.
Фигура вращения задаётся тремя параметрами: образующей (набор точек), осью вращения и количеством разбиений. Угол вращений можно вычислить, поделив 360° на количество разбиений.
Программа должна давать возможность задать образующую и построить фигуру вращения относительно выбранной координатной оси с заданным количеством разбиений. Формат модели должен содержать данные о гранях.
Сохранить полученную модель в файл.
Необходимо загрузить и отобразить полученную модель, применить к ней аффинные преобразования.
### Task3: Построение графика двух переменных.
Сегмент поверхности задаётся функцией f(x, y) = z, диапазонами отсечения [x0, x1], [y0, y1] и количеством разбиений по осям (шагом).
Программа должна позволять строить сегмент поверхности, заданный выбранной функцией на заданном диапазоне с заданным количеством разбиений. Формат модели должен содержать данные о гранях. Диапазоны и разбиения можно задавать идентичными для X и Y.
Необходимо отобразить полученную модель, позволить применять к ней аффинные преобразования.
Загрузить и Сохранить полученную модель в файл.
