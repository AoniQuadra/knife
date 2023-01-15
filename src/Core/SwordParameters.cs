using System.Collections.Generic;

namespace Core
{
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
                MaxSwordLength, MinSwordLength);

        /// <summary>
        /// Длина лезвия
        /// </summary>
        private static Parameter _bladeLength =
            new(SwordParameterType.BladeLength,
                MaxBladeLength, MinBladeLength);

        /// <summary>
        /// Толщина лезвия
        /// </summary>
        private static Parameter _bladeThickness =
            new(SwordParameterType.BladeThickness,
                MaxBladeThickless, MinBladeThickless);

        /// <summary>
        /// Ширина гарды
        /// </summary>
        private static Parameter _guardWidth =
            new(SwordParameterType.GuardWidth,
                MaxGuardWigth, MinGuardWigth);

        /// <summary>
        /// Диаметр рукоятки
        /// </summary>
        private static Parameter _handleDiameter =
            new(SwordParameterType.HandleDiameter,
                MaxHadleDiameter, MinHandleDiameter);

        /// <summary>
        /// Длина рукоятки вместе с гардой
        /// </summary>
        // Грам ошибка
        private static Parameter _handleLengthWithGuard =
            new(SwordParameterType.HandleLengthWithGuard,
                MaxHandleLengthWithGuard, MinHandleLengthWithGuard);

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
        /// Минимальная длинна меча
        /// </summary>
        public const int MinSwordLength = 1000;
        
        /// <summary>
        /// Максимальная длинна меча
        /// </summary>
        public const int MaxSwordLength = 1500;

        /// <summary>
        /// Минимальная длинна лезвия
        /// </summary>
        public const int MinBladeLength = 700;

        /// <summary>
        /// Максимальная длинна лезвия
        /// </summary>
        public const int MaxBladeLength = 1000;

        /// <summary>
        /// Минимальная толщина лезвия
        /// </summary>
        public const int MinBladeThickless = 5;

        /// <summary>
        /// Максимальная толщина лезвия
        /// </summary>
        public const int MaxBladeThickless = 15;

        /// <summary>
        /// Минимальная ширина гарды
        /// </summary>
        public const int MinGuardWigth = 200;

        /// <summary>
        /// Максимальная ширина гарды
        /// </summary>
        public const int MaxGuardWigth = 300;

        /// <summary>
        /// Минимальный диаметр рукоятки
        /// </summary>
        public const int MinHandleDiameter = 10;

        /// <summary>
        /// Максимальный диаметр ручки
        /// </summary>
        public const int MaxHadleDiameter = 30;

        /// <summary>
        /// Минимальная длина рукоятки вместе с гардой
        /// </summary>
        public const int MinHandleLengthWithGuard = 175;

        /// <summary>
        /// Максимальная длина рукоятки вместе с гардой
        /// </summary>
        public const int MaxHandleLengthWithGuard = 250;

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
            set => _bladeLength.Value = value;
        }

        /// <summary>
        /// Задаёт или возвращает толщину лезвия
        /// </summary>
        public int BladeThikless
        {
            get => _bladeThickness.Value;
            set => _bladeThickness.Value = value;
                
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
            set => _handleDiameter.Value = value;
                
        }

            /// <summary>
        /// Задаёт или возвращает длину рукоятки вместе с гардой
        /// </summary>
        public int HandleLenghtWithGuard
        {
            get => _handleLengthWithGuard.Value;
            set => _handleLengthWithGuard.Value = value;
                
        }

        /// <summary>
        /// Конструктор класса с минимальными значенми по умолчанию
        /// </summary>
        public SwordParameters()
        {
            SwordLength = MinSwordLength;
            BladeLength = MinBladeLength;
            BladeThikless = MinBladeThickless;
            GuardWidht = MinGuardWigth;
            HandleDiameter = MinHandleDiameter;
            HandleLenghtWithGuard = MinHandleLengthWithGuard;
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
