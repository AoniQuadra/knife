using Core;

namespace KompasWrapper
{
    /// <summary>
    /// Класс осуществляющий построение детали
    /// </summary>
    public class SwordBuilder
    {
        /// <summary>
        /// Объект класса коннектора для связи с КОМПАС-3D
        /// </summary>
        private readonly KompasConnector _connector = new();

        /// <summary>
        /// Построение детали по заданным параметрам.
        /// </summary>
        /// <param name="parameters">Объект заданных параметров меча.</param>
        public void BuildSword(SwordParameters parameters)
        {
            _connector.StartKompas();
            _connector.CreateDocument();
            _connector.SetDetailProperties();
            double swordLength = parameters.SwordLength;
            double bladeLength = parameters.BladeLength;
            double bladeThickness = parameters.BladeThikless;
            double guardWidth = parameters.GuardWidht;
            double handleDiameter = parameters.HandleDiameter;
            double handleLengthWithGuard = parameters.HandleLenghtWithGuard;
            BuildBlade(bladeLength, bladeThickness);
            BuildGuard(bladeLength, bladeThickness, guardWidth);
            BuildHandle(bladeLength, handleDiameter, handleLengthWithGuard);
        }

        /// <summary>
        /// Построение лезвия меча.
        /// </summary>
        /// <param name="bladeLength">Длина лезвия.</param>
        /// <param name="bladeThickness">Толщина лезвия.</param>
        private void BuildBlade(double bladeLength, double bladeThickness)
        {
            // Создание основы меча.

            // Координаты точек основания меча.
            // 0 элемент - координата по X;
            // 1 элемент - координата по Y;
            double[,] basePoints =
            {
                { -40, 0 },
                { 0, -bladeThickness/2 },
                { 40, 0 },
                { 0, bladeThickness/2 }
            };

            var entitySketch = _connector.CreatePolygonByDefaultPlane(basePoints);
            _connector.ExtrudeSketch(entitySketch, 
                bladeLength / 2 - 50, true);
            _connector.ExtrudeSketch(entitySketch, 
                bladeLength / 2 - 200, false);

            _connector.CreateOffsetPlane(bladeLength / 2 - 200, false);
            _connector.CreatePolygonByOffsetPlane(basePoints, 
                bladeLength / 2 - 200, true);

            // Создание вершины острия меча.

            // Координаты точек вершины меча.
            var edgePoints = ChangeScale(basePoints, 0.01, 0.01);

            _connector.CreateOffsetPlane(bladeLength / 2, false);
            _connector.CreatePolygonByOffsetPlane(edgePoints, 
                bladeLength / 2, true);

            // Создание острия меча.
            _connector.ExtrudeBySections();

            // Создание перехода к рукояти.

            _connector.CreateOffsetPlane(bladeLength / 2 - 50, true);
            _connector.CreatePolygonByOffsetPlane(basePoints, 
                -bladeLength / 2 + 50, true);

            // Координаты точек первого перехода меча.
            var transitionPoints = ChangeScale(basePoints, 1.05, 1);
            _connector.CreateOffsetPlane(bladeLength / 2 - 30, true);
            _connector.CreatePolygonByOffsetPlane(transitionPoints, 
                -bladeLength / 2 + 30, true);

            // Координаты точек второго перехода меча.
            transitionPoints = ChangeScale(basePoints, 1.375, 1);
            _connector.CreateOffsetPlane(bladeLength / 2 - 10, true);
            _connector.CreatePolygonByOffsetPlane(transitionPoints, 
                -bladeLength / 2 + 10, true);

            // Выдавливание перехода меча.
            _connector.ExtrudeBySections();

            // Создание выреза на мече.

            var circleCenter = new[]
            {
                0, bladeThickness/2 + 19
            };
            const double cutRadius = 21;
            var sketch = 
                _connector.CreateCircleByOffsetPlane(circleCenter, cutRadius, 
                    -bladeLength / 2 + 50, false);
            circleCenter = new[]
            {
                0, -bladeThickness/2 - 19
            };
            _connector.CutExtrusion(sketch, bladeLength / 2 + 170);
            sketch = 
                _connector.CreateCircleByOffsetPlane(circleCenter, cutRadius, 
                    -bladeLength / 2 + 50, false);
            _connector.CutExtrusion(sketch, bladeLength / 2 + 170);
        }

