using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Combattimento_tra_personaggi;

namespace Combattimento_tra_personaggi
{
    public partial class CardControl : UserControl
    {
        public event EventHandler CardActionClicked;

        private bool _isFrontVisible;
        private bool _isAnimating;
        private Character _character; // Campo privato per la proprietà Character
        public Character Character
        {
            get
            {
                return _character; // Ritorna il campo privato
            }
            set
            {
                // Solo aggiorna se il valore è diverso o se è la prima assegnazione
                if (_character != value) // Evita assegnazioni ridondanti e cicli infiniti se si modifica un campo
                {
                    _character = value; // Assegna al campo privato
                    UpdateCardDisplay(); // Aggiorna la UI quando il personaggio cambia
                }
            }

        }
        public bool IsFrontVisible
        {
            get { return _isFrontVisible; }private set { }
        }

        public CardControl(Character character) : this()
        {
            this.Character = character;
        }
        public CardControl()
        {
            InitializeComponent();
            this.Character = new Character();
            this._isAnimating = false;
            this._isFrontVisible = true;
            btt_attack.Click += (sender, e) => CardActionClicked?.Invoke(this, e);
        }


        public void UpdateCardDisplay()
        {

            // Imposta il tipo di carta e il colore del tag
            if (Character is Guerriero)
            {
                lbl_Title.Text = "Guerriero";
                pnl_front.BackColor = Color.Coral;

            }
            else if (Character is Mago)
            {
                lbl_Title.Text = "Mago";
                pnl_front.BackColor = Color.DodgerBlue;
            }
            else if (Character is Arciere)
            {
                lbl_Title.Text = "Arciere";
                pnl_front.BackColor = Color.ForestGreen;
            }
            else
            {
                lbl_Title.Text = "Generico";
                pnl_front.BackColor = Color.Gray;
            }

            // Descrizione di esempio per il retro
            lbl_infocard.Text = Character.InfoCard(); // Usa il metodo InfoCard esistente
            btt_attack.Text = $"Attacca con {lbl_Title.Text}";
        }

        public async Task Flip()
        {
            if (_isAnimating) return;
            _isAnimating = true;

            int originalWidth = this.Width;
            int originalX = this.Location.X;

            int animationDuration = 400;
            int steps = 20;
            int delayPerStep = animationDuration / steps;

            // --- Prima metà dell'animazione: la carta si restringe ---
            for (int i = 0; i < steps / 2; i++)
            {
                int currentWidth = originalWidth - (originalWidth / (steps / 2)) * (i + 1);
                int currentX = originalX + (originalWidth - currentWidth) / 2;

                this.Width = currentWidth;
                this.Location = new Point(currentX, this.Location.Y);
                await Task.Delay(delayPerStep);
            }

            // --- Punto di mezzo: scambia la visibilità dei pannelli ---
            _isFrontVisible = !_isFrontVisible;
            pnl_front.Visible = _isFrontVisible;

            // --- Seconda metà dell'animazione: la carta si espande ---
            for (int i = (steps / 2) - 1; i >= 0; i--)
            {
                int currentWidth = originalWidth - (originalWidth / (steps / 2)) * i;
                int currentX = originalX + (originalWidth - currentWidth) / 2;

                this.Width = currentWidth;
                this.Location = new Point(currentX, this.Location.Y);
                await Task.Delay(delayPerStep);
            }

            // --- Animazione completata: assicura le dimensioni e la posizione originali ---
            this.Width = originalWidth;
            this.Location = new Point(originalX, this.Location.Y);

            _isAnimating = false;
        }

        private void lbl_Title_Click(object sender, EventArgs e)
        {

        }
        private void CardControl_Load(object sender, EventArgs e)
        {
            UpdateCardDisplay();
        }

        private void btt_attack_Click(object sender, EventArgs e)
        {

        }
        public void ShowBack()
        {
            _isFrontVisible = false;
            pnl_front.Visible = false;
        }

        // Nuovo metodo: Mostra il lato frontale della carta immediatamente
        public void ShowFront()
        {
            _isFrontVisible = true;
            pnl_front.Visible = true;
        }
    }
}
