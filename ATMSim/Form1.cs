namespace ATMSim
{
    public partial class Form1 : Form
    {
        private double balance = 10000f;

        private TextBox[] pinTextBoxes;
        private Button submitButton;
        private Button phoneMessageBtn;
        private Button checkBalanceBtn;
        private Button getCashBtn;

        private Label infoLabel;
        
        private Button backBtn;

        private Label balanceLabel;

        private TextBox cashValueTextBox;
        private Button submitCashValueBtn;

        private TextBox phoneNumberTextBox;
        private Button submitPhoneNumberBtn;

        public Form1()
        {
            InitializeComponent();
            InitializeComponents();
        }

        public static bool IsNumber(string s)
        {
            double result;
            return double.TryParse(s, out result);
        }

        private void InitializeComponents()
        {
            // Создание текстовых полей для ввода PIN-кода
            pinTextBoxes = new TextBox[4];
            for (int i = 0; i < 4; i++)
            {
                pinTextBoxes[i] = new TextBox();
                pinTextBoxes[i].Location = new Point(130 + i * 40, 160);
                pinTextBoxes[i].Size = new Size(30, 20);
                pinTextBoxes[i].MaxLength = 1;
                pinTextBoxes[i].TextAlign = HorizontalAlignment.Center;
                Controls.Add(pinTextBoxes[i]);
            }

            submitButton = new Button();
            submitButton.Location = new Point(155, 220);
            submitButton.Size = new Size(100, 30);
            submitButton.Text = "Tassyklamak";
            submitButton.Click += SubmitButton_Click;
            Controls.Add(submitButton);

            Text = "PIN-kod";
            ClientSize = new Size(400, 400);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void RedrawMainPage()
        {
            Controls.Clear();
            Size mainPageBtnsSize = new Size(250, 30);

            phoneMessageBtn = new Button();
            phoneMessageBtn.Location = new Point(80, 140);
            phoneMessageBtn.Size = mainPageBtnsSize;
            phoneMessageBtn.Text = "SMS hyzmaty";
            phoneMessageBtn.Click += PhoneMessageBtn_Click;
            Controls.Add(phoneMessageBtn);

            checkBalanceBtn = new Button();
            checkBalanceBtn.Location = new Point(80, 180);
            checkBalanceBtn.Size = mainPageBtnsSize;
            checkBalanceBtn.Text = "Balansy barlamak";
            checkBalanceBtn.Click += CheckBalanceBtn_Click;
            Controls.Add(checkBalanceBtn);

            getCashBtn = new Button();
            getCashBtn.Location = new Point(80, 220);
            getCashBtn.Size = mainPageBtnsSize;
            getCashBtn.Text = "Nagt pul çekmek";
            getCashBtn.Click += GetCashBtn_Click;
            Controls.Add(getCashBtn);
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            RedrawMainPage();
        }

        private void PhoneMessageBtn_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            infoLabel = new Label();
            infoLabel.Text = "Telefon belgiňizi giriziň:";
            infoLabel.Location = new Point(80, 110);
            infoLabel.Size = new Size(250, 20);
            Controls.Add(infoLabel);

            phoneNumberTextBox = new TextBox();
            phoneNumberTextBox.Location = new Point(80, 140);
            phoneNumberTextBox.Size = new Size(250, 20);
            phoneNumberTextBox.MaxLength = 8;
            Controls.Add(phoneNumberTextBox);

            submitPhoneNumberBtn = new Button();
            submitPhoneNumberBtn.Location = new Point(155, 180);
            submitPhoneNumberBtn.Size = new Size(100, 30);
            submitPhoneNumberBtn.Text = "Tassyklamak";
            submitPhoneNumberBtn.Click += submitPhoneNumberBtn_Click;
            Controls.Add(submitPhoneNumberBtn);

            backBtn = new Button();
            backBtn.Location = new Point(155, 220);
            backBtn.Size = new Size(100, 30);
            backBtn.Text = "Yza";
            backBtn.Click += BackBtn_Click;
            Controls.Add(backBtn);
        }

        private void CheckBalanceBtn_Click(object sender, EventArgs e)
        {
            Controls.Clear();

            infoLabel = new Label();
            infoLabel.Text = $"Siziň kartyňyzdaky pul möçberi {balance} manat";
            infoLabel.Location = new Point(80, 130);
            infoLabel.Size = new Size(250, 50);
            infoLabel.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(infoLabel);


            backBtn = new Button();
            backBtn.Location = new Point(155, 220);
            backBtn.Size = new Size(100, 30);
            backBtn.Text = "Yza";
            backBtn.Click += BackBtn_Click;
            Controls.Add(backBtn);
        }
        

        private void GetCashBtn_Click(object sender, EventArgs e)
        {

            Controls.Clear();

            infoLabel = new Label();
            infoLabel.Text = "Pul möçberini giriziň:";
            infoLabel.Location = new Point(80, 110);
            infoLabel.Size = new Size(250, 20);
            Controls.Add(infoLabel);

            cashValueTextBox = new TextBox();
            cashValueTextBox.Location = new Point(80, 140);
            cashValueTextBox.Size = new Size(250, 20);
            Controls.Add(cashValueTextBox);

            submitCashValueBtn = new Button();
            submitCashValueBtn.Location = new Point(155, 180);
            submitCashValueBtn.Size = new Size(100, 30);
            submitCashValueBtn.Text = "Tassyklamak";
            submitCashValueBtn.Click += submitCashValueBtn_Click;
            Controls.Add(submitCashValueBtn);

            backBtn = new Button();
            backBtn.Location = new Point(155, 220);
            backBtn.Size = new Size(100, 30);
            backBtn.Text = "Yza";
            backBtn.Click += BackBtn_Click;
            Controls.Add(backBtn);
        }

        private void submitCashValueBtn_Click(object sender, EventArgs e)
        {
            string cashValue = (string)cashValueTextBox.Text;
            cashValue = cashValue.Replace(".", ",");
            if (IsNumber(cashValue))
            {
                double cashPrompt = Convert.ToDouble(cashValue);
                if (cashPrompt <= balance) { 
                    balance -= cashPrompt;
                    MessageBox.Show($"Siziň kartyňyzdan {cashPrompt} manat çekildi!", "Üstünlikli", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RedrawMainPage();
                } else
                {
                    MessageBox.Show("Kartyňyzdaky pul möçberi ýeterlikli däl!", "Ýalňyşlyk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("San girizmegiňizi haýyş edýäris!", "Ýalňyşlyk", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void submitPhoneNumberBtn_Click(object sender, EventArgs e)
        {
            string phoneNumber = (string)phoneNumberTextBox.Text;
            if (IsNumber(phoneNumber))
            {
                if (phoneNumber.Length == 8)
                {
                    MessageBox.Show($"\"+993{phoneNumber}\" belgä SMS hyzmaty iň ýakyn wagtda birikdiriler!", "Üstünlikli", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RedrawMainPage();

                } else
                {
                    MessageBox.Show("Telefon belgiňizi dogry giriziň!", "Ýalňyşlyk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("San girizmegiňizi haýyş edýäris!", "Ýalňyşlyk", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string pinCode = "";
            for (int i = 0; i < 4; i++)
            {
                pinCode += pinTextBoxes[i].Text;
            }

            if (pinCode == "1234")
            {
                Text = "Operasiýany saýlaň";

                MessageBox.Show("PIN-kod dogry!", "Üstünlikli", MessageBoxButtons.OK, MessageBoxIcon.Information);
                for (int i = 0; i < 4; i++)
                {
                    Controls.Remove(pinTextBoxes[i]);
                }


                Controls.Remove(submitButton);
                ClientSize = new Size(400, 400);

                RedrawMainPage();
            }
            else
            {
                MessageBox.Show("PIN-kod nädogry!", "Ýalňyşlyk", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
