
namespace eAgenda.WindowsApp.Features.Compromissos
{
    partial class TelaCompromissoForm
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
            this.horaInicio = new System.Windows.Forms.DateTimePicker();
            this.dateCompromisso = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbContato = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAssunto = new System.Windows.Forms.TextBox();
            this.assunto = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.labelLocal = new System.Windows.Forms.Label();
            this.horaConclusao = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.radioPresencial = new System.Windows.Forms.RadioButton();
            this.radioOnline = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // horaInicio
            // 
            this.horaInicio.CalendarMonthBackground = System.Drawing.Color.DarkSeaGreen;
            this.horaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.horaInicio.Location = new System.Drawing.Point(435, 115);
            this.horaInicio.Margin = new System.Windows.Forms.Padding(4);
            this.horaInicio.Name = "horaInicio";
            this.horaInicio.ShowUpDown = true;
            this.horaInicio.Size = new System.Drawing.Size(116, 22);
            this.horaInicio.TabIndex = 26;
            // 
            // dateCompromisso
            // 
            this.dateCompromisso.CalendarMonthBackground = System.Drawing.Color.DarkSeaGreen;
            this.dateCompromisso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateCompromisso.Location = new System.Drawing.Point(137, 114);
            this.dateCompromisso.Margin = new System.Windows.Forms.Padding(4);
            this.dateCompromisso.Name = "dateCompromisso";
            this.dateCompromisso.Size = new System.Drawing.Size(156, 22);
            this.dateCompromisso.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 116);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Hora Inicio:";
            // 
            // cmbContato
            // 
            this.cmbContato.FormattingEnabled = true;
            this.cmbContato.Location = new System.Drawing.Point(137, 150);
            this.cmbContato.Margin = new System.Windows.Forms.Padding(4);
            this.cmbContato.Name = "cmbContato";
            this.cmbContato.Size = new System.Drawing.Size(156, 24);
            this.cmbContato.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Contato";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Data";
            // 
            // txtAssunto
            // 
            this.txtAssunto.Location = new System.Drawing.Point(137, 47);
            this.txtAssunto.Margin = new System.Windows.Forms.Padding(4);
            this.txtAssunto.Name = "txtAssunto";
            this.txtAssunto.Size = new System.Drawing.Size(226, 22);
            this.txtAssunto.TabIndex = 20;
            // 
            // assunto
            // 
            this.assunto.AutoSize = true;
            this.assunto.Location = new System.Drawing.Point(61, 50);
            this.assunto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.assunto.Name = "assunto";
            this.assunto.Size = new System.Drawing.Size(59, 17);
            this.assunto.TabIndex = 19;
            this.assunto.Text = "Assunto";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(137, 15);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(132, 22);
            this.txtId.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Id:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(472, 252);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(364, 252);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(100, 28);
            this.btnGravar.TabIndex = 15;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(136, 81);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(4);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(227, 22);
            this.txtEndereco.TabIndex = 30;
            // 
            // labelLocal
            // 
            this.labelLocal.AutoSize = true;
            this.labelLocal.Location = new System.Drawing.Point(78, 84);
            this.labelLocal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocal.Name = "labelLocal";
            this.labelLocal.Size = new System.Drawing.Size(42, 17);
            this.labelLocal.TabIndex = 29;
            this.labelLocal.Text = "Local";
            // 
            // horaConclusao
            // 
            this.horaConclusao.CalendarMonthBackground = System.Drawing.Color.DarkSeaGreen;
            this.horaConclusao.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.horaConclusao.Location = new System.Drawing.Point(435, 152);
            this.horaConclusao.Margin = new System.Windows.Forms.Padding(4);
            this.horaConclusao.Name = "horaConclusao";
            this.horaConclusao.ShowUpDown = true;
            this.horaConclusao.Size = new System.Drawing.Size(116, 22);
            this.horaConclusao.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 153);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Hora Conclusâo:";
            // 
            // radioPresencial
            // 
            this.radioPresencial.AutoSize = true;
            this.radioPresencial.Checked = true;
            this.radioPresencial.Location = new System.Drawing.Point(380, 16);
            this.radioPresencial.Name = "radioPresencial";
            this.radioPresencial.Size = new System.Drawing.Size(95, 21);
            this.radioPresencial.TabIndex = 33;
            this.radioPresencial.TabStop = true;
            this.radioPresencial.Text = "Presencial";
            this.radioPresencial.UseVisualStyleBackColor = true;
            // 
            // radioOnline
            // 
            this.radioOnline.AutoSize = true;
            this.radioOnline.Location = new System.Drawing.Point(481, 16);
            this.radioOnline.Name = "radioOnline";
            this.radioOnline.Size = new System.Drawing.Size(70, 21);
            this.radioOnline.TabIndex = 34;
            this.radioOnline.Text = "Online";
            this.radioOnline.UseVisualStyleBackColor = true;
            // 
            // TelaCompromissoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 295);
            this.Controls.Add(this.radioOnline);
            this.Controls.Add(this.radioPresencial);
            this.Controls.Add(this.horaConclusao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.labelLocal);
            this.Controls.Add(this.horaInicio);
            this.Controls.Add(this.dateCompromisso);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbContato);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAssunto);
            this.Controls.Add(this.assunto);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Name = "TelaCompromissoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Compromissos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaCompromissoForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker horaInicio;
        private System.Windows.Forms.DateTimePicker dateCompromisso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbContato;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAssunto;
        private System.Windows.Forms.Label assunto;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label labelLocal;
        private System.Windows.Forms.DateTimePicker horaConclusao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioPresencial;
        private System.Windows.Forms.RadioButton radioOnline;
    }
}