        /// <summary>
        /// Построение гарды меча.
        /// </summary>
        /// <param name="bladeLength">Длина лезвия.</param>
        /// <param name="bladeThickness">Толщина лезвия.</param>
        /// <param name="guardWidth">Ширина гарды.</param>
        private void BuildGuard(double bladeLength, 
            double bladeThickness, double guardWidth)
        {
            // Построение основания гарды меча.

            // Координаты точек основания гарды.
            // 0 элемент - координата по X;
            // 1 элемент - координата по Y.
            double[,] guardPoints =
            {
                { guardWidth/2, -bladeThickness/2 - 2 },
                { -guardWidth/2, -bladeThickness/2 - 2 },
                { -guardWidth/2, bladeThickness/2 + 2  },
                { guardWidth/2, bladeThickness/2 + 2 }
            };
            var sketch = _connector.CreatePolygonByOffsetPlane(guardPoints, 
                -bladeLength / 2 + 10, false);
            _connector.ExtrudeSketch(sketch, 20, true);

            // Построение эфесов.

            // Координаты точек левого эфеса.
            // 0 элемент - координата по X;
            // 1 элемент - координата по Y.
            double[,] leftHiltPoints =
            {
                { guardWidth/2, -bladeThickness/2 - 9 },
                { guardWidth/2 - 20, -bladeThickness/2 - 9 },
                { guardWidth/2 - 20, bladeThickness/2 + 9  },
                { guardWidth/2, bladeThickness/2 + 9 }
            };
            sketch = _connector.CreatePolygonByOffsetPlane(leftHiltPoints,
                -bladeLength / 2 + 10, false);
            _connector.ExtrudeSketch(sketch, 30, true);
            _connector.ExtrudeSketch(sketch, 10, false);

            // Координаты точек правого эфеса.
            // 0 элемент - координата по X;
            // 1 элемент - координата по Y.
            double[,] rightHiltPoints =
            {
                { -guardWidth/2, -bladeThickness/2 - 9 },
                { -guardWidth/2 + 20, -bladeThickness/2 - 9 },
                { -guardWidth/2 + 20, bladeThickness/2 + 9  },
                { -guardWidth/2, bladeThickness/2 + 9 }
            };
            sketch = _connector.CreatePolygonByOffsetPlane(rightHiltPoints, 
                -bladeLength / 2 + 10, false);
            _connector.ExtrudeSketch(sketch, 30, true);
            _connector.ExtrudeSketch(sketch, 10, false);
        }

        /// <summary>
        /// Создание рукоятки меча.
        /// </summary>
        /// <param name="bladeLength">Длина лезвия.</param>
        /// <param name="handleDiameter">Диаметр рукоятки.</param>
        /// <param name="handleLengthWithGuard">Длинна рукоятки вместе с гардой.</param>
        private void BuildHandle(double bladeLength,
            double handleDiameter, double handleLengthWithGuard)
        {
            // Создание ручки.

            var radius = handleDiameter / 2;
            var circleCenter = new double[]
            {
                0, 0
            };
            var sketch = 
                _connector.CreateCircleByOffsetPlane(circleCenter, radius,
                    -bladeLength / 2 + 10, false);
            _connector.ExtrudeSketch(sketch, handleLengthWithGuard - 30, true);

            // Построение навершия.

            // Начальный круг навершия.

            radius = handleDiameter / 2;
            circleCenter = new double[]
            {
                0, 0
            };
            _connector.CreateOffsetPlane(bladeLength / 2 - 40 + handleLengthWithGuard,
                true);
            _connector.CreateCircleByOffsetPlane(circleCenter, radius, 
                -bladeLength / 2 - handleLengthWithGuard + 40, true);

            // Центральный круг навершия.

            radius = handleDiameter / 2 + 8;
            _connector.CreateOffsetPlane(bladeLength / 2 + handleLengthWithGuard - 25, 
                true);
            _connector.CreateCircleByOffsetPlane(circleCenter, radius, 
                -bladeLength / 2 - handleLengthWithGuard + 25, 
                true);

            // Конечный круг навершия.

            radius = handleDiameter / 2;
            _connector.CreateOffsetPlane(bladeLength / 2 + handleLengthWithGuard - 10, 
                true);
            _connector.CreateCircleByOffsetPlane(circleCenter, radius, 
                -bladeLength / 2 + 10 - handleLengthWithGuard, 
                true);

            // Выдавливание навершия.
            _connector.ExtrudeBySections();
        }

        /// <summary>
        /// Изменить масштаб координат матрицы.
        /// </summary>
        /// <param name="points">Матрица координат.</param>
        /// <param name="scaleX">Масштаб по X.</param>
        /// <param name="scaleY">Масштаб по Y.</param>
        /// <returns>Матрицу с измененным масштабом.</returns>
        private static double[,] ChangeScale(double[,] points, 
            double scaleX, double scaleY)
        {
            double[,] scaleMatrix =
            {
                { scaleX, 0 },
                { 0, scaleY }
            };
            var resultMatrix =
                new double[points.GetLength(0), scaleMatrix.GetLength(1)];

            // Умножение матриц.
            for (var i = 0; i < points.GetLength(0); i++)
            {
                for (var j = 0; j < scaleMatrix.GetLength(1); j++)
                {
                    resultMatrix[i, j] = 0;
                    for (var k = 0; k < points.GetLength(1); k++)
                    {
                        resultMatrix[i, j] += points[i, k] * scaleMatrix[k, j];
                    }
                }
            }

            return resultMatrix;
        }
    }
}