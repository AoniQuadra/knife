using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Core;
using KompasWrapper;

namespace PluginUI
{
    /// <summary>
    /// Класс хранящий и обрабатывающий пользовательский интерфейс плагина
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Объект класса построителя
        /// </summary>
        private readonly SwordBuilder _swordBuilder = new SwordBuilder();

        /// <summary>
        /// Объект класса с параметрами
        /// </summary>
        private readonly SwordParameters _swordParameters =
            new SwordParameters();

        /// <summary>
        /// Словарь содержащий пары (Текстбоксы, имя параметра)
        /// </summary>
        private readonly Dictionary<TextBox, SwordParameterType> _textBoxesDictionary;

        /// <summary>
        /// Словарь содержащие пары (Текстбокс, корректное ли значение в нём)
        /// </summary>
        private readonly Dictionary<TextBox, bool> _isValueInTextBoxCorrect;

        public MainForm()
        {
            InitializeComponent();

            _textBoxesDictionary = new Dictionary<TextBox, SwordParameterType>
            {
                {SwordLengthTextBox, SwordParameterType.SwordLength},
                {BladeLengthTextBox, SwordParameterType.BladeLength},
                {BladeThiklessTextBox, SwordParameterType.BladeThickness},
                {GuardWidhtTextBox, SwordParameterType.GuardWidth},
                {HandleDiameterTextBox, SwordParameterType.HandleDiameter},
                {HandleLenghtWithGuardTextBox, SwordParameterType.HandleLengthWithGuard}
            };

            _isValueInTextBoxCorrect = new Dictionary<TextBox, bool>
            {
                {SwordLengthTextBox, true},
                {BladeLengthTextBox, true},
                {BladeThiklessTextBox, true},
                {GuardWidhtTextBox, true},
                {HandleDiameterTextBox, true},
                {HandleLenghtWithGuardTextBox, true}
            };

            foreach (var textBox in _textBoxesDictionary)
            {
                textBox.Key.Text = _swordParameters
                    .GetParameterValueByName(textBox.Value).ToString();
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Построить"
        /// </summary>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            _swordBuilder.BuildSword(_swordParameters);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!(sender is TextBox textBox)) return;

            Validating(textBox);
        }


        /// <summary>
        /// Общий метод валидации текстбокса
        /// </summary>
        private new void Validating(TextBox textBox)
        {
            try
            {
                _textBoxesDictionary.TryGetValue(textBox,
                    out var parameterInTextBoxName);
                _swordParameters.SetParameterByName(parameterInTextBoxName,
                    int.Parse(textBox.Text));

                if (textBox == BladeLengthTextBox)
                {
                    GuardWidhtTextBox.Text =
                        _swordParameters.GuardWidht.ToString();
                }
                else if (textBox == GuardWidhtTextBox)
                {
                    BladeLengthTextBox.Text =
                        _swordParameters.BladeLength.ToString();
                }

                //Значение в текстбоксе правильное
                _isValueInTextBoxCorrect[textBox] = true;
                bool isTextBoxesValuesCorrect = true;

                foreach (var isValueCorrect in _isValueInTextBoxCorrect)
                {
                    isTextBoxesValuesCorrect &= isValueCorrect.Value;
                }

                //Проверяем, можно ли активировать кнопку
                if (isTextBoxesValuesCorrect)
                {
                    BuildButton.Enabled = true;
                }
                textBox.BackColor = Color.White;
                toolTip.Active = false;
            }
            catch (Exception exception)
            {
                //Значение в текстбоксе неправильное
                BuildButton.Enabled = false;
                textBox.BackColor = Color.LightSalmon;
                toolTip.Active = true;
                toolTip.SetToolTip(textBox, exception.Message);
                _isValueInTextBoxCorrect[textBox] = false;
            }
        }
    }
}
