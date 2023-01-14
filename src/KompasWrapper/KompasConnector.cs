using System;
using Kompas6API5;
using Kompas6Constants3D;
using System.Runtime.InteropServices;

namespace KompasWrapper
{
    /// <summary>
    /// Класс связи с КОМПАС-3D через API
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Объект Компас API.
        /// </summary>
        private KompasObject _kompas;

        /// <summary>
        /// Деталь.
        /// </summary>
        private ksPart _part;

        /// <summary>
        /// Документ-модель.
        /// </summary>
        private ksDocument3D _document;

        /// <summary>
        /// Коллекция эскизов на смещенных плоскостях.
        /// </summary>
        private ksEntityCollection _offsetSketchCollection;

        /// <summary>
        /// Запуск Компас-3D.
        /// </summary>
        public void StartKompas()
        {
            try
            {
                if (_kompas != null)
                {
                    _kompas.Visible = true;
                    _kompas.ActivateControllerAPI();
                }
                if (_kompas != null) return;
                var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompas = (KompasObject)Activator.CreateInstance(kompasType);
                StartKompas();
                if (_kompas == null)
                {
                    throw new Exception("Не удается открыть Компас-3D.");
                }
            }
            catch (COMException)
            {
                _kompas = null;
                StartKompas();
            }
        }

        /// <summary>
        /// Создание документа в Компас-3D.
        /// </summary>
        public void CreateDocument()
        {
            try
            {
                _document = (ksDocument3D)_kompas.Document3D();
                _document.Create();
                _document = (ksDocument3D)_kompas.ActiveDocument3D();
            }
            catch
            {
                throw new ArgumentException("Не удается построить деталь");
            }
        }

        /// <summary>
        /// Установка свойств детали.
        /// </summary>
        public void SetDetailProperties()
        {
            _part = (ksPart)_document.GetPart((short)Part_Type.pTop_Part);
            _part.name = "Sword";
            _part.Update();
            _offsetSketchCollection = 
                (ksEntityCollection)_part.EntityCollection((short)Obj3dType.o3d_sketch);
        }

        /// <summary>
        /// Создание круга на смещенной плоскости.
        /// </summary>
        /// <param name="center">Координаты центра круга.</param>
        /// <param name="radius">Радиус круга.</param>
        /// <param name="offset">Смещение плоскости.</param>
        /// <param name="isSketchCollection">Проверка, нужно ли добавлять
        /// элемент в коллекцию.</param>
        /// <returns>Сформированный эскиз.</returns>
        public ksEntity CreateCircleByOffsetPlane(double[] center, double radius, 
            double offset, bool isSketchCollection)
        {
            // TODO: Дубль
            ksEntity sketch =
                (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition definition =
                (ksSketchDefinition)sketch.GetDefinition();
            ksEntityCollection collection =
                (ksEntityCollection)_part.EntityCollection((short)Obj3dType.o3d_planeOffset);
            collection.SelectByPoint(offset, 0, 0);
            ksEntity plane = (ksEntity)collection.First();
            definition.SetPlane(plane);
            sketch.Create();
            ksDocument2D sketchEdit = (ksDocument2D)definition.BeginEdit();
            sketchEdit.ksCircle(center[0], center[1], radius, 1);
            definition.EndEdit();
            if (isSketchCollection)
            {
                _offsetSketchCollection.Add(sketch);
            }
            return sketch;
        }

        /// <summary>
        /// Выдавливание по сечениям смещенных эскизов.
        /// </summary>
        public void ExtrudeBySections()
        {
            ksEntity entity = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossLoft);
            ksBossLoftDefinition definition = (ksBossLoftDefinition)entity.GetDefinition();
            ksEntityCollection collection = (ksEntityCollection)definition.Sketchs();
            for (var i = 0; i < _offsetSketchCollection.GetCount(); i++)
            {

                collection.Add(_offsetSketchCollection.GetByIndex(i));
            }

            entity.Create();
            _offsetSketchCollection.Clear();
        }

