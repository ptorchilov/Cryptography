namespace Lab04
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Class for application form.
    /// </summary>
    public partial class ApplicationForm : Form
    {
        #region Fields

        /// <summary>
        /// The keys
        /// </summary>
        private long[] keys;

        /// <summary>
        /// The fiat shamir
        /// </summary>
        private FiatShamir fiatShamir;

        /// <summary>
        /// The message
        /// </summary>
        private String message;

        #endregion
        
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationForm"/> class.
        /// </summary>
        public ApplicationForm()
        {
            InitializeComponent();
        } 

        #endregion

        #region Private methods

        /// <summary>
        /// Buttons the send click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonSendClick(object sender, EventArgs e)
        {

            var ksi1String = textBoxKsi1.Text;

            var ksi2String = textBoxKsi2.Text;

            if (ValidateKsiValue(ksi1String, 1) && ValidateKsiValue(ksi2String, 2))
            {

                var ksi1 = Convert.ToInt64(textBoxKsi1.Text);

                var ksi2 = Convert.ToInt64(textBoxKsi2.Text);

                message = textBoxMessage.Text;

                fiatShamir = new FiatShamir(ksi1, ksi2);

                keys = fiatShamir.GenerateSignature(message);

                ShowParams();
            }
        }

        /// <summary>
        /// Buttons the verify click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonVerifyClick(object sender, EventArgs e)
        {
            if (keys != null && keys.Any())
            {
                if (fiatShamir != null)
                {
                    var isValid = fiatShamir.ValidateSignature(keys, message);

                    ShowValidateParams(isValid);
                }
            }
        } 

        #endregion

        #region Output

        /// <summary>
        /// Shows the success parameters.
        /// </summary>
        private void ShowValidateParams(bool isValid)
        {
            var sb = new StringBuilder();

            sb.Append(@"{\rtf1\fcharset204 ");
            sb.Append(@"------------ Проверка подписи -----------\line ");

            sb.Append("1. Определяем параметр W: ");
            sb.Append(@"\b ");
            sb.Append(fiatShamir.W);
            sb.Append(@"\b0\line ");

            sb.Append("W В двоичном виде: ");
            sb.Append(@"\b ");
            sb.Append(fiatShamir.WBinary);
            sb.Append(@"\b0\line ");

            sb.Append("2. Вычисляем хэш функцию для Mu: ");
            sb.Append(@"\b ");
            sb.Append(fiatShamir.Hash);
            sb.Append(@"\b0\line ");

            sb.Append("3. Проверяем эквивалентность значений: ");
            sb.Append(@"\b ");
            sb.Append(fiatShamir.Hash);
            if (isValid)
            {
                sb.Append(" = ");
            }
            else
            {
                sb.Append(" != ");
            }

            sb.Append(fiatShamir.S).Append(@"\b0\line ");

            sb.Append("Принятое сообщение: ");
            sb.Append(@"\b ");
            sb.Append(message);
            sb.Append(@"\b0\line ");

            sb.Append("Принятое сообщение в двоичном виде: ");
            sb.Append(@"\b ");
            sb.Append(fiatShamir.CodedMsg);
            sb.Append(@"\b0\line ");

            sb.Append("}");

            textBox4.Rtf = sb.ToString();
        }

        /// <summary>
        /// Shows the parameters.
        /// </summary>
        private void ShowParams()
        {
            var sb = new StringBuilder();

            sb.Append(@"{\rtf1\fcharset204 ");
            sb.Append(@"---------- Формирование подписи ---------\line ");

            sb.Append("Передаваемое сообщение в двоичном виде: ");
            sb.Append(@"\b ");
            sb.Append(fiatShamir.CodedMsg);
            sb.Append(@"\b0\line ");

            sb.Append("1. Определяем модуль сравнения на основе Кси1 и Кси2: ");
            sb.Append(@"\b ");
            sb.Append(fiatShamir.M);
            sb.Append(@"\b0\line ");

            sb.Append("2. Выбираем случайное число 0 < Alpha <= M - 1: ");
            sb.Append(@"\b ");
            sb.Append(fiatShamir.Alpha);
            sb.Append(@"\b0\line ");

            sb.Append("3. Вычисляем Beta = Alpha ^ 2 (mod M): ");
            sb.Append(@"\b ");
            sb.Append(fiatShamir.Beta);
            sb.Append(@"\b0\line ");

            sb.Append("Beta в двоичном виде: ");
            sb.Append(@"\b ");
            sb.Append(fiatShamir.BetaBinary);
            sb.Append(@"\b0\line ");

            sb.Append("4. Вычисляем хэш функцию для сообщения Mu (секретный ключ S): ");
            sb.Append(@"\b ");
            sb.Append(fiatShamir.S);
            sb.Append(@"\b0\line ");

            sb.Append("5. Выбираем случайные числа A взаимнопростые с M: ");
            sb.Append(@"\b ");
            foreach (var ai in fiatShamir.A)
            {
                sb.Append(ai).Append(" ");
            }
            sb.Append(@"\b0\line ");

            sb.Append("6. Вычисляем значение секретного ключа T: ");
            sb.Append(@"\b ");
            sb.Append(fiatShamir.T);
            sb.Append(@"\b0\line ");

            sb.Append("7. Вычисляем значения открытых ключей B: ");
            sb.Append(@"\b ");
            foreach (var bi in fiatShamir.B)
            {
                sb.Append(bi).Append(" ");
            }
            sb.Append(@"\b0\line ");
            sb.Append("}");

            textBox3.Rtf = sb.ToString();
        }

        #endregion

        #region Input Validators

        /// <summary>
        /// Validates the ksi value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private bool ValidateKsiValue(String value, int number)
        {
            int result;
            string errorMessage;

            if (Int32.TryParse(value, out result))
            {
                if (!PrimeTool.IsPrime(result))
                {
                    errorMessage = String.Format("Значение для Кси {0} не простое.", number);
                    MessageBox.Show(errorMessage);

                    return false;
                }

                return true;
            }

            errorMessage = String.Format("Значение для Кси {0} не является числом.", number);
            MessageBox.Show(errorMessage);

            return false;
        }

        #endregion
    }
}
