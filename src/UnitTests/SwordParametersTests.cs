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
        private readonly Dictionary<SwordParameterType, int>
            _maxValuesOfParameterDictionary =
                new()
                {
                    {
                        SwordParameterType.SwordLength,
                        SwordParameters.MaxSwordLength
                    },
                    {
                        SwordParameterType.BladeLength,
                        SwordParameters.MaxBladeLength
                    },
                    {
                        SwordParameterType.BladeThickness,
                        SwordParameters.MaxBladeThickless
                    },
                    {
                        SwordParameterType.GuardWidth,
                        SwordParameters.MaxGuardWigth
                    },
                    {
                        SwordParameterType.HandleDiameter,
                        SwordParameters.MaxHadleDiameter
                    },
                    {
                        SwordParameterType.HandleLengthWithGuard,
                        SwordParameters.MaxHandleLengthWithGuard
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

            var newValue = (SwordParameters.MinSwordLength
                            + SwordParameters.MinSwordLength) / 2;
            SwordParameterType testParameterName =
                SwordParameterType.SwordLength;
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
                          == SwordParameters.MaxSwordLength
                          && testSwordParameters.BladeThikless
                          == SwordParameters.MaxBladeThickless
                          && testSwordParameters.HandleDiameter
                          == SwordParameters.MaxHadleDiameter
                          && testSwordParameters.HandleLenghtWithGuard
                          == SwordParameters.MaxHandleLengthWithGuard, Is.True,
                "Возникает, если геттер вернул не то значение");
        }

        [Test(Description = "Тест на сеттер ширины гарды")]
        public void TestHeadDiameter_Set()
        {
            var testSwordParameters = DefaultParameters;

            testSwordParameters.GuardWidht = SwordParameters.MaxGuardWigth;
            testSwordParameters.BladeLength = SwordParameters.MinBladeLength;

            Assert.That(testSwordParameters.GuardWidht, Is.EqualTo(SwordParameters.MaxGuardWigth),
                "Сеттер не поменял знаечние зависимого параметра");
        }

        [Test(Description = "Тест на сеттер длинны лезвия")]
        public void TestSlitLength_Set()
        {
            var testSwordParameters = DefaultParameters;

            testSwordParameters.GuardWidht = SwordParameters.MaxGuardWigth;
            testSwordParameters.GuardWidht = SwordParameters.MinGuardWigth;

            Assert.That(testSwordParameters.BladeLength, Is.EqualTo(SwordParameters.MinBladeLength),
                "Сеттер не поменял знаечние зависимого параметра");
        }
    }
}