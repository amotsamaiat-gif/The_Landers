using System;
using System.Drawing;
using System.Windows.Forms;
namespace The_Landers
{
    public partial class Form1 : Form
    {
        private GameEngine gameEngine;
        private Random ColorRandom = new Random();
        public Form1()
        {
            InitializeComponent();
            BuildMenus();
            BuildGuidePanel();

            Displaylbl1.ForeColor = System.Drawing.Color.White;
            Displaylbl1.BackColor = System.Drawing.Color.Black;
            Displaylbl1.Font = new System.Drawing.Font("Consolas", 14);
            Displaylbl1.AutoSize = false;


            gameEngine = new GameEngine(10); // Example: 10 levels to be played
            this.KeyPreview = true; // Ensure the form receives key events
            this.KeyDown += Form1_KeyDown;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            Displaylbl1.Text = gameEngine.ToString();
            lblLevelNumber.Text = $"Level" + gameEngine.CurrentLevelNumber + " Hp: " + gameEngine.Herostats;

            Color[] palette = { Color.Lime, Color.Cyan, Color.Yellow, Color.Magenta, Color.Red, Color.Orange, Color.Purple, Color.Brown, Color.Gray, Color.White, Color.CornflowerBlue };
            Displaylbl1.ForeColor = palette[ColorRandom.Next(palette.Length)];
        }

        private MenuStrip menuStrip;

        private void BuildMenus()
        {
            menuStrip = new MenuStrip();
            ToolStripMenuItem gameMenu = new ToolStripMenuItem("Settings ⚙️");

            ToolStripMenuItem newItem = new ToolStripMenuItem("New Game");
            ToolStripMenuItem saveItem = new ToolStripMenuItem("Save Game");
            ToolStripMenuItem loadItem = new ToolStripMenuItem("Load Game");
            ToolStripMenuItem exitItem = new ToolStripMenuItem("Exit");

            newItem.Click += NewGame_Click;
            saveItem.Click += SaveGame_Click;
            loadItem.Click += LoadGame_Click;
            exitItem.Click += (s, e) => Close();

            gameMenu.DropDownItems.Add(newItem);
            gameMenu.DropDownItems.Add(saveItem);
            gameMenu.DropDownItems.Add(loadItem);
            gameMenu.DropDownItems.Add(exitItem);
            menuStrip.Items.Add(gameMenu);

            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);
            menuStrip.BringToFront();
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            gameEngine = new GameEngine(10); // Start a new game with 10 levels
            UpdateDisplay();
        }

        private void SaveGame_Click(object sender, EventArgs e)
        {
            // Implement save game logic here
            MessageBox.Show("Game saved!");
        }

        private void LoadGame_Click(object sender, EventArgs e)
        {
            // Implement load game logic here
            MessageBox.Show("Game loaded!");
            UpdateDisplay();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Direction direction;
            bool isAttack = false;

            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    direction = Direction.Up;
                    break;
                case Keys.Down:
                case Keys.S:
                    direction = Direction.Down;
                    break;
                case Keys.Left:
                case Keys.A:
                    direction = Direction.Left;
                    break;
                case Keys.Right:
                case Keys.D:
                    direction = Direction.Right;
                    break;

                    return;


                case Keys.I:
                    direction = Direction.Up;
                    isAttack = true;
                    break;

                case Keys.K:
                    direction = Direction.Down;
                    isAttack = true;
                    break;

                case Keys.J:
                    direction = Direction.Left;
                    isAttack = true;
                    break;


                case Keys.L:
                    direction = Direction.Right;
                    isAttack = true;
                    break;

                default:
                    return;
            }

            if (isAttack)
            {
                gameEngine.TriggerHeroAttack(direction);
            }
            else
            {
                gameEngine.ActivateMovement(direction);
            }
            UpdateDisplay();
        }

        private Panel guidePanel;
        private int guideY;

        private void BuildGuidePanel()
        {
            guidePanel = new Panel();
            guidePanel.BackColor = Color.FromArgb(25, 25, 35);
            guidePanel.Location = new Point(0, menuStrip.Height);
            guidePanel.Size = new Size(230, ClientSize.Height - menuStrip.Height);
            guidePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            Controls.Add(guidePanel);

            lblLevelNumber.ForeColor = Color.White;
            lblLevelNumber.BackColor = Color.Transparent;
            lblLevelNumber.Font = new Font("Consolas", 11, FontStyle.Bold);
            lblLevelNumber.AutoSize = true;
            lblLevelNumber.Location = new Point(10, 8);
            guidePanel.Controls.Add(lblLevelNumber);

            guideY = 38; // first block starts just under the Level/HP label

            AddGuideLabel("HOW TO MOVE", Color.Gold, FontStyle.Bold);
            AddGuideLabel("W / Up    = up\nS / Down  = down\nA / Left  = left\nD / Right = right", Color.White, FontStyle.Regular);

            AddGuideLabel("HOW TO ATTACK", Color.Gold, FontStyle.Bold);
            AddGuideLabel("Stand next to an enemy,\nthen press:\nI = up     K = down\nJ = left   L = right", Color.White, FontStyle.Regular);

            AddGuideLabel("SYMBOLS", Color.Gold, FontStyle.Bold);
            AddGuideLabel("⚔ = you\nX = grunt   x = dead\n░ = exit (next level)", Color.White, FontStyle.Regular);

            // Put the map to the right of the panel and let it resize with the window
            Displaylbl1.Dock = DockStyle.None;
            Displaylbl1.Location = new Point(guidePanel.Width, menuStrip.Height);
            Displaylbl1.Size = new Size(ClientSize.Width - guidePanel.Width, ClientSize.Height - menuStrip.Height);
            Displaylbl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            lblLevelNumber.Visible = true;
            lblLevelNumber.BringToFront();
            lblLevelNumber.AutoSize = false;
            lblLevelNumber.Size = new Size(210, 24);

            guidePanel.BringToFront();
            menuStrip.BringToFront();
        }

        // Adds one block of text under the previous one, then lets guideY  move down for the next block.
        private void AddGuideLabel(string text, Color color, FontStyle style)
        {
            Label label = new Label();
            label.Text = text;
            label.ForeColor = color;
            label.BackColor = Color.Transparent;
            label.Font = new Font("Consolas", 9, style);
            label.AutoSize = true;
            label.Location = new Point(10, guideY);
            guidePanel.Controls.Add(label);

            // GetPreferredSize measures the text so the next block never overlaps this one
            guideY += label.PreferredHeight + 6;
        }


        private void Displaylbl1_Click(object sender, EventArgs e)
        {

        }
    }
}
