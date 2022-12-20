using OOO_Aromatny_Mir.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOO_Aromatny_Mir
{
    public partial class FormAuthorization : Form
    {
        private string rightCaptchaText;
        private int secondsOfBlock;
        public FormAuthorization()
        {
            InitializeComponent();
        }

        private string GenerateCaptcha(int size)
        {
            Random random = new Random();
            string generatedCaptcha = "";
            string symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            for (int i = 0; i < size; i++)
            {
                generatedCaptcha += symbols[random.Next(0, symbols.Length + 1)].ToString();
            }
            return generatedCaptcha;
        }

        private void DrawCaptcha (string captcha)
        {
            int fontSize = 18;
            int placeX = 0;
            Random random = new Random();
            Bitmap captchaPlace = new Bitmap(PictureBoxCaptcha.Width,PictureBoxCaptcha.Height);
            Graphics captchaDraw = Graphics.FromImage(captchaPlace);
            Font captchaFont = new Font("Georgia", fontSize);
            captchaDraw.Clear(Color.White);
            captchaDraw.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (int i = 0; i < captcha.Length; i++)
            {
                placeX = random.Next(placeX + fontSize / 2, placeX + fontSize * 2);
                int placeY = random.Next(0,PictureBoxCaptcha.Height - fontSize * 2);
                captchaDraw.DrawString(captcha[i].ToString(),captchaFont,Brushes.Black,placeX,placeY);
                captchaDraw.DrawLine(Pens.Black, placeX, placeY, random.Next(placeX, PictureBoxCaptcha.Width), random.Next(placeY, PictureBoxCaptcha.Height));
            }
            captchaDraw.Flush();
            PictureBoxCaptcha.Image = captchaPlace;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string login = TextBoxLogin.Text;
            string password = TextBoxPassword.Text;
            var user = Helper.Model.User.Where(u => u.UserLogin == login && u.UserPassword == password).FirstOrDefault();
            Helper.CurrentUser = user;
            Helper.CurrentUserRole = Helper.Model.Role.Where(r => r.RoleID == user.UserRole).FirstOrDefault();
        }
    }
}
