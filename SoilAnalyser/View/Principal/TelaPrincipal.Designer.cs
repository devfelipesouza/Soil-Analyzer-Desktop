namespace SoilAnalyser
{
    partial class TelaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.DragControl_Principal = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.header = new System.Windows.Forms.Panel();
            this.btn_minimizar = new Bunifu.Framework.UI.BunifuImageButton();
            this.btn_fechar = new Bunifu.Framework.UI.BunifuImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelAnimator = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.slidePane = new System.Windows.Forms.Panel();
            this.btn_ajuda = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_configuracoes = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_graficos = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_relatorios = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_controles = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.btn_cadastros = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uC_Cadastros1 = new SoilAnalyser.UC_Cadastros();
            this.uC_Ajuda1 = new SoilAnalyser.UC_Ajuda();
            this.uC_Configuracoes1 = new SoilAnalyser.UC_Configuracoes();
            this.uC_Graficos1 = new SoilAnalyser.UC_Graficos();
            this.uC_Relatorios1 = new SoilAnalyser.UC_Relatorios();
            this.uC_Irrigacoes1 = new SoilAnalyser.UC_Irrigacoes();
            this.AnimatorMenus = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_fechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.slidePane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // DragControl_Principal
            // 
            this.DragControl_Principal.Fixed = true;
            this.DragControl_Principal.Horizontal = true;
            this.DragControl_Principal.TargetControl = this.header;
            this.DragControl_Principal.Vertical = true;
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(194)))), ((int)(((byte)(74)))));
            this.header.Controls.Add(this.btn_minimizar);
            this.header.Controls.Add(this.btn_fechar);
            this.AnimatorMenus.SetDecoration(this.header, BunifuAnimatorNS.DecorationType.None);
            this.PanelAnimator.SetDecoration(this.header, BunifuAnimatorNS.DecorationType.None);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(835, 29);
            this.header.TabIndex = 95;
            // 
            // btn_minimizar
            // 
            this.btn_minimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_minimizar.BackColor = System.Drawing.Color.Transparent;
            this.btn_minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimatorMenus.SetDecoration(this.btn_minimizar, BunifuAnimatorNS.DecorationType.None);
            this.PanelAnimator.SetDecoration(this.btn_minimizar, BunifuAnimatorNS.DecorationType.None);
            this.btn_minimizar.Image = ((System.Drawing.Image)(resources.GetObject("btn_minimizar.Image")));
            this.btn_minimizar.ImageActive = null;
            this.btn_minimizar.Location = new System.Drawing.Point(777, 0);
            this.btn_minimizar.Name = "btn_minimizar";
            this.btn_minimizar.Size = new System.Drawing.Size(29, 27);
            this.btn_minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_minimizar.TabIndex = 98;
            this.btn_minimizar.TabStop = false;
            this.btn_minimizar.Zoom = 10;
            this.btn_minimizar.Click += new System.EventHandler(this.btn_minimizar_Click);
            // 
            // btn_fechar
            // 
            this.btn_fechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_fechar.BackColor = System.Drawing.Color.Transparent;
            this.btn_fechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimatorMenus.SetDecoration(this.btn_fechar, BunifuAnimatorNS.DecorationType.None);
            this.PanelAnimator.SetDecoration(this.btn_fechar, BunifuAnimatorNS.DecorationType.None);
            this.btn_fechar.Image = ((System.Drawing.Image)(resources.GetObject("btn_fechar.Image")));
            this.btn_fechar.ImageActive = null;
            this.btn_fechar.Location = new System.Drawing.Point(809, 2);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(24, 24);
            this.btn_fechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btn_fechar.TabIndex = 97;
            this.btn_fechar.TabStop = false;
            this.btn_fechar.Zoom = 10;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // pictureBox1
            // 
            this.PanelAnimator.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.AnimatorMenus.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(835, 495);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // PanelAnimator
            // 
            this.PanelAnimator.AnimationType = BunifuAnimatorNS.AnimationType.Particles;
            this.PanelAnimator.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 1;
            animation1.Padding = new System.Windows.Forms.Padding(100, 50, 100, 150);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 2F;
            animation1.TransparencyCoeff = 0F;
            this.PanelAnimator.DefaultAnimation = animation1;
            this.PanelAnimator.MaxAnimationTime = 3500;
            this.PanelAnimator.TimeStep = 0.019F;
            // 
            // slidePane
            // 
            this.slidePane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(194)))), ((int)(((byte)(74)))));
            this.slidePane.Controls.Add(this.btn_ajuda);
            this.slidePane.Controls.Add(this.btn_configuracoes);
            this.slidePane.Controls.Add(this.btn_graficos);
            this.slidePane.Controls.Add(this.btn_relatorios);
            this.slidePane.Controls.Add(this.btn_controles);
            this.slidePane.Controls.Add(this.bunifuImageButton1);
            this.slidePane.Controls.Add(this.btn_cadastros);
            this.AnimatorMenus.SetDecoration(this.slidePane, BunifuAnimatorNS.DecorationType.None);
            this.PanelAnimator.SetDecoration(this.slidePane, BunifuAnimatorNS.DecorationType.None);
            this.slidePane.Dock = System.Windows.Forms.DockStyle.Left;
            this.slidePane.Location = new System.Drawing.Point(0, 0);
            this.slidePane.Name = "slidePane";
            this.slidePane.Size = new System.Drawing.Size(38, 524);
            this.slidePane.TabIndex = 3;
            // 
            // btn_ajuda
            // 
            this.btn_ajuda.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(194)))), ((int)(((byte)(74)))));
            this.btn_ajuda.BackColor = System.Drawing.Color.Transparent;
            this.btn_ajuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ajuda.BorderRadius = 0;
            this.btn_ajuda.ButtonText = " Ajuda";
            this.btn_ajuda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimatorMenus.SetDecoration(this.btn_ajuda, BunifuAnimatorNS.DecorationType.None);
            this.PanelAnimator.SetDecoration(this.btn_ajuda, BunifuAnimatorNS.DecorationType.None);
            this.btn_ajuda.DisabledColor = System.Drawing.Color.Gray;
            this.btn_ajuda.Font = new System.Drawing.Font("Century", 8.25F);
            this.btn_ajuda.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_ajuda.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_ajuda.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_ajuda.Iconimage")));
            this.btn_ajuda.Iconimage_right = null;
            this.btn_ajuda.Iconimage_right_Selected = null;
            this.btn_ajuda.Iconimage_Selected = null;
            this.btn_ajuda.IconMarginLeft = 0;
            this.btn_ajuda.IconMarginRight = 0;
            this.btn_ajuda.IconRightVisible = true;
            this.btn_ajuda.IconRightZoom = 0D;
            this.btn_ajuda.IconVisible = true;
            this.btn_ajuda.IconZoom = 55D;
            this.btn_ajuda.IsTab = true;
            this.btn_ajuda.Location = new System.Drawing.Point(-1, 233);
            this.btn_ajuda.Name = "btn_ajuda";
            this.btn_ajuda.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_ajuda.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(136)))), ((int)(((byte)(29)))));
            this.btn_ajuda.OnHoverTextColor = System.Drawing.Color.Black;
            this.btn_ajuda.selected = false;
            this.btn_ajuda.Size = new System.Drawing.Size(192, 44);
            this.btn_ajuda.TabIndex = 6;
            this.btn_ajuda.Text = " Ajuda";
            this.btn_ajuda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ajuda.Textcolor = System.Drawing.Color.Black;
            this.btn_ajuda.TextFont = new System.Drawing.Font("Verdana", 12.75F);
            this.btn_ajuda.Visible = false;
            this.btn_ajuda.Click += new System.EventHandler(this.btn_ajuda_Click);
            // 
            // btn_configuracoes
            // 
            this.btn_configuracoes.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(194)))), ((int)(((byte)(74)))));
            this.btn_configuracoes.BackColor = System.Drawing.Color.Transparent;
            this.btn_configuracoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_configuracoes.BorderRadius = 0;
            this.btn_configuracoes.ButtonText = " Configurações";
            this.btn_configuracoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimatorMenus.SetDecoration(this.btn_configuracoes, BunifuAnimatorNS.DecorationType.None);
            this.PanelAnimator.SetDecoration(this.btn_configuracoes, BunifuAnimatorNS.DecorationType.None);
            this.btn_configuracoes.DisabledColor = System.Drawing.Color.Gray;
            this.btn_configuracoes.Font = new System.Drawing.Font("Century", 8.25F);
            this.btn_configuracoes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_configuracoes.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_configuracoes.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_configuracoes.Iconimage")));
            this.btn_configuracoes.Iconimage_right = null;
            this.btn_configuracoes.Iconimage_right_Selected = null;
            this.btn_configuracoes.Iconimage_Selected = null;
            this.btn_configuracoes.IconMarginLeft = 0;
            this.btn_configuracoes.IconMarginRight = 0;
            this.btn_configuracoes.IconRightVisible = true;
            this.btn_configuracoes.IconRightZoom = 0D;
            this.btn_configuracoes.IconVisible = true;
            this.btn_configuracoes.IconZoom = 55D;
            this.btn_configuracoes.IsTab = true;
            this.btn_configuracoes.Location = new System.Drawing.Point(0, 83);
            this.btn_configuracoes.Name = "btn_configuracoes";
            this.btn_configuracoes.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_configuracoes.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(136)))), ((int)(((byte)(29)))));
            this.btn_configuracoes.OnHoverTextColor = System.Drawing.Color.Black;
            this.btn_configuracoes.selected = false;
            this.btn_configuracoes.Size = new System.Drawing.Size(192, 44);
            this.btn_configuracoes.TabIndex = 5;
            this.btn_configuracoes.Text = " Configurações";
            this.btn_configuracoes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_configuracoes.Textcolor = System.Drawing.Color.Black;
            this.btn_configuracoes.TextFont = new System.Drawing.Font("Verdana", 12.75F);
            this.btn_configuracoes.Click += new System.EventHandler(this.btn_configuracoes_Click);
            // 
            // btn_graficos
            // 
            this.btn_graficos.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(194)))), ((int)(((byte)(74)))));
            this.btn_graficos.BackColor = System.Drawing.Color.Transparent;
            this.btn_graficos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_graficos.BorderRadius = 0;
            this.btn_graficos.ButtonText = " Gráficos";
            this.btn_graficos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimatorMenus.SetDecoration(this.btn_graficos, BunifuAnimatorNS.DecorationType.None);
            this.PanelAnimator.SetDecoration(this.btn_graficos, BunifuAnimatorNS.DecorationType.None);
            this.btn_graficos.DisabledColor = System.Drawing.Color.Gray;
            this.btn_graficos.Font = new System.Drawing.Font("Century", 8.25F);
            this.btn_graficos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_graficos.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_graficos.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_graficos.Iconimage")));
            this.btn_graficos.Iconimage_right = null;
            this.btn_graficos.Iconimage_right_Selected = null;
            this.btn_graficos.Iconimage_Selected = null;
            this.btn_graficos.IconMarginLeft = 0;
            this.btn_graficos.IconMarginRight = 0;
            this.btn_graficos.IconRightVisible = true;
            this.btn_graficos.IconRightZoom = 0D;
            this.btn_graficos.IconVisible = true;
            this.btn_graficos.IconZoom = 55D;
            this.btn_graficos.IsTab = true;
            this.btn_graficos.Location = new System.Drawing.Point(-1, 183);
            this.btn_graficos.Name = "btn_graficos";
            this.btn_graficos.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_graficos.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(136)))), ((int)(((byte)(29)))));
            this.btn_graficos.OnHoverTextColor = System.Drawing.Color.Black;
            this.btn_graficos.selected = false;
            this.btn_graficos.Size = new System.Drawing.Size(192, 44);
            this.btn_graficos.TabIndex = 4;
            this.btn_graficos.Text = " Gráficos";
            this.btn_graficos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_graficos.Textcolor = System.Drawing.Color.Black;
            this.btn_graficos.TextFont = new System.Drawing.Font("Verdana", 12.75F);
            this.btn_graficos.Click += new System.EventHandler(this.btn_graficos_Click);
            // 
            // btn_relatorios
            // 
            this.btn_relatorios.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(194)))), ((int)(((byte)(74)))));
            this.btn_relatorios.BackColor = System.Drawing.Color.Transparent;
            this.btn_relatorios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_relatorios.BorderRadius = 0;
            this.btn_relatorios.ButtonText = " Relatórios";
            this.btn_relatorios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimatorMenus.SetDecoration(this.btn_relatorios, BunifuAnimatorNS.DecorationType.None);
            this.PanelAnimator.SetDecoration(this.btn_relatorios, BunifuAnimatorNS.DecorationType.None);
            this.btn_relatorios.DisabledColor = System.Drawing.Color.Gray;
            this.btn_relatorios.Font = new System.Drawing.Font("Century", 8.25F);
            this.btn_relatorios.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_relatorios.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_relatorios.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_relatorios.Iconimage")));
            this.btn_relatorios.Iconimage_right = null;
            this.btn_relatorios.Iconimage_right_Selected = null;
            this.btn_relatorios.Iconimage_Selected = null;
            this.btn_relatorios.IconMarginLeft = 0;
            this.btn_relatorios.IconMarginRight = 0;
            this.btn_relatorios.IconRightVisible = true;
            this.btn_relatorios.IconRightZoom = 0D;
            this.btn_relatorios.IconVisible = true;
            this.btn_relatorios.IconZoom = 55D;
            this.btn_relatorios.IsTab = true;
            this.btn_relatorios.Location = new System.Drawing.Point(0, 133);
            this.btn_relatorios.Name = "btn_relatorios";
            this.btn_relatorios.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_relatorios.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(136)))), ((int)(((byte)(29)))));
            this.btn_relatorios.OnHoverTextColor = System.Drawing.Color.Black;
            this.btn_relatorios.selected = false;
            this.btn_relatorios.Size = new System.Drawing.Size(192, 44);
            this.btn_relatorios.TabIndex = 3;
            this.btn_relatorios.Text = " Relatórios";
            this.btn_relatorios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_relatorios.Textcolor = System.Drawing.Color.Black;
            this.btn_relatorios.TextFont = new System.Drawing.Font("Verdana", 12.75F);
            this.btn_relatorios.Click += new System.EventHandler(this.btn_relatorios_Click);
            // 
            // btn_controles
            // 
            this.btn_controles.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(194)))), ((int)(((byte)(74)))));
            this.btn_controles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(194)))), ((int)(((byte)(74)))));
            this.btn_controles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_controles.BorderRadius = 0;
            this.btn_controles.ButtonText = " Processos";
            this.btn_controles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimatorMenus.SetDecoration(this.btn_controles, BunifuAnimatorNS.DecorationType.None);
            this.PanelAnimator.SetDecoration(this.btn_controles, BunifuAnimatorNS.DecorationType.None);
            this.btn_controles.DisabledColor = System.Drawing.Color.Gray;
            this.btn_controles.Font = new System.Drawing.Font("Century", 8.25F);
            this.btn_controles.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_controles.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_controles.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_controles.Iconimage")));
            this.btn_controles.Iconimage_right = null;
            this.btn_controles.Iconimage_right_Selected = null;
            this.btn_controles.Iconimage_Selected = null;
            this.btn_controles.IconMarginLeft = 0;
            this.btn_controles.IconMarginRight = 0;
            this.btn_controles.IconRightVisible = true;
            this.btn_controles.IconRightZoom = 0D;
            this.btn_controles.IconVisible = true;
            this.btn_controles.IconZoom = 70D;
            this.btn_controles.IsTab = true;
            this.btn_controles.Location = new System.Drawing.Point(-4, 83);
            this.btn_controles.Name = "btn_controles";
            this.btn_controles.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_controles.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(136)))), ((int)(((byte)(29)))));
            this.btn_controles.OnHoverTextColor = System.Drawing.Color.Black;
            this.btn_controles.selected = true;
            this.btn_controles.Size = new System.Drawing.Size(192, 44);
            this.btn_controles.TabIndex = 2;
            this.btn_controles.Text = " Processos";
            this.btn_controles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_controles.Textcolor = System.Drawing.Color.Black;
            this.btn_controles.TextFont = new System.Drawing.Font("Verdana", 12.75F);
            this.btn_controles.Visible = false;
            this.btn_controles.Click += new System.EventHandler(this.btn_controles_Click);
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimatorMenus.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.PanelAnimator.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(8, 3);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(24, 24);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bunifuImageButton1.TabIndex = 0;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // btn_cadastros
            // 
            this.btn_cadastros.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(194)))), ((int)(((byte)(74)))));
            this.btn_cadastros.BackColor = System.Drawing.Color.Transparent;
            this.btn_cadastros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cadastros.BorderRadius = 0;
            this.btn_cadastros.ButtonText = " Cadastros";
            this.btn_cadastros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimatorMenus.SetDecoration(this.btn_cadastros, BunifuAnimatorNS.DecorationType.None);
            this.PanelAnimator.SetDecoration(this.btn_cadastros, BunifuAnimatorNS.DecorationType.None);
            this.btn_cadastros.DisabledColor = System.Drawing.Color.Gray;
            this.btn_cadastros.Font = new System.Drawing.Font("Century", 8.25F);
            this.btn_cadastros.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_cadastros.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_cadastros.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_cadastros.Iconimage")));
            this.btn_cadastros.Iconimage_right = null;
            this.btn_cadastros.Iconimage_right_Selected = null;
            this.btn_cadastros.Iconimage_Selected = null;
            this.btn_cadastros.IconMarginLeft = 0;
            this.btn_cadastros.IconMarginRight = 0;
            this.btn_cadastros.IconRightVisible = true;
            this.btn_cadastros.IconRightZoom = 0D;
            this.btn_cadastros.IconVisible = true;
            this.btn_cadastros.IconZoom = 65D;
            this.btn_cadastros.IsTab = true;
            this.btn_cadastros.Location = new System.Drawing.Point(-1, 33);
            this.btn_cadastros.Name = "btn_cadastros";
            this.btn_cadastros.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_cadastros.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(136)))), ((int)(((byte)(29)))));
            this.btn_cadastros.OnHoverTextColor = System.Drawing.Color.Black;
            this.btn_cadastros.selected = false;
            this.btn_cadastros.Size = new System.Drawing.Size(189, 44);
            this.btn_cadastros.TabIndex = 1;
            this.btn_cadastros.Text = " Cadastros";
            this.btn_cadastros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cadastros.Textcolor = System.Drawing.Color.Black;
            this.btn_cadastros.TextFont = new System.Drawing.Font("Verdana", 12.75F);
            this.btn_cadastros.Click += new System.EventHandler(this.btn_cadastros_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.uC_Cadastros1);
            this.panel1.Controls.Add(this.uC_Ajuda1);
            this.panel1.Controls.Add(this.uC_Configuracoes1);
            this.panel1.Controls.Add(this.uC_Graficos1);
            this.panel1.Controls.Add(this.uC_Relatorios1);
            this.panel1.Controls.Add(this.uC_Irrigacoes1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.header);
            this.AnimatorMenus.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.PanelAnimator.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(38, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 524);
            this.panel1.TabIndex = 4;
            // 
            // uC_Cadastros1
            // 
            this.uC_Cadastros1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PanelAnimator.SetDecoration(this.uC_Cadastros1, BunifuAnimatorNS.DecorationType.None);
            this.AnimatorMenus.SetDecoration(this.uC_Cadastros1, BunifuAnimatorNS.DecorationType.None);
            this.uC_Cadastros1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_Cadastros1.Location = new System.Drawing.Point(0, 29);
            this.uC_Cadastros1.Name = "uC_Cadastros1";
            this.uC_Cadastros1.Size = new System.Drawing.Size(835, 495);
            this.uC_Cadastros1.TabIndex = 4;
            this.uC_Cadastros1.Visible = false;
            // 
            // uC_Ajuda1
            // 
            this.PanelAnimator.SetDecoration(this.uC_Ajuda1, BunifuAnimatorNS.DecorationType.None);
            this.AnimatorMenus.SetDecoration(this.uC_Ajuda1, BunifuAnimatorNS.DecorationType.None);
            this.uC_Ajuda1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_Ajuda1.Location = new System.Drawing.Point(0, 29);
            this.uC_Ajuda1.Name = "uC_Ajuda1";
            this.uC_Ajuda1.Size = new System.Drawing.Size(835, 495);
            this.uC_Ajuda1.TabIndex = 96;
            this.uC_Ajuda1.Visible = false;
            // 
            // uC_Configuracoes1
            // 
            this.uC_Configuracoes1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PanelAnimator.SetDecoration(this.uC_Configuracoes1, BunifuAnimatorNS.DecorationType.None);
            this.AnimatorMenus.SetDecoration(this.uC_Configuracoes1, BunifuAnimatorNS.DecorationType.None);
            this.uC_Configuracoes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_Configuracoes1.Location = new System.Drawing.Point(0, 29);
            this.uC_Configuracoes1.Name = "uC_Configuracoes1";
            this.uC_Configuracoes1.Size = new System.Drawing.Size(835, 495);
            this.uC_Configuracoes1.TabIndex = 8;
            this.uC_Configuracoes1.Visible = false;
            // 
            // uC_Graficos1
            // 
            this.uC_Graficos1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PanelAnimator.SetDecoration(this.uC_Graficos1, BunifuAnimatorNS.DecorationType.None);
            this.AnimatorMenus.SetDecoration(this.uC_Graficos1, BunifuAnimatorNS.DecorationType.None);
            this.uC_Graficos1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_Graficos1.Location = new System.Drawing.Point(0, 29);
            this.uC_Graficos1.Name = "uC_Graficos1";
            this.uC_Graficos1.Size = new System.Drawing.Size(835, 495);
            this.uC_Graficos1.TabIndex = 7;
            this.uC_Graficos1.Visible = false;
            // 
            // uC_Relatorios1
            // 
            this.uC_Relatorios1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PanelAnimator.SetDecoration(this.uC_Relatorios1, BunifuAnimatorNS.DecorationType.None);
            this.AnimatorMenus.SetDecoration(this.uC_Relatorios1, BunifuAnimatorNS.DecorationType.None);
            this.uC_Relatorios1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_Relatorios1.Location = new System.Drawing.Point(0, 29);
            this.uC_Relatorios1.Name = "uC_Relatorios1";
            this.uC_Relatorios1.Size = new System.Drawing.Size(835, 495);
            this.uC_Relatorios1.TabIndex = 6;
            this.uC_Relatorios1.Visible = false;
            // 
            // uC_Irrigacoes1
            // 
            this.uC_Irrigacoes1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PanelAnimator.SetDecoration(this.uC_Irrigacoes1, BunifuAnimatorNS.DecorationType.None);
            this.AnimatorMenus.SetDecoration(this.uC_Irrigacoes1, BunifuAnimatorNS.DecorationType.None);
            this.uC_Irrigacoes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_Irrigacoes1.Location = new System.Drawing.Point(0, 29);
            this.uC_Irrigacoes1.Name = "uC_Irrigacoes1";
            this.uC_Irrigacoes1.Size = new System.Drawing.Size(835, 495);
            this.uC_Irrigacoes1.TabIndex = 5;
            this.uC_Irrigacoes1.Visible = false;
            // 
            // AnimatorMenus
            // 
            this.AnimatorMenus.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.AnimatorMenus.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 1F;
            this.AnimatorMenus.DefaultAnimation = animation2;
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 524);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.slidePane);
            this.PanelAnimator.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.AnimatorMenus.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaPrincipal";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaPrincipal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TelaPrincipal_FormClosed);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_fechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.slidePane.ResumeLayout(false);
            this.slidePane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl DragControl_Principal;
        private BunifuAnimatorNS.BunifuTransition PanelAnimator;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel slidePane;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuFlatButton btn_controles;
        private System.Windows.Forms.PictureBox pictureBox1;
        private UC_Cadastros uC_Cadastros1;
        private UC_Irrigacoes uC_Irrigacoes1;
        private UC_Configuracoes uC_Configuracoes1;
        private UC_Graficos uC_Graficos1;
        private UC_Relatorios uC_Relatorios1;
        private BunifuAnimatorNS.BunifuTransition AnimatorMenus;       
        private UC_Ajuda uC_Ajuda1;
        private System.Windows.Forms.Panel header;
        private Bunifu.Framework.UI.BunifuImageButton btn_minimizar;
        private Bunifu.Framework.UI.BunifuImageButton btn_fechar;
        public Bunifu.Framework.UI.BunifuFlatButton btn_cadastros;
        public Bunifu.Framework.UI.BunifuFlatButton btn_configuracoes;
        public Bunifu.Framework.UI.BunifuFlatButton btn_graficos;
        public Bunifu.Framework.UI.BunifuFlatButton btn_relatorios;
        public Bunifu.Framework.UI.BunifuFlatButton btn_ajuda;
    }
}