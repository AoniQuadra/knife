using System;

namespace Core
{
    /// <summary>
    /// Класс параметра
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Минимальное значение параметра
        /// </summary>
        private int _min;

        /// <summary>
        /// Максимальное значение параметра
        /// </summary>
        private int _max;

        /// <summary>
        /// Присваемое значение параметра
        /// </summary>
        private int _value;

        /// <summary>
        /// Название параметра для составления сообщения исключения
        /// </summary>
        private ParameterNames _name;

        /// <summary>
        /// Передаёт или задаёт имя, которое должно быть не
        /// пустым или не являтся разделяющим знаком
        /// </summary>
        public ParameterNames Name
        {
            get => _name;
            set => _name = value;
        }

        /// <summary>
        /// Передаёт или задаёт минимальное значение
        /// </summary>
        public int Min
        {
            get => _min;
            set => _min = value;
        }

        /// <summary>
        /// Передаёт или задаёт максимальное значение
        /// </summary>
        public int Max
        {
            get => _max;

            set
            {
                if (value <= _min)
                {
                    throw new Exception("Maximum should be "
                                        + "more or equal to minimum");
                }

                _max = value;
            }
        }

        /// <summary>
        /// Передаёт или задаёт значение параметра
        /// </summary>
        public int Value
        {
            get => _value;

            set
            {
                if (value < _min)
                {
                    throw new Exception($"{Name} should be "
                                        + $"more or equal to {Min}");
                }
                else if (value > _max)
                {
                    throw new Exception($"{Name} should be "
                                        + $"less or equal to {Max}");
                }

                _value = value;
            }
        }

        /// <summary>
        /// Конструктор шаблона параметра
        /// </summary>
        /// <param name="name">Название параметра</param>
        /// <param name="max">Максимально возможное значение</param>
        /// <param name="min">Минимально возможное значение</param>
        public Parameter(ParameterNames name, int max, int min)
        {
            Name = name;
            Min = min;
            Max = max;
        }
    }
}
