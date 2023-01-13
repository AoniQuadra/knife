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
            new(ParameterNames.SwordLength,
                MAX_SWORD_LENGTH, MIN_SWORD_LENGTH);

        /// <summary>
        /// Длина лезвия
        /// </summary>
        private static Parameter _bladeLength =
            new(ParameterNames.BladeLength,
                MAX_BLADE_LENGTH, MIN_BLADE_LENGTH);

        /// <summary>
        /// Толщина лезвия
        /// </summary>
        private static Parameter _bladeThikless =
            new(ParameterNames.BladeThickness,
                MAX_BLADE_THIKLESS, MIN_BLADE_THIKLESS);

        /// <summary>
        /// ширина гарды
        /// </summary>
        private static Parameter _guardWidht =
            new(ParameterNames.GuardWidth,
                MAX_GUARD_WIGHT, MIN_GUARD_WIGHT);

        /// <summary>
        /// Диаметр рукоятки
        /// </summary>
        private static Parameter _handleDiameter =
            new(ParameterNames.HandleDiameter,
                MAX_HANDLE_DIAMETER, MIN_HANDLE_DIAMETER);

        /// <summary>
        /// Длина рукоятки вместе с гардой
        /// </summary>
        private static Parameter _handleLenghtWithGuard =
            new(ParameterNames.HandleLengthWithGuard,
                MAX_HANDLE_LENGHT_WITH_GUARD, MIN_HANDLE_LENGHT_WITH_GUARD);

        /// <summary>
        /// Словарь содержащий пары (Имя параметра, указатель на него)
        /// </summary>
        private Dictionary<ParameterNames, Parameter>
            _parametersDictionary =
                new()
                {
                    {_swordLength.Name, _swordLength},
                    {_bladeLength.Name, _bladeLength},
                    {_bladeThikless.Name, _bladeThikless},
                    {_guardWidht.Name, _guardWidht},
                    {_handleDiameter.Name, _handleDiameter},
                    {_handleLenghtWithGuard.Name, _handleLenghtWithGuard}
                };

        /// <summary>
        /// Конастанты минимальных и максимальных значений параметров в мм
        /// Минимальные значения являются дефолтными
        /// </summary>
        public const int MIN_SWORD_LENGTH = 1000;
        public const int MAX_SWORD_LENGTH = 1500;

        public const int MIN_BLADE_LENGTH = 700;
        public const int MAX_BLADE_LENGTH = 1000;

        public const int MIN_BLADE_THIKLESS = 5;
        public const int MAX_BLADE_THIKLESS = 15;

        public const int MIN_GUARD_WIGHT = 200;
        public const int MAX_GUARD_WIGHT = 300;

        public const int MIN_HANDLE_DIAMETER = 10;
        public const int MAX_HANDLE_DIAMETER = 30;

        public const int MIN_HANDLE_LENGHT_WITH_GUARD = 175;
        public const int MAX_HANDLE_LENGHT_WITH_GUARD = 250;

        /// <summary>
        /// Константы ограничений для параметров
        /// </summary>
        //public const int SLITE_HEAD_DIFFERENCE = 2;

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
            get => _bladeThikless.Value;
            set =>_bladeThikless.Value = value;
            }

        /// <summary>
        /// Задаёт или возвращает ширину гарды
        /// </summary>
        public int GuardWidht
        {
            get => _guardWidht.Value;
            set
            {
                _guardWidht.Value = value;
               // _bladeLength.Value = value /*- SLITE_HEAD_DIFFERENCE*/;
            }
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
                _bladeThikless.Value = value;
            }
        }

            /// <summary>
        /// Задаёт или возвращает длину рукоятки вместе с гардой
        /// </summary>
        public int HandleLenghtWithGuard
        {
            get => _handleLenghtWithGuard.Value;
            set => _handleLenghtWithGuard.Value = value;
        }

        /// <summary>
        /// Конструктор класса с минимальными значенми по умолчанию
        /// </summary>
        public SwordParameters()
        {
            SwordLength = MIN_SWORD_LENGTH;
            BladeLength = MIN_BLADE_LENGTH;
            BladeThikless = MIN_BLADE_THIKLESS;
            GuardWidht = MIN_GUARD_WIGHT;
            HandleDiameter = MIN_HANDLE_DIAMETER;
            HandleLenghtWithGuard = MIN_HANDLE_LENGHT_WITH_GUARD;
        }

        /// <summary>
        /// Метод передающй значение в сеттер параметра по имени
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <param name="value">Значение</param>
        public void SetParameterByName(ParameterNames name, int value)
        {
            if (_parametersDictionary.ContainsKey(name))
            {
                switch (name)
                {
                    case ParameterNames.BladeLength:
                        BladeLength = value;
                        break;
                    case ParameterNames.GuardWidth:
                        GuardWidht = value;
                        break;
                    default:
                        _parametersDictionary.TryGetValue(name,
                            out var parameter);
                        parameter.Value = value;
                        break;
                }
            }
        }

        /// <summary>
        /// Метод возвращающий значение параметра по имени
        /// </summary>
        /// <param name="name">Имя</param>
        /// <returns>Значение</returns>
        public int GetParameterValueByName(ParameterNames name)
        {
            _parametersDictionary.TryGetValue(name, out var parameter);
            return parameter.Value;
        }
    }
}
