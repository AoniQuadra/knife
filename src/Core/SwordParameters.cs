using System.Collections.Generic;

namespace Core
{
    // TODO: Грам ошибки проверить
    /// <summary>
    /// Класс хранящий параметры меча
    /// </summary>
    public class SwordParameters
    {
        /// <summary>
        /// Общая длина меча
        /// </summary>
        private static Parameter _swordLength =
            new(SwordParameterType.SwordLength,
                MAXSWORDLENGTH, MINSWORDLENGTH);

        /// <summary>
        /// Длина лезвия
        /// </summary>
        private static Parameter _bladeLength =
            new(SwordParameterType.BladeLength,
                MAXBLADELENGTH, MINBLADELENGTH);

        /// <summary>
        /// Толщина лезвия
        /// </summary>
        private static Parameter _bladeThickness =
            new(SwordParameterType.BladeThickness,
                MAXBLADETHIKLESS, MINBLADETHIKLESS);

        /// <summary>
        /// Ширина гарды
        /// </summary>
        private static Parameter _guardWidth =
            new(SwordParameterType.GuardWidth,
                MAXGUARDWIGHT, MINGUARDWIGHT);

        /// <summary>
        /// Диаметр рукоятки
        /// </summary>
        private static Parameter _handleDiameter =
            new(SwordParameterType.HandleDiameter,
                MAXHANDLEDIAMETER, MINHANDLEDIAMETER);

        /// <summary>
        /// Длина рукоятки вместе с гардой
        /// </summary>
        // Грам ошибка
        private static Parameter _handleLengthWithGuard =
            new(SwordParameterType.HandleLengthWithGuard,
                MAXHANDLELENGHTWITHGUARD, MINHANDLELENGHTWITHGUARD);

        /// <summary>
        /// Возврщает и задаёт тип лезвия
        /// </summary>
        public BladeType BladeType { get; set; }

        /// <summary>
        /// Словарь содержащий пары (Имя параметра, указатель на него)
        /// </summary>
        private Dictionary<SwordParameterType, Parameter>
            _parametersDictionary =
                new()
                {
                    {_swordLength.Name, _swordLength},
                    {_bladeLength.Name, _bladeLength},
                    {_bladeThickness.Name, _bladeThickness},
                    {_guardWidth.Name, _guardWidth},
                    {_handleDiameter.Name, _handleDiameter},
                    {_handleLengthWithGuard.Name, _handleLengthWithGuard}
                };

        /// <summary>
        /// Конастанты минимальных и максимальных значений параметров в мм
        /// Минимальные значения являются дефолтными
        /// </summary>
        // TODO: RSDN     Done
        // TODO: XML для каждого    Done
       
        /// <summary>
        /// Минимальная длинна меча
        /// </summary>
        public const int MINSWORDLENGTH = 1000;

        /// <summary>
        /// Максимальная длинна меча
        /// </summary>
        public const int MAXSWORDLENGTH = 1500;

        /// <summary>
        /// Минимальная длинна лезвия
        /// </summary>
        public const int MINBLADELENGTH = 700;

        /// <summary>
        /// Максимальная длинна лезвия
        /// </summary>
        public const int MAXBLADELENGTH = 1000;

        /// <summary>
        /// Минимальная толщина лезвия
        /// </summary>
        public const int MINBLADETHIKLESS = 5;

        /// <summary>
        /// Максимальная толщина лезвия
        /// </summary>
        public const int MAXBLADETHIKLESS = 15;

        /// <summary>
        /// Минимальная ширина гарды
        /// </summary>
        public const int MINGUARDWIGHT = 200;

        /// <summary>
        /// Максимальная ширина гарды
        /// </summary>
        public const int MAXGUARDWIGHT = 300;

        /// <summary>
        /// Минимальный диаметр рукоятки
        /// </summary>
        public const int MINHANDLEDIAMETER = 10;

        /// <summary>
        /// Максимальный диаметр ручки
        /// </summary>
        public const int MAXHANDLEDIAMETER = 30;