        /// <summary>
        /// Создание многоугольника по смещенной плоскости.
        /// </summary>
        /// <param name="points">Координаты многоугольника.</param>
        /// <param name="offset">Смещение плоскости, где находится эскиз.</param>
        /// <param name="isSketchCollection">Проверка, нужно ли добавлять
        /// элемент в коллекцию.</param>
        /// <returns>Сформированный эскиз.</returns>
        public ksEntity CreatePolygonByOffsetPlane(double[,] points,
            double offset, bool isSketchCollection)
        {
            // TODO: Дубль
            ksEntity sketch = 
                (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition definition = 
                (ksSketchDefinition)sketch.GetDefinition();
            ksEntityCollection collection =
                (ksEntityCollection)_part.EntityCollection((short)Obj3dType.o3d_planeOffset);
            collection.SelectByPoint(offset, 0, 0);
            ksEntity plane = (ksEntity)collection.First();
            definition.SetPlane(plane);
            sketch.Create();
            ksDocument2D sketchEdit = (ksDocument2D)definition.BeginEdit();
            for (var i = 0; i < points.GetLength(0) - 1; i++)
            {
                sketchEdit.ksLineSeg(points[i, 0], points[i, 1],
                    points[i + 1, 0], points[i + 1, 1], 1);
            }

            sketchEdit.ksLineSeg(points[0, 0], points[0, 1],
                points[points.GetLength(0) - 1, 0],
                points[points.GetLength(0) - 1, 1], 1);
            definition.EndEdit();

            if (isSketchCollection)
            {
                _offsetSketchCollection.Add(sketch);
            }
            return sketch;
        }

        /// <summary>
        /// Создание многоугольника по базовой плоскости YOZ.
        /// </summary>
        /// <param name="points">Координаты многоугольника.</param>
        /// <returns>Сформированный эскиз.</returns>
        public ksEntity CreatePolygonByDefaultPlane(double[,] points)
        {
            // TODO: Дубль
            ksEntity entitySketch = 
                (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
            ksEntity basePlane = 
                (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);
            ksSketchDefinition sketchDefinition = 
                (ksSketchDefinition)entitySketch.GetDefinition();
            sketchDefinition.SetPlane(basePlane);
            entitySketch.Create();
            ksDocument2D sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit();
            for (var i = 0; i < points.GetLength(0) - 1; i++)
            {
                sketchEdit.ksLineSeg(points[i, 0], points[i, 1],
                    points[i + 1, 0], points[i + 1, 1], 1);
            }

            sketchEdit.ksLineSeg(points[0, 0], points[0, 1],
                points[points.GetLength(0) - 1, 0],
                points[points.GetLength(0) - 1, 1], 1);
            sketchDefinition.EndEdit();
            return entitySketch;
        }

        /// <summary>
        /// Создание смещенной плоскости.
        /// </summary>
        /// <param name="offset">Смещение плоскости относительно YOZ.</param>
        /// <param name="direction"></param>
        public void CreateOffsetPlane(double offset, bool direction)
        {
            ksEntity sketch = 
                (ksEntity)_part.NewEntity((short)Obj3dType.o3d_planeOffset);
            ksEntity basePlane = 
                (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);
            ksPlaneOffsetDefinition offsetDefinition = 
                (ksPlaneOffsetDefinition)sketch.GetDefinition();
            offsetDefinition.offset = offset;
            offsetDefinition.direction = direction;
            sketch.hidden = true;
            offsetDefinition.SetPlane(basePlane);
            sketch.Create();
        }

        /// <summary>
        /// Метод, выполняющий выдавливание по эскизу.
        /// </summary>
        /// <param name="sketch">Эскиз.</param>
        /// <param name="height">Высота выдавливания.</param>
        /// <param name="type">Направление выдавливания.</param>
        public void ExtrudeSketch(ksEntity sketch, double height, bool type)
        {
            ksEntity entityExtrusion = 
                (ksEntity)_part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
            ksBaseExtrusionDefinition extrusionDefinition = 
                (ksBaseExtrusionDefinition)entityExtrusion.GetDefinition();
            if (!type)
            {
                extrusionDefinition.directionType = (short)Direction_Type.dtReverse;
            }
            else
            {
                extrusionDefinition.directionType = (short)Direction_Type.dtNormal;
            }
            extrusionDefinition.SetSideParam(type, (short)End_Type.etBlind, height);
            extrusionDefinition.SetSketch(sketch);
            entityExtrusion.Create();
        }

        /// <summary>
        /// Метод, выполняющий вырезание выдавливанием по эскизу.
        /// </summary>
        /// <param name="sketch">Эскиз.</param>
        /// <param name="height">Высота вырезания.</param>
        public void CutExtrusion(ksEntity sketch, double height)
        {
            ksEntity entityCutExtrusion = (ksEntity)_part.NewEntity((short)
                Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition cutExtrusionDefinition = 
                (ksCutExtrusionDefinition)entityCutExtrusion.GetDefinition();
            cutExtrusionDefinition.directionType = (short)Direction_Type.
                dtNormal;
            cutExtrusionDefinition.SetSideParam(true, (short)End_Type.
                etBlind, height);
            cutExtrusionDefinition.SetSketch(sketch);
            entityCutExtrusion.Create();
        }
    }
}
