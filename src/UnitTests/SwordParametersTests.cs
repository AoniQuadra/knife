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
                        SwordParameters.MAXSWORDLENGTH
                    },
                    {
                        SwordParameterType.BladeLength,
                        SwordParameters.MAXBLADELENGTH
                    },
                    {
                        SwordParameterType.BladeThickness,
                        SwordParameters.MAXBLADETHIKLESS
                    },
                    {
                        SwordParameterType.GuardWidth,
                        SwordParameters.MAXGUARDWIGHT
                    },
                    {
                        SwordParameterType.HandleDiameter,
                        SwordParameters.MAXHANDLEDIAMETER
                    },
                    {
                        SwordParameterType.HandleLengthWithGuard,
                        SwordParameters.MAXHANDLELENGHTWITHGUARD
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

            var newValue = (SwordParameters.MINSWORDLENGTH
                            + SwordParameters.MINSWORDLENGTH) / 2;
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
                          == SwordParameters.MAXSWORDLENGTH
                          && testSwordParameters.BladeThikless
                          == SwordParameters.MAXBLADETHIKLESS
                          && testSwordParameters.HandleDiameter
                          == SwordParameters.MAXHANDLEDIAMETER
                          && testSwordParameters.HandleLenghtWithGuard
                          == SwordParameters.MAXHANDLELENGHTWITHGUARD, Is.True,
                "Возникает, если геттер вернул не то значение");
        }

        [Test(Description = "Тест на сеттер диаметра головки")]
        public void TestHeadDiameter_Set()
        {
            var testSwordParameters = DefaultParameters;

            testSwordParameters.GuardWidht = SwordParameters.MAXGUARDWIGHT;
            testSwordParameters.BladeLength = SwordParameters.MINBLADELENGTH;

            Assert.That(testSwordParameters.GuardWidht, Is.EqualTo(SwordParameters.MAXGUARDWIGHT
                /*+ SwordParameters.SLITE_HEAD_DIFFERENCE*/),
                "Сеттер не поменял знаечние зависимого параметра");
        }

        [Test(Description = "Тест на сеттер длины шлица")]
        public void TestSlitLength_Set()
        {
            var testSwordParameters = DefaultParameters;

            testSwordParameters.GuardWidht = SwordParameters.MAXGUARDWIGHT;
            testSwordParameters.GuardWidht = SwordParameters.MINGUARDWIGHT;

            Assert.That(testSwordParameters.BladeLength, Is.EqualTo(SwordParameters.MINBLADELENGTH),
                "Сеттер не поменял знаечние зависимого параметра");
        }
    }
}