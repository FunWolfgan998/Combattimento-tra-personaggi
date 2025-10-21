using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combattimento_tra_personaggi
{
    public partial class Form1 : Form
    {
        Random rnd;
        List<Character> deck_1, deck_2;
        List<CardControl> player1_cardControls,player2_cardControls;
        private CardControl attackingCard = null; // La carta che ha iniziato l'attacco
        private CardControl targetCard = null;    // La carta che subisce l'attacco
        bool IsPlayer1_turn;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            rnd = new Random();
            IsPlayer1_turn = true;
            deck_1 = CreateDeck(5);
            deck_2 = CreateDeck(5);
            btt_turn.Enabled = false;
            CreateCardsofDesks();
            UI();

        }
        #region Logica gioco

        #endregion

        private List<Character> CreateDeck(int deck_dimension)
        {
            List<Character> cards = new List<Character>();
            
            for(int i = 0; i < deck_dimension; i++)
            {
                int character = rnd.Next(1, 4);
                switch (character)
                {
                    case 1:
                        cards.Add(new Guerriero());
                        break;
                    case 2:
                        cards.Add(new Mago());
                        break;
                    case 3:
                        cards.Add(new Arciere());
                        break;
                    default: 
                        break;
                }
            }
            return cards;
        }

        private void CreateCardsofDesks()
        {
            player1_cardControls = new List<CardControl>();
            player2_cardControls = new List<CardControl>();

            // Posizioni iniziali e offset per le carte
            int startX_Player1 = 50;
            int startY_Player1 = 470; // Posiziona le carte del giocatore in basso
            int cardSpacing = 10;
            int cardWidth = 200; // Larghezza della CardControl

            int startX_Player2 = 50;
            int startY_Player2 = 20; // Posiziona le carte del bot in alto

            // Visualizza le carte del Giocatore 1
            for (int i = 0; i < deck_1.Count; i++)
            {
                CardControl cardControl = new CardControl(deck_1[i]);
                cardControl.Location = new Point(startX_Player1 + (i * (cardWidth + cardSpacing)), startY_Player1);
                cardControl.Tag = new Point(startX_Player1 + (i * (cardWidth + cardSpacing)), startY_Player1);
                cardControl.CardActionClicked += Card_ActionClicked;
                this.Controls.Add(cardControl);
                player1_cardControls.Add(cardControl);
                cardControl.ShowFront();
            }

            for (int i = 0; i < deck_2.Count; i++)
            {
                CardControl cardControl = new CardControl(deck_2[i]);
                cardControl.Tag = new Point(startX_Player2 + (i * (cardWidth + cardSpacing)), startY_Player2);
                cardControl.Location = new Point(startX_Player2 + (i * (cardWidth + cardSpacing)), startY_Player2);
                cardControl.CardActionClicked += Card_ActionClicked;
                this.Controls.Add(cardControl);
                player2_cardControls.Add(cardControl);
                cardControl.ShowBack();
            }

        }
        //gestisce cosa accade quado si preme il pulsante attacca.
        private async void Card_ActionClicked(object sender, EventArgs e)
        {
            if (!(sender is CardControl clickedCard) || clickedCard.Character == null) return;

            // --- LOGICA DI SELEZIONE DELLE CARTE SUL CAMPO ---

            // CASO 1: IL CAMPO DI BATTAGLIA È COMPLETAMENTE VUOTO
            // Il giocatore di turno sceglie la prima carta da mettere in campo (target).
            if (targetCard == null && attackingCard == null)
            {
                // Controlla se è il turno del giocatore che ha cliccato
                if (!IsCardOfCurrentPlayer(clickedCard))
                {
                    MessageBox.Show("Non è il tuo turno!");
                    return;
                }
                targetCard = clickedCard;
                await MoveCardToArea(targetCard, pnl_TargetCardArea);
                btt_turn.Text = "Passa Turno";
                btt_turn.Enabled = true;
            }
            // CASO 2: C'È UN DIFENSORE, MA NESSUN ATTACCANTE
            // L'avversario sceglie la sua carta per attaccare.
            else if (targetCard != null && attackingCard == null)
            {
                // Se si clicca sul target, si può deselezionare
                if (clickedCard == targetCard)
                {
                    MessageBox.Show("Carta ritirata dal campo.");
                    await MoveCardBackToHand(targetCard);
                    targetCard = null;
                    btt_turn.Enabled = false;
                    return;
                }

                // Altrimenti, si sta scegliendo un attaccante. Controlla se è il turno giusto.
                if (!IsCardOfCurrentPlayer(clickedCard))
                {
                    MessageBox.Show("Non è il tuo turno!");
                    return;
                }

                attackingCard = clickedCard;
                await MoveCardToArea(attackingCard, pnl_AttackingCardArea);
                btt_turn.Text = "Combatti!";
                btt_turn.Enabled = true;
            }
            // CASO 3: C'È GIÀ UN ATTACCANTE SUL CAMPO
            // L'unica azione permessa è deselezionare l'attaccante.
            else if (targetCard != null && attackingCard != null)
            {
                if (clickedCard == attackingCard)
                {
                    MessageBox.Show("Attaccante ritirato.");
                    await MoveCardBackToHand(attackingCard);
                    attackingCard = null;
                    btt_turn.Text = "Passa Turno"; // Il testo torna a "Passa Turno" perché c'è solo il target
                   
                    btt_turn.Enabled = (targetCard != null); // Abilitato solo se il target è ancora lì
                }
                else
                {
                    MessageBox.Show("Puoi solo ritirare il tuo attaccante o cliccare su 'Combatti!'");
                }
            }
        }

        // Funzione di supporto per controllare se la carta appartiene al giocatore del turno corrente
        private bool IsCardOfCurrentPlayer(CardControl card)
        {
            bool isPlayer1Card = player1_cardControls.Contains(card);
            return (IsPlayer1_turn && isPlayer1Card) || (!IsPlayer1_turn && !isPlayer1Card);
        }

        // Metodo per eseguire il combattimento
        private async Task PerformCombat(CardControl attacker, CardControl defender)
        {
            if (attacker == null || defender == null) return;

            Point defenderOriginalPositionInHand = (Point)defender.Tag;
            bool defenderWasHidden = !defender.IsFrontVisible;

            if (defenderWasHidden) await defender.Flip();
            await Task.Delay(500);

            // FASE 1: ATTACCO
            int damage = attacker.Character.inflict_damage();
            defender.Character.take_damage(damage);
            MessageBox.Show($"{attacker.Character.GetType()} infligge {damage} danni a {defender.Character.GetType()}!");
            defender.UpdateCardDisplay();
            await Task.Delay(1000);

            // FASE 2: GESTIONE DEL DIFENSORE
            if (!defender.Character.IsAlive())
            {
                MessageBox.Show($"{defender.Character.GetType()} è stato sconfitto!");
                this.Controls.Remove(defender);
                player1_cardControls.Remove(defender);
                player2_cardControls.Remove(defender);
                defender.Dispose();
            }
            else
            {
                MessageBox.Show($"{defender.Character.GetType()} sopravvive e si ritira!");
                await MoveCardBackToHand(defender); // Lo rimandiamo indietro
                if (defenderWasHidden) await defender.Flip();
            }

            // FASE 3: L'ATTACCANTE DIVENTA IL NUOVO TARGET
            MessageBox.Show($"{attacker.Character.GetType()} conquista la posizione e diventa il nuovo bersaglio!");
            await MoveCardToArea(attacker, pnl_TargetCardArea); // L'attaccante si sposta nell'area del target

            // --- AGGIORNAMENTO DELLO STATO DEL GIOCO ---
            this.targetCard = attacker;      // L'attaccante è ORA il target
            this.attackingCard = null;
        }
        private async void btt_turn_Click(object sender, EventArgs e)
        {
            // Disabilita il pulsante per evitare doppi click
            btt_turn.Enabled = false;

            // CASO 1: PASSAGGIO DI TURNO SENZA COMBATTIMENTO
            if (attackingCard == null && targetCard != null)
            {
                IsPlayer1_turn = !IsPlayer1_turn; // Cambia il turno
                MessageBox.Show(IsPlayer1_turn ? "Turno del Giocatore 1" : "Turno del Giocatore 2");

                // <--- CHIAMATA AL NUOVO METODO --->
                await FlipDecksForTurnChange();

                return; // Esci dal metodo
            }

            // CASO 2: COMBATTIMENTO
            if (attackingCard != null && targetCard != null)
            {
                // Esegui la sequenza di combattimento
                await PerformCombat(attackingCard, targetCard);

                // Cambia il turno
                IsPlayer1_turn = !IsPlayer1_turn;
                MessageBox.Show(IsPlayer1_turn ? "Ora è il turno del Giocatore 1" : "Ora è il turno del Giocatore 2");

                // <--- CHIAMATA AL NUOVO METODO --->
                await FlipDecksForTurnChange();

            }
        }

        #region UI
        // Metodo per riportare una carta alla sua posizione originale
        private void UI()
        {
            pnl_AttackingCardArea.Location = new Point(this.Width / 2 - 250, this.Height / 2 - 150);
            pnl_TargetCardArea.Location = new Point(this.Width / 2 + 50, this.Height / 2 - 150);
            pnl_AttackingCardArea.BorderStyle = BorderStyle.FixedSingle;
            pnl_TargetCardArea.BorderStyle = BorderStyle.FixedSingle;
            pnl_AttackingCardArea.SendToBack();
            pnl_TargetCardArea.SendToBack();
        }
        private async Task MoveCardBackToHand(CardControl card)
        {
            if (card.Tag is Point originalLocation)
            {
                Point startLocation = card.Location;
                int duration = 300;
                int steps = 20;
                int delay = duration / steps;

                float deltaX = (float)(originalLocation.X - startLocation.X) / steps;
                float deltaY = (float)(originalLocation.Y - startLocation.Y) / steps;

                for (int i = 0; i < steps; i++)
                {
                    card.Location = new Point(
                        (int)(startLocation.X + deltaX * i),
                        (int)(startLocation.Y + deltaY * i)
                    );
                    await Task.Delay(delay);
                }
                card.Location = originalLocation; // Assicurati che sia alla posizione esatta
            }
        }
        private async Task MoveCardToArea(CardControl card, Panel targetArea)
        {
            // Salva la posizione originale della carta prima di spostarla


            Point targetLocation = new Point(targetArea.Location.X + (targetArea.Width - card.Width) / 2,
                                             targetArea.Location.Y + (targetArea.Height - card.Height) / 2);
            int duration = 300; // Durata dello spostamento
            int steps = 20;
            int delay = duration / steps;

            Point startLocation = card.Location;
            float deltaX = (float)(targetLocation.X - startLocation.X) / steps;
            float deltaY = (float)(targetLocation.Y - startLocation.Y) / steps;

            for (int i = 0; i < steps; i++)
            {
                card.Location = new Point(
                    (int)(startLocation.X + deltaX * i),
                    (int)(startLocation.Y + deltaY * i)
                );
                await Task.Delay(delay);
            }
            card.Location = targetLocation; // Assicurati che sia alla posizione esatta
        }
        private async Task FlipDecksForTurnChange()
        {
            // Creiamo una lista di Task da eseguire in parallelo.
            List<Task> flipTasks = new List<Task>();

            // Gira le carte del giocatore 1
            foreach (var card in player1_cardControls)
            {
                if (card == targetCard || card == attackingCard)
                {
                    card.ShowFront();
                    continue;
                }
                // Se è il turno del giocatore 1, le sue carte devono essere scoperte (IsFrontVisible = true).
                // Se non lo sono, le giriamo.
                if (IsPlayer1_turn && !card.IsFrontVisible)
                {
                    flipTasks.Add(card.Flip());
                }
                // Se non è il turno del giocatore 1, le sue carte devono essere coperte.
                // Se non lo sono, le giriamo.
                else if (!IsPlayer1_turn && card.IsFrontVisible&&(card!=targetCard||card!=attackingCard))
                {
                    flipTasks.Add(card.Flip());
                }
            }

            // Gira le carte del giocatore 2
            foreach (var card in player2_cardControls)
            {
                if (card == targetCard || card == attackingCard)
                {
                    card.ShowFront();
                    continue;
                }
                    // Se non è il turno del giocatore 2, le sue carte devono essere scoperte.
                    if (!IsPlayer1_turn && !card.IsFrontVisible)
                {
                    flipTasks.Add(card.Flip());
                }
                // Se è il turno del giocatore 1, le carte del giocatore 2 devono essere coperte.
                else if (IsPlayer1_turn && card.IsFrontVisible)
                {
                    flipTasks.Add(card.Flip());
                }
            }

            // Attendi che tutte le animazioni di flip siano completate.
            await Task.WhenAll(flipTasks);
            
        }
        #endregion
    }
}