        /// <summary>
        /// Минимальная длина рукоятки вместе с гардой
        /// </summary>
        public const int MINHANDLELENGHTWITHGUARD = 175;

        /// <summary>
        /// Максимальная длина рукоятки вместе с гардой
        /// </summary>
        public const int MAXHANDLELENGHTWITHGUARD = 250;

        /// <summary>
        /// Константы ограничений для параметров
        /// </summary>
        
        //public const int HANDLE_LENGHT_DIFFERENCE = 250;
        public const int BLADETHIСKDIFFERENCE = 10;

        //сделать так, чтобы менялось максимальное или минимальное значение у параметра, а не значение



        /// <summary>
        /// Задаёт или возвращает общую длину меча
        /// </summary>
        public int SwordLength
        {
            get => _swordLength.Value;
            set => _swordLength.Value = value;
        }

        /// <summary>
        /// Задаёт или возвращает длину лезвия
        /// </summary>
        public int BladeLength
        {
            get => _bladeLength.Value;
            set
            {            
                _bladeLength.Value = value;
                //_handleLengthWithGuard.Value = value - HANDLE_LENGHT_DIFFERENCE;
            }
        }

        /// <summary>
        /// Задаёт или возвращает толщину лезвия
        /// </summary>
        public int BladeThikless
        {
            get => _bladeThickness.Value;
            set
            { 
                _bladeThickness.Value = value;
                //_handleDiameter.Value = value -  BLADE_THIСK_DIFFERENCE;
            }
        }

        /// <summary>
        /// Задаёт или возвращает ширину гарды
        /// </summary>
        public int GuardWidht
        {
            get => _guardWidth.Value;
            set => _guardWidth.Value = value;
        }

        /// <summary>
        /// Задаёт или возвращает диаметр рукоятки
        /// </summary>
        public int HandleDiameter
        {
            get => _handleDiameter.Value;
            set
            {
                _handleDiameter.Value = value;
                //_bladeThickness.Value = value + BLADETHIСKDIFFERENCE;
                //MAXBLADETHIKLESS = MAXBLADETHIKLESS - BLADETHIСKDIFFERENCE;
            }
        }

            /// <summary>
        /// Задаёт или возвращает длину рукоятки вместе с гардой
        /// </summary>
        public int HandleLenghtWithGuard
        {
            get => _handleLengthWithGuard.Value;
            set 
            {
                _handleLengthWithGuard.Value = value;
                //_bladeLength.Value = value + HANDLE_LENGHT_DIFFERENCE;
            }
        }

        /// <summary>
        /// Конструктор класса с минимальными значенми по умолчанию
        /// </summary>
        public SwordParameters()
        {
            SwordLength = MINSWORDLENGTH;
            BladeLength = MINBLADELENGTH;
            BladeThikless = MINBLADETHIKLESS;
            GuardWidht = MINGUARDWIGHT;
            HandleDiameter = MINHANDLEDIAMETER;
            HandleLenghtWithGuard = MINHANDLELENGHTWITHGUARD;
            BladeType = BladeType.Sharp;
        }

        /// <summary>
        /// Метод передающй значение в сеттер параметра по имени
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <param name="value">Значение</param>
        public void SetParameterByName(SwordParameterType name, int value)
        {
            if (_parametersDictionary.ContainsKey(name))
            {
                switch (name)
                {
                    case SwordParameterType.BladeLength:
                    {
                        BladeLength = value;
                        break;
                    }
                    case SwordParameterType.GuardWidth:
                    {
                        GuardWidht = value;
                        break;
                    }
                    default:
                    {
                        _parametersDictionary.TryGetValue(name,
                            out var parameter);
                        parameter.Value = value;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Метод возвращающий значение параметра по имени
        /// </summary>
        /// <param name="name">Имя</param>
        /// <returns>Значение</returns>
        public int GetParameterValueByName(SwordParameterType name)
        {
            _parametersDictionary.TryGetValue(name, out var parameter);
            return parameter.Value;
        }
    }
}
