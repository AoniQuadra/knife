using System;
using System.Collections.Generic;
using Core;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class SwordParametersTests
    {
        /// <summary>
        /// Свойство возвращающее новый обект класса MalletParameters
        /// </summary>
        private SwordParameters DefaultParameters =>
            new();

        /// <summary>
        /// Словарь имён и максимальных значений параметров
        /// </summary>
        private readonly Dictionary<ParameterNames, int>
            _maxValuesOfParameterDictionary =
                new()
                {
                    {
                        ParameterNames.SwordLength,
                        SwordParameters.MAX_SWORD_LENGTH
                    },
                    {
                        ParameterNames.BladeLength,
                        SwordParameters.MAX_BLADE_LENGTH
                    },
                    {
                        ParameterNames.BladeThickness,
                        SwordParameters.MAX_BLADE_THIKLESS
                    },
                    {
                        ParameterNames.GuardWidth,
                        SwordParameters.MAX_GUARD_WIGHT
                    },
                    {
                        ParameterNames.HandleDiameter,
                        SwordParameters.MAX_HANDLE_DIAMETER
                    },
                    {
                        ParameterNames.HandleLengthWithGuard,
                        SwordParameters.MAX_HANDLE_LENGHT_WITH_GUARD
                    },
                };

        [Test(Description = "Тест метода передающий значение "
                            + "в сеттер параметра по его имени")]
        public void TestSetParameterByName()
        {
            var testSwordParameters = DefaultParameters;

            foreach (var parameterMaxValue
                     in _maxValuesOfParameterDictionary)
            {
                testSwordParameters.SetParameterByName(
                    parameterMaxValue.Key, parameterMaxValue.Value);
            }

            int errorCounter = 0;

            foreach (var parameterMaxValue
                     in _maxValuesOfParameterDictionary)
            {
                if (testSwordParameters.GetParameterValueByName(
                        parameterMaxValue.Key) != parameterMaxValue.Value)
                {
                    errorCounter++;
                }
            }

            Assert.That(errorCounter, Is.Zero,
                "Значения не были помещены в сеттеры параметров");
        }

        [Test(Description = "Тест на геттер значения параметра по имени")]
        public void TestGetParameterByName()
        {
            var testSwordParameters = DefaultParameters;

            var newValue = (SwordParameters.MIN_SWORD_LENGTH
                            + SwordParameters.MIN_SWORD_LENGTH) / 2;
            ParameterNames testParameterName =
                ParameterNames.SwordLength;
            testSwordParameters
                .SetParameterByName(testParameterName, newValue);

            Assert.That(testSwordParameters
                    .GetParameterValueByName(testParameterName), Is.EqualTo(newValue),
                "Из геттера вернулось неверное значение");
        }

        [Test(Description = "Позитивный тест на геттеры параметров")]
        public void TestParameterGet()
        {
            var testSwordParameters = DefaultParameters;

            foreach (var parameterMaxValue
                     in _maxValuesOfParameterDictionary)
            {
                testSwordParameters.SetParameterByName(
                    parameterMaxValue.Key, parameterMaxValue.Value);
            }

            Assert.That(testSwordParameters.SwordLength
                          == SwordParameters.MAX_SWORD_LENGTH
                          && testSwordParameters.BladeThikless
                          == SwordParameters.MAX_BLADE_THIKLESS
                          && testSwordParameters.HandleDiameter
                          == SwordParameters.MAX_HANDLE_DIAMETER
                          && testSwordParameters.HandleLenghtWithGuard
                          == SwordParameters.MAX_HANDLE_LENGHT_WITH_GUARD, Is.True,
                "Возникает, если геттер вернул не то значение");
        }

        [Test(Description = "Тест на сеттер диаметра головки")]
        public void TestHeadDiameter_Set()
        {
            var testSwordParameters = DefaultParameters;

            testSwordParameters.GuardWidht = SwordParameters.MAX_GUARD_WIGHT;
            testSwordParameters.BladeLength = SwordParameters.MIN_BLADE_LENGTH;

            Assert.That(testSwordParameters.GuardWidht, Is.EqualTo(SwordParameters.MAX_GUARD_WIGHT
                /*+ SwordParameters.SLITE_HEAD_DIFFERENCE*/),
                "Сеттер не поменял знаечние зависимого параметра");
        }

        [Test(Description = "Тест на сеттер длины шлица")]
        public void TestSlitLength_Set()
        {
            var testSwordParameters = DefaultParameters;

            testSwordParameters.GuardWidht = SwordParameters.MAX_GUARD_WIGHT;
            testSwordParameters.GuardWidht = SwordParameters.MIN_GUARD_WIGHT;

            Assert.That(testSwordParameters.BladeLength, Is.EqualTo(SwordParameters.MIN_BLADE_LENGTH),
                "Сеттер не поменял знаечние зависимого параметра");
        }
    }
